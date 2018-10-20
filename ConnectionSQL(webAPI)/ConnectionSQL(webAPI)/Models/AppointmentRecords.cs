using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ConnectionSQL_webAPI_.Models
{
    public class AppointmentRecords
    {
        public int AppointmentId { get; set; }
        public Nullable<int> UserId { get; set; }
        [DisplayName("Doctor:")]
        [Required(ErrorMessage = "This field is required.")]
        public Nullable<int> DoctorId { get; set; }
        [DisplayName("Hospital:")]
        [Required(ErrorMessage = "This field is required.")]
        public Nullable<int> HospitalId { get; set; }
        [DisplayName("Appointment Date:")]
        [Required(ErrorMessage = "This field is required.")]
        public Nullable<System.DateTime> AppointmentDate { get; set; }
        [DisplayName("Start Time:")]
        [Required(ErrorMessage = "This field is required.")]
        public Nullable<System.TimeSpan> StartTime { get; set; }
        [DisplayName("End Time:")]
        [Required(ErrorMessage = "This field is required.")]
        public Nullable<System.TimeSpan> EndTime { get; set; }
        public string AppointmentStatus { get; set; }
        [DisplayName("Problem:")]
        [Required(ErrorMessage = "This field is required.")]
        public Nullable<int> ProblemId { get; set; }
        public Nullable<int> PaymentId { get; set; }

        public List<AppointmentRecords> appointmentinfo { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
    }
}