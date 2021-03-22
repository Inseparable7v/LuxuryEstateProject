namespace LuxuryEstateProject.Web.ViewModels.Blog
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using LuxuryEstateProject.Data.Models;
    using LuxuryEstateProject.Services.Mapping;

    public class EditBlogInputModel : IMapFrom<Blog>
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        [MinLength(3)]

        public string SubName { get; set; }

        [Required]
        [MinLength(3)]

        public string Author { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [MinLength(10)]

        public string Description { get; set; }
    }
}
