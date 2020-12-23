﻿using LuxuryEstateProject.Web.ViewModels.Property;
using Microsoft.AspNetCore.Hosting;

namespace LuxuryEstateProject.Web.Controllers.Agent
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using LuxuryEstateProject.Services.Data.Agent;
    using LuxuryEstateProject.Services.Data.Property;
    using LuxuryEstateProject.Web.ViewModels.Agent;
    using Microsoft.AspNetCore.Mvc;

    public class AgentController : BaseController
    {
        private IAgentService agentService;
        private IPropertyService propertyService;
        private IWebHostEnvironment environment;

        public AgentController(IAgentService agentService, IPropertyService propertyService, IWebHostEnvironment environment)
        {
            this.agentService = agentService;
            this.propertyService = propertyService;
            this.environment = environment;
        }

        public IActionResult Create()
        {
            var viewModel = new AgentInputViewModel()
            {
                Properties = this.propertyService.GetAllAsSelectListItems(),
            };
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AgentInputViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.Properties = this.propertyService.GetAllAsSelectListItems();
                return this.View(input);
            }

            try
            {
                await this.agentService.CreateAgentAsync(input, $"{this.environment.WebRootPath}/assets/img/");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                input.Properties = this.propertyService.GetAllAsSelectListItems();

                return this.View(input);
            }

            this.TempData["Message"] = "Agent added successfully.";

            return this.RedirectToAction("All");
        }

        public IActionResult All(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int ItemPerPage = 6;

            var state = this.agentService.GetAllAgents<AgentViewModel>(id, ItemPerPage).ToList();
            var model = new AgentsListViewModel
            {
                ItemsPerPage = ItemPerPage,
                PageNumber = id,
                PropertiesCount = this.agentService.GetCount(),
                Agents = state,
            };

            return this.View(model);
        }

        public async Task<IActionResult> SingleAgent(int id)
        {
            var property = this.propertyService.ListOfPropertiesByAgentId<RealEstateViewModel>(id);

            var agent = await this.agentService.GetByIdAsync<SingleAgentViewModel>(id);

            var model = new SingleAgentViewModel
            {
                Name = agent.Name,
                RealEstateProperties = property,
                Description = agent.Description,
                Email = agent.Email,
                LastName = agent.LastName,
                Phone = agent.Phone,
                ImageRemoteImageUrl = agent.ImageRemoteImageUrl,
            };

            if (agent == null)
            {
                return this.NotFound();
            }

            return this.View(model);
        }
    }
}
