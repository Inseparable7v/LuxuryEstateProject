namespace LuxuryEstateProject.Web.ViewModels.Blog
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BlogListViewModel : PagingViewModel
    {
        public IEnumerable<VisualizeBlogViewModel> Blogs { get; set; }
    }
}
