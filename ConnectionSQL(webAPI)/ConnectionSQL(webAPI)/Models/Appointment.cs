
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace ConnectionSQL_webAPI_.Models
{

using System;
    using System.Collections.Generic;
    
public partial class Appointment
{

    public int AppointmentId { get; set; }

    public Nullable<int> UserId { get; set; }

    public Nullable<int> DoctorId { get; set; }

    public Nullable<int> HospitalId { get; set; }

    public Nullable<System.DateTime> AppointmentDate { get; set; }

    public Nullable<System.TimeSpan> StartTime { get; set; }

    public Nullable<System.TimeSpan> EndTime { get; set; }

    public string AppointmentStatus { get; set; }

    public Nullable<int> ProblemId { get; set; }

    public Nullable<int> PaymentId { get; set; }

    public Nullable<System.DateTime> CreatedDate { get; set; }

    public string CreatedBy { get; set; }

    public Nullable<System.DateTime> UpdatedDate { get; set; }

    public string UpdatedBy { get; set; }



    public virtual DoctorInfo DoctorInfo { get; set; }

    public virtual Hospital Hospital { get; set; }

    public virtual Payment Payment { get; set; }

    public virtual Problem Problem { get; set; }

    public virtual User User { get; set; }

}

}
