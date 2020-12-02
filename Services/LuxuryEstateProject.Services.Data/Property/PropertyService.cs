namespace LuxuryEstateProject.Services.Data.Property
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using LuxuryEstateProject.Data.Common.Repositories;
    using LuxuryEstateProject.Data.Models;
    using LuxuryEstateProject.Services.Mapping;
    using LuxuryEstateProject.Web.ViewModels.Property;
    using Microsoft.EntityFrameworkCore;

    public class PropertyService : IPropertyService
    {
        private readonly IDeletableEntityRepository<RealEstateProperty> realRepository;

        public PropertyService(IDeletableEntityRepository<RealEstateProperty> realRepository)
        {
            this.realRepository = realRepository;
        }

        public void AddProperty()
        {
            throw new NotImplementedException();
        }

        public int GetCount()
        {
            return this.realRepository.AllAsNoTracking().Count();
        }

        public IEnumerable<T> GetLatestProperties<T>()
        {
            var latestProperties = this.realRepository.AllAsNoTracking().Take(5).OrderByDescending(x => x.Id).To<T>().ToList();

            return latestProperties;
        }

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 6)
        {
            var recipes = this.realRepository.AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .To<T>().ToList();
            return recipes;
        }

        public async Task<T> GetByIdAsync<T>(int id)
        {
            return await this.realRepository.AllAsNoTracking().Where(x => x.Id.Equals(id)).To<T>().FirstOrDefaultAsync();
        }
    }
}
