namespace LuxuryEstateProject.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using LuxuryEstateProject.Data.Common.Models;

    public class District : BaseDeletableModel<int>
    {
        [Required]
        public string Name { get; set; }
    }
}
