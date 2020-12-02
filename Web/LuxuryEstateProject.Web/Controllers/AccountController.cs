namespace LuxuryEstateProject.Web.Controllers
{
    using LuxuryEstate.Web.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    public class AccountController : BaseController
    {
        public AccountController()
        {
        }

        [HttpGet]
        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Login(SignUpInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            return this.Redirect("/");
        }
    }
}
