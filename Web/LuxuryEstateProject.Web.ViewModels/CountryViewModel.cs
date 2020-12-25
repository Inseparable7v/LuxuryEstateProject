namespace LuxuryEstateProject.Web.ViewModels
{

    using LuxuryEstateProject.Data.Models;
    using LuxuryEstateProject.Services.Mapping;

    public class CountryViewModel : IMapFrom<Country>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CityName { get; set; }

        public string CityDistrictName { get; set; }
    }
}
