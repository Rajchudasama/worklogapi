//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace worklogapi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class job
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public job()
        {
            this.shifts = new HashSet<shift>();
        }
    
        public int Id { get; set; }
        public string title { get; set; }
        public decimal tax { get; set; }
        public decimal hourlyrate { get; set; }
        public Nullable<int> userid { get; set; }
    
        public virtual Login Login { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<shift> shifts { get; set; }
    }
}
