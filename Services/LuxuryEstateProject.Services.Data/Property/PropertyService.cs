using System.IO;

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
        private readonly string[] allowedExtensions = new[] { "jpg", "png", "gif", "jpeg" };

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

        /// <inheritdoc/>
        public IEnumerable<T> GetLatestProperties<T>()
        {
            var latestProperties = this.realRepository.AllAsNoTracking().Take(5).OrderByDescending(x => x.Id).To<T>().ToList();

            return latestProperties;
        }

        /// <inheritdoc/>
        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 6)
        {
            var recipes = this.realRepository.AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .To<T>().ToList();
            return recipes;
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

             // wwwroot / images / recipes / jhdsi - 343g3h453 -= g34g.jpg
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

                property.Images.Add(dbImage);

                var physicalPath = $"{imagePath}{dbImage.Id}.{extension}";
                await using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
                await image.CopyToAsync(fileStream);
            }

            await this.realRepository.AddAsync(property);
            await this.realRepository.SaveChangesAsync();

        }

        //public async Task CreateAsync(CreateRecipeInputModel input, string userId, string imagePath)
        //{
        //    var recipe = new Recipe
        //    {
        //        CategoryId = input.CategoryId,
        //        CookingTime = TimeSpan.FromMinutes(input.CookingTime),
        //        Instructions = input.Instructions,
        //        Name = input.Name,
        //        PortionsCount = input.PortionsCount,
        //        PreparationTime = TimeSpan.FromMinutes(input.PreparationTime),
        //        AddedByUserId = userId,
        //    };

        //    foreach (var inputIngredient in input.Ingredients)
        //    {
        //        var ingredient = this.ingredientsRespository.All().FirstOrDefault(x => x.Name == inputIngredient.IngredientName);
        //        if (ingredient == null)
        //        {
        //            ingredient = new Ingredient { Name = inputIngredient.IngredientName };
        //        }

        //        recipe.Ingredients.Add(new RecipeIngredient
        //        {
        //            Ingredient = ingredient,
        //            Quantity = inputIngredient.Quantity,
        //        });
        //    }

        //    // /wwwroot/images/recipes/jhdsi-343g3h453-=g34g.jpg
        //    Directory.CreateDirectory($"{imagePath}/recipes/");
        //    foreach (var image in input.Images)
        //    {
        //        var extension = Path.GetExtension(image.FileName).TrimStart('.');
        //        if (!this.allowedExtensions.Any(x => extension.EndsWith(x)))
        //        {
        //            throw new Exception($"Invalid image extension {extension}");
        //        }

        //        var dbImage = new Image
        //        {
        //            AddedByUserId = userId,
        //            Extension = extension,
        //        };
        //        recipe.Images.Add(dbImage);

        //        var physicalPath = $"{imagePath}/recipes/{dbImage.Id}.{extension}";
        //        using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
        //        await image.CopyToAsync(fileStream);
        //    }

        //    await this.recipesRepository.AddAsync(recipe);
        //    await this.recipesRepository.SaveChangesAsync();
        //}

    }
}
