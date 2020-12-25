namespace LuxuryEstateProject.Web.ViewModels.Property
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using LuxuryEstateProject.Data.Models;
    using LuxuryEstateProject.Services.Mapping;

    public class AmenitiesViewModel : IMapFrom<RealEstateAmenity>
    {
        public string AmenityName { get; set; }
    }
}
