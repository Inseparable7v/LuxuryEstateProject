using Microsoft.AspNetCore.Mvc.Rendering;

namespace LuxuryEstateProject.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using LuxuryEstateProject.Data.Common.Repositories;
    using LuxuryEstateProject.Data.Models;

    public class CountryService : ICountryService
    {
        private IDeletableEntityRepository<Country> countryRepository;

        public CountryService(IDeletableEntityRepository<Country> countryRepository)
        {
            this.countryRepository = countryRepository;
        }

        public IEnumerable<SelectListItem> GetAllAsSelectListItems()
        {
            return this.countryRepository.AllAsNoTracking().Select(x => new SelectListItem { Text = x.Name,Value = x.Id.ToString()}).OrderBy(c => c.Text);

            //return this.countryRepository.AllAsNoTracking()
            //    .Select(x => new
            //    {
            //        x.Id,
            //        x.Name,
            //    })
            //    .OrderBy(x => x.Name)
            //    .ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }
    }
}
