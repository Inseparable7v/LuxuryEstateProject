namespace LuxuryEstateProject.Web.ViewModels.Property
{
    using LuxuryEstateProject.Data.Models;
    using LuxuryEstateProject.Services.Mapping;

    public class AmenitiesViewModel : IMapFrom<RealEstateAmenity>
    {
        public string AmenityName { get; set; }
    }
}
