//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Auc.Data.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblUniversity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblUniversity()
        {
            this.tblStudents = new HashSet<tblStudent>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<bool> Removed { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblStudent> tblStudents { get; set; }
    }
}
