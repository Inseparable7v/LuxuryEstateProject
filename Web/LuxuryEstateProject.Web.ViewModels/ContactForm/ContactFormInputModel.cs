namespace LuxuryEstateProject.Web.ViewModels.ContactForm
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Text;

    public class ContactFormInputModel
    {
        [DisplayName("Your Name")]
        public string Name { get; set; }

        public string Email { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }
    }
}
