using Core.Map;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Maps
{
   public class SupplierMap : CoreMap<Supplier>
    {
        public SupplierMap()
        {
            ToTable("dbo.Supplier");
            Property(x => x.CompanyName).IsOptional();
            Property(x => x.ContactName).IsOptional();

            Property(x => x.ProvinceID).IsOptional();
            Property(x => x.ID).IsOptional();
            Property(x => x.TownID).IsOptional();

           
        }
    }
}
