namespace LuxuryEstateProject.Web.ViewModels.Blog
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CommentViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string AddedByUserId { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Email { get; set; }
    }
}
