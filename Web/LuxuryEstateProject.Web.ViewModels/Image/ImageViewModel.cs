namespace LuxuryEstateProject.Web.ViewModels.Image
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using LuxuryEstateProject.Services.Mapping;

    public class ImageViewModel : IMapFrom<Data.Models.Image>
    {
        public string RemoteImageUrl { get; set; }
    }
}
