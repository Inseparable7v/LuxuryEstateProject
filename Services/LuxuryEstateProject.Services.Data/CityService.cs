namespace LuxuryEstateProject.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

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
                IEnumerable<SelectListItem> regions = this.cityRepository.AllAsNoTracking()
                    .OrderBy(n => n.Name)
                    .Where(n => n.Country.Id == id)
                    .Select(n =>
                        new SelectListItem
                        {
                            Value = n.Id.ToString(),
                            Text = n.Name,
                        }).ToList();
                return new SelectList(regions, "Value", "Text");
            }
            return null;
        }
    }
}
