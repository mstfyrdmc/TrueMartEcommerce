using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
   public class BankCard : CoreEntity
    {
        public Guid? AppUserID { get; set; }
        public string CardOwnerName { get; set; }
        public string CardOwnerLastName { get; set; }
        public string CardNo { get; set; }
        public DateTime BestBeforeDate { get; set; }

        public string CardCVC { get; set; }

        public virtual AppUser AppUser { get; set; }
    }
}
