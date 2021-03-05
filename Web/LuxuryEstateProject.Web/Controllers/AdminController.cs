namespace LuxuryEstateProject.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using LuxuryEstateProject.Services.Data.Agent;
    using LuxuryEstateProject.Services.Data.Property;
    using LuxuryEstateProject.Web.ViewModels.Agent;
    using LuxuryEstateProject.Web.ViewModels.Property;
    using Microsoft.AspNetCore.Mvc;

    public class AdminController : BaseController
    {
        private readonly IAgentService agentService;
        private readonly IPropertyService propertyService;

        public AdminController(IAgentService agentService, IPropertyService propertyService)
        {
            this.propertyService = propertyService;
            this.agentService = agentService;
        }

        public IActionResult AdminPanel()
        {
            var state = this.agentService.GetAllAgentsAdminPanel<AgentViewModel>().ToList().OrderBy(x => x.Id);

            var model = new AgentsListViewModel
            {
                Agents = state,
            };

            foreach (var agentViewModel in model.Agents)
            {
                agentViewModel.RealEstateViewModels = this.propertyService.ListOfPropertiesByAgentIdAsync<RealEstateViewModel>(agentViewModel.Id);
                model.PropertiesCount = agentViewModel.RealEstateViewModels.Count();
            }

            return this.View(model);
        }
    }
}
