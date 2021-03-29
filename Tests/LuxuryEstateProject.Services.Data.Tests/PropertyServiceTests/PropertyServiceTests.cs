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
    using Microsoft.AspNetCore.Mvc.Rendering;
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
                Amenities = new List<SelectListItem>(),
                Cities = new List<SelectListItem>(),
                Countries = new List<SelectListItem>(),
                Districts = new List<SelectListItem>(),
            };

            var propertiesRepository = new EfDeletableEntityRepository<RealEstateProperty>(db);

            var service = new PropertyService(propertiesRepository);

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

            var firstProperty = service.GetAll<VisualisePropertiesViewModel>(1);

            Assert.Equal(property.Id, firstProperty.FirstOrDefault().Id);
        }

        [Fact]
        public async Task TestGetLatestPropertiesShouldWorkCorrectly()
        {
            var db = GetDatabase();
            AutoMapperConfig.RegisterMappings(typeof(VisualisePropertiesViewModel).Assembly);

            var propertiesRepository = new EfDeletableEntityRepository<RealEstateProperty>(db);

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

            var service = new PropertyService(propertiesRepository);

            await db.RealEstateProperties.AddAsync(property);
            await db.RealEstateProperties.AddAsync(property2);
            await db.SaveChangesAsync();

            var firstProperty = service.GetLatestProperties<VisualisePropertiesViewModel>();

            Assert.Equal(property2.Name, firstProperty.Skip(1).FirstOrDefault().Name);
        }

        [Fact]
        public async Task EditPropertyShouldWorkCorrectly()
        {
            var db = GetDatabase();
            AutoMapperConfig.RegisterMappings(typeof(EditPropertyinputModel).Assembly);

            var propertiesRepository = new EfDeletableEntityRepository<RealEstateProperty>(db);

            var property = new RealEstateProperty()
            {
                Id = 1,
                Description = "DescriptionDescriptionDescriptionDescriptionDescriptionDescription",
                Price = 0.123M,
                Bed = 1,
                Bath = 1,
                Garage = 1,
                Name = "Name",
                AgentId = 0,
                Floor = 0,
                Size = 0,
                Year = 0,
            };

            var editProperty = new EditPropertyinputModel()
            {
                Id = 1,
                Name = "test",
                Description = "DescriptionDescriptionDescriptionDescriptionDescriptionDescription",
                Price = 0.123M,
                Bed = 1,
                Bath = 1,
                Garage = 1,
                AgentId = 2,
                Floor = 2,
                Size = 234,
                Year = 2020,
            };

            var service = new PropertyService(propertiesRepository);

            await db.RealEstateProperties.AddAsync(property);
            await db.SaveChangesAsync();

            await service.UpdateAsync(1, editProperty);

            Assert.Equal("test", property.Name);
        }

        [Fact]
        public async Task DeletePropertyShouldWorkCorrectly()
        {

            var db = GetDatabase();
            AutoMapperConfig.RegisterMappings(typeof(EditPropertyinputModel).Assembly);

            var propertiesRepository = new EfDeletableEntityRepository<RealEstateProperty>(db);

            var property = new RealEstateProperty()
            {
                Id = 1,
                Description = "DescriptionDescriptionDescriptionDescriptionDescriptionDescription",
                Price = 0.123M,
                Bed = 1,
                Bath = 1,
                Garage = 1,
                Name = "Name",
                AgentId = 0,
                Floor = 0,
                Size = 0,
                Year = 2020,
            };

            var service = new PropertyService(propertiesRepository);

            await db.RealEstateProperties.AddAsync(property);
            await db.SaveChangesAsync();

            await service.DeleteAsync(1);
            var propertyCount = service.GetCount();

            Assert.Equal(0, propertyCount);
        }

        [Fact]
        public async Task GetAllPropertiesSortedShouldWorkCorrectly()
        {
            var db = GetDatabase();
            AutoMapperConfig.RegisterMappings(typeof(VisualisePropertiesViewModel).Assembly);

            var propertiesRepository = new EfDeletableEntityRepository<RealEstateProperty>(db);

            var property = new RealEstateProperty()
            {
                Id = 1,
                Description = "DescriptionDescriptionDescriptionDescriptionDescriptionDescription",
                Price = 0.123M,
                Bed = 1,
                Bath = 1,
                Garage = 1,
                Name = "Name",
                AgentId = 0,
                Floor = 0,
                Size = 0,
                Year = 0,
            };

            var property2 = new RealEstateProperty()
            {
                Id = 2,
                Name = "test",
                Description = "DescriptionDescriptionDescriptionDescriptionDescriptionDescription",
                Price = 0.123M,
                Bed = 1,
                Bath = 1,
                Garage = 1,
                AgentId = 2,
                Floor = 2,
                Size = 234,
                Year = 2020,
            };

            var service = new PropertyService(propertiesRepository);

            await db.RealEstateProperties.AddAsync(property);
            await db.RealEstateProperties.AddAsync(property2);
            await db.SaveChangesAsync();

            var sortedProperties = service.GetAllSortedAlpha<VisualisePropertiesViewModel>(1);

            Assert.Equal(property2.Name, sortedProperties.FirstOrDefault().Name);
        }

        [Fact]
        public async Task GetByIdShouldWorkCorrectly()
        {
            var db = GetDatabase();
            AutoMapperConfig.RegisterMappings(typeof(VisualisePropertiesViewModel).Assembly);

            var propertiesRepository = new EfDeletableEntityRepository<RealEstateProperty>(db);

            var property = new RealEstateProperty()
            {
                Id = 1,
                Description = "DescriptionDescriptionDescriptionDescriptionDescriptionDescription",
                Price = 0.123M,
                Bed = 1,
                Bath = 1,
                Garage = 1,
                Name = "Name",
                AgentId = 0,
                Floor = 0,
                Size = 0,
                Year = 0,
            };

            var service = new PropertyService(propertiesRepository);

            await db.RealEstateProperties.AddAsync(property);
            await db.SaveChangesAsync();

            var propertyById = service.GetByIdAsync<VisualisePropertiesViewModel>(1);

            Assert.Equal(property.Id, propertyById.Id);
        }

        [Fact]
        public async Task GetPropertyByAgentIdShouldWorkCorrectly()
        {
            var db = GetDatabase();
            AutoMapperConfig.RegisterMappings(typeof(VisualisePropertiesViewModel).Assembly);

            var propertiesRepository = new EfDeletableEntityRepository<RealEstateProperty>(db);

            var property = new RealEstateProperty()
            {
                Id = 1,
                Description = "DescriptionDescriptionDescriptionDescriptionDescriptionDescription",
                Price = 0.123M,
                Bed = 1,
                Bath = 1,
                Garage = 1,
                Name = "Name",
                AgentId = 1,
                Floor = 0,
                Size = 0,
                Year = 0,
            };

            var agent = new Agent()
            {
                Id = 1,
                Name = "FirstAgentName",
                Phone = "0896759530",
                Email = "daniel.2@abv.bg",
                LastName = "SecondAgentName",
            };

            var service = new PropertyService(propertiesRepository);

            await db.Agents.AddAsync(agent);
            await db.RealEstateProperties.AddAsync(property);
            await db.SaveChangesAsync();

            var propertyByAgentId = service.ListOfPropertiesByAgentIdAsync<VisualisePropertiesViewModel>(1);

            Assert.Equal(agent.Id, propertyByAgentId.FirstOrDefault().Id);
        }

        public class VisualisePropertiesViewModel : IMapFrom<RealEstateProperty>
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public int AgentId { get; set; }
        }
    }
}
