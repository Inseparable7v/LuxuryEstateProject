namespace LuxuryEstateProject.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using LuxuryEstateProject.Data.Common.Repositories;
    using LuxuryEstateProject.Data.Models;

    public class BuildingTypeService : IBuildingType
    {
        private IDeletableEntityRepository<RealEstateProperty> realestateRepository;

        public BuildingTypeService(IDeletableEntityRepository<RealEstateProperty> realestateRepository)
        {
            this.realestateRepository = realestateRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return this.realestateRepository.AllAsNoTracking()
                .Select(x => new
                {
                    x.BuildingTypeId,
                    x.BuildingType.Name,
                })
                .OrderBy(x => x.Name)
                .ToList().Select(x => new KeyValuePair<string, string>(x.BuildingTypeId.ToString(), x.Name));
        }
    }
}
