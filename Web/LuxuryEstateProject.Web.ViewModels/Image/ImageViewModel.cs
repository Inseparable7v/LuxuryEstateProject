namespace LuxuryEstateProject.Web.ViewModels.Image
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using AutoMapper;
    using LuxuryEstateProject.Data.Models;
    using LuxuryEstateProject.Services.Mapping;
    using LuxuryEstateProject.Web.ViewModels.Property;

    public class ImageViewModel : IMapFrom<Image>
    {
        public string RemoteImageUrl { get; set; }
    }
}
