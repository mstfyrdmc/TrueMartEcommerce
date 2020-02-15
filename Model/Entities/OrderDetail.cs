using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
   public class OrderDetail : CoreEntity
    {
        //yeni
        public Guid? AppUserID { get; set; }
        //yeni
        public Guid? ProductID { get; set; }
        public Guid? OrderID { get; set; }
        //yeni
        public virtual AppUser AppUser { get; set; }
        //yeni
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
        public int? Quentity { get; set; }
       
        public decimal? Price { get; set; }
    }
}
