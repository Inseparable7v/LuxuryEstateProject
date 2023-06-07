namespace LuxuryEstateProject.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using LuxuryEstateProject.Common;
    using LuxuryEstateProject.Data.Models;
    using LuxuryEstateProject.Services.Data;
    using LuxuryEstateProject.Web.ViewModels.Blog;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class BlogController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IBlogService blogsService;
        private readonly IWebHostEnvironment environment;
        private readonly ICommentService commentService;

        public BlogController(
            UserManager<ApplicationUser> userManager,
            IBlogService blogsService,
            IWebHostEnvironment environment,
            ICommentService commentService)
        {
            this.userManager = userManager;
            this.blogsService = blogsService;
            this.environment = environment;
            this.commentService = commentService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [Authorize]
        public IActionResult Create()
        {
            var viewModel = new CreateBlogInputModel();

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);

            try
            {
                await this.blogsService.CreateAsync(input, user.Id, $"{this.environment.WebRootPath}/images");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                Console.WriteLine(ex.InnerException.Message);
                return this.View(input);
            }

            return this.Redirect("/");
        }

        public IActionResult All(int id = 1)
        {
            const int itemsPerPage = 6;

            var viewModel = new BlogListViewModel
            {
                ItemsPerPage = itemsPerPage,
                PageNumber = id,
                PropertiesCount = this.blogsService.GetCount(),
                Blogs = this.blogsService.GetAll<VisualizeBlogViewModel>(id, itemsPerPage),
            };

            return this.View(viewModel);
        }

        public IActionResult ById(int id)
        {
            var blog = this.blogsService.GetById<BlogDetailsViewModel>(id);

            return this.View(blog);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Edit(int id)
        {
            var inputModel = this.blogsService.GetById<EditBlogInputModel>(id);

            return this.View(inputModel);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditBlogInputModel blogInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            try
            {
                await this.blogsService.UpdateAsync(id, blogInputModel);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
            }

            return this.RedirectToAction(nameof(this.ById), new { id = id });
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Delete(int id)
        {
            await this.blogsService.DeleteAsync(id);
            return this.RedirectToAction(nameof(this.All));
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        [HttpPost]
        public async Task<IActionResult> AddComment(string content, int blogId)
        {
            var userId = this.userManager.GetUserId(this.User);
            var userName = this.User.Identity.Name;
            if (content != null)
            {
                await this.commentService.AddCommentAsync(content, blogId, userId, userName);
            }

            return this.RedirectToAction(nameof(this.ById), new { id = blogId });
        }
    }
}
