namespace LuxuryEstateProject.Web.ViewModels.ContactForm
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class ContactFormInputModel
    {
        [MaxLength(25)]
        [MinLength(0)]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [MinLength(0)]
        [MaxLength(25)]
        public string Subject { get; set; }

        [MaxLength(500)]
        public string Body { get; set; }
    }
}
