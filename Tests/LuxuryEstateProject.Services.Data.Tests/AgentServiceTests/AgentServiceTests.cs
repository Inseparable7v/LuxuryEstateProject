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
        public async Task CreateAgentShouldWorkCorrectly()
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

        [Fact]
        public async Task GetAllAgentShouldWorkCorrectly()
        {
            var db = GetDatabase();

            var agentRepository = new EfDeletableEntityRepository<Agent>(db);
            var propertyRepository = new EfDeletableEntityRepository<RealEstateProperty>(db);

            var agent = new Agent()
            {
                Description = "AgentTestsAgentTestsAgentTestsAgentTestsAgentTestsAgentTestsAgentTests",
                Name = "FirstAgentName",
                Phone = "0896759530",
                Email = "daniel.2@abv.bg",
                LastName = "SecondAgentName",
                Id = 1,
            };

            var service = new AgentService(agentRepository, propertyRepository);

            await db.Agents.AddAsync(agent);
            await db.SaveChangesAsync();

            var agentById = await service.GetByIdAsync<VisualiseAgentsViewModel>(1);

            Assert.Equal(agent.Id, agentById.Id);
        }

        [Fact]
        public async Task GetSingleAgentShouldWorkCorrectly()
        {
            var db = GetDatabase();

            var agentRepository = new EfDeletableEntityRepository<Agent>(db);
            var propertyRepository = new EfDeletableEntityRepository<RealEstateProperty>(db);

            var agent = new Agent()
            {
                Description = "AgentTestsAgentTestsAgentTestsAgentTestsAgentTestsAgentTestsAgentTests",
                Name = "FirstAgentName",
                Phone = "0896759530",
                Email = "daniel.2@abv.bg",
                LastName = "SecondAgentName",
                Id = 1,
            };

            var service = new AgentService(agentRepository, propertyRepository);

            await db.Agents.AddAsync(agent);
            await db.SaveChangesAsync();

            var singleAgent = service.SingleAgent<VisualiseAgentsViewModel>();

            Assert.Equal(agent.Name, singleAgent.Name);
        }

        [Fact]
        public async Task GetAllAgentsShouldWorkCorrectly()
        {
            var db = GetDatabase();

            var agentRepository = new EfDeletableEntityRepository<Agent>(db);
            var propertyRepository = new EfDeletableEntityRepository<RealEstateProperty>(db);

            var agent = new Agent()
            {
                Description = "AgentTestsAgentTestsAgentTestsAgentTestsAgentTestsAgentTestsAgentTests",
                Name = "FirstAgentName",
                Phone = "0896759530",
                Email = "daniel.2@abv.bg",
                LastName = "SecondAgentName",
                Id = 1,
            };

            var service = new AgentService(agentRepository, propertyRepository);

            await db.Agents.AddAsync(agent);
            await db.SaveChangesAsync();

            var getAllAgents = service.GetAllAgents<VisualiseAgentsViewModel>(1);

            Assert.Equal(agent.Phone, getAllAgents.FirstOrDefault().Phone);
        }

        [Fact]
        public async Task UpdateAsyncShouldWorkCorrectly()
        {
            var db = GetDatabase();

            var agentRepository = new EfDeletableEntityRepository<Agent>(db);
            var propertyRepository = new EfDeletableEntityRepository<RealEstateProperty>(db);

            var agent = new Agent()
            {
                Description = "AgentTestsAgentTestsAgentTestsAgentTestsAgentTestsAgentTestsAgentTests",
                Name = "FirstAgentName",
                Phone = "0896759530",
                Email = "daniel.2@abv.bg",
                LastName = "SecondAgentName",
                Id = 1,
            };

            var agentToEdit = new EditAgentInputModel()
            {
                Description = "AgentTestsAgentTestsAgentTestsAgentTestsAgentTestsAgentTestsAgentTests",
                Name = "FirstAgentName",
                Phone = "0896759530",
                Email = "Edited@abv.bg",
                LastName = "SecondAgentName",
                Id = 2,
            };

            var service = new AgentService(agentRepository, propertyRepository);

            await db.Agents.AddAsync(agent);
            await db.SaveChangesAsync();

            await service.UpdateAsync(1, agentToEdit);

            Assert.Equal(agentToEdit.Email, agent.Email);
        }

        [Fact]
        public async Task DeleteAgentAsyncShouldWorkCorrectly()
        {
            var db = GetDatabase();

            var agentRepository = new EfDeletableEntityRepository<Agent>(db);
            var propertyRepository = new EfDeletableEntityRepository<RealEstateProperty>(db);

            var agent = new Agent()
            {
                Description = "AgentTestsAgentTestsAgentTestsAgentTestsAgentTestsAgentTestsAgentTests",
                Name = "FirstAgentName",
                Phone = "0896759530",
                Email = "daniel.2@abv.bg",
                LastName = "SecondAgentName",
                Id = 1,
                RealEstateProperties = new List<RealEstateProperty>()
                {
                    new RealEstateProperty
                    {
                        Id = 1,
                        AgentId = 1,
                    },
                },
            };

            var service = new AgentService(agentRepository, propertyRepository);

            await db.Agents.AddAsync(agent);
            await db.SaveChangesAsync();

            await service.DeleteAgentAsync(1);

            Assert.Equal(0, service.GetCount());
        }

        [Fact]
        public async Task GetAllAgentsAdminPanelShouldWorkCorrectly()
        {
            var db = GetDatabase();

            var agentRepository = new EfDeletableEntityRepository<Agent>(db);
            var propertyRepository = new EfDeletableEntityRepository<RealEstateProperty>(db);

            var agent = new Agent()
            {
                Description = "AgentTestsAgentTestsAgentTestsAgentTestsAgentTestsAgentTestsAgentTests",
                Name = "FirstAgentName",
                Phone = "0896759530",
                Email = "daniel.2@abv.bg",
                LastName = "FirstAgentName",
                Id = 1,
            };
            var agent2 = new Agent()
            {
                Description = "AgentTestsAgentTestsAgentTestsAgentTestsAgentTestsAgentTestsAgentTests",
                Name = "FirstAgentName",
                Phone = "0896759530",
                Email = "daniel.2@abv.bg",
                LastName = "SecondAgentName",
                Id = 2,
            };

            var service = new AgentService(agentRepository, propertyRepository);

            await db.Agents.AddAsync(agent);
            await db.Agents.AddAsync(agent2);
            await db.SaveChangesAsync();

            var adminPageAgents = service.GetAllAgentsAdminPanel<VisualiseAgentsViewModel>();

            Assert.Equal(agent2.LastName, adminPageAgents.FirstOrDefault().LastName);
        }

        [Fact]
        public async Task GetHomePageAgentShouldWorkCorrectly()
        {
            var db = GetDatabase();

            var agentRepository = new EfDeletableEntityRepository<Agent>(db);
            var propertyRepository = new EfDeletableEntityRepository<RealEstateProperty>(db);

            var agent = new Agent()
            {
                Description = "AgentTestsAgentTestsAgentTestsAgentTestsAgentTestsAgentTestsAgentTests",
                Name = "FirstAgentName",
                Phone = "0896759530",
                Email = "daniel.2@abv.bg",
                LastName = "FirstAgentName",
                Id = 1,
            };
            var agent2 = new Agent()
            {
                Description = "Agent22TestsAgentTestsAgentTestsAgentTestsAgentTestsAgentTestsAgentTests",
                Name = "FirstAgentName",
                Phone = "0896759530",
                Email = "daniel.2@abv.bg",
                LastName = "SecondAgentName",
                Id = 2,
            };

            var service = new AgentService(agentRepository, propertyRepository);

            await db.Agents.AddAsync(agent);
            await db.Agents.AddAsync(agent2);
            await db.SaveChangesAsync();

            var countOfAgents = service.GetHomePageAgents<VisualiseAgentsViewModel>();

            Assert.Equal(agent2.Id, countOfAgents.FirstOrDefault().Id);
        }
    }

    public class VisualiseAgentsViewModel : IMapFrom<Agent>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string LastName { get; set; }
    }
}
