using System.Linq;
using System.Runtime.CompilerServices;
using AutoMapper;
using LuxuryEstateProject.Web.ViewModels.Property;

namespace LuxuryEstateProject.Web.ViewModels.Agent
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using LuxuryEstateProject.Services.Mapping;

    public class SingleAgentViewModel : IMapFrom<Data.Models.Agent>,  IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string FullName => this.Name + " " + this.LastName;

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Description { get; set; }

        public string ImageRemoteImageUrl { get; set; }

        public IEnumerable<RealEstateViewModel> RealEstateProperties { get; set; }

        /// <inheritdoc/>
        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Data.Models.Agent, SingleAgentViewModel>()
                .ForMember(x => x.ImageRemoteImageUrl, opt =>
                    opt.MapFrom(x =>
                        x.Images.FirstOrDefault().RemoteImageUrl != null ?
                            x.Images.FirstOrDefault().RemoteImageUrl :
                            "/assets/img/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension));
        }
    }
}
