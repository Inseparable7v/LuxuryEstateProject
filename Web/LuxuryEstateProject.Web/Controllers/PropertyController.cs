using System;
using LuxuryEstateProject.Services.Data;
using LuxuryEstateProject.Services.Data.Agent;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;

namespace LuxuryEstateProject.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using LuxuryEstateProject.Data.Models;
    using LuxuryEstateProject.Services.Data.Property;
    using LuxuryEstateProject.Web.ViewModels.Property;
    using Microsoft.AspNetCore.Mvc;

    public class PropertyController : BaseController
    {
        private IPropertyService propertyService;
        private ICountryService countryService;
        private IWebHostEnvironment environment;
        private IAgentService agentService;
        private IBuildingType buildingTypesService;

        public PropertyController(IPropertyService propertyService, ICountryService countryService, IAgentService agentService, IBuildingType buildingTypesService, IWebHostEnvironment environment)
        {
            this.propertyService = propertyService;
            this.countryService = countryService;
            this.environment = environment;
            this.agentService = agentService;
            this.buildingTypesService = buildingTypesService;
        }

        public IActionResult Create()
        {
            var viewModel = new PropertyInputModel
            {
                Countries = this.countryService.GetAllAsSelectListItems(),
                AgentsCreateForm = this.agentService.GetAllAsSelectListItems(),
                BuildingTypes = this.buildingTypesService.GetAllAsSelectListItems(),
            };
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PropertyInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.Countries = this.countryService.GetAllAsSelectListItems();
                input.BuildingTypes = this.buildingTypesService.GetAllAsSelectListItems();
                input.AgentsCreateForm = this.agentService.GetAllAsSelectListItems();
                return this.View(input);
            }

            // var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //var user = await this.userManager.GetUserAsync(this.User);

            try
            {
                await this.propertyService.CreatePropertyAsync(input, $"{this.environment.WebRootPath}/assets/img/");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                input.Countries = this.countryService.GetAllAsSelectListItems();
                input.AgentsCreateForm = this.agentService.GetAllAsSelectListItems();
                input.BuildingTypes = this.buildingTypesService.GetAllAsSelectListItems();

                return this.View(input);
            }

            this.TempData["Message"] = "Property added successfully.";

            // TODO: Redirect to recipe info page
            return this.RedirectToAction("PropertyGrid");
        }

        public IActionResult PropertyGrid(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int IteamsPerPage = 6;

            var model = new RealEstateListViewModel
            {
                ItemsPerPage = IteamsPerPage,
                PageNumber = id,
                PropertiesCount = this.propertyService.GetCount(),
                PropertyViewModels = this.propertyService.GetAll<RealEstateViewModel>(id, IteamsPerPage),
            };

            return this.View(model);
        }

        public async Task<IActionResult> PropertySingle(int id)
        {
            var property = await this.propertyService.GetByIdAsync<SinglePropertyViewModel>(id);

            return this.View(property);
        }
    }
}
