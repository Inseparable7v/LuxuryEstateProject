namespace LuxuryEstateProject.Web.ViewModels.Property
{
    using System.Collections.Generic;

    using LuxuryEstateProject.Web.ViewModels.Agent;
    using Microsoft.AspNetCore.Http;

    public class PropertyInputModel : BasePropertyInputModel
    {
        public IEnumerable<IFormFile> Images { get; set; }

        public IEnumerable<AgentViewModel> Agents { get; set; }
    }
}
