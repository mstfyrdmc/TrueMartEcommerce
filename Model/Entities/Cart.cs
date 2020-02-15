using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
   public class Cart : CoreEntity
    {
        public Guid? AppUserID { get; set; }

        public Guid? ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal? Price { get; set; }
        public int Quentity { get; set; }
        public string ImagePath { get; set; }

        public virtual AppUser AppUser { get; set; }
        public virtual Product Product { get; set; }

    }
}
