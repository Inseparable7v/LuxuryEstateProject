namespace LuxuryEstateProject.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;

    using LuxuryEstateProject.Services.Data.Agent;
    using LuxuryEstateProject.Services.Data.Property;
    using LuxuryEstateProject.Web.ViewModels;
    using LuxuryEstateProject.Web.ViewModels.Agent;
    using LuxuryEstateProject.Web.ViewModels.Property;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IPropertyService propertyService;
        private readonly IAgentService agentService;

        public HomeController(IPropertyService propertyService, IAgentService agentService)
        {
            this.agentService = agentService;
            this.propertyService = propertyService;
        }

        public IActionResult Index()
        {
            var property = this.propertyService.GetLatestProperties<RealEstateViewModel>();
            var agent = this.agentService.GetHomePageAgents<AgentViewModel>();

            var model = new RealEstateListViewModel { PropertyViewModels = property, Agents = agent };
            return this.View(model);
        }

        public IActionResult About()
        {
            var state = this.agentService.GetHomePageAgents<AgentViewModel>();

            var model = new AgentsListViewModel { Agents = state };

            return this.View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
