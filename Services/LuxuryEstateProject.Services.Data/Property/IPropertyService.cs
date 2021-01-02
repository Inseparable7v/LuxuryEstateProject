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

        IEnumerable<T> ListOfPropertiesByAgentId<T>(int id);

        IEnumerable<T> GetLatestProperties<T>();

        IEnumerable<T> GetAll<T>(int page, int itemsPerPage);

        IEnumerable<SelectListItem> GetAllAsSelectListItems();

        Task UpdateAsync(int id, EditPropertyinputModel input);
    }
}
