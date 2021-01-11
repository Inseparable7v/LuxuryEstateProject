namespace LuxuryEstateProject.Web.Controllers.Agent
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using LuxuryEstateProject.Common;
    using LuxuryEstateProject.Services.Data.Agent;
    using LuxuryEstateProject.Services.Data.Property;
    using LuxuryEstateProject.Web.ViewModels.Agent;
    using LuxuryEstateProject.Web.ViewModels.Property;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;

    public class AgentController : BaseController
    {
        private readonly IAgentService agentService;
        private readonly IPropertyService propertyService;
        private readonly IWebHostEnvironment environment;

        public AgentController(IAgentService agentService, IPropertyService propertyService, IWebHostEnvironment environment)
        {
            this.agentService = agentService;
            this.propertyService = propertyService;
            this.environment = environment;
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Create()
        {
            var viewModel = new AgentInputViewModel();
            return this.View(viewModel);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        [HttpPost]
        public async Task<IActionResult> Create(AgentInputViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            try
            {
                await this.agentService.CreateAgentAsync(input, $"{this.environment.WebRootPath}/assets/img/");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);

                return this.View(input);
            }

            this.TempData["Message"] = "Agent added successfully.";

            return this.RedirectToAction("All");
        }

        public IActionResult All(int id = 1)
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
            var property = this.propertyService.ListOfPropertiesByAgentId<RealEstateViewModel>(id);

            var agent = await this.agentService.GetByIdAsync<SingleAgentViewModel>(id);

            var model = new SingleAgentViewModel
            {
                Id = agent.Id,
                Name = agent.Name,
                RealEstateProperties = property,
                Description = agent.Description,
                Email = agent.Email,
                LastName = agent.LastName,
                Phone = agent.Phone,
                ImageRemoteImageUrl = agent.ImageRemoteImageUrl,
            };

            return this.View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await this.agentService.GetByIdAsync<EditAgentInputModel>(id);

            return this.View(model);
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Edit(int id, EditAgentInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.agentService.UpdateAsync(id, input);

            return this.RedirectToAction(nameof(this.All));
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Delete(int id)
        {
            await this.agentService.DeleteAgentAsync(id);

            return this.RedirectToAction(nameof(this.All));
        }
    }
}