namespace LuxuryEstateProject.Web.ViewModels.Property
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using LuxuryEstateProject.Data.Models;
    using Microsoft.AspNetCore.Mvc.Rendering;

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
        [MaxLength(2000)]
        [MinLength(15)]
        public string Description { get; set; }

        [DisplayName("Property Price")]
        [Range(0, 10000000)]
        public decimal Price { get; set; }

        [Range(0, 10000)]
        public float Size { get; set; }

        [Range(0, 2)]
        [DisplayName("For")]
        public PropertyType Type { get; set; }

        [Range(0, 7)]
        public Material Material { get; set; }

        [DisplayName("Country")]
        public int CountryId { get; set; }

        public IEnumerable<SelectListItem> Countries { get; set; }

        [DisplayName("City")]
        public int CityId { get; set; }

        public IEnumerable<SelectListItem> Cities { get; set; }

        [DisplayName("District")]
        public int DistrictId { get; set; }

        public IEnumerable<SelectListItem> Districts { get; set; }

        [DisplayName("Agent")]
        public int AgentId { get; set; }

        public IEnumerable<SelectListItem> AgentsCreateForm { get; set; }

        public List<string> Amenity { get; set; }

        public IEnumerable<SelectListItem> Amenities { get; set; }
    }
}
