namespace LuxuryEstateProject.Web.ViewModels.Agent
{
    using System.Collections.Generic;

    using LuxuryEstateProject.Web.ViewModels.Property;

    public class AgentsListViewModel : PagingViewModel
    {
        public IEnumerable<AgentViewModel> Agents { get; set; }

        public IEnumerable<RealEstateViewModel> EstateViewModels { get; set; }
    }
}
