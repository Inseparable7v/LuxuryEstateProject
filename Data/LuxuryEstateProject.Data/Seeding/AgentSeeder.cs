namespace LuxuryEstateProject.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using LuxuryEstateProject.Data.Models;

    public class AgentSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Agents.Any())
            {
                return;
            }

            await dbContext.Agents.AddRangeAsync(new List<Agent>()
            {
                new Agent()
                {
                    Name = "Merlin",
                    LastName = "Pachotti",
                    Email = "Merlin123@gmail.com",
                    Phone = "089542389",
                    Description = "Funny",
                    Images = new List<Image>()
                    {
                        new Image()
                        {
                            RemoteImageUrl = "https://images.unsplash.com/photo-1556157382-97eda2d62296?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=1350&q=80",
                        },
                    },
                },
                new Agent()
                {
                    Name = "Jessy",
                    LastName = "Hitler",
                    Email = "Jessy5323@abv.bg",
                    Phone = "095837543",
                    Description = "Crazy",
                    Images = new List<Image>()
                    {
                        new Image()
                        {
                            RemoteImageUrl = "https://images.unsplash.com/photo-1555421689-d68471e189f2?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=1350&q=80",
                        },
                    },
                },
            });
        }
    }
}
