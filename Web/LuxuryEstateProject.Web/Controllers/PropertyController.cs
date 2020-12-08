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

        public PropertyController(IPropertyService propertyService)
        {
            this.propertyService = propertyService;
        }

        public IActionResult CreateProperty()
        {

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
