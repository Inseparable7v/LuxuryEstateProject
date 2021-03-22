namespace LuxuryEstateProject.Web.ViewModels.Blog
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using AutoMapper;
    using LuxuryEstateProject.Data.Models;
    using LuxuryEstateProject.Services.Mapping;

    public class BlogDetailsViewModel : IMapFrom<Blog>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string SubName { get; set; }

        public string Author { get; set; }

        public string Category { get; set; }

        public ICollection<string> ImageUrl { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public string AddedByUserId { get; set; }

        public string Email { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<BlogImage> BlogImages { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Blog, BlogDetailsViewModel>()
                .ForMember(x => x.ImageUrl, opt => opt.MapFrom(x =>
                        x.BlogImages.Select(x => x.RemoteImageUrl != null ? x.RemoteImageUrl :"/images/blogs/" + x.Id + "." + x.Extension)));
        }
    }
}
