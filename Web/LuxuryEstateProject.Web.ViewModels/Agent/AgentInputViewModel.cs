namespace LuxuryEstateProject.Web.ViewModels.Agent
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using LuxuryEstateProject.Web.ViewModels.Property;
    using Microsoft.AspNetCore.Http;

    public class AgentInputViewModel : BaseAgentInputModel
    {
        public IEnumerable<IFormFile> Images { get; set; }
    }
}
