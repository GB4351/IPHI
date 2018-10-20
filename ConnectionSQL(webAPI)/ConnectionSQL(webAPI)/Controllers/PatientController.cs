using ConnectionSQL_webAPI_.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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

        [HttpGet]
        public ActionResult Appointment(int id = 0)
        {
            AppointmentRecords appointmodel = new AppointmentRecords();
            using (IPHISEntities dbmodel = new IPHISEntities())
            {
            }
            return View(appointmodel);
        }


        [HttpPost]
        public ActionResult Appointment(AppointmentRecords appointmodel)
        {
            using (IPHISEntities dbmodel = new IPHISEntities())
            {
                Appointment appointmodel1 = new Appointment();
                appointmodel1.DoctorId = appointmodel.DoctorId;
                appointmodel1.HospitalId = appointmodel.HospitalId;
                appointmodel1.AppointmentDate = appointmodel.AppointmentDate;
                appointmodel1.StartTime = appointmodel.StartTime;
                appointmodel1.EndTime = appointmodel.EndTime;
                appointmodel1.ProblemId = appointmodel.ProblemId;

                dbmodel.Appointments.Add(appointmodel1);
                try
                {
                    dbmodel.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    Console.WriteLine(e);
                }
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Appointment Booked Successfully.Confirmation Mail Will Be Sent To You Shortly.";
            return View("Appointment", new AppointmentRecords());
        }
    }
}