using Core.Map;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Maps
{
   public class SubCategoryMap : CoreMap<SubCategory>
    {
        public SubCategoryMap()
        {

            ToTable("dbo.SubCategories");
            Property(m => m.SubCategoryName).HasMaxLength(200).IsOptional();
            Property(m => m.Description).IsOptional();
            Property(m => m.ImagePath).HasMaxLength(150).IsOptional();
           
            
        }
    }
}
