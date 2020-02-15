using Core.Map;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Maps
{
   public class BankCardMap : CoreMap<BankCard>
    {
        public BankCardMap()
        {

            ToTable("BankCard");
            Property(x => x.CardOwnerName).HasMaxLength(50).IsRequired();
            Property(x => x.CardOwnerLastName).HasMaxLength(50).IsRequired();
            Property(x => x.CardNo).HasMaxLength(16).IsRequired();
            Property(x => x.BestBeforeDate).HasColumnType("date").IsRequired();
            Property(x => x.CardCVC).HasMaxLength(3).IsRequired();
        }
    }
}
