namespace LuxuryEstateProject.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using LuxuryEstateProject.Data;
    using Microsoft.EntityFrameworkCore;

    public class TestBase
    {
        public TestBase()
        {
            new MapperInitializationProfile();
        }

        public static ApplicationDbContext GetDatabase()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            var db = new ApplicationDbContext(options);

            return db;
        }
    }
}
