namespace LuxuryEstateProject.Web.ViewModels.Property
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using LuxuryEstateProject.Data.Models;
    using LuxuryEstateProject.Services.Mapping;

    public class AmenitiesViewModel : IMapFrom<Amenities>
    {
        public string Name { get; set; }
    }
}
