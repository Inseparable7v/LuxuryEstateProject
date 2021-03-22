namespace LuxuryEstateProject.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using LuxuryEstateProject.Web.ViewModels.Blog;

    public interface IBlogService
    {
        Task CreateAsync(CreateBlogInputModel input, string userId, string imagePath);

        IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 12);

        IEnumerable<T> GetBlogs<T>(int count);

        T GetById<T>(int id);

        Task DeleteAsync(int id);

        int GetCount();

        Task UpdateAsync(int id, EditBlogInputModel input);
    }
}
