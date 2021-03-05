namespace LuxuryEstateProject.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using LuxuryEstateProject.Services.Data.Agent;
    using LuxuryEstateProject.Services.Data.Property;
    using LuxuryEstateProject.Web.ViewModels.Agent;
    using LuxuryEstateProject.Web.ViewModels.Property;
    using Microsoft.AspNetCore.Mvc;


    public class DashboardController : AdministrationController
    {
        private const int Id = 1;
        private const int ItemPerPage = 6;

        private readonly IAgentService agentService;
        private readonly IPropertyService propertyService;

        public DashboardController(IAgentService agentService, IPropertyService propertyService)
        {
            this.propertyService = propertyService;
            this.agentService = agentService;
        }

        public IActionResult Index()
        {
            var state = this.agentService.GetAllAgents<AgentViewModel>(Id, ItemPerPage).ToList().OrderBy(x => x.Id);

            var model = new AgentsListViewModel
            {
                ItemsPerPage = ItemPerPage,
                PageNumber = Id,
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
