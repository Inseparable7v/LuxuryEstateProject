namespace LuxuryEstateProject.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using LuxuryEstateProject.Data.Common.Repositories;
    using LuxuryEstateProject.Data.Models;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class CountryService : ICountryService
    {
        private IDeletableEntityRepository<Country> countryRepository;

        public CountryService(IDeletableEntityRepository<Country> countryRepository)
        {
            this.countryRepository = countryRepository;
        }

        public IEnumerable<SelectListItem> GetAllAsSelectListItems()
        {
            return this.countryRepository.AllAsNoTracking().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).OrderBy(c => c.Text);
        }

        public IEnumerable<SelectListItem> GetCountries()
        {
            List<SelectListItem> countries = this.countryRepository.AllAsNoTracking()
                .OrderBy(n => n.Name)
                .Select(n =>
                    new SelectListItem
                    {
                        Value = n.Id.ToString(),
                        Text = n.Name,
                    }).ToList();
            var countrytip = new SelectListItem()
            {
                Value = null,
                Text = "--- select country ---",
            };
            countries.Insert(0, countrytip);
            return new SelectList(countries, "Value", "Text");
        }
    }
}
