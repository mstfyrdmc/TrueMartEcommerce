using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Supplier : CoreEntity
    {
        public Guid? TownID { get; set; }
        public Guid? ProvinceID { get; set; }

       
        public string CompanyName { get; set; }
        public string ContactName { get; set; }

        
        public virtual Province Province { get; set; }
        public virtual Town Town { get; set; }

        public virtual List<ContactInfo> ContactInfos { get; set; } 

      
        public virtual List<Product> Products { get; set; }
    }
}
