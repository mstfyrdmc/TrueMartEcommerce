using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
   public class Town : CoreEntity
    {
        public Guid ProvinceID { get; set; }
       
        public string TownName { get; set; }

        public virtual Province Province { get; set; }

        
        public virtual List<SiteEmployee> SiteEmployees { get; set; }
        public virtual List<AppUser> AppUsers { get; set; }
        public virtual List<Shipper> Shippers { get; set; }
        public virtual List<Supplier> Suppliers { get; set; }

    }
}
