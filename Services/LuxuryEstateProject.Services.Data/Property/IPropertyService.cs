namespace LuxuryEstateProject.Services.Data.Property
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using LuxuryEstateProject.Web.ViewModels.Property;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public interface IPropertyService
    {
        Task CreatePropertyAsync(PropertyInputModel input, string imagePath);

        Task<T> GetByIdAsync<T>(int id);

        int GetCount();

        IEnumerable<T> ListOfPropertiesByAgentIdAsync<T>(int id);

        IEnumerable<T> GetLatestProperties<T>();

        IEnumerable<T> GetAll<T>(int page, int itemsPerPage);

        Task UpdateAsync(int id, EditPropertyinputModel input);

        Task DeleteAsync(int id);

        IEnumerable<T> GetAllSortedAlpha<T>(int page, int itemsPerPage);
    }
}
