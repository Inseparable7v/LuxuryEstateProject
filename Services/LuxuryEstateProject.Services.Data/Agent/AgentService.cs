namespace LuxuryEstateProject.Services.Data.Agent
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using LuxuryEstateProject.Data.Common.Repositories;
    using LuxuryEstateProject.Data.Models;
    using LuxuryEstateProject.Services.Mapping;
    using LuxuryEstateProject.Web.ViewModels.Agent;
    using Microsoft.EntityFrameworkCore;

    public class AgentService : IAgentService
    {
        private readonly IDeletableEntityRepository<Agent> agentRepository;

        public AgentService(IDeletableEntityRepository<Agent> agentRepository)
        {
            this.agentRepository = agentRepository;
        }

        /// <inheritdoc/>
        public IEnumerable<T> GetAllAgents<T>()
        {
            return this.agentRepository.AllAsNoTracking().To<T>().ToList();
        }

        /// <inheritdoc/>
        public IEnumerable<T> GetHomePageAgents<T>()
        {
            return this.agentRepository.AllAsNoTracking().Take(3).OrderByDescending(x => x.Id).To<T>().ToList();
        }

        /// <inheritdoc/>
        public T SingleAgent<T>()
        {
            return this.agentRepository.AllAsNoTracking().OrderBy(x => x.Id).To<T>().FirstOrDefault();
        }

        /// <inheritdoc/>
        public async Task<T> GetByIdAsync<T>(int id)
        {
            return await this.agentRepository.AllAsNoTracking().Where(x => x.Id.Equals(id)).To<T>().FirstOrDefaultAsync();
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return this.agentRepository.AllAsNoTracking()
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.LastName,
                })
                .OrderBy(x => x.Name)
                .ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }
    }
}
