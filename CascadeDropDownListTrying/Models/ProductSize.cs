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
    
    public partial class ProductSize
    {
        public System.Guid ID { get; set; }
        public int Status { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedIP { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedIP { get; set; }
        public Nullable<System.Guid> Product_ID { get; set; }
        public Nullable<System.Guid> Size_ID { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual Size Size { get; set; }
    }
}
