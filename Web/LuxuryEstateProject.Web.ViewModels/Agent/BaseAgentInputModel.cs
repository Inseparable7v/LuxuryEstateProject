namespace LuxuryEstateProject.Web.ViewModels.Agent
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Microsoft.AspNetCore.Mvc.Rendering;

    public abstract class BaseAgentInputModel
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public string FullName => this.Name + " " + this.LastName;

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Description { get; set; }

        public int PropertyId { get; set; }

        public IEnumerable<SelectListItem> Properties { get; set; }
    }
}
