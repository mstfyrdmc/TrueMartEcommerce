using Core.Map;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Maps
{
   public class ProductMap : CoreMap<Product>
    {
        public ProductMap()
        {
            ToTable("dbo.Product");
            Property(m => m.ProductName).HasMaxLength(100).IsRequired();
            Property(m => m.Price).HasColumnType("money").IsOptional();
            Property(m => m.Description).IsOptional();
            
            Property(m => m.SubCategoryID).IsOptional();  
           Property(m => m.SubSubCategoryID).IsOptional(); 




        }
    }
}
