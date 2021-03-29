namespace LuxuryEstateProject.Services.Data.Tests.BlogServiceTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using LuxuryEstateProject.Data.Models;
    using LuxuryEstateProject.Data.Repositories;
    using LuxuryEstateProject.Services.Mapping;
    using LuxuryEstateProject.Web.ViewModels.Blog;
    using Microsoft.AspNetCore.Http;
    using Xunit;

    public class BlogServiceTests : TestBase
    {
        public BlogServiceTests()
        {
        }

        [Fact]
        public async Task CreateAsyncShouldWorkCorrectly()
        {
            var db = GetDatabase();

            var blogRepository = new EfDeletableEntityRepository<Blog>(db);

            var blog = new CreateBlogInputModel()
            {
                Author = "Aristotle",
                Category = BlogCategory.Blog,
                Name = "Philosophy",
                BlogImages = new List<IFormFile>(),
            };

            var service = new BlogService(blogRepository);

            await service.CreateAsync(blog, "1", "/.../...");

            await db.SaveChangesAsync();

            Assert.Equal(1, db.Blog.Count());
        }

        [Fact]
        public async Task GetHomePageBlogsShoulWorkCorrectly()
        {
            var db = GetDatabase();

            var blogRepository = new EfDeletableEntityRepository<Blog>(db);

            var firstBlog = new Blog()
            {
                Id = 1,
                Author = "Aristotle",
                Category = BlogCategory.Blog,
                Name = "Philosophy",
            };

            var secondBlog = new Blog()
            {
                Id = 2,
                Author = "Aristotle",
                Category = BlogCategory.Blog,
                Name = "Philosophy",
            };

            var service = new BlogService(blogRepository);

            await db.Blog.AddAsync(firstBlog);
            await db.Blog.AddAsync(secondBlog);
            await db.SaveChangesAsync();

            var blogEntity = service.GetHomePageBlogs<VisualiseBlogViewModel>();

            Assert.Equal(secondBlog.Id, blogEntity.FirstOrDefault().Id);
        }

        [Fact]
        public async Task GetAllShouldWorkCorrectly()
        {
            var db = GetDatabase();

            var blogRepository = new EfDeletableEntityRepository<Blog>(db);

            var firstBlog = new Blog()
            {
                Id = 1,
                Author = "Aristotle",
                Category = BlogCategory.Blog,
                Name = "Philosophy",
            };

            var service = new BlogService(blogRepository);

            await db.Blog.AddAsync(firstBlog);
            await db.SaveChangesAsync();

            var blogs = service.GetAll<VisualiseBlogViewModel>(1);

            Assert.Equal(firstBlog.Name, blogs.FirstOrDefault().Name);
        }

        [Fact]
        public async Task GetBlogShouldWorkCorrectly()
        {
            var db = GetDatabase();

            var blogRepository = new EfDeletableEntityRepository<Blog>(db);

            var firstBlog = new Blog()
            {
                Id = 1,
                Author = "Aristotle",
                Category = BlogCategory.Blog,
                Name = "Philosophy",
            };

            var service = new BlogService(blogRepository);

            await db.Blog.AddAsync(firstBlog);
            await db.SaveChangesAsync();

            var blogs = service.GetBlogs<VisualiseBlogViewModel>(1);

            Assert.Equal(firstBlog.Author, blogs.FirstOrDefault().Author);
        }

        [Fact]
        public async Task GetByIdShouldWorkCorrectly()
        {
            var db = GetDatabase();

            var blogRepository = new EfDeletableEntityRepository<Blog>(db);

            var firstBlog = new Blog()
            {
                Id = 1,
                Author = "Aristotle",
                Category = BlogCategory.Blog,
                Name = "Philosophy",
                SubName = "Artor",
            };

            var service = new BlogService(blogRepository);

            await db.Blog.AddAsync(firstBlog);
            await db.SaveChangesAsync();

            var blogs = service.GetById<VisualiseBlogViewModel>(1);

            Assert.Equal(firstBlog.SubName, blogs.SubName);
        }

        [Fact]
        public async Task UpdateAsyncShouldWorkCorrectly()
        {
            var db = GetDatabase();

            var blogRepository = new EfDeletableEntityRepository<Blog>(db);

            var firstBlog = new Blog()
            {
                Id = 1,
                Author = "Aristotle",
                Category = BlogCategory.Blog,
                Name = "Philosophy",
                Date = DateTime.Now.AddDays(1),
                Description = "DescriptionTestDescriptionTestDescriptionTestDescriptionTest",
                SubName = "Arthor",
            };

            var editedBlog = new EditBlogInputModel()
            {
                Date = DateTime.Now,
                Author = "Aristotle",
                Category = BlogCategory.Blog,
                Name = "Philosophy",
                Description = "DescriptionTestDescriptionTestDescriptionTestDescriptionTest",
                SubName = "Arthor",
            };

            var service = new BlogService(blogRepository);

            await db.Blog.AddAsync(firstBlog);
            await db.SaveChangesAsync();

            await service.UpdateAsync(1, editedBlog);

            Assert.Equal(editedBlog.Date, firstBlog.Date);
        }

        [Fact]
        public async Task DeleteAsyncShouldWorkCorrectly()
        {
            var db = GetDatabase();

            var blogRepository = new EfDeletableEntityRepository<Blog>(db);

            var firstBlog = new Blog()
            {
                Id = 1,
                Author = "Aristotle",
                Category = BlogCategory.Blog,
                Name = "Philosophy",
            };

            var service = new BlogService(blogRepository);

            await db.Blog.AddAsync(firstBlog);
            await db.SaveChangesAsync();

            await service.DeleteAsync(1);

            Assert.Equal(0, service.GetCount());
        }
    }

    public class VisualiseBlogViewModel : IMapFrom<Blog>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public string SubName { get; set; }
    }
}
