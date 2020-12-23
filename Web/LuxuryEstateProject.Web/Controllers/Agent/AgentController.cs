using LuxuryEstateProject.Web.ViewModels.Property;

namespace LuxuryEstateProject.Web.Controllers.Agent
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using LuxuryEstateProject.Services.Data.Agent;
    using LuxuryEstateProject.Services.Data.Property;
    using LuxuryEstateProject.Web.ViewModels.Agent;
    using Microsoft.AspNetCore.Mvc;

    public class AgentController : BaseController
    {
        private IAgentService agentService;
        private IPropertyService propertyService;

        public AgentController(IAgentService agentService, IPropertyService propertyService)
        {
            this.agentService = agentService;
            this.propertyService = propertyService;
        }

        public IActionResult All(int id)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int ItemPerPage = 6;

            var state = this.agentService.GetAllAgents<AgentViewModel>(id, ItemPerPage).ToList();
            var model = new AgentsListViewModel
            {
                ItemsPerPage = ItemPerPage,
                PageNumber = id,
                PropertiesCount = this.agentService.GetCount(),
                Agents = state,
            };

            return this.View(model);
        }

        public async Task<IActionResult> SingleAgent(int id)
        {
            var agent = await this.agentService.GetByIdAsync<SingleAgentViewModel>(id);

            if (agent == null)
            {
                return this.NotFound();
            }

            //var realestate = this.propertyService.ListOfPropertiesById<RealEstateViewModel>(id);

            //var agents = new SingleAgentViewModel()
            //{
            //    RealEstate = realestate,
            //};

            return this.View(agent);
        }
    }
}
