using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMT.DataAccess;
using PMT.Presentation.Models;

namespace PMT.Presentation.Controllers
{
   
    public class FlightController : Controller
    {
        
        // GET: Flight
        public ActionResult GetFlights()
        {
            if (Session["role"] != null)
            {
                if ((string)Session["role"] == "admin")
                {

                    Repository flight = new Repository();
                    List<Flight> flights = flight.GetFlights();
                    List<FlightModel> allflights = new List<FlightModel>();
                    foreach (Flight oldflight in flights)
                    {
                        FlightModel newflight = new FlightModel();
                        newflight.FlightName = oldflight.FlightName;
                        newflight.FlightNumber = oldflight.FlightNumber;
                        newflight.SeatsCapacity = oldflight.SeatsCapacity;
                        newflight.NoOfSeatsAvailable = oldflight.NoOfSeatsAvailable;
                        allflights.Add(newflight);
                    }
                    return View(allflights);
                }
            }
            return RedirectToAction("Login", "User");
        }
        public ActionResult AddFlights()
        {
            if (Session["role"] != null)
            {
                if ((string)Session["role"] == "admin")
                {
                    FlightModel emptyflight = new FlightModel();
                    return View(emptyflight);
                }
            }
            return RedirectToAction("Login", "User");
        }
        [HttpPost]
        public ActionResult AddFlights(FlightModel flight)
        {
            if (Session["role"] != null)
            {
                if ((string)Session["role"] == "admin")
                {
                    Repository allflights = new Repository();
                    Flight newflight = new Flight();
                    newflight.FlightName = flight.FlightName;
                    newflight.FlightNumber = flight.FlightNumber;
                    newflight.SeatsCapacity = flight.SeatsCapacity;
                    newflight.NoOfSeatsAvailable = flight.NoOfSeatsAvailable;
                    int result = 0;
                    if (ModelState.IsValid)
                    {
                        if (newflight.SeatsCapacity == newflight.NoOfSeatsAvailable)
                        {
                            result = allflights.AddFlight(newflight);
                            if (result == 1)
                            {
                                ViewBag.AddMessage = "Added Successfully";
                            }
                            else
                            {
                                ViewBag.ErrorMessage = "Attempt Unsuccessfull; Error: Please review the  requested action";
                            }
                        }
                        else
                        {
                            ViewBag.ErrorMessageEqual = "Seats Capacity and Available Seats must be same";
                        }
                    }
                    return View();
                }
            }
            return RedirectToAction("Login", "User");
        }
        public ActionResult UpdateFlight(String flightnumber)
        {
            if (Session["role"] != null)
            {
                if ((string)Session["role"] == "admin")
                {
                    Repository allflights = new Repository();
                    Flight findflight = allflights.GetFlight(flightnumber);
                    FlightModel flight = new FlightModel();
                    flight.FlightNumber = findflight.FlightNumber;
                    flight.FlightName = findflight.FlightName;
                    flight.SeatsCapacity = findflight.SeatsCapacity;
                    flight.NoOfSeatsAvailable = findflight.NoOfSeatsAvailable;
                    return View(flight);
                }
            }
            return RedirectToAction("Login", "User");
        }
        [HttpPost]
        public ActionResult UpdateFlight(FlightModel flight1)
        {
            if (Session["role"] != null)
            {
                if ((string)Session["role"] == "admin")
                {
                    Repository allflights = new Repository();
                    Flight updateflight = new Flight();
                    updateflight.FlightNumber = flight1.FlightNumber;
                    updateflight.FlightName = flight1.FlightName;
                    updateflight.SeatsCapacity = flight1.SeatsCapacity;
                    updateflight.NoOfSeatsAvailable = flight1.NoOfSeatsAvailable;
                    int result = 0;
                    if (ModelState.IsValid)
                    {
                        result = allflights.UpdateFlight(updateflight);
                        if (result == 1)
                        {
                            ViewBag.UpdateMessage = "Updated Successfully";
                        }
                        else
                        {
                            ViewBag.ErrorMessage = "Attempt Unsuccessfull; Error: Please review the  requested action";
                        }
                    }
                    return View();
                }
            }
            return RedirectToAction("Login", "User");
        }
        public ActionResult RemoveFlight(String flightnumber)
        {
            if (Session["role"] != null)
            {
                if ((string)Session["role"] == "admin")
                {
                    Repository allflights = new Repository();
                    Flight gotflight = allflights.GetFlight(flightnumber);
                    FlightModel model = new FlightModel();
                    model.FlightNumber = gotflight.FlightNumber;
                    model.FlightName = gotflight.FlightName;
                    model.SeatsCapacity = gotflight.SeatsCapacity;
                    model.NoOfSeatsAvailable = gotflight.NoOfSeatsAvailable;
                    return View(model);
                }
            }
            return RedirectToAction("Login", "User");
        }
        [HttpPost]
        [ActionName("RemoveFlight")]
        public ActionResult RemoveFlightPost(String flightnumber)
        {
            if (Session["role"] != null)
            {
                if ((string)Session["role"] == "admin")
                {
                    Repository allflights = new Repository();
                    int result = 0;

                    result = allflights.RemoveFlight(flightnumber);
                    if (result > 0)
                    {
                        ViewBag.RemoveMessage = "Removed Successfully";
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Attempt Unsuccessfull; Error: Please review the  requested action";
                    }

                    return View();
                }
            }
            return RedirectToAction("Login", "User");
        }   
    }
}