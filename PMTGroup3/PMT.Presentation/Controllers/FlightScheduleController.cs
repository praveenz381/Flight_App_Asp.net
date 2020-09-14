using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMT.DataAccess;
using PMT.Presentation.Models;

namespace PMT.Presentation.Controllers
{
    
    public class FlightScheduleController : Controller
    {
        // GET: FlightSchedule
        public ActionResult FlightSchedules()
        {
            if (Session["role"] != null)
            {
                if ((string)Session["role"] == "admin")
                {
                    Repository rep = new Repository();
                    List<FlightSchedule> schedules = rep.GetFlightSchedules();
                    List<FlightScheduleModel> results = new List<FlightScheduleModel>();
                    foreach (FlightSchedule f in schedules)
                    {
                        FlightScheduleModel model = new FlightScheduleModel();
                        model.Id = f.Id;
                        model.FlightNumber = f.FlightNumber;
                        model.Origin = f.Airport1.Location;
                        model.Destination = f.Airport.Location;
                        model.DepartureTime = f.DepartureTime;
                        model.ArrivalTime = f.ArrivalTime;
                        results.Add(model);
                    }
                    return View(results);
                }
            }
            return RedirectToAction("Login", "User");
        }

        public ActionResult AddSchedule()
        {
            if (Session["role"] != null)
            {
                if ((string)Session["role"] == "admin")
                {
                    Repository repo = new Repository();
                    FlightScheduleModel scheduleModel = new FlightScheduleModel();
                    List<FlightModel> flights = new List<FlightModel>();
                    foreach (Flight flight in repo.LoadFlights())
                    {
                        FlightModel model = new FlightModel();
                        model.FlightNumber = flight.FlightNumber;
                        model.FlightName = flight.FlightName;
                        flights.Add(model);
                    }
                    List<AirportModel> airports = new List<AirportModel>();
                    foreach (Airport airport in repo.LoadAirports())
                    {
                        AirportModel model = new AirportModel();
                        model.AirportCode = airport.AirportCode;
                        model.Location = airport.Location;
                        airports.Add(model);
                    }
                    ViewBag.Airports = airports;
                    ViewBag.Flights = flights;
                    return View(scheduleModel);
                }
            }
            return RedirectToAction("Login", "User");
        }

        [HttpPost]
        public ActionResult AddSchedule(FlightScheduleModel model)
        {
            if (Session["role"] != null)
            {
                if ((string)Session["role"] == "admin")
                {
                    Repository rep = new Repository();
                    FlightSchedule schedule = new FlightSchedule();
                    //schedule.Id = model.Id;
                    schedule.FlightNumber = model.FlightNumber;
                    schedule.Origin = model.Origin;
                    schedule.Destination = model.Destination;
                    schedule.DepartureTime = model.DepartureTime;
                    schedule.ArrivalTime = model.ArrivalTime;
                    int res = 0;
                    if (ModelState.IsValid)
                    {
                        res = rep.AddSchedule(schedule);
                        if (res == 1)
                        {
                            ViewBag.AddMsg = "Schedule added";
                        }
                    }

                    return RedirectToAction("AddSchedule");
                }
            }
            return RedirectToAction("Login", "User");
        }

        public ActionResult DeleteSchedule(int id)
        {
            if (Session["role"] != null)
            {
                if ((string)Session["role"] == "admin")
                {
                    Repository rep = new Repository();
                    FlightSchedule schedule = rep.GetSchedule(id);
                    FlightScheduleModel model = new FlightScheduleModel();
                    model.Id = schedule.Id;
                    model.FlightNumber = schedule.FlightNumber;
                    model.Origin = schedule.Origin;
                    model.Destination = schedule.Destination;
                    model.DepartureTime = schedule.DepartureTime;
                    model.ArrivalTime = schedule.ArrivalTime;
                    return View(model);
                }
            }
            return RedirectToAction("Login", "User");
        }

        [HttpPost]
        [ActionName("DeleteSchedule")]
        public ActionResult DeleteFlightSchedule(int id)
        {
            if (Session["role"] != null)
            {
                if ((string)Session["role"] == "admin")
                {
                    Repository rep = new Repository();
                    int res = 0;
                    if (ModelState.IsValid)
                    {
                        res = rep.RemoveSchedule(id);
                        if (res == 1)
                        {
                            ViewBag.RemoveMsg = "Schedule removed";
                        }

                    }

                    return View();
                }
            }
            return RedirectToAction("Login", "User");
        }

        public ActionResult UpdateSchedule(int id)
        {
            if (Session["role"] != null)
            {
                if ((string)Session["role"] == "admin")
                {
                    Repository rep = new Repository();
                    FlightSchedule schedule = rep.GetSchedule(id);
                    List<FlightModel> flights = new List<FlightModel>();
                    foreach (Flight flight in rep.LoadFlights())
                    {
                        FlightModel model = new FlightModel();
                        model.FlightNumber = flight.FlightNumber;
                        model.FlightName = flight.FlightName;
                        flights.Add(model);
                    }
                    List<AirportModel> airports = new List<AirportModel>();
                    foreach (Airport airport in rep.LoadAirports())
                    {
                        AirportModel model = new AirportModel();
                        model.AirportCode = airport.AirportCode;
                        model.Location = airport.Location;
                        airports.Add(model);
                    }
                    ViewBag.Airports = airports;
                    ViewBag.Flights = flights;
                    return View(schedule);
                }
            }
            return RedirectToAction("Login", "User");
        }

        [HttpPost]
        public ActionResult UpdateSchedule(FlightSchedule schedule)
        {
            if (Session["role"] != null)
            {
                if ((string)Session["role"] == "admin")
                {
                    Repository rep = new Repository();
                    int res = 0;
                    if (ModelState.IsValid)
                    {
                        res = rep.UpdateSchedule(schedule);
                        if (res == 1)
                        {
                            ViewBag.UpdateMsg = "Schedule Updated";
                        }
                    }
                    return RedirectToAction("FlightSchedules");
                }
            }
            return RedirectToAction("Login", "User");
        }
    }
}