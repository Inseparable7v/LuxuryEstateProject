namespace LuxuryEstateProject.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
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
                        },
                        new City
                        {
                            Name = "Bitola",
                        },
                        new City
                        {
                            Name = "Kumanovo",
                        },
                        new City
                        {
                            Name = "Prilep",
                        },
                        new City
                        {
                            Name = "Tetovo",
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
                        },
                        new City()
                        {
                            Name = "Burgas",
                        },
                        new City()
                        {
                            Name = "Plovdiv",
                        },
                        new City()
                        {
                            Name = "Varna",
                        },
                        new City()
                        {
                            Name = "Veliko Turnovo",
                        },
                    },
                },
            });
        }
    }
}
