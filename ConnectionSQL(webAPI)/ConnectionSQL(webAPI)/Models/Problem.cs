
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
    
public partial class Problem
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Problem()
    {

        this.Appointments = new HashSet<Appointment>();

    }


    public int ProblemId { get; set; }

    public string Problem1 { get; set; }

    public Nullable<int> DepartmentId { get; set; }

    public string Description { get; set; }

    public Nullable<System.DateTime> CreatedDate { get; set; }

    public string CreatedBy { get; set; }

    public Nullable<System.DateTime> UpdatedDate { get; set; }

    public string UpdatedBy { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Appointment> Appointments { get; set; }

}

}
