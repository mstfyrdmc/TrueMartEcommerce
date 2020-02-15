using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
   public class Shipper : CoreEntity
    {
        public Guid? ProvinceID { get; set; }
        public Guid? TownID { get; set; }
        public string ShipperName { get; set; }
        public string EmailAddress { get; set; }

        public virtual Town Town { get; set; }
        public virtual Province Province { get; set; }
       
        public virtual List<Order> Orders { get; set; }
        public virtual List<ContactInfo> ContactInfos { get; set; } 

     
      
    }
}
