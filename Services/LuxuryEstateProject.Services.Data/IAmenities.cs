namespace LuxuryEstateProject.Services.Data
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc.Rendering;

    public interface IAmenities
    {
        IEnumerable<SelectListItem> GetAllAsSelectListItems();
    }
}
