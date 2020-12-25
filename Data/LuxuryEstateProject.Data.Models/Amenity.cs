namespace LuxuryEstateProject.Data.Models
{
    using System.Collections.Generic;

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
