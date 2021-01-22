namespace LuxuryEstateProject.Services.Data.Tests.PropertyServiceTests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using LuxuryEstateProject.Data.Common.Repositories;
    using LuxuryEstateProject.Data.Models;
    using LuxuryEstateProject.Data.Repositories;
    using LuxuryEstateProject.Services.Data.Property;
    using LuxuryEstateProject.Services.Mapping;
    using LuxuryEstateProject.Web.ViewModels.Property;
    using Microsoft.AspNetCore.Http;
    using Moq;
    using Newtonsoft.Json;
    using Xunit;

    public class PropertyServiceTests : TestBase
    {
        private Mock<IDeletableEntityRepository<RealEstateProperty>> propertiesRepository;

        public PropertyServiceTests()
        {
            this.propertiesRepository = new Mock<IDeletableEntityRepository<RealEstateProperty>>();
        }

        [Fact]
        public async Task AddPropertyShouldWorkCorrectly()
        {
            var db = GetDatabase();
            var property = new PropertyInputModel()
            {
                Name = "Test",
                Amenity = new List<string>(),
                AgentId = 1,
                Bath = 1,
                Bed = 2,
                CityId = 1,
                CountryId = 2,
                DistrictId = 1,
                Floor = 2,
                Garage = 2,
                Material = Material.Brick,
                Price = 231231.30m,
                Size = 69,
                Description = "TESTTESTTESTTESTTESTTESTTESTTESTTESTTEST",
                Type = PropertyType.Sale,
                Year = 2020,
                TotalNumberOfFloors = 10,
                Images = new List<IFormFile>(),
            };

            var properties = new EfDeletableEntityRepository<RealEstateProperty>(db);

            var service = new PropertyService(properties);

            await service.CreatePropertyAsync(property, "/.../");
            await db.SaveChangesAsync();

            Assert.Equal(1, db.RealEstateProperties.Count());
        }

        [Fact]
        public async Task TestGetHomePageService()
        {
            var db = GetDatabase();
            AutoMapperConfig.RegisterMappings(typeof(VisualisePropertiesViewModel).Assembly);
            var property = new RealEstateProperty()
            {
                Id = 2,
                Name = "Name",
            };
            var property2 = new RealEstateProperty()
            {
                Id = 1,
                Name = "Name",
            };
            var propertiesRepository = new EfDeletableEntityRepository<RealEstateProperty>(db);

            var service = new PropertyService(propertiesRepository);

            await db.RealEstateProperties.AddAsync(property);
            await db.RealEstateProperties.AddAsync(property2);
            await db.SaveChangesAsync();

            var lol = service.GetAll<VisualisePropertiesViewModel>(1);

            Assert.Equal(property.Id, lol.FirstOrDefault().Id);
        }

        public class VisualisePropertiesViewModel : IMapFrom<RealEstateProperty>
        {
            public int Id { get; set; }

            public string Name { get; set; }
        }

        public class EditPropertyInputModel : IMapFrom<RealEstateProperty>
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public string Description { get; set; }

            public int Price { get; set; }

            public int Bed { get; set; }

            public int Bath { get; set; }

            public int Garage { get; set; }
        }
    }
}
