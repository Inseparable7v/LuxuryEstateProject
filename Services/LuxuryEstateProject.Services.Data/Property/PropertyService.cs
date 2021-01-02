namespace LuxuryEstateProject.Services.Data.Property
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using LuxuryEstateProject.Data.Common.Repositories;
    using LuxuryEstateProject.Data.Models;
    using LuxuryEstateProject.Services.Mapping;
    using LuxuryEstateProject.Web.ViewModels.Property;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using SixLabors.ImageSharp.Formats.Png;
    using SixLabors.ImageSharp.Processing;

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

        public IEnumerable<T> ListOfPropertiesByAgentId<T>(int id)
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

        public IEnumerable<SelectListItem> GetAllAsSelectListItems()
        {
            return this.realRepository.All().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).OrderBy(c => c.Text);
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

            foreach (var amenityInput in input.Amenity)
            {
                property.RealEstateAmenities.Add(new RealEstateAmenity()
                {
                    AmenityId = int.Parse(amenityInput),
                    RealEstatePropertyId = property.Id,
                });
            }

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

                imageSharp.Mutate(x => x.Resize(750, 725));

                property.Images.Add(dbImage);

                var physicalPath = $"{imagePath}{dbImage.Id}.{extension}";
                await using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
                await imageSharp.SaveAsync(fileStream, new PngEncoder());
            }

            await this.realRepository.AddAsync(property);
            await this.realRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, EditPropertyinputModel input)
        {
            var model = this.realRepository.All().FirstOrDefault(x => x.Id.Equals(id));

            model.Bath = input.Bath;
            model.Bed = input.Bed;
            model.AgentId = input.AgentId;
            model.Description = input.Description;
            model.Floor = input.Floor;
            model.TotalNumberOfFloors = input.TotalNumbersOfFloors;
            model.Size = input.Size;
            model.Price = input.Price;
            model.Name = input.Name;
            model.Year = input.Year;

            await this.realRepository.SaveChangesAsync();
        }
    }
}
