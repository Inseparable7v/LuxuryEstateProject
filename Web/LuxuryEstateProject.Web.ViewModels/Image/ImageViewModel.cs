namespace LuxuryEstateProject.Web.ViewModels.Image
{
    using LuxuryEstateProject.Data.Models;
    using LuxuryEstateProject.Services.Mapping;

    public class ImageViewModel : IMapFrom<Image>
    {
        public string RemoteImageUrl { get; set; }
    }
}
