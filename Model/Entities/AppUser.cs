using Core.Entity;
using Model.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
   public class AppUser  : CoreEntity
    {
        public Guid? ProvinceID { get; set; } 
        public Guid? TownID { get; set; }

        public string UserName { get; set; }
        public string EmailAdress { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public Sex Sex { get; set; }
        public bool IsAdmin { get; set; }

       

        public virtual Province Province { get; set; }
        public virtual Town Town { get; set; }

        public virtual List<Product> Products { get; set; }
        public virtual List<ProductComment> ProductComments { get; set; }
        public virtual List<Cart> Carts { get; set; }
        public virtual List<BankCard> BankCards{ get; set; } 
        
        public virtual List<Order> Orders{ get; set; }
        public virtual List<ContactInfo> ContactInfos{ get; set; }  

       

    }
}
