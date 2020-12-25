using Newtonsoft.Json;

namespace LuxuryEstateProject.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;

    using LuxuryEstateProject.Data.Common.Repositories;
    using LuxuryEstateProject.Data.Models;
    using LuxuryEstateProject.Services.Data.Property;
    using Moq;
    using Xunit;

    public class PropertyServiceTests
    {
        [Fact]
        public void TestGetHomePageService()
        {
            int id = 2;
            var repository = new Mock<IDeletableEntityRepository<RealEstateProperty>>();

            repository.Setup(r => r.AllAsNoTracking()).Returns(new List<RealEstateProperty>
            {
                new RealEstateProperty() {Id = id, Description = "Test",Floor = 3,Size = 2313,Name = "Test",},
                new RealEstateProperty() {Id = 1},
            }.AsQueryable);

            var service = new PropertyService(repository.Object);

            var obj1 = JsonConvert.SerializeObject(new RealEstateProperty() {Id = 2, Description = "Test",Floor = 3,Size = 2313,Name = "Test",});
            var obj2 = JsonConvert.SerializeObject(service.GetByIdAsync<RealEstateProperty>(id));

            Assert.Equal(obj1,obj2);
        }
    }
}
