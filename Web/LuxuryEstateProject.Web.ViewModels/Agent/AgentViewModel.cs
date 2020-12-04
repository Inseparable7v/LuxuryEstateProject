namespace LuxuryEstateProject.Web.ViewModels.Agent
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;

    using AutoMapper;
    using LuxuryEstateProject.Data.Models;
    using LuxuryEstateProject.Services.Mapping;
    using LuxuryEstateProject.Web.ViewModels.Image;

    public class AgentViewModel : IMapFrom<Agent>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Description { get; set; }

        public string ImageRemoteImageUrl { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Agent, AgentViewModel>()
                .ForMember(x => x.ImageRemoteImageUrl, opt =>
                    opt.MapFrom(x =>
                        x.Images.FirstOrDefault().RemoteImageUrl != null ?
                            x.Images.FirstOrDefault().RemoteImageUrl :
                            "/assets/img/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension));
        }
    }
}
