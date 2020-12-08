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

            var property = await dbContext.RealEstateProperties.AddAsync(new RealEstateProperty
            {
                Description = "Some sexy ass property",
                Name = "Dragalevtzi Property",
                Garage = 3,
                Bed = 6,
                Bath = 4,
                Floor = 3,
                Price = 206500.430m,
                Size = 423.6f,
                Year = 2021,
                Type = PropertyType.Rent,
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
                        Name = "SunRoom",
                    },
                },
                Agent = new Agent
                {
                    Email = "daniel.todorow1@gmail.com",
                    Name = "Merlin",
                    Phone = "0896797550",
                    LastName = "Pachotti",
                    Description = "Some random text",
                    IsDeleted = false,
                    CreatedOn = DateTime.UtcNow,
                    Images = new List<Image>
                    {
                        new Image
                        {
                            RemoteImageUrl = "https://images.unsplash.com/photo-1556157382-97eda2d62296?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=1350&q=80",
                            CreatedOn = DateTime.UtcNow,
                            IsDeleted = false,
                        },
                        new Image
                        {
                            RemoteImageUrl = "https://images.unsplash.com/photo-1555421689-d68471e189f2?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=1350&q=80",
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
                                    Name = "Dragalevtzi",
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
                        RemoteImageUrl = "https://images.pexels.com/photos/2343468/pexels-photo-2343468.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260",
                        CreatedOn = DateTime.UtcNow,
                        IsDeleted = false,
                    },new Image
                    {
                        RemoteImageUrl = "https://images.pexels.com/photos/4885978/pexels-photo-4885978.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260",
                        CreatedOn = DateTime.UtcNow,
                        IsDeleted = false,
                    },
                },
            });
        }
    }
}
