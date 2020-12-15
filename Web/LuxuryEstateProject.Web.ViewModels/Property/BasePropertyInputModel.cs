namespace LuxuryEstateProject.Web.ViewModels.Property
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class BasePropertyInputModel
    {
        public string Name { get; set; }

        public int Bath { get; set; }

        public int Garage { get; set; }

        public int Bed { get; set; }

        public int? Floor { get; set; }

        public int? TotalNumberOfFloors { get; set; }

        public int? Year { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public float Size { get; set; }
        //public string BuildingType { get; set; }

        public int CountryId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Countries { get; set; }

        public int AgentId { get; set; }

        public IEnumerable<KeyValuePair<string,string>> AgentsCreateForm { get; set; }

        public int BuildingTypeId { get; set; }

        public IEnumerable<KeyValuePair<string,string>> BuildingTypes { get; set; }

    }
}
