namespace LuxuryEstateProject.Services.Data.Tests.PropertyServiceTests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using LuxuryEstateProject.Data.Common.Repositories;
    using LuxuryEstateProject.Data.Models;
    using LuxuryEstateProject.Data.Repositories;
    using LuxuryEstateProject.Services.Data.Property;
    using LuxuryEstateProject.Web.ViewModels.Property;
    using Microsoft.AspNetCore.Http;
    using Moq;
    using Newtonsoft.Json;
    using Xunit;

    public class PropertyServiceTests
    {
        //private Mock<IDeletableEntityRepository<RealEstateProperty>> propertiesRepository;

        //public PropertyServiceTests()
        //{
        //    this.propertiesRepository = new Mock<IDeletableEntityRepository<RealEstateProperty>>();
        //}

        //[Fact]
        //public async Task AddPropertyShouldWorkCorrectly()
        //{
        //    //var db = TestDatabase.GetDatabase();
        //    //var property = new PropertyInputModel()
        //    //{
        //    //    Name = "Test",
        //    //    Bath = 2,
        //    //    Price = 321312,
        //    //    AgentId = 2,
        //    //    Bed = 2,
        //    //    CityId = 2,
        //    //    CountryId = 1,
        //    //    Description = "hajkdsadlascnkzxjlkcnzxjlcl",
        //    //    DistrictId = 2,
        //    //    Floor = 4,
        //    //    Garage = 1,
        //    //    Size = 85,
        //    //    TotalNumberOfFloors = 2,
        //    //    Year = 2020,
        //    //    Type = PropertyType.Rent,
        //    //    Material = Material.Brick,
        //    //    Amenity = new List<string>(),
        //    //    Images = new List<IFormFile>(),
        //    //};

        //    //var properties = new EfDeletableEntityRepository<RealEstateProperty>(db);

        //    //var service = new PropertyService(properties);

        //    //await db.RealEstateProperties.AddAsync(property);
        //    //await service.CreatePropertyAsync(property, ".../.../");
        //    //await db.SaveChangesAsync();

        //    //Assert.Equal(1, db.RealEstateProperties.Count());
        //}

        [Fact]
        public void TestGetHomePageService()
        {
            int id = 2;
            var repository = new Mock<IDeletableEntityRepository<RealEstateProperty>>();

            repository.Setup(r => r.AllAsNoTracking()).Returns(new List<RealEstateProperty>
            {
                new RealEstateProperty() {Id = id, Description = "Test", Floor = 3, Size = 2313, Name = "Test", },
                new RealEstateProperty() {Id = 1, Description = "Test2d", },
            }.AsQueryable);

            var service = new PropertyService(repository.Object);

            Assert.Equal(2,service.GetCount());
        }
    }
}
