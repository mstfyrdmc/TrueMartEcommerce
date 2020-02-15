using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
   public class Order : CoreEntity
    {
        public Order()
        {
            this.OrderDetails = new List<OrderDetail>();
        }
        public Guid? AppUserID { get; set; }
        public Guid? ShipperID { get; set; }
        public bool IsComfirmed { get; set; }
        public string ShippedAddress { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }

        public virtual AppUser AppUser { get; set; }
        public  virtual Shipper Shipper { get; set; }

        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}
