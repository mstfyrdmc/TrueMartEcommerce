using Core.Map;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Maps
{
  public  class ProductSizeMap : CoreMap<ProductSize>
    {
        public ProductSizeMap()
        {
            ToTable("dbo.ProductSize");
            Property(m => m.Size).IsOptional();
        }

    }
}
