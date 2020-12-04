namespace LuxuryEstateProject.Web.ViewModels.Property
{
    using System.Collections.Generic;

    using LuxuryEstateProject.Web.ViewModels.Agent;

    public class RealEstateListViewModel : PagingViewModel
    {
        public IEnumerable<RealEstateViewModel> PropertyViewModels { get; set; }

        public IEnumerable<AgentViewModel> Agents { get; set; }
    }
}
