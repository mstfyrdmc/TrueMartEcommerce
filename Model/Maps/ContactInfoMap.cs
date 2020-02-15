using Core.Map;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Maps
{
   public class ContactInfoMap : CoreMap<ContactInfo>
    {
        public ContactInfoMap()
        {
            ToTable("dbo.ContactInformation");
            Property(x => x.PhoneNumber).HasMaxLength(15).IsOptional();
            Property(x => x.EmailAddress).HasMaxLength(250).IsOptional();
            Property(x => x.FaxNo).HasMaxLength(15).IsOptional();
            Property(x => x.Address).IsOptional();
            Property(x => x.AppUserID).IsOptional();
            Property(x => x.ShipperID).IsOptional();//yeni
            Property(x => x.SiteEmployeeID).IsOptional();//yeni
            Property(x => x.SupplierID).IsOptional();//yeni
        }
    }
}
