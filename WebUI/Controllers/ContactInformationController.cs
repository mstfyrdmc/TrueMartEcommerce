using Model.Entities;
using Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class ContactInformationController : Controller
    {
        ProductService ps = new ProductService();
        CategoryService cs = new CategoryService();
        SubCategoryService sub = new SubCategoryService();
        SubSubCategoryService subsub = new SubSubCategoryService();
        ImageService img = new ImageService();
        ProductCommentService pcs = new ProductCommentService();
        BrandService bs = new BrandService();
        ContactInfoService info = new ContactInfoService();
        AppUserService aus = new AppUserService();
        OrderService os = new OrderService();
        public ActionResult Index()
        {
            ViewData["Categories"] = cs.GetActive();
            ViewData["SubCategories"] = sub.GetActive();
            ViewData["SubSubCategories"] = subsub.GetActive();
            ViewData["Order"] = os.GetActive();
            ViewData["Product"] = ps.GetActive();
            ViewData["Image"] = img.GetActive();
            ViewData["Brands"] = bs.GetActive();
            ViewData["ContactInfo"] = info.GetActive();
         
            
            AppUser gelen = (AppUser)Session["oturum"];
            return View(info.GetActive());
        }
        public ActionResult Insert()
        {

            ViewData["Categories"] = cs.GetActive();
            ViewData["SubCategories"] = sub.GetActive();
            ViewData["SubSubCategories"] = subsub.GetActive();
            ViewData["Order"] = os.GetActive();
            ViewData["Product"] = ps.GetActive();
            ViewData["Image"] = img.GetActive();
            ViewData["Brands"] = bs.GetActive();
            ViewData["ContactInfo"] = info.GetActive();

            AppUser gelen = (AppUser)Session["oturum"];
            return View();
        }
        [HttpPost]
        public ActionResult Insert(ContactInfo item)
        {

            ViewData["Categories"] = cs.GetActive();
            ViewData["SubCategories"] = sub.GetActive();
            ViewData["SubSubCategories"] = subsub.GetActive();
            ViewData["Order"] = os.GetActive();
            ViewData["Product"] = ps.GetActive();
            ViewData["Image"] = img.GetActive();
            ViewData["Brands"] = bs.GetActive();
            ViewData["ContactInfo"] = info.GetActive();

            AppUser gelen = (AppUser)Session["oturum"];

            item.AppUserID = gelen.ID;

            bool sonuc = info.Add(item);
            if (sonuc)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "İletişim bilgisi ekleme işlemi sırasında bir hata oluştu";
            }
            return View();
        }
        public ActionResult Update(Guid id)
        {
            ViewData["Categories"] = cs.GetActive();
            ViewData["SubCategories"] = sub.GetActive();
            ViewData["SubSubCategories"] = subsub.GetActive();
            ViewData["Order"] = os.GetActive();
            ViewData["Product"] = ps.GetActive();
            ViewData["Image"] = img.GetActive();
            ViewData["Brands"] = bs.GetActive();
            ViewData["ContactInfo"] = info.GetActive();

            AppUser gelen = (AppUser)Session["oturum"];
            ContactInfo guncellenecek = info.GetByID(id);
            return View(guncellenecek);
        }
        [HttpPost]
        public ActionResult Update(ContactInfo item)
        {

            ViewData["Categories"] = cs.GetActive();
            ViewData["SubCategories"] = sub.GetActive();
            ViewData["SubSubCategories"] = subsub.GetActive();
            ViewData["Order"] = os.GetActive();
            ViewData["Product"] = ps.GetActive();
            ViewData["Image"] = img.GetActive();
            ViewData["Brands"] = bs.GetActive();
            ViewData["ContactInfo"] = info.GetActive();

            AppUser gelen = (AppUser)Session["oturum"];
            ContactInfo guncellenecek = info.GetByID(item.ID);
            guncellenecek.Address = item.Address;
            guncellenecek.AppUserID = gelen.ID;
            guncellenecek.EmailAddress = item.EmailAddress;
            guncellenecek.FaxNo = item.FaxNo;
            guncellenecek.PhoneNumber = item.PhoneNumber;
            guncellenecek.ShipperID = item.ShipperID;
            guncellenecek.SiteEmployeeID = item.SiteEmployeeID;
            guncellenecek.SupplierID = item.SupplierID;
            bool sonuc = info.Update(guncellenecek);
            if (sonuc)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Güncelleme işlemi esnasında bir problem yaşandı";
            }
            return View();
        }
        public ActionResult Delete(Guid id)
        {

            ViewData["Categories"] = cs.GetActive();
            ViewData["SubCategories"] = sub.GetActive();
            ViewData["SubSubCategories"] = subsub.GetActive();
            ViewData["Order"] = os.GetActive();
            ViewData["Product"] = ps.GetActive();
            ViewData["Image"] = img.GetActive();
            ViewData["Brands"] = bs.GetActive();
            ViewData["ContactInfo"] = info.GetActive();

            AppUser gelen = (AppUser)Session["oturum"];
            info.Remove(id);
            return RedirectToAction("Index");
        }
    }
}