using Core.Entity;
using Model.Entities;
using Model.Maps;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Model.Context
{
   public class ProjectContext : DbContext
    {
        public ProjectContext()
        {
            
            Database.Connection.ConnectionString = "Server=.;Database=TrueMartDataBase;UID=sa;PWD=123";
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new SubCategoryMap());
            modelBuilder.Configurations.Add(new SubSubCategoryMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new ProductCommentMap());
            modelBuilder.Configurations.Add(new AppUserMap());
            modelBuilder.Configurations.Add(new BrandMap());
            modelBuilder.Configurations.Add(new CartMap());
            modelBuilder.Configurations.Add(new ImageMap());
            modelBuilder.Configurations.Add(new BankCardMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new OrderDetailMap());
            modelBuilder.Configurations.Add(new ShipperMap());
            modelBuilder.Configurations.Add(new ContactInfoMap());
            modelBuilder.Configurations.Add(new SiteEmployeeMap());
            modelBuilder.Configurations.Add(new ProvinceMap());
            modelBuilder.Configurations.Add(new TownMap());
            modelBuilder.Configurations.Add(new SupplierMap());
            modelBuilder.Configurations.Add(new ProductColourMap());
            modelBuilder.Configurations.Add(new ProductDetailMap());
            modelBuilder.Configurations.Add(new ProductSizeMap());
            
           
     

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<SubSubCategory> SubSubCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductComment> ProductComments { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<BankCard> BankCards { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<SiteEmployee> SiteEmployees { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<ProductColour> ProductColours { get; set; }



       

        public override int SaveChanges()
        {
            var ModifiedEntities = ChangeTracker.Entries().Where(m => m.State == EntityState.Modified || m.State == EntityState.Added).ToList();
            DateTime datetime = DateTime.Now;
            string ip = HttpContext.Current.Request.UserHostAddress;
            foreach (var item in ModifiedEntities)
            {
                CoreEntity entity = item.Entity as CoreEntity;
                if (item != null)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            entity.CreatedIP = ip;
                            entity.CreatedDate = datetime;
                            break;
                        case EntityState.Modified:
                            entity.ModifiedIP = ip;
                            entity.ModifiedDate = datetime;
                            break;
                    }
                }
            }
            
            
                return base.SaveChanges();
            
            
               
            }
                
            
            
        }
    }

