using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConnectionSQL_webAPI_.Controllers
{
    public class PatientController : Controller
    {
        // GET: Patient
        public ActionResult Default_P(string firstName,string lastName)
        {
            if (Session["firstName"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            else
            {
                //ViewBag.FirstName =firstName;
                //ViewBag.LastName = lastName;
                return View();
            }
            
        }

        public ActionResult Appointment()
        {
            return View();
        }
    }
}