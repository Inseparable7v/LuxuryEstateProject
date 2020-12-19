using System.Linq;

namespace LuxuryEstateProject.Services.Data
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc.Rendering;

    public interface ICountryService
    {
        IEnumerable<SelectListItem> GetAllAsSelectListItems();
        IEnumerable<SelectListItem> GetCountries();
    }
}
