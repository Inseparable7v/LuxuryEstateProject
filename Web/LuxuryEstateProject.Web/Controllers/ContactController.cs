namespace LuxuryEstateProject.Web.Controllers
{
    using System.Text;
    using System.Threading.Tasks;

    using LuxuryEstateProject.Services.Messaging;
    using LuxuryEstateProject.Web.ViewModels.ContactForm;
    using Microsoft.AspNetCore.Mvc;

    public class ContactController : BaseController
    {
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
            var html = new StringBuilder();
            html.AppendLine($"<h1>{input.Name}</h1>");
            html.AppendLine($"<h3>{input.Body}</h3>");
            await this.emailSender.SendEmailAsync(input.Email, input.Name, "daniel.todorow1@gmail.com", input.Subject, html.ToString());

            this.ViewData["Message"] = "Send is succesfull";

            return this.View();
        }
    }
}
