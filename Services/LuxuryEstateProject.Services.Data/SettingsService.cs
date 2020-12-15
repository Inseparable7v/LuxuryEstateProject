namespace LuxuryEstateProject.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using LuxuryEstateProject.Data.Common.Repositories;
    using LuxuryEstateProject.Data.Models;
    using LuxuryEstateProject.Services.Mapping;

    public class SettingsService : ISettingsService
    {
        private readonly IDeletableEntityRepository<Setting> settingsRepository;

        public SettingsService(IDeletableEntityRepository<Setting> settingsRepository)
        {
            this.settingsRepository = settingsRepository;
        }

        /// <inheritdoc/>
        public int GetCount()
        {
            return this.settingsRepository.AllAsNoTracking().Count();
        }

        /// <inheritdoc/>
        public IEnumerable<T> GetAll<T>()
        {
            return this.settingsRepository.All().To<T>().ToList();
        }
    }
}
