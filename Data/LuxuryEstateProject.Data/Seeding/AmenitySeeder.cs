namespace LuxuryEstateProject.Data.Seeding
{
    using System;
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

            await dbContext.Amenities.AddAsync(new Amenity()
            {
                Name = "Internet",
            });
            await dbContext.Amenities.AddAsync(new Amenity()
            {
                Name = "Security",
            });
            await dbContext.Amenities.AddAsync(new Amenity()
            {
                Name = "Video surveillance",
            });
            await dbContext.Amenities.AddAsync(new Amenity()
            {
                Name = "Elevator",
            });
            await dbContext.Amenities.AddAsync(new Amenity()
            {
                Name = "Furnished",
            });
            await dbContext.Amenities.AddAsync(new Amenity()
            {
                Name = "SunRoom",
            });
        }
    }
}
