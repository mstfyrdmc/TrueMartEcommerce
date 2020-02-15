using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
   public class Product : CoreEntity
    {
       
        public string ProductName { get; set; }
        public decimal? Price { get; set; }
        public string Description { get; set; }
        public int UnitsInStock { get; set; }

        public Guid? AppUserID { get; set; }
        public Guid BrandID { get; set; }
        public Guid SupplierID { get; set; }
        public Guid CategoryID { get; set; }
        public Guid? SubCategoryID { get; set; }
        public Guid? SubSubCategoryID { get; set; }

        public virtual Category Category { get; set; }
        public virtual AppUser AppUser { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public virtual SubSubCategory SubSubCategory { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual Supplier Supplier { get; set; }
        


        public virtual List<Image> Images { get; set; }
        public virtual List<ProductComment> ProductComments { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
        public virtual List<ProductDetail> ProductDetails { get; set; }
        
    }
}
