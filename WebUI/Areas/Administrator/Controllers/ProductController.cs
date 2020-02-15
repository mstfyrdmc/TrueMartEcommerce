using Model.Context;
using Model.Entities;
using Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Areas.Administrator.Controllers
{
    public class ProductController : Controller
    {
        ProductService ps = new ProductService();
        CategoryService cs = new CategoryService();
        SubCategoryService ssc = new SubCategoryService();
        SubSubCategoryService sc = new SubSubCategoryService();
        AppUserService ap = new AppUserService();
        BrandService bs = new BrandService();
        SupplierService sp = new SupplierService();
        ProjectContext db = new ProjectContext();
        public ActionResult Index()
        {
            return View(ps.GetAll());
        }

        public ActionResult Insert()
        {
           
            ViewBag.CategoryID = new SelectList(cs.GetActive(), "ID", "CategoryName");
            ViewBag.SubCategoryID = new SelectList(ssc.GetActive(), "ID", "SubCategoryName");
            ViewBag.SubSubCategoryID = new SelectList(sc.GetActive(), "ID", "SubSubCategoryName");
            ViewBag.AppUserID = new SelectList(ap.GetActive().Where(m=> m.IsAdmin==true), "ID", "UserName");
            ViewBag.BrandID = new SelectList(bs.GetActive(), "ID", "BrandName");
            ViewBag.SupplierID = new SelectList(sp.GetActive(), "ID", "CompanyName");

            
            return View();
            
        }
        
        [HttpPost]
        public ActionResult Insert(Product item)
        {
            ViewBag.CategoryID = new SelectList(cs.GetActive(), "ID", "CategoryName", item.CategoryID);
            ViewBag.SubCategoryID = new SelectList(ssc.GetActive(), "ID", "SubCategoryName", item.SubCategoryID);
            ViewBag.SubSubCategoryID = new SelectList(sc.GetActive(), "ID", "SubSubCategoryName", item.SubSubCategoryID);
            ViewBag.AppUserID = new SelectList(ap.GetActive().Where(m => m.IsAdmin == true), "ID", "UserName", item.AppUserID);
            ViewBag.BrandID = new SelectList(bs.GetActive(), "ID", "BrandName", item.BrandID);
            ViewBag.SupplierID = new SelectList(sp.GetActive(), "ID", "CompanyName", item.SupplierID);
           
            
            bool sonuc = ps.Add(item);
            if (sonuc)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Ürün ekleme işlemi sırasında bir hata oluştu";
            }

            return View();

        }

        public ActionResult GetSubCategories(Guid? id)
        {
           
           
                var subCategories = new List<SubCategory>();
                var filteredCategories = db.SubCategories.Where(m => m.CategoryID == id).ToList();
                return Json(filteredCategories, JsonRequestBehavior.AllowGet);
            
          
        }
      
        public ActionResult Update(Guid id)
        {
            Product product = ps.GetByID(id);
            ViewBag.CategoryID = new SelectList(cs.GetActive(), "ID", "CategoryName", product.CategoryID);
            ViewBag.SubCategoryID = new SelectList(ssc.GetActive(), "ID", "SubCategoryName", product.SubCategoryID);
            ViewBag.SubSubCategoryID = new SelectList(sc.GetActive(), "ID", "SubSubCategoryName", product.SubSubCategoryID);
            ViewBag.AppUserID = new SelectList(ap.GetActive().Where(m => m.IsAdmin == true), "ID", "UserName", product.AppUserID);
            ViewBag.BrandID = new SelectList(bs.GetActive(), "ID", "BrandName", product.BrandID);
            ViewBag.SupplierID = new SelectList(sp.GetActive(), "ID", "CompanyName", product.SupplierID);
            
            return View(ps.GetByID(id));
        }
        [HttpPost]
        public ActionResult Update(Product item)
        {
            ViewBag.CategoryID = new SelectList(cs.GetActive(), "ID", "CategoryName", item.CategoryID);
            ViewBag.SubCategoryID = new SelectList(ssc.GetActive(), "ID", "SubCategoryName", item.CategoryID);
            ViewBag.SubSubCategoryID = new SelectList(ssc.GetActive(), "ID", "SubSubCategoryName", item.CategoryID);
            ViewBag.AppUserID = new SelectList(ap.GetActive().Where(m => m.IsAdmin == true), "ID", "UserName", item.AppUserID);
            ViewBag.BrandID = new SelectList(bs.GetActive(), "ID", "BrandName", item.BrandID);
            ViewBag.SupplierID = new SelectList(sp.GetActive(), "ID", "CompanyName", item.SupplierID);
         

            Product guncellenecek = ps.GetByID(item.ID);
            guncellenecek.ProductName = item.ProductName;
            guncellenecek.Description = item.Description;
            guncellenecek.Price = item.Price;
            guncellenecek.UnitsInStock = item.UnitsInStock;
            guncellenecek.CategoryID = item.CategoryID;
            guncellenecek.SubCategoryID = item.SubCategoryID;
            guncellenecek.SubSubCategoryID = item.SubSubCategoryID;

            bool sonuc = ps.Update(guncellenecek);
            if (sonuc)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Ürün güncelleme işlemi esnasında bir problem yaşandı";
            }

            return View();
        }
        public ActionResult Delete(Guid id)
        {
            ps.Remove(id);
            return RedirectToAction("Index");
        }
    }
}