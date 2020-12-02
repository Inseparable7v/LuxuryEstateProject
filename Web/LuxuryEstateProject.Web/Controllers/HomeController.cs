namespace LuxuryEstateProject.Web.Controllers
{
    using System.Diagnostics;

    using LuxuryEstateProject.Services.Data.Property;
    using LuxuryEstateProject.Web.ViewModels;
    using LuxuryEstateProject.Web.ViewModels.Property;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IPropertyService propertyService;

        public HomeController(IPropertyService propertyService)
        {
            this.propertyService = propertyService;
        }

        public IActionResult Index()
        {
            var state = this.propertyService.GetLatestProperties<RealEstateViewModel>();
            var model = new RealEstateListViewModel { PropertyViewModels = state };
            return this.View(model);
        }

        public IActionResult About()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
