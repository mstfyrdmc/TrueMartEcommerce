using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
   public class SiteEmployee : CoreEntity
    {
        public Guid? ProvinceID { get; set; }

        public Guid? TownID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Profession { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }


        public virtual Province Province { get; set; }
        public virtual Town Town { get; set; }
        public virtual List<ContactInfo> ContactInfos { get; set; } 

       
    }
}
