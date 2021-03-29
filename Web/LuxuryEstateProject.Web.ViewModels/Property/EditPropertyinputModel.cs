namespace LuxuryEstateProject.Web.ViewModels.Property
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using LuxuryEstateProject.Data.Models;
    using LuxuryEstateProject.Services.Mapping;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class EditPropertyinputModel : IMapFrom<RealEstateProperty>
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        [MinLength(0)]
        [DisplayName("Property Name")]
        public string Name { get; set; }

        [Required]
        [Range(0, 10)]
        public int Garage { get; set; }

        [Required]
        [Range(0, 10)]
        public int Bed { get; set; }

        [Required]
        [Range(0, 15)]
        public int Bath { get; set; }

        [Required]
        [MaxLength(200)]
        [MinLength(15)]
        public string Description { get; set; }

        [DisplayName("Property Price")]
        [Range(0, 10000000)]
        public decimal Price { get; set; }

        [Range(0, 150)]
        public int Floor { get; set; }

        [Range(0, 10000)]
        public float Size { get; set; }

        public int Year { get; set; }

        public int AgentId { get; set; }

        public IEnumerable<SelectListItem> AgentsCreateForm { get; set; }
    }
}
