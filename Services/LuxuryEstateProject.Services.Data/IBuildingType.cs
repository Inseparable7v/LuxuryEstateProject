using Microsoft.AspNetCore.Mvc.Rendering;

namespace LuxuryEstateProject.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IBuildingType
    {
        IEnumerable<SelectListItem> GetAllAsSelectListItems();
    }
}
