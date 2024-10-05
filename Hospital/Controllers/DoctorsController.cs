using ContactDoctor.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ContactDoctor.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly List<Models.Doctor> doctors;

        public DoctorsController()
        {
            doctors = new List<Models.Doctor>
            {
                new Models.Doctor { Id = 1, Name = "Dr. John Smith", Specialization = "Cardiology", Img = "doctor1.jpg" },
                new Models.Doctor { Id = 2, Name = "Dr. Sarah Johnson", Specialization = "Pediatrics", Img = "doctor3.jpg" },
                new Models.Doctor { Id = 3, Name = "Dr. Emily Davis", Specialization = "Dermatology", Img = "doctor5.jpg" },
                new Models.Doctor { Id = 4, Name = "Dr. Michael Lee", Specialization = "Orthopedics", Img = "doctor6.jpg" },
                new Models.Doctor { Id = 5, Name = "Dr. William Clark", Specialization = "Neurology", Img = "doctor4.jpg" },
            };
        }

        public IActionResult BookAppointment()
        {
            return View(doctors);
        }

        public IActionResult CompleteAppointment(string DrName)
        {
            ViewBag.DoctorName = DrName;
            return View();
        }

        [HttpPost]
        public IActionResult SubmitAppointment([FromBody] AppointmentData data)
        {
            // Here you would typically save the appointment to a database
            return Json(new { success = true, message = "Your appointment has been successfully completed. Thank you!" });
        }
    }

    public class AppointmentData
    {
        public string PatientName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string AppointmentTime { get; set; }
        public string DoctorName { get; set; }
    }
}