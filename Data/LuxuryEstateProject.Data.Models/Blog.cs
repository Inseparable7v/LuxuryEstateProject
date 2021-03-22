namespace LuxuryEstateProject.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using LuxuryEstateProject.Data.Common.Models;

    public class Blog : BaseDeletableModel<int>
    {
        public Blog()
        {
            this.Comments = new HashSet<Comment>();
            this.BlogImages = new HashSet<BlogImage>();
        }

        public string Name { get; set; }

        public string SubName { get; set; }

        public string Author { get; set; }

        public string Category { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<BlogImage> BlogImages { get; set; }
    }
}
