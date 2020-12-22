namespace LuxuryEstateProject.Services.Data.Agent
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

    public interface IAgentService
    {
        IEnumerable<T> GetAllAgents<T>(int page, int itemsPerPage);

        IEnumerable<T> GetHomePageAgents<T>();

        IEnumerable<SelectListItem> GetAllAsSelectListItems();

        T SingleAgent<T>();

        int GetCount();

        Task<T> GetByIdAsync<T>(int id);
    }
}
