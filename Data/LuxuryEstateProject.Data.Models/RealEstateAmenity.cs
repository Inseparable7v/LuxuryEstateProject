namespace LuxuryEstateProject.Data.Models
{
    public class RealEstateAmenity
    {
        public int Id { get; set; }

        public int AmenityId { get; set; }

        public virtual Amenity Amenity { get; set; }

        public int RealEstatePropertyId { get; set; }

        public virtual RealEstateProperty RealEstateProperty { get; set; }
    }
}
