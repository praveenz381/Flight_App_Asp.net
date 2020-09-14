using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PMT.Presentation.Models
{
    public class FlightScheduleModel
    {
        /*[Required(ErrorMessage ="Id is mandatory")]
        [Display(Name ="Flight ID")]   */    
        public int Id { get; set; }


        
        /*[Display(Name = "Flight Number")]
        [StringLength(6, MinimumLength = 3, ErrorMessage = "Minimum length is 3 and maximum length is 6")]
        [RegularExpression("^[A-Z0-9]{6}$", ErrorMessage = "Should contain only letters and numbers")]*/
        public string FlightNumber { get; set; }



        /*[Display(Name = "Source")]
        [RegularExpression("^[a-zA-Z ]{6}$", ErrorMessage = "Should contain only letters")]
        [StringLength(6, MinimumLength = 3, ErrorMessage = "Minimum length is 3 and maximum length is 6")]*/
        public string Origin { get; set; }



        /*[Display(Name = "Destination")]
        [RegularExpression("^[a-zA-Z ]{6}$", ErrorMessage = "Should contain only letters")]
        [StringLength(6, MinimumLength = 3, ErrorMessage = "Minimum length is 3 and maximum length is 6")]*/
        public string Destination { get; set; }


        [Required(ErrorMessage ="Departure time required")]
        [Display(Name = "Departure Time")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> DepartureTime { get; set; }


        [Required(ErrorMessage = "Arrival time required")]
        [Display(Name = "Arrival Time")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> ArrivalTime { get; set; }

        public int AvailableSeats { get; set; }
    }
}