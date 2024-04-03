using AppDocker.Entities;
using System.ComponentModel.DataAnnotations;

namespace AppDocker.Models
{
    public class AddUserBindingModel
    {
        [Display(Name = "FirstName")]
        [Required(ErrorMessage = "Field must be set!")]
        public string? FirstName { get; set;}

        [Display(Name = "LastName")]
        [Required(ErrorMessage = "Field must be set!")]
        public string? LastName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Field must be set!")]
        public string? Email { get; set; }
    }
}
