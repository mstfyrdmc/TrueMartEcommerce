using Core.Map;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Maps
{
   public class ProductDetailMap : CoreMap<ProductDetail>
    {
        public ProductDetailMap()
        {
            ToTable("dbo.ProductDetails");
            Property(m => m.Description).IsOptional();
            Property(m => m.ProductID).IsOptional();
        }
    }
}
