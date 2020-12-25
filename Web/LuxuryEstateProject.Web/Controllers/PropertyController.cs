using System;
using System.Collections.Generic;
using LuxuryEstateProject.Services.Data;
using LuxuryEstateProject.Services.Data.Agent;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        private readonly IPropertyService propertyService;
        private readonly ICountryService countryService;
        private readonly IWebHostEnvironment environment;
        private readonly IAgentService agentService;
        private readonly ICity cityService;
        private readonly IDistrict districtService;
        private readonly IAmenities amenitiesService;

        public PropertyController(IPropertyService propertyService, ICountryService countryService, IAgentService agentService, IAmenities amenitiesService, ICity cityService, IDistrict districtService, IWebHostEnvironment environment)
        {
            this.propertyService = propertyService;
            this.countryService = countryService;
            this.environment = environment;
            this.agentService = agentService;
            this.cityService = cityService;
            this.districtService = districtService;
            this.amenitiesService = amenitiesService;
        }

        [HttpGet]
        public ActionResult GetRegions(int Id)
        {
            if (!string.IsNullOrWhiteSpace(Id.ToString()))
            {
                IEnumerable<SelectListItem> regions = cityService.GetCities(Id);
                return Json(regions);
            }

            return null;
        }

        [HttpGet]
        public ActionResult GetDistrict(int Id)
        {
            if (!string.IsNullOrWhiteSpace(Id.ToString()))
            {
                IEnumerable<SelectListItem> district = districtService.GetDistricts(Id);
                return Json(district);
            }

            return null;
        }

        public IActionResult Create()
        {
            var viewModel = new PropertyInputModel
            {
                Countries = this.countryService.GetAllAsSelectListItems(),
                AgentsCreateForm = this.agentService.GetAllAsSelectListItems(),
                Amenities = this.amenitiesService.GetAllAsSelectListItems(),
            };
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PropertyInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.Countries = this.countryService.GetAllAsSelectListItems();
                input.AgentsCreateForm = this.agentService.GetAllAsSelectListItems();
                input.Cities = this.cityService.GetAllAsSelectListItems();
                input.Districts = this.districtService.GetAllAsSelectListItems();
                input.Amenities = this.amenitiesService.GetAllAsSelectListItems();
                return this.View(input);
            }

            try
            {
                await this.propertyService.CreatePropertyAsync(input, $"{this.environment.WebRootPath}/assets/img/");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                input.Countries = this.countryService.GetAllAsSelectListItems();
                input.AgentsCreateForm = this.agentService.GetAllAsSelectListItems();
                input.Cities = this.cityService.GetAllAsSelectListItems();
                input.Districts = this.districtService.GetAllAsSelectListItems();
                input.Amenities = this.amenitiesService.GetAllAsSelectListItems();

                return this.View(input);
            }

            this.TempData["Message"] = "Property added successfully.";

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
