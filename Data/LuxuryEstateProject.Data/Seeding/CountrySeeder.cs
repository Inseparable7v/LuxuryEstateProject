namespace LuxuryEstateProject.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using LuxuryEstateProject.Data.Models;

    class CountrySeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Countries.Any())
            {
                return;
            }

            await dbContext.Countries.AddRangeAsync(new List<Country>()
            {
                new Country()
                {
                    Name = "Macedonia",
                    Cities = new List<City>()
                    {
                        new City
                        {
                            Name = "Skopje",
                            Districts = new List<District>()
                            {
                                new District()
                                {
                                    Name = "Center",
                                },
                            },
                        },
                        new City
                        {
                            Name = "Bitola",
                            Districts = new List<District>()
                            {
                                new District()
                                {
                                    Name = "Bair",
                                },
                            },
                        },
                        new City
                        {
                            Name = "Kumanovo",
                            Districts = new List<District>()
                            {
                                new District()
                                {
                                    Name = "Goce Delchev",
                                },
                            },
                        },
                        new City
                        {
                            Name = "Prilep",
                            Districts = new List<District>()
                            {
                                new District()
                                {
                                    Name = "Varosh",
                                },
                            },
                        },
                        new City
                        {
                            Name = "Tetovo",
                            Districts = new List<District>()
                            {
                                new District()
                                {
                                    Name = "Center",
                                },
                            },
                        },
                    },
                },
                new Country()
                {
                    Name = "Bulgaria",
                    Cities = new List<City>()
                    {
                        new City()
                        {
                            Name = "Sofia",
                            Districts = new List<District>()
                            {
                                new District()
                                {
                                    Name = "Lozenetz",
                                },
                            },
                        },
                        new City()
                        {
                            Name = "Burgas",
                            Districts = new List<District>()
                            {
                                new District()
                                {
                                    Name = "Meden Rudnik",
                                },
                            },
                        },
                        new City()
                        {
                            Name = "Plovdiv",
                            Districts = new List<District>()
                            {
                                new District()
                                {
                                    Name = "Trakiya",
                                },
                            },
                        },
                        new City()
                        {
                            Name = "Varna",
                            Districts = new List<District>()
                            {
                                new District()
                                {
                                    Name = "Vuzrajdane",
                                },
                            },
                        },
                        new City()
                        {
                            Name = "Veliko Turnovo",
                            Districts = new List<District>()
                            {
                                new District()
                                {
                                    Name = "Buzlodja",
                                },
                            },
                        },
                    },
                },
            });
        }
    }
}
