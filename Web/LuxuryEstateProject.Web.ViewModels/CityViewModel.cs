namespace LuxuryEstateProject.Web.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using LuxuryEstateProject.Data.Models;
    using LuxuryEstateProject.Services.Mapping;

    public class CityViewModel : IMapFrom<City>
    {
        public string Name { get; set; }

        public string DistrictsName { get; set; }
    }
}
