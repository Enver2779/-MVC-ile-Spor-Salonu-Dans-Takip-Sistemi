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
    
    public partial class ogretmen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ogretmen()
        {
            this.ogretmendans = new HashSet<ogretmendans>();
        }
    
        public int ogrid { get; set; }
        public string adi { get; set; }
        public string soyadi { get; set; }
        public string memleket { get; set; }
        public string eposta { get; set; }
        public string psw { get; set; }
        public int bolumid { get; set; }
        public Nullable<decimal> maası { get; set; }
    
        public virtual salon salon { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ogretmendans> ogretmendans { get; set; }
    }
}
