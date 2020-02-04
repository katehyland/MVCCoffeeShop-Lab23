using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Models
{
    public class RegistrationViewModel
    {
        //add DataAnnotations to allow for JQuery Validation
        [Required(AllowEmptyStrings = false, ErrorMessage = "Give me name!")]
        [StringLength(maximumLength: 20, MinimumLength = 3, ErrorMessage = "Length between 3 - 20")]
        [Display(Name = "User Name")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Give me email!")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        
        [Compare("Email", ErrorMessage = "Must Match Email")]
        [Display(Name = "Confirm Email")]
        public string ConfirmEmail { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Give me password!")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Must Match Password")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Give me phone!")]
        [Display(Name = "Phone")]
        public string Phone { get; set; }
    }
}