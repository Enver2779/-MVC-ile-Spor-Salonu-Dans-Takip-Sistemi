//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DansveSalon.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class salon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public salon()
        {
            this.ogretmen = new HashSet<ogretmen>();
        }
    
        public int bolumid { get; set; }
        public string bolumadi { get; set; }
        public string acıklama { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ogretmen> ogretmen { get; set; }
    }
}
