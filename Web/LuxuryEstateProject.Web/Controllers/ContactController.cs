namespace LuxuryEstateProject.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    public class ContactController : BaseController
    {
        public ContactController()
        {
        }

        public IActionResult ContactForm()
        {
            return this.View();
        }
    }
}
