using System.ComponentModel;
using LuxuryEstateProject.Data.Models;

namespace LuxuryEstateProject.Web.ViewModels.Property
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public abstract class BasePropertyInputModel
    {
        [Required]
        [MaxLength(25)]
        [MinLength(0)]
        [DisplayName("Property Name")]
        public string Name { get; set; }

        [Required]
        [Range(0, 15)]
        public int Bath { get; set; }

        [Required]
        [Range(0, 10)]
        public int Garage { get; set; }

        [Required]
        [Range(0, 10)]
        public int Bed { get; set; }

        [Range(0, 150)]
        public int Floor { get; set; }

        [Range(0, 150)]
        [DisplayName("TotalFloors")]
        public int TotalNumberOfFloors { get; set; }

        public int Year { get; set; }

        [Required]
        [MaxLength(200)]
        [MinLength(15)]
        public string Description { get; set; }

        [DisplayName("Property Price")]
        public decimal Price { get; set; }

        [Range(0, 10000)]
        public float Size { get; set; }

        [Range(0, 2)]
        public PropertyType Type { get; set; }

        [DisplayName("Country")]
        public int CountryId { get; set; }

        public IEnumerable<SelectListItem> Countries { get; set; }

        [DisplayName("Agent")]
        public int AgentId { get; set; }

        public IEnumerable<SelectListItem> AgentsCreateForm { get; set; }

        [DisplayName("Building Material")]
        public int BuildingTypeId { get; set; }

        public IEnumerable<SelectListItem> BuildingTypes { get; set; }

    }
}
