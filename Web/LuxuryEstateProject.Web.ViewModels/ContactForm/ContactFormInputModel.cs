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
        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете съдържание на вашите имена")]
        public string Name { get; set; }

        [EmailAddress]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете съдържание на вашият емайл адрес")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете съдържание на заглавието")]
        [StringLength(100, ErrorMessage = "Заглавието трябва да е поне {2} и не повече от {1} символа.", MinimumLength = 5)]
        public string Subject { get; set; }

        [MaxLength(500)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете съдържание на съобщението")]
        [StringLength(10000, ErrorMessage = "Съобщението трябва да е поне {2} символа.", MinimumLength = 20)]
        public string Body { get; set; }
    }
}
