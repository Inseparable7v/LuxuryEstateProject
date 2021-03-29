namespace LuxuryEstateProject.Web.Controllers
{
    using System.Diagnostics;

    using LuxuryEstateProject.Services.Data;
    using LuxuryEstateProject.Services.Data.Agent;
    using LuxuryEstateProject.Services.Data.Property;
    using LuxuryEstateProject.Web.ViewModels;
    using LuxuryEstateProject.Web.ViewModels.Agent;
    using LuxuryEstateProject.Web.ViewModels.Blog;
    using LuxuryEstateProject.Web.ViewModels.Property;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IPropertyService propertyService;
        private readonly IBlogService blogService;
        private readonly IAgentService agentService;

        public HomeController(IPropertyService propertyService, IAgentService agentService, IBlogService blogService)
        {
            this.agentService = agentService;
            this.propertyService = propertyService;
            this.blogService = blogService;
        }

        public IActionResult Index()
        {
            var property = this.propertyService.GetLatestProperties<RealEstateViewModel>();
            var agent = this.agentService.GetHomePageAgents<AgentViewModel>();
            var blogs = this.blogService.GetHomePageBlogs<VisualizeBlogViewModel>();

            var model = new RealEstateListViewModel { PropertyViewModels = property, Agents = agent, Blogs = blogs };
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

        public IActionResult Privacy()
        {
            return this.View();
        }
    }
}
