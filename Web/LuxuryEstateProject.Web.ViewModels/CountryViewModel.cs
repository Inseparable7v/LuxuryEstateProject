namespace LuxuryEstateProject.Web.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using LuxuryEstateProject.Data.Models;
    using LuxuryEstateProject.Services.Mapping;

    public class CountryViewModel : IMapFrom<Country>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CityName { get; set; }

        public string CityDistrictName { get; set; }
    }
}
