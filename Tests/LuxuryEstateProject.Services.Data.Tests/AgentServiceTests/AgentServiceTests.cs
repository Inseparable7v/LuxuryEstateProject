namespace LuxuryEstateProject.Services.Data.Tests.AgentServiceTests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using LuxuryEstateProject.Data.Models;
    using LuxuryEstateProject.Data.Repositories;
    using LuxuryEstateProject.Services.Data.Agent;
    using LuxuryEstateProject.Services.Mapping;
    using LuxuryEstateProject.Web.ViewModels.Agent;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Http.Internal;
    using Xunit;

    public class AgentServiceTests : TestBase
    {
        public AgentServiceTests()
        {
        }

        [Fact]
        public async Task GetAllAgentsShouldWorkCorrectly()
        {
            var db = GetDatabase();

            var agentRepository = new EfDeletableEntityRepository<Agent>(db);
            var propertyRepository = new EfDeletableEntityRepository<RealEstateProperty>(db);

            var agent = new AgentInputViewModel()
            {
                Description = "AgentTestsAgentTestsAgentTestsAgentTestsAgentTestsAgentTestsAgentTests",
                Name = "FirstAgentName",
                Phone = "0896759530",
                Email = "daniel.2@abv.bg",
                LastName = "SecondAgentName",
                Images = new List<IFormFile>(),
            };

            var service = new AgentService(agentRepository, propertyRepository);

            await service.CreateAgentAsync(agent, "/.../...");
            await db.SaveChangesAsync();

            Assert.Equal(1, db.Agents.Count());
        }
    }

    public class VisualisePropertiesViewModel : IMapFrom<Agent>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int AgentId { get; set; }
    }
}
