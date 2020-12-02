namespace LuxuryEstateProject.Web.ViewModels.Property
{
    using System.Collections.Generic;

    public class RealEstateListViewModel : PagingViewModel
    {
        public IEnumerable<RealEstateViewModel> PropertyViewModels { get; set; }
    }
}
