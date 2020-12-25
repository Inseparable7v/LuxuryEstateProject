namespace LuxuryEstateProject.Data.Models
{
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using LuxuryEstateProject.Data.Common.Models;

    public class RealEstateProperty : BaseDeletableModel<int>
    {
        public RealEstateProperty()
        {
            this.Images = new HashSet<Image>();
            this.RealEstateAmenities = new HashSet<RealEstateAmenity>();
        }

        [Required]
        public string Name { get; set; }

        public float Size { get; set; }

        public int Bath { get; set; }

        public int Garage { get; set; }

        public int Bed { get; set; }

        public int? Floor { get; set; }

        public int? TotalNumberOfFloors { get; set; }

        public int? Year { get; set; }

        [Required]
        public string Description { get; set; }

        public PropertyType Type { get; set; }

        public decimal Price { get; set; }

        public int CountryId { get; set; }

        public virtual Country Countries { get; set; }

        public Material BuildingType { get; set; }

        public int AgentId { get; set; }

        public virtual Agent Agent { get; set; }

        public virtual ICollection<RealEstateAmenity> RealEstateAmenities { get; set; }

        public virtual ICollection<Image> Images { get; set; }
    }
}
