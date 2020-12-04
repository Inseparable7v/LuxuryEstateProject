namespace LuxuryEstateProject.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using LuxuryEstateProject.Data.Models;
    using Microsoft.EntityFrameworkCore.Internal;

    public class PropertySeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            //if (dbContext.RealEstateProperties.Any())
            //{
            //    return;
            //}

            await dbContext.RealEstateProperties.AddAsync(new RealEstateProperty
            {
                Description = "Some sexy ass property",
                Name = "Vitosha Property",
                Garage = 3,
                Bed = 6,
                Bath = 4,
                Floor = 3,
                Price = 206500.430m,
                Size = 423.6f,
                Year = 2021,
                Type = PropertyType.ForSale,
                TotalNumberOfFloors = 6,
                IsDeleted = false,
                CreatedOn = DateTime.UtcNow,

                Amenities = new List<Amenities>
                {
                    new Amenities
                    {
                        CreatedOn = DateTime.UtcNow,
                        IsDeleted = false,
                        Name = "Balcony",
                    },
                    new Amenities
                    {
                        CreatedOn = DateTime.UtcNow,
                        IsDeleted = false,
                        Name = "Internet",
                    },
                    new Amenities
                    {
                        CreatedOn = DateTime.UtcNow,
                        IsDeleted = false,
                        Name = "East View",
                    },
                },
                Agent = new Agent
                {
                    Email = "daniel.todorow1@gmail.com",
                    Name = "Jimmy",
                    Phone = "0896797550",
                    LastName = "Italiano",
                    Description = "Some random text",
                    IsDeleted = false,
                    CreatedOn = DateTime.UtcNow,
                    Images = new List<Image>
                    {
                        new Image
                        {
                            RemoteImageUrl = "https://hr14.org/wp-content/uploads/2020/02/real-estate-agent-qualities-e1478704779127.jpg",
                            CreatedOn = DateTime.UtcNow,
                            IsDeleted = false,
                        },
                        new Image
                        {
                            RemoteImageUrl = "https://www.blogrollcenter.com/wp-content/uploads/ngg_featured/choose_a_real_estate_agent_to_sell_a_house.jpg",
                            CreatedOn = DateTime.UtcNow,
                            IsDeleted = false,
                        },
                    },
                },
                BuildingType = new BuildingType
                {
                    Name = "Brick",
                    Properties = new List<RealEstateProperty>(),
                    IsDeleted = false,
                    CreatedOn = DateTime.UtcNow,
                },
                Countries = new Country
                {
                    Name = "Bulgaria",
                    IsDeleted = false,
                    Cities = new HashSet<City>
                    {
                        new City
                        {
                            Name = "Sofia",
                            CreatedOn = DateTime.UtcNow,
                            IsDeleted = false,
                            Districts = new HashSet<District>
                            {
                                new District
                                {
                                    Name = "Vitosha",
                                    CreatedOn = DateTime.UtcNow,
                                    IsDeleted = false,
                                },
                            },
                        },
                    },
                    CreatedOn = DateTime.UtcNow,
                },
                Images = new List<Image>
                {
                    new Image
                    {
                        RemoteImageUrl = "https://i.pinimg.com/originals/2d/a0/a3/2da0a3e36f00e259099734ae5132846c.jpg",
                        CreatedOn = DateTime.UtcNow,
                        IsDeleted = false,
                    },
                },
            });
        }
    }
}
