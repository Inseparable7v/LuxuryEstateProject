using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Processing;

namespace LuxuryEstateProject.Services.Data.Property
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using LuxuryEstateProject.Data.Common.Repositories;
    using LuxuryEstateProject.Data.Models;
    using LuxuryEstateProject.Services.Mapping;
    using LuxuryEstateProject.Web.ViewModels.Property;
    using Microsoft.EntityFrameworkCore;

    public class PropertyService : IPropertyService
    {
        private readonly string[] allowedExtensions = new[] { "jpg", "png", "jpeg" };

        private readonly IDeletableEntityRepository<RealEstateProperty> realRepository;

        public PropertyService(IDeletableEntityRepository<RealEstateProperty> realRepository)
        {
            this.realRepository = realRepository;
        }

        /// <inheritdoc/>
        public int GetCount()
        {
            return this.realRepository.AllAsNoTracking().Count();
        }

        public IEnumerable<T> ListOfPropertiesById<T>(int id)
        {
            return this.realRepository.AllAsNoTracking().Where(x => x.AgentId.Equals(id)).To<T>().ToList();
        }

        /// <inheritdoc/>
        public IEnumerable<T> GetLatestProperties<T>()
        {
            var latestProperties = this.realRepository.AllAsNoTracking().Take(5).OrderByDescending(x => x.Id).To<T>().ToList();

            return latestProperties;
        }

        /// <inheritdoc/>
        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 6)
        {
            var properties = this.realRepository.AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .To<T>().ToList();
            return properties;
        }

        /// <inheritdoc/>
        public async Task<T> GetByIdAsync<T>(int id)
        {
            return await this.realRepository.AllAsNoTracking().Where(x => x.Id.Equals(id)).To<T>().FirstOrDefaultAsync();
        }

        /// <inheritdoc/>
        public async Task CreatePropertyAsync(PropertyInputModel input, string imagePath)
        {
            var property = new RealEstateProperty
            {
                Bath = input.Bath,
                Name = input.Name,
                Bed = input.Bed,
                CountryId = input.CountryId,
                Floor = input.Floor,
                TotalNumberOfFloors = input.TotalNumberOfFloors,
                Price = input.Price,
                Size = input.Size,
                Year = input.Year,
                AgentId = input.AgentId,
                BuildingType = (Material)input.Material,
                Description = input.Description,
                Garage = input.Garage,
                Type = (PropertyType)input.Type,
            };
            Directory.CreateDirectory($"{imagePath}");
            foreach (var image in input.Images)
            {
                var extension = Path.GetExtension(image.FileName).TrimStart('.');
                if (!this.allowedExtensions.Any(x => extension.EndsWith(x)))
                {
                    throw new Exception($"Invalid image extension {extension}");
                }

                var dbImage = new Image
                {
                    Extension = extension,
                };

                using var imageSharp = SixLabors.ImageSharp.Image.Load(image.OpenReadStream());

                imageSharp.Mutate(x => x.Resize(700, 900));

                property.Images.Add(dbImage);

                var physicalPath = $"{imagePath}{dbImage.Id}.{extension}";
                await using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
                await imageSharp.SaveAsync(fileStream, new PngEncoder());

                //await image.CopyToAsync(fileStream);
            }

            await this.realRepository.AddAsync(property);
            await this.realRepository.SaveChangesAsync();

        }
    }
}
