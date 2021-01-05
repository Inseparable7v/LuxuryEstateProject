namespace LuxuryEstateProject.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using LuxuryEstateProject.Common;
    using LuxuryEstateProject.Services.Data;
    using LuxuryEstateProject.Services.Data.Agent;
    using LuxuryEstateProject.Services.Data.Property;
    using LuxuryEstateProject.Services.Messaging;
    using LuxuryEstateProject.Web.ViewModels.Property;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class PropertyController : BaseController
    {
        private readonly IPropertyService propertyService;
        private readonly ICountryService countryService;
        private readonly IWebHostEnvironment environment;
        private readonly IAgentService agentService;
        private readonly ICity cityService;
        private readonly IDistrict districtService;
        private readonly IEmailSender emailSender;
        private readonly IAmenities amenitiesService;

        public PropertyController(IPropertyService propertyService, ICountryService countryService, IAgentService agentService, IAmenities amenitiesService, ICity cityService, IDistrict districtService, IEmailSender emailSender, IWebHostEnvironment environment)
        {
            this.propertyService = propertyService;
            this.countryService = countryService;
            this.environment = environment;
            this.agentService = agentService;
            this.cityService = cityService;
            this.districtService = districtService;
            this.emailSender = emailSender;
            this.amenitiesService = amenitiesService;
        }

        [Authorize]
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

        [Authorize]
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

        [Authorize]
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

        [Authorize]
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

        [Authorize]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await this.propertyService.GetByIdAsync<EditPropertyinputModel>(id);
            if (!model.AgentId.Equals(null))
            {
                model.AgentsCreateForm = this.agentService.GetAllAsSelectListItems();
                return this.View(model);
            }
            return this.RedirectToAction(nameof(this.PropertyGrid));
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Edit(int id, EditPropertyinputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                inputModel.AgentsCreateForm = this.agentService.GetAllAsSelectListItems();
                return this.View(inputModel);
            }

            await this.propertyService.UpdateAsync(id, inputModel);
            return this.RedirectToAction(nameof(this.PropertySingle));
        }

        [Authorize]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> SendToEmail(int id)
        {
            var property = await this.propertyService.GetByIdAsync<SinglePropertyViewModel>(id);
            var html = new StringBuilder();
            html.AppendLine($"<h1>{property.Name}</h1>");
            html.AppendLine($"<h3>{property.Description}</h3>");
            html.AppendLine($"<h3>{property.Price}</h3>");
            await this.emailSender.SendEmailAsync("LuxuryEstate@gmail.com", "LuxuryEstate", "daniel.todorow1@gmail.com", property.Name, html.ToString());
            return this.RedirectToAction(nameof(this.PropertySingle), new { id });
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Delete(int id)
        {
            await this.propertyService.DeleteAsync(id);

            return this.RedirectToAction(nameof(this.PropertyGrid));
        }
    }
}
