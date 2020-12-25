namespace LuxuryEstateProject.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Microsoft.AspNetCore.Mvc.Rendering;

    public interface IAmenities
    {
        IEnumerable<SelectListItem> GetAllAsSelectListItems();
    }
}
