namespace LuxuryEstateProject.Web.Controllers.Agent
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using LuxuryEstateProject.Services.Data.Agent;
    using LuxuryEstateProject.Web.ViewModels.Agent;
    using Microsoft.AspNetCore.Mvc;

    public class AgentController : BaseController
    {
        private IAgentService agentService;

        public AgentController(IAgentService agentService)
        {
            this.agentService = agentService;
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
            var agent = await this.agentService.GetByIdAsync<AgentViewModel>(id);

            return this.View(agent);
        }
    }
}
