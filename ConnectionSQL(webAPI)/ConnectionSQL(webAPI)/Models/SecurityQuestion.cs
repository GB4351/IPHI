
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
    
public partial class SecurityQuestion
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public SecurityQuestion()
    {

        this.Answers = new HashSet<Answer>();

        this.Answers1 = new HashSet<Answer>();

        this.Answers2 = new HashSet<Answer>();

    }


    public int QuestionId { get; set; }

    public string Question { get; set; }

    public Nullable<System.DateTime> CreatedDate { get; set; }

    public string CreatedBy { get; set; }

    public Nullable<System.DateTime> UpdatedDate { get; set; }

    public string UpdatedBy { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Answer> Answers { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Answer> Answers1 { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Answer> Answers2 { get; set; }

}

}