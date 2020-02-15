using Core.Map;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Maps
{
   public class SubSubCategoryMap : CoreMap<SubSubCategory>
    {
        public SubSubCategoryMap()
        {
            ToTable("dbo.SubSubCategories");
            Property(m => m.SubSubCategoryName).HasMaxLength(70).IsRequired();
            Property(m => m.Description).IsOptional();
            Property(m => m.ImagePath).HasMaxLength(150).IsOptional();
            
        }
    }
}
