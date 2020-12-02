namespace LuxuryEstateProject.Web.ViewModels.Property
{
    using LuxuryEstateProject.Data.Models;
    using LuxuryEstateProject.Services.Mapping;

    public class DistrictViewModel : IMapFrom<District>
    {
        public string Name { get; set; }

        public CountryViewModel Country { get; set; }
    }
}
