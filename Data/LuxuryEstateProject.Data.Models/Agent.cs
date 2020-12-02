namespace LuxuryEstateProject.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using LuxuryEstateProject.Data.Common.Models;

    public class Agent : BaseDeletableModel<int>
    {
        public Agent()
        {
            this.RealEstateProperties = new HashSet<RealEstateProperty>();
            this.Images = new HashSet<Image>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual ICollection<RealEstateProperty> RealEstateProperties { get; set; }

        public virtual IEnumerable<Image> Images { get; set; }
    }
}
