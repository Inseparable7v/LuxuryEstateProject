namespace LuxuryEstateProject.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using LuxuryEstateProject.Data.Common.Repositories;
    using LuxuryEstateProject.Data.Models;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class CityService : ICity
    {
        private IDeletableEntityRepository<City> cityRepository;

        public CityService(IDeletableEntityRepository<City> cityRepository)
        {
            this.cityRepository = cityRepository;
        }

        public IEnumerable<SelectListItem> GetAllAsSelectListItems()
        {
            return this.cityRepository.AllAsNoTracking().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).OrderBy(c => c.Text);
        }

        public IEnumerable<SelectListItem> GetCities(int id)
        {
            if (!String.IsNullOrWhiteSpace(id.ToString()))
            {
                List<SelectListItem> cities = this.cityRepository.AllAsNoTracking()
                    .OrderBy(n => n.Name)
                    .Where(n => n.Country.Id == id)
                    .Select(n =>
                        new SelectListItem
                        {
                            Value = n.Id.ToString(),
                            Text = n.Name,
                        }).ToList();

                var cityFirstItem = new SelectListItem()
                {
                    Value = null,
                    Text = "--- select city ---",
                };
                cities.Insert(0, cityFirstItem);
                return new SelectList(cities, "Value", "Text");
            }

            return null;
        }
    }
}
