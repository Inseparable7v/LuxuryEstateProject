namespace LuxuryEstateProject.Web.ViewModels
{

    using LuxuryEstateProject.Data.Models;
    using LuxuryEstateProject.Services.Mapping;

    public class CityViewModel : IMapFrom<City>
    {
        public string Name { get; set; }

        public string DistrictsName { get; set; }
    }
}
