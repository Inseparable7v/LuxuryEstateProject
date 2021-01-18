namespace LuxuryEstateProject.Services.Data
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc.Rendering;

    public interface IDistrict
    {
        IEnumerable<SelectListItem> GetAllAsSelectListItems();

        IEnumerable<SelectListItem> GetDistricts(int id);
    }
}
