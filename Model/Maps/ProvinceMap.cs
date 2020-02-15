using Core.Map;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Maps
{
   public class ProvinceMap : CoreMap<Province>
    {
        public ProvinceMap()
        {
            ToTable("dbo.Province");
            Property(m => m.ProvinceName).HasMaxLength(50).IsOptional();
        }
    }
}
