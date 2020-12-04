namespace LuxuryEstateProject.Services.Data.Agent
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IAgentService
    {
        IEnumerable<T> GetAllAgents<T>();

        IEnumerable<T> GetHomePageAgents<T>();

        T SingleAgent<T>();

        Task<T> GetByIdAsync<T>(int id);
    }
}
