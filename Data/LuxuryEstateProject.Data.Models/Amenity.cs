namespace LuxuryEstateProject.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using LuxuryEstateProject.Data.Common.Models;

    public class Amenity : BaseDeletableModel<int>
    {
        public Amenity()
        {
            this.RealEstateAmenities = new HashSet<RealEstateAmenity>();
        }

        public string Name { get; set; }

        public ICollection<RealEstateAmenity> RealEstateAmenities { get; set; }
    }
}
