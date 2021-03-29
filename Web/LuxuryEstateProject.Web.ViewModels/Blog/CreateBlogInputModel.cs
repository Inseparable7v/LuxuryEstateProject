namespace LuxuryEstateProject.Web.ViewModels.Blog
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using LuxuryEstateProject.Data.Models;
    using Microsoft.AspNetCore.Http;

    public class CreateBlogInputModel
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
        [Range(0, 4)]
        public BlogCategory Category { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [MinLength(10)]
        public string Description { get; set; }

        public ICollection<Comment> Comment { get; set; }

        public ICollection<IFormFile> BlogImages { get; set; }
    }
}
