﻿

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
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using System.Data.Entity.Core.Objects;
using System.Linq;


public partial class IPHISEntities : DbContext
{
    public IPHISEntities()
        : base("name=IPHISEntities")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Answer> Answers { get; set; }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<DoctorBelongsHospital> DoctorBelongsHospitals { get; set; }

    public virtual DbSet<DoctorInfo> DoctorInfoes { get; set; }

    public virtual DbSet<Hospital> Hospitals { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Problem> Problems { get; set; }

    public virtual DbSet<SecurityQuestion> SecurityQuestions { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserLoginDetail> UserLoginDetails { get; set; }

    public virtual DbSet<UserType> UserTypes { get; set; }


    public virtual ObjectResult<User_Addr_Sec_Ans_Result> User_Addr_Sec_Ans()
    {

        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<User_Addr_Sec_Ans_Result>("User_Addr_Sec_Ans");
    }

}

}
