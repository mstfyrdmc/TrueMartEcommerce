//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CascadeDropDownListTrying.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SubSubCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SubSubCategory()
        {
            this.Products = new HashSet<Product>();
        }
    
        public System.Guid ID { get; set; }
        public System.Guid SubCategoryID { get; set; }
        public string SubSubCategoryName { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedIP { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedIP { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
        public virtual SubCategory SubCategory { get; set; }
    }
}
