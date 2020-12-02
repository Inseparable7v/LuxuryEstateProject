namespace LuxuryEstateProject.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using LuxuryEstateProject.Data.Common.Models;

    public class BuildingType : BaseDeletableModel<int>
    {
        public BuildingType()
        {
            this.Properties = new HashSet<RealEstateProperty>();
        }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<RealEstateProperty> Properties { get; set; }
    }
}
