using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMT.Presentation.Models;
using PMT.DataAccess;
namespace PMT.Presentation.Controllers
{

    public class AirportController : Controller
    {
        public ActionResult GetAirport()
        {
            if (Session["role"] != null)
            {
                if ((string)Session["role"] == "admin")
                {
                    Repository r = new Repository();
                    List<Airport> airports = r.GetAirportDetails();
                    List<AirportModel> result = new List<AirportModel>();
                    foreach (Airport a in airports)
                    {
                        AirportModel model = new AirportModel();
                        model.AirportCode = a.AirportCode;
                        model.AirportName = a.AirportName;
                        model.Description = a.Description;
                        model.Location = a.Location;
                        result.Add(model);
                    }
                    return View(result);
                }
            }
            return RedirectToAction("Login","User");
        }

        public ActionResult Create()
        {
            if (Session["role"] != null)
            {
                if ((string)Session["role"] == "admin")
                {
                    Models.AirportModel model = new Models.AirportModel();
                    return View(model);
                }
            }
            return RedirectToAction("Login", "User");
        }
        [HttpPost]
        public ActionResult Create(AirportModel model)
        {
            if (Session["role"] != null)
            {
                if ((string)Session["role"] == "admin")
                {
                    Repository r = new Repository();
                    Airport result = new Airport();
                    result.AirportCode = model.AirportCode;
                    result.AirportName = model.AirportName;
                    result.Description = model.Description;
                    result.Location = model.Location;
                    int output = 0;
                    if (ModelState.IsValid)
                    {
                        output = r.AddAirport(result);
                        if (output == 1)
                        {
                            ViewBag.AddMessage = "airport details added !!";
                        }
                        else
                        {
                            ViewBag.AddError = "Not added !!";
                        }
                    }
                    return View();
                }
            }
            return RedirectToAction("Login", "User");
        }
        public ActionResult UpdateAirport(String id)
        {
            if (Session["role"] != null)
            {
                if ((string)Session["role"] == "admin")
                {
                    Repository r = new Repository();
                    Airport a = r.GetAirport(id);
                    AirportModel model = new AirportModel();
                    model.AirportCode = a.AirportCode;
                    model.AirportName = a.AirportName;
                    model.Description = a.Description;
                    model.Location = a.Location;
                    return View(model);
                }
            }
            return RedirectToAction("Login", "User");
        }
        [HttpPost]
        public ActionResult UpdateAirport(AirportModel a)
        {
            if (Session["role"] != null)
            {
                if ((string)Session["role"] == "admin")
                {
                    Repository r = new Repository();
                    Airport updateAirport = new Airport();
                    updateAirport.AirportCode = a.AirportCode;
                    updateAirport.AirportName = a.AirportName;
                    updateAirport.Description = a.Description;
                    updateAirport.Location = a.Location;
                    int result = 0;
                    if (ModelState.IsValid)
                    {
                        result = r.UpdateAirport(updateAirport);
                        if (result == 1)
                        {
                            ViewBag.UpdateMessage = "airport details updated !!";
                        }
                        else
                        {
                            ViewBag.UpdateError = "not updated !!!";
                        }
                    }
                    return View();
                }
            }
            return RedirectToAction("Login", "User");
        }




        public ActionResult RemoveAirport(String AirportCode)
        {
            if (Session["role"] != null)
            {
                if ((string)Session["role"] == "admin")
                {
                    Repository r = new Repository();
                    Airport ap = r.GetAirport(AirportCode);
                    AirportModel model = new AirportModel();
                    model.AirportCode = ap.AirportCode;
                    model.AirportName = ap.AirportName;
                    model.Location = ap.Location;
                    model.Description = ap.Description;
                    return View(model);
                }
            }
            return RedirectToAction("Login", "User");
        }
        [HttpPost] 
        [ActionName("RemoveAirport")]
        public ActionResult Remove(String AirportCode)
        {
            if (Session["role"] != null)
            {
                if ((string)Session["role"] == "admin")
                {
                    Repository r = new Repository();
                    int result = 0;
                    if (ModelState.IsValid)
                    {
                        result = r.RemoveAirport(AirportCode);
                        if (result > 0)
                        {
                            ViewBag.DeleteMessage = "airport details deleted !!";
                        }
                        else
                        {
                            ViewBag.DeleteError = "Not deleted";
                        }
                    }
                    return View();
                }
            }
            return RedirectToAction("Login", "User");
        }
       
    }
}