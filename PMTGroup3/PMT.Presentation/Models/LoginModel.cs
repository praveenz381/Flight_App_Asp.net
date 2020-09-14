using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PMT.Presentation.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Username is mandatory.")]
        [Display(Name = "Username")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Enter a valid Username")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Password is mandatory.")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(12, MinimumLength = 6, ErrorMessage = "Password should be between 6 to 12 characters.")]
        public string Password { get; set; }
    }
}