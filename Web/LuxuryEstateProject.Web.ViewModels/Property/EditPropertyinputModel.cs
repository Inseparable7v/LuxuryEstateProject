namespace LuxuryEstateProject.Web.ViewModels.Property
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using LuxuryEstateProject.Data.Models;
    using LuxuryEstateProject.Services.Mapping;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class EditPropertyinputModel : IMapFrom<RealEstateProperty>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Garage { get; set; }

        public int Bed { get; set; }

        public int Bath { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Floor { get; set; }

        public float Size { get; set; }

        public int Year { get; set; }

        public int TotalNumbersOfFloors { get; set; }

        public int AgentId { get; set; }

        public IEnumerable<SelectListItem> AgentsCreateForm { get; set; }
    }
}
