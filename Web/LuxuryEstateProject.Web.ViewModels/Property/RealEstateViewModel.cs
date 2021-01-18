﻿namespace LuxuryEstateProject.Web.ViewModels.Property
{
    using System.Linq;

    using AutoMapper;
    using LuxuryEstateProject.Data.Models;
    using LuxuryEstateProject.Services.Mapping;

    public class RealEstateViewModel : IMapFrom<RealEstateProperty>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Garage { get; set; }

        public string Bed { get; set; }

        public string ImageRemoteImageUrl { get; set; }

        public string Bath { get; set; }

        public string Type { get; set; }

        public string DistrictName { get; set; }

        public decimal Price { get; set; }

        public int Floor { get; set; }

        public float Size { get; set; }

        public string Year { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<RealEstateProperty, RealEstateViewModel>()
                .ForMember(x => x.ImageRemoteImageUrl, opt =>
                    opt.MapFrom(x =>
                        x.Images.FirstOrDefault().RemoteImageUrl != null ?
                            x.Images.FirstOrDefault().RemoteImageUrl :
                            "/assets/img/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension));
        }
    }
}
