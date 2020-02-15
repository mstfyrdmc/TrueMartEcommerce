using Core.Map;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Maps
{
   public class OrderMap : CoreMap<Order>
    {
        public OrderMap()
        {
            ToTable("dbo.Orders");
            Property(x => x.IsComfirmed).HasColumnName("Confirmed").IsOptional();
            Property(x => x.OrderDate).HasColumnType("date").IsOptional();
            Property(x => x.ShippedDate).HasColumnType("date").IsOptional();
            Property(x => x.ShippedAddress).IsOptional();
            Property(x => x.AppUserID).IsOptional();//yeni
            Property(x => x.ShipperID).IsOptional();//yeni
        }
    }
}
