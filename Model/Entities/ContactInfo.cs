using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
   public class ContactInfo : CoreEntity
    {
        public Guid? AppUserID { get; set; }

        public Guid? SupplierID { get; set; }

        public Guid? ShipperID { get; set; }

        public Guid? SiteEmployeeID { get; set; } 
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string FaxNo { get; set; }
        public string Address { get; set; }

        public virtual AppUser AppUser { get; set; }
        public virtual Shipper Shipper { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual SiteEmployee SiteEmployee { get; set; }
    }
}
