using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PMT.Presentation.Models
{
    public class UserModel
    {
        //auto-generated
        //public int UserId { get; set; }

        [Required(ErrorMessage = "First Name is mandatory.")]
        [Display(Name = "First Name")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "First Name should consist of alphabets only.")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "First Name should be between 3 to 30  characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is mandatory.")]
        [Display(Name = "Last Name")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Last Name should consist of alphabets only.")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Last Name should be between 3 to 30  characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email Address is mandatory.")]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress,ErrorMessage = "Enter a valid Email ID")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Password is mandatory.")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(12, MinimumLength = 6, ErrorMessage = "Password should be between 6 to 12 characters.")]
        public string Password { get; set; }
    }
}