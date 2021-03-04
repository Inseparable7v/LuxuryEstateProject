namespace LuxuryEstateProject.Web.Areas.Administration.Controllers
{
    using System.Linq;

    using LuxuryEstateProject.Services.Data;
    using LuxuryEstateProject.Services.Data.Agent;
    using LuxuryEstateProject.Web.ViewModels.Administration.Dashboard;
    using LuxuryEstateProject.Web.ViewModels.Agent;
    using Microsoft.AspNetCore.Mvc;

    public class DashboardController : AdministrationController
    {
        private readonly IAgentService agentService;

        public DashboardController(IAgentService agentService)
        {
            this.agentService = agentService;
        }

        public IActionResult Index()
        {
            int id = 1;
            int ItemPerPage = 6;

            var state = this.agentService.GetAllAgents<AgentViewModel>(id, ItemPerPage).ToList().OrderBy(x => x.Id);

            var model = new AgentsListViewModel
            {
                ItemsPerPage = ItemPerPage,
                PageNumber = id,
                PropertiesCount = this.agentService.GetCount(),
                Agents = state,
            };

            return this.View(model);
        }
    }
}
