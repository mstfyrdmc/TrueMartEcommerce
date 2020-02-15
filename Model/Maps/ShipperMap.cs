using Core.Map;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Maps
{
   public class ShipperMap : CoreMap<Shipper>
    {
        public ShipperMap()
        {
            ToTable("dbo.Shippers");
            Property(x => x.ShipperName).HasMaxLength(100).IsOptional();
            Property(x => x.EmailAddress).HasMaxLength(100).IsOptional();
            Property(x => x.ProvinceID).IsOptional();
            Property(x => x.ID).IsOptional();
            Property(x => x.TownID).IsOptional();

        }
    }
}
