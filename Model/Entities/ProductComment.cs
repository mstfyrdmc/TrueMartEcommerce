using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
  public  class ProductComment : CoreEntity
    {
        public Guid? ProductID { get; set; }
        public Guid? AppUserID { get; set; }
        public string Comment { get; set; }
        public int ProductLikes { get; set; }

        public virtual Product Product { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
