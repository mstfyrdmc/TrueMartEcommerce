using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
   public class Province : CoreEntity
    {
        public string ProvinceName { get; set; }

        public virtual List<SiteEmployee> SiteEmployees { get; set; }

        public virtual List<Supplier> Suppliers { get; set; }

        public virtual List<AppUser> AppUsers { get; set; }
        public virtual List<Shipper> Shippers { get; set; }
        public virtual List<Town> Towns { get; set; }
    }
}
