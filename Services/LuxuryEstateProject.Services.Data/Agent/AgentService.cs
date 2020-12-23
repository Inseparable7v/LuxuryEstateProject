﻿namespace LuxuryEstateProject.Services.Data.Agent
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using LuxuryEstateProject.Data.Common.Repositories;
    using LuxuryEstateProject.Data.Models;
    using LuxuryEstateProject.Services.Mapping;
    using LuxuryEstateProject.Web.ViewModels.Agent;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using SixLabors.ImageSharp.Formats.Png;
    using SixLabors.ImageSharp.Processing;

    public class AgentService : IAgentService
    {

        private readonly string[] allowedExtensions = new[] { "jpg", "png", "jpeg" };

        private readonly IDeletableEntityRepository<Agent> agentRepository;
        private IDeletableEntityRepository<RealEstateProperty> propertyRepository;

        public AgentService(IDeletableEntityRepository<Agent> agentRepository, IDeletableEntityRepository<RealEstateProperty> propertyRepository)
        {
            this.agentRepository = agentRepository;
            this.propertyRepository = propertyRepository;
        }

        /// <inheritdoc/>
        public IEnumerable<T> GetAllAgents<T>(int page, int itemsPerPage = 6)
        {
            var agents = this.agentRepository.AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .To<T>().ToList();
            return agents;
        }

        /// <inheritdoc/>
        public IEnumerable<T> GetHomePageAgents<T>()
        {
            return this.agentRepository.AllAsNoTracking().Take(3).OrderByDescending(x => x.Id).To<T>().ToList();
        }

        public async Task CreateAgentAsync(AgentInputViewModel input, string imagePath)
        {
            var prop = this.propertyRepository.AllAsNoTracking().Where(x => x.Id.Equals(input.PropertyId)).ToList();

            var agent = new Agent
            {
                Name = input.Name,
                Description = input.Description,
                Email = input.Email,
                LastName = input.LastName,
                Phone = input.Phone,
                RealEstateProperties = new List<RealEstateProperty>(),
            };

            foreach (var property in agent.RealEstateProperties)
            {
                property.AgentId = agent.Id;
            }

            Directory.CreateDirectory($"{imagePath}");
            foreach (var image in input.Images)
            {
                var extension = Path.GetExtension(image.FileName).TrimStart('.');
                if (!this.allowedExtensions.Any(x => extension.EndsWith(x)))
                {
                    throw new Exception($"Invalid image extension {extension}");
                }

                var dbImage = new Image
                {
                    Extension = extension,
                };

                using var imageSharp = SixLabors.ImageSharp.Image.Load(image.OpenReadStream());

                imageSharp.Mutate(x => x.Resize(600, 700));

                agent.Images.Add(dbImage);

                var physicalPath = $"{imagePath}{dbImage.Id}.{extension}";
                await using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
                await imageSharp.SaveAsync(fileStream, new PngEncoder());

                //await image.CopyToAsync(fileStream);
            }

            await this.agentRepository.AddAsync(agent);
            await this.agentRepository.SaveChangesAsync();

        }
        //var property = new RealEstateProperty
        //{
        //    Bath = input.Bath,
        //    Name = input.Name,
        //    Bed = input.Bed,
        //    CountryId = input.CountryId,
        //    Floor = input.Floor,
        //    TotalNumberOfFloors = input.TotalNumberOfFloors,
        //    Price = input.Price,
        //    Size = input.Size,
        //    Year = input.Year,
        //    AgentId = input.AgentId,
        //    BuildingType = (Material)input.Material,
        //    Description = input.Description,
        //    Garage = input.Garage,
        //    Type = (PropertyType)input.Type,
        //};
        /// <inheritdoc/>
        public T SingleAgent<T>()
        {
            return this.agentRepository.AllAsNoTracking().OrderBy(x => x.Id).To<T>().FirstOrDefault();
        }

        public int GetCount()
        {
            return this.agentRepository.AllAsNoTracking().Count();
        }

        /// <inheritdoc/>
        public async Task<T> GetByIdAsync<T>(int id)
        {
            return await this.agentRepository.AllAsNoTracking().Where(x => x.Id.Equals(id)).To<T>().FirstOrDefaultAsync();
        }

        public IEnumerable<SelectListItem> GetAllAsSelectListItems()
        {

            return this.agentRepository.All().Select(x => new SelectListItem { Text = x.Name + " " + x.LastName, Value = x.Id.ToString() }).OrderBy(c => c.Text);
        }
    }
}
