namespace LuxuryEstateProject.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

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
