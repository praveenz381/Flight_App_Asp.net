using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PMT.Presentation.Models
{
    public class AirportModel
    {
        [Required(ErrorMessage ="Airport code is mandatory")]
        [Display(Name ="Airport Code")]
        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "Should contain only numbers and letters")]
        [StringLength(6, ErrorMessage = "Maximum length is 6")]
        public string AirportCode { get; set; }
            

        [Required(ErrorMessage = "Airport Name is mandatory")]
        [Display(Name = "Airport Name")]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "Should contain only letters")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Minimum length is 10 and maximum length is 30")]
        public string AirportName { get; set; }


        [Display(Name = "Airport Location")]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "Should contain only letters")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Minimum length is 3 and maximum length is 30")]
        public string Location { get; set; }


        [Display(Name = "Description")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Minimum length is 3 and maximum length is 200")]
        public string Description { get; set; }
    }
}