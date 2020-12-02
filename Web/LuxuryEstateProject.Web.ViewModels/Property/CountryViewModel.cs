namespace LuxuryEstateProject.Web.ViewModels.Property
{
    using LuxuryEstateProject.Data.Models;
    using LuxuryEstateProject.Services.Mapping;

    public class CountryViewModel : IMapFrom<Country>
    {
        public string Name { get; set; }

        public string CitiesName { get; set; }
    }
}
