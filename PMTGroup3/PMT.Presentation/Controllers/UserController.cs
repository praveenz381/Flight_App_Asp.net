using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMT.DataAccess;
using PMT.Presentation.Models;

namespace PMT.Presentation.Controllers
{
    public class UserController : Controller
    {
        public ActionResult ShowHome()
        {
            return View();
        }
        // GET: User
        public ActionResult Login()
        {
            LoginModel login = new LoginModel();
            return View(login);
        }

        [HttpPost]
        public ActionResult Login(LoginModel login)
        {
            Repository repository = new Repository();
            User user = new User();
            if (ModelState.IsValid)
            {
                user = repository.Login(login.EmailId, login.Password);
            }

            ViewBag.Msg = "";
            //ViewBag.viewname, viewbag.action

            if (user == null)
            {
                ViewBag.Msg = "Invalid username or password.";
              
            }
            else if (user.RoleId == 1)
            {
                Session["role"] = "admin";
                return RedirectToAction("ShowHome");
                
            }
            else if(user.RoleId==2)
            {
                Session["role"] = "user";
                return RedirectToAction("SearchFlights");
            }

           
            return View();  //user
        }

        public ActionResult Register()
        {
            UserModel model = new UserModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Register(UserModel model)
        {
            Repository r = new Repository();
            User user = new User();
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.EmailId = model.EmailId;
            user.Password = model.Password;
            user.RoleId = 2;

            if (ModelState.IsValid)
            {
                int result = r.Register(user);
                if (result == 1)
                {
                    ViewBag.Register = "User registered successfully!";
                }
            }
            return View();
        }

        

        public ActionResult SearchFlights()
        {
            if (Session["role"] != null)
            {
                if ((string)Session["role"] == "user")
                {
                    List<FlightScheduleModel> result = new List<FlightScheduleModel>();
                    return View(result);
                }
            }
            return RedirectToAction("Login");
        }

        [HttpPost]
        public ActionResult SearchFlights(string origin, string destination, string departure)
        {
            if (Session["role"] != null)
            {
                if ((string)Session["role"] == "user")
                {

                    DateTime departureDate = DateTime.Parse(departure);
                    Repository r = new Repository();
                    List<FlightSchedule> flights = new List<FlightSchedule>();

                    flights = r.SearchSchedule(origin, destination, departureDate.ToShortDateString());
                    List<FlightScheduleModel> result = new List<FlightScheduleModel>();
                    foreach (FlightSchedule f in flights)
                    {
                        FlightScheduleModel fl = new FlightScheduleModel();
                        fl.FlightNumber = f.FlightNumber;
                        fl.Origin = f.Airport1.Location;
                        fl.Destination = f.Airport.Location;
                        fl.DepartureTime = f.DepartureTime;
                        fl.ArrivalTime = f.ArrivalTime;
                        fl.AvailableSeats = f.Flight.NoOfSeatsAvailable;
                        result.Add(fl);
                    }
                    return View(result);
                }
            }
            return RedirectToAction("Login");
        }
    }
}