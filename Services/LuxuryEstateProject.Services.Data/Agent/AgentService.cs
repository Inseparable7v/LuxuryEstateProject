using Microsoft.AspNetCore.Mvc.Rendering;

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
        public IEnumerable<T> GetAllAgents<T>(int page, int itemsPerPage = 6)
        {
            var agents = this.agentRepository.AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .To<T>().ToList();
            return agents;
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

        public int GetCount()
        {
            return this.agentRepository.AllAsNoTracking().Count();
        }

        /// <inheritdoc/>
        public async Task<T> GetByIdAsync<T>(int id)
        {
            return await this.agentRepository.AllAsNoTracking().Where(x => x.Id.Equals(id)).To<T>().FirstOrDefaultAsync();
        }

        public IEnumerable<SelectListItem> GetAllAsSelectListItems()
        {

            return this.agentRepository.All().Select(x => new SelectListItem { Text = x.Name + " " + x.LastName, Value = x.Id.ToString() }).OrderBy(c => c.Text);
        }
    }
}
