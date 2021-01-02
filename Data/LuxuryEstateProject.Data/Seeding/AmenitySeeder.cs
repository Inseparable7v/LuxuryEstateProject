namespace LuxuryEstateProject.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using LuxuryEstateProject.Data.Models;

    class AmenitySeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Amenities.Any())
            {
                return;
            }

            await dbContext.AddRangeAsync(new List<Amenity>
            {
                new Amenity
                {
                    Name = "Cable Tv",
                },
                new Amenity
                {
                    Name = "Internet",
                },
                new Amenity
                {
                    Name = "Security",
                },
                new Amenity
                {
                    Name = "Video surveillance",
                },
                new Amenity
                {
                    Name = "Sun Room",
                },
                new Amenity
                {
                    Name = "Furnished",
                },
                new Amenity
                {
                    Name = "Elevator",
                },
                new Amenity
                {
                    Name = "Parking",
                },
                new Amenity
                {
                    Name = "Balcony",
                },
                new Amenity
                {
                    Name = "Concrete Flooring",
                },
                new Amenity
                {
                    Name = "Outdoor Kitchen",
                },
            });
        }
    }
}
