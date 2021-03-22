namespace LuxuryEstateProject.Web.ViewModels.Blog
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using AutoMapper;
    using LuxuryEstateProject.Data.Models;
    using LuxuryEstateProject.Services.Mapping;

    public class SingleBlogViewModel : IMapFrom<Blog>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<string> ImageUrl { get; set; }

        public string Category { get; set; }

        public DateTime Date { get; set; }

        public string AddedByUserId { get; set; }

        public virtual ICollection<BlogImage> BlogImage { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Blog, VisualizeBlogViewModel>()
                .ForMember(x => x.ImageUrl, opt => opt.MapFrom(x =>
                x.BlogImages.Select(x => x.RemoteImageUrl ?? "/images/blogs/" + x.Id + "." + x.Extension)));
        }
    }
}
