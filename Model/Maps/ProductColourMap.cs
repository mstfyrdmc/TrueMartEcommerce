using Core.Map;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Maps
{
   public class ProductColourMap : CoreMap<ProductColour>
    {
        public ProductColourMap()
        {
            ToTable("dbo.ProductColour");
            Property(m => m.Colour).IsOptional();
            
        }
    }
}
