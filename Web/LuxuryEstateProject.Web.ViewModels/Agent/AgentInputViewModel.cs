﻿namespace LuxuryEstateProject.Web.ViewModels.Agent
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Http;

    public class AgentInputViewModel : BaseAgentInputModel
    {
        public IFormFile Images { get; set; }
    }
}
