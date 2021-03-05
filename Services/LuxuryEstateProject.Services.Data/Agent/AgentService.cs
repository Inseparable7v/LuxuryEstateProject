namespace LuxuryEstateProject.Services.Data.Agent
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using LuxuryEstateProject.Data.Common.Repositories;
    using LuxuryEstateProject.Data.Models;
    using LuxuryEstateProject.Services.Mapping;
    using LuxuryEstateProject.Web.ViewModels.Agent;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using SixLabors.ImageSharp;
    using SixLabors.ImageSharp.Formats.Png;
    using SixLabors.ImageSharp.Processing;

    public class AgentService : IAgentService
    {
        private readonly string[] allowedExtensions = new[] { "jpg", "png", "jpeg" };

        private readonly IDeletableEntityRepository<Agent> agentRepository;
        private readonly IDeletableEntityRepository<RealEstateProperty> propertyRepository;

        public AgentService(IDeletableEntityRepository<Agent> agentRepository, IDeletableEntityRepository<RealEstateProperty> propertyRepository)
        {
            this.agentRepository = agentRepository;
            this.propertyRepository = propertyRepository;
        }

        /// <inheritdoc/>
        public IEnumerable<T> GetAllAgents<T>(int page, int itemsPerPage = 6)
        {
            var agents = this.agentRepository.All()
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .To<T>().ToList();
            return agents;
        }

        public IEnumerable<T> GetAllAgentsAdminPanel<T>()
        {
            var agents = this.agentRepository.All()
                .OrderByDescending(x => x.Id)
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
            var agent = new Agent
            {
                Name = input.Name,
                Description = input.Description,
                Email = input.Email,
                LastName = input.LastName,
                Phone = input.Phone,
            };

            Directory.CreateDirectory($"{imagePath}");

            var image = input.Images;

            var extension = Path.GetExtension(image.FileName).TrimStart('.');
            if (!this.allowedExtensions.Any(x => extension.EndsWith(x)))
            {
                throw new Exception($"Invalid image extension {extension}");
            }

            var dbImage = new LuxuryEstateProject.Data.Models.Image
            {
                Extension = extension,
            };

            using var imageSharp = SixLabors.ImageSharp.Image.Load(image.OpenReadStream());

            imageSharp.Mutate(
            x => x.Resize(
                new ResizeOptions
                {
                    Mode = ResizeMode.Min,
                    Size = new Size(800, 740),
                    Position = AnchorPositionMode.Center,
                }));

            agent.Images.Add(dbImage);

            var physicalPath = $"{imagePath}{dbImage.Id}.{extension}";
            await using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
            await imageSharp.SaveAsync(fileStream, new PngEncoder());

            await this.agentRepository.AddAsync(agent);

            await this.agentRepository.SaveChangesAsync();
        }

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

        public async Task UpdateAsync(int id, EditAgentInputModel input)
        {
            var model = this.agentRepository.All().FirstOrDefault(x => x.Id.Equals(id));

            model.Name = input.Name;
            model.LastName = input.LastName;
            model.Phone = input.Phone;
            model.Description = input.Description;
            model.Email = input.Email;

            await this.agentRepository.SaveChangesAsync();
        }

        public async Task DeleteAgentAsync(int id)
        {
            var agent = await this.agentRepository.All().FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (!agent.RealEstateProperties.Any())
            {
            }
            else
            {
                var properties = await this.propertyRepository.All().Where(x => x.AgentId.Equals(agent.Id)).ToListAsync();

                foreach (var property in properties)
                {
                    this.propertyRepository.Delete(property);
                }
            }

            this.agentRepository.Delete(agent);
            await this.agentRepository.SaveChangesAsync();
        }
    }
}
