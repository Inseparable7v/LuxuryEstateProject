namespace LuxuryEstateProject.Web.Controllers
{
    using System.Text;
    using System.Threading.Tasks;

    using LuxuryEstateProject.Services.Messaging;
    using LuxuryEstateProject.Web.ViewModels.ContactForm;
    using Microsoft.AspNetCore.Mvc;

    public class ContactController : BaseController
    {
        private const string RedirectedFromContactForm = "RedirectedFromContactForm";
        private readonly IEmailSender emailSender;

        public ContactController(IEmailSender emailSender)
        {
            this.emailSender = emailSender;
        }

        public IActionResult ContactForm()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> ContactForm(ContactFormInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.emailSender.SendEmailAsync(input.Email, input.Name, "daniel.todorow1@gmail.com", input.Subject, input.Body);

            this.TempData["Message"] = "Send is succesfull";
            this.TempData[RedirectedFromContactForm] = true;

            return this.RedirectToAction("ThankYou");
        }

        public IActionResult ThankYou()
        {
            if (this.TempData[RedirectedFromContactForm] == null)
            {
                return this.NotFound();
            }

            return this.View();
        }
    }
}
