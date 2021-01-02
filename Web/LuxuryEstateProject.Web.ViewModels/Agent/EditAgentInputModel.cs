namespace LuxuryEstateProject.Web.ViewModels.Agent
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using LuxuryEstateProject.Data.Models;
    using LuxuryEstateProject.Services.Mapping;

    public class EditAgentInputModel : BaseAgentInputModel, IMapFrom<Agent>
    {
        public int Id { get; set; }
    }
}
