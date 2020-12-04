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

        public IActionResult All()
        {
            var state = this.agentService.GetAllAgents<AgentViewModel>().ToList();
            var model = new AgentsListViewModel{ Agents = state };

            return this.View(model);
        }

        public async Task<IActionResult> SingleAsync(int id)
        {
            var property = await this.agentService.GetByIdAsync<AgentViewModel>(id);

            return this.View(property);
        }
    }
}
