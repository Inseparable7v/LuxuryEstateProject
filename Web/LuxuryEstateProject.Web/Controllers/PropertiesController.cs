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

    [ApiController]
    [Route("api/[controller]")]
    public class PropertiesController
    {
        private IPropertyService propertyService;
        private IAgentService agentService;

        public PropertiesController(IPropertyService propertyService, IAgentService agentService)
        {
            this.propertyService = propertyService;
            this.agentService = agentService;
        }

        [HttpGet]
        public List<SinglePropertyViewModel> Properties()
        {
            var agents = this.agentService.GetAllAgentsAdminPanel<SingleAgentViewModel>().ToList();

            var prop = new List<SinglePropertyViewModel>();

            foreach (var agent in agents)
            {
                 prop = this.propertyService.ListOfPropertiesByAgentIdAsync<SinglePropertyViewModel>(agent.Id).ToList();
            }

            return prop;
        }
    }
}
