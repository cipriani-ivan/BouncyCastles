//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BouncyCastles.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Castle
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Castle()
        {
            this.Orders = new HashSet<Order>();
        }
    
        public int CastlesID { get; set; }
        public string Type { get; set; }
        public int MaxCapacity { get; set; }
        public int NumStock { get; set; }
        public int PriceForDay { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}