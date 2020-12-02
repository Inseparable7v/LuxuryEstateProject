namespace LuxuryEstate.Web.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class SignUpInputModel
    {
        [Required]
        [MinLength(4)]
        [MaxLength(25)]
        public string Username { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(25)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Password doesn't match")]
        public string RepeatPassword { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
