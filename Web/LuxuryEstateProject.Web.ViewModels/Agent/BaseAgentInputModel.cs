namespace LuxuryEstateProject.Web.ViewModels.Agent
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public abstract class BaseAgentInputModel
    {
        [Required]
        [MaxLength(25)]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        [MaxLength(25)]
        [MinLength(3)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "Phone should contain 10 numbers")]
        [Phone]
        public string Phone { get; set; }

        [MaxLength(150)]
        [MinLength(10)]
        public string Description { get; set; }

        //public int PropertyId { get; set; }

        //public IEnumerable<SelectListItem> Properties { get; set; }
    }
}
