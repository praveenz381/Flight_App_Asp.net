using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PMT.Presentation.Models
{
    public class FlightModel
    {
        [Required(ErrorMessage ="Flight Number is mandatory")]
        [Display(Name ="Flight Number")]
        [RegularExpression("^[A-Z0-9]{6}$", ErrorMessage = "Should contain only letters and numbers")]
        public string FlightNumber { get; set; }



        [Required(ErrorMessage = "Flight Name is mandatory")]
        [Display(Name = "Flight Name")]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "Should contain only letters")]
        public string FlightName { get; set; }



        [Required(ErrorMessage = "Seat Capacity is mandatory")]
        [Display(Name = "Seat Capacity")]
        [Range(0,450,ErrorMessage ="Enter Seats in range 0-450")]
        /*[StringLength(4, ErrorMessage = "Minimum length is 2 and maximum length is 4")]*/
        public int SeatsCapacity { get; set; }



        [Required(ErrorMessage = "No of seats available is mandatory")]
        [Display(Name = "Seat Available")]
        [Range(0,450,ErrorMessage = "Enter Seats in range 0-450")]
        //[StringLength(4, MinimumLength = 0, ErrorMessage = "Minimum length is 0 and maximum length is 4")]
        public int NoOfSeatsAvailable { get; set; }
    }
}