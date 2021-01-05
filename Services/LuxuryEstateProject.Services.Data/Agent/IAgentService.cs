namespace LuxuryEstateProject.Services.Data.Agent
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using LuxuryEstateProject.Web.ViewModels.Agent;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public interface IAgentService
    {
        IEnumerable<T> GetAllAgents<T>(int page, int itemsPerPage);

        IEnumerable<T> GetHomePageAgents<T>();

        IEnumerable<SelectListItem> GetAllAsSelectListItems();

        Task CreateAgentAsync(AgentInputViewModel input, string imagePath);

        T SingleAgent<T>();

        int GetCount();

        Task<T> GetByIdAsync<T>(int id);

        Task UpdateAsync(int id, EditAgentInputModel input);

        Task DeleteAgentAsync(int id);
    }
}
