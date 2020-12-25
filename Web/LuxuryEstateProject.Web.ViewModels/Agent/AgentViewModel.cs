using LuxuryEstateProject.Web.ViewModels.Property;

namespace LuxuryEstateProject.Web.ViewModels.Agent
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using LuxuryEstateProject.Data.Models;
    using LuxuryEstateProject.Services.Mapping;

    public class AgentViewModel : IMapFrom<Agent>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Description { get; set; }

        public string ImageRemoteImageUrl { get; set; }

        public IEnumerable<RealEstateViewModel> RealEstateViewModels { get; set; }

        /// <inheritdoc/>
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
