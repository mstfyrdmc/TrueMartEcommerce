using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class WebUIContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public WebUIContext() : base("name=WebUIContext")
        {
        }

        public System.Data.Entity.DbSet<Model.Entities.Order> Orders { get; set; }

        public System.Data.Entity.DbSet<Model.Entities.AppUser> AppUsers { get; set; }

        public System.Data.Entity.DbSet<Model.Entities.Shipper> Shippers { get; set; }

        public System.Data.Entity.DbSet<Model.Entities.ProductComment> ProductComments { get; set; }

        public System.Data.Entity.DbSet<Model.Entities.Product> Products { get; set; }

        public System.Data.Entity.DbSet<Model.Entities.OrderDetail> OrderDetails { get; set; }
    }
}
