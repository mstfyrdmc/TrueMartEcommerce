using Core.Map;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Maps
{
   public class CartMap : CoreMap<Cart>
    {
        public CartMap()
        {
            ToTable("dbo.Cart");
            Property(m => m.ProductName).HasMaxLength(70).IsOptional();
            Property(m => m.Price).HasColumnType("money").IsOptional();
            Property(m => m.ImagePath).HasMaxLength(150).IsOptional();
            Property(m => m.Quentity).IsOptional();
            Property(m => m.ProductID).IsOptional();
            Property(m => m.AppUserID).IsOptional();
            
        }
    }
}
