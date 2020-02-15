using Core.Map;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Maps
{
  public  class TownMap : CoreMap<Town>
    {
        public TownMap()
        {
            ToTable("dbo.Town");
            Property(x => x.TownName).HasMaxLength(50).IsOptional();
            Property(x => x.ProvinceID).IsOptional();
        }
    }
}
