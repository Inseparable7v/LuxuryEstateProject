namespace LuxuryEstateProject.Services.Data.Property
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using LuxuryEstateProject.Data.Models;
    using LuxuryEstateProject.Web.ViewModels.Property;

    public interface IPropertyService
    {
        void AddProperty();

        Task<T> GetByIdAsync<T>(int id);

        int GetCount();

        IEnumerable<T> GetLatestProperties<T>();

        IEnumerable<T> GetAll<T>(int page, int itemsPerPage);
    }
}
