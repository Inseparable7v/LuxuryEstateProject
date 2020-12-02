namespace LuxuryEstateProject.Web.ViewModels.Property
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;

    using AutoMapper;
    using LuxuryEstateProject.Data.Models;
    using LuxuryEstateProject.Services.Mapping;
    using LuxuryEstateProject.Web.ViewModels.Agent;

    public class SinglePropertyViewModel : IMapFrom<RealEstateProperty>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public float Size { get; set; }

        public decimal Price { get; set; }

        public int Bath { get; set; }

        public int Garage { get; set; }

        public int Bed { get; set; }

        public int Floor { get; set; }

        public int Year { get; set; }

        public string Type { get; set; }

        public string ImageRemoteImageUrl { get; set; }

        public AgentViewModel Agent { get; set; }

        public string CountriesName { get; set; }

        public string CityName { get; set; }

        public string DistrictName { get; set; }

        public ICollection<AmenitiesViewModel> Amenities { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<RealEstateProperty, SinglePropertyViewModel>()
                .ForMember(
                    x => x.CityName,
                    opt => opt.MapFrom(x => x.Countries.Cities.FirstOrDefault().Name)).ForMember(
                        x => x.DistrictName,
                        opt => opt.MapFrom(y => y.Countries.Cities.FirstOrDefault().Districts.FirstOrDefault().Name))
                .ForMember(x => x.ImageRemoteImageUrl, opt =>
                    opt.MapFrom(x =>
                        x.Images.FirstOrDefault().RemoteImageUrl != null ?
                            x.Images.FirstOrDefault().RemoteImageUrl :
                            "/assets/img/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension));
        }
    }
}
