using Core.Map;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Maps
{
   public class OrderDetailMap : CoreMap<OrderDetail>
    {
        public OrderDetailMap()
        {
            ToTable("dbo.OrderDetails");
            //Property(x => x.Name).HasMaxLength(50).IsOptional();
            //Property(x => x.Surname).HasMaxLength(50).IsOptional();
            Property(x => x.Quentity).IsOptional();
            Property(x => x.Price).HasColumnType("money").IsOptional();
            //yeni
            Property(m => m.AppUserID).IsOptional();
            //yeni
        }
    }
}
