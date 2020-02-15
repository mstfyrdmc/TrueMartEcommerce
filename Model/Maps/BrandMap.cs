using Core.Map;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Maps
{
   public class BrandMap : CoreMap<Brand>
    {
        public BrandMap()
        {
            ToTable("dbo.Brands");
            Property(x => x.BrandName).HasMaxLength(50).IsRequired();
            Property(x => x.Description).IsOptional();
            Property(x => x.ImagePath).IsOptional();
        }
    }
}
