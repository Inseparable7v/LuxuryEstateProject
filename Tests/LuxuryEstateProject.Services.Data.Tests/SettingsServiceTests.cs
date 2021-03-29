namespace LuxuryEstateProject.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using LuxuryEstateProject.Data;
    using LuxuryEstateProject.Data.Common.Repositories;
    using LuxuryEstateProject.Data.Models;
    using LuxuryEstateProject.Data.Repositories;
    using LuxuryEstateProject.Web.ViewModels.Settings;
    using Microsoft.EntityFrameworkCore;

    using Moq;

    using Xunit;

    public class SettingsServiceTests : TestBase
    {
        public SettingsServiceTests()
        {
        }

        [Fact]
        public async Task GetCountShouldReturnCorrectNumberUsingDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "SettingsTestDb").Options;
            using var dbContext = new ApplicationDbContext(options);
            dbContext.Settings.Add(new Setting());
            dbContext.Settings.Add(new Setting());
            dbContext.Settings.Add(new Setting());
            await dbContext.SaveChangesAsync();

            using var repository = new EfDeletableEntityRepository<Setting>(dbContext);
            var service = new SettingsService(repository);
            Assert.Equal(3, service.GetCount());
        }

        [Fact]
        public async Task GetAllShouldReturnCorrectNumberUsingDbContext()
        {
            var db = GetDatabase();

            var settingRepository = new EfDeletableEntityRepository<Setting>(db);

            var setting = new Setting()
            {
                Id = 1,
                Name = "test",
                Value = "valueTest",
            };

            var service = new SettingsService(settingRepository);

            await db.Settings.AddAsync(setting);
            await db.SaveChangesAsync();

            var firstSetting = service.GetAll<SettingsListViewModel>().FirstOrDefault();

            //var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            //    .UseInMemoryDatabase(databaseName: "SettingsTestDb").Options;
            //using var dbContext = new ApplicationDbContext(options);
            //dbContext.Settings.Add(new Setting() { Id = 1, Name = "test", Value = "valueTest", });
            //await dbContext.SaveChangesAsync();

            //using var repository = new EfDeletableEntityRepository<Setting>(dbContext);
            //var service = new SettingsService(repository);
            Assert.Equal(1, firstSetting.Settings.FirstOrDefault().Id);
        }
    }
}
