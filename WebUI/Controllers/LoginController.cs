using Model.Context;
using Model.Entities;
using Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class LoginController : Controller
    {
        AppUserService aus = new AppUserService();
        CategoryService cs = new CategoryService();
        SubCategoryService sub = new SubCategoryService();
        SubSubCategoryService subsub = new SubSubCategoryService();
        ProvinceService ps = new ProvinceService();
        TownService ts = new TownService();
        CartService cart = new CartService();
        OrderService os = new OrderService();
        ProjectContext db = new ProjectContext();

       
        public ActionResult Login()
        {

            ViewData["Categories"] = cs.GetActive();
            ViewData["SubCategories"] = sub.GetActive();
            ViewData["SubSubCategories"] = subsub.GetActive();
            ViewData["Cart"] = cart.GetActive();
            ViewData["AppUser"] = aus.GetActive();
            ViewData["Order"] = os.GetActive();
            ViewData["Province"] = ps.GetActive();
            ViewData["Town"] = ts.GetActive();
            
            return View();
        }
        [HttpPost]
        public ActionResult Login(AppUser item)
        {
            ViewData["Categories"] = cs.GetActive();
            ViewData["SubCategories"] = sub.GetActive();
            ViewData["SubSubCategories"] = subsub.GetActive();
            ViewData["Cart"] = cart.GetActive();
            ViewData["AppUser"] = aus.GetActive();
            ViewData["Order"] = os.GetActive();
            ViewData["Province"] = ps.GetActive();
            ViewData["Town"] = ts.GetActive();
            AppUser gelen = aus.FindByUsername(item.UserName);



            bool isAdministrator = gelen.IsAdmin;
            if (aus.Any(m => m.UserName == item.UserName && m.Password == item.Password))
            {


                if (isAdministrator)
                {
                    Session["oturum"] = gelen;
                    return RedirectToAction("Index", "Product", new { area = "Administrator" });
                }
                else
                {
                    Session["oturum"] = gelen;
                    ViewBag.UserName = gelen.UserName;
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ViewBag.Messages = "Bilgilerinizi kontrol ederek tekrar giriniz";
            }


            return View();
        }
        
        public ActionResult Register()
        {
            ViewData["Categories"] = cs.GetActive();
            ViewData["SubCategories"] = sub.GetActive();
            ViewData["SubSubCategories"] = subsub.GetActive();
            ViewData["Cart"] = cart.GetActive();
            ViewData["AppUser"] = aus.GetActive();
            ViewData["Order"] = os.GetActive();
            ViewBag.ProvinceID = new SelectList(ps.GetActive(), "ID", "ProvinceName");
            ViewBag.TownID = new SelectList(ts.GetActive(), "ID", "TownName");
           
            return View();
        }
        [HttpPost]
        public ActionResult Register(AppUser item)
        {
            ViewData["Categories"] = cs.GetActive();
            ViewData["SubCategories"] = sub.GetActive();
            ViewData["SubSubCategories"] = subsub.GetActive();
            ViewData["Cart"] = cart.GetActive();
            ViewData["AppUser"] = aus.GetActive();
            ViewData["Order"] = os.GetActive();
            ViewBag.ProvinceID = new SelectList(ps.GetActive(), "ID", "ProvinceName", item.ProvinceID);
            ViewBag.TownID = new SelectList(ts.GetActive(), "ID", "TownName", item.TownID);
           

            if (ModelState.IsValid)
            {

                bool sonuc = aus.Add(item);
                if (sonuc)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Message = "Kullanıcı ekleme işleminde bir hata oluştu";
                }
            }
            else
            {
                ViewBag.Message = "Kullanıcı ekleme işleminde bir hata oluştu";
            }
            return View();
        }
        public JsonResult GetTownByProvince(Guid id)
        {
            List<Town> towns = new List<Town>();
            if (id != null)
            {

                towns = db.Towns.Where(m => m.ProvinceID == id).ToList();
            }
            else
            {
                towns.Insert(0, new Town { TownName = "--Select a category first--" });
            }
            var result = (from r in towns
                          select new
                          {
                              id = r.ID,
                              name = r.TownName
                          }).ToList();

            return Json(result,JsonRequestBehavior.AllowGet);
        }
        public ActionResult UpdateUsers(Guid id)
        {
            ViewData["Categories"] = cs.GetActive();
            ViewData["SubCategories"] = sub.GetActive();
            ViewData["SubSubCategories"] = subsub.GetActive();
            ViewData["Cart"] = cart.GetActive();
            ViewData["AppUser"] = aus.GetActive();
            ViewData["Order"] = os.GetActive();
            ViewBag.ProvinceID = new SelectList(ps.GetActive(), "ID", "ProvinceName");
            ViewBag.TownID = new SelectList(ts.GetActive(), "ID", "TownName");
           

            return View(aus.GetByID(id));
        }
        [HttpPost]
        public ActionResult UpdateUsers(AppUser item)
        {
            ViewData["Categories"] = cs.GetActive();
            ViewData["SubCategories"] = sub.GetActive();
            ViewData["SubSubCategories"] = subsub.GetActive();
            ViewData["Cart"] = cart.GetActive();
            ViewData["AppUser"] = aus.GetActive();
            ViewData["Order"] = os.GetActive();
            
            ViewBag.ProvinceID = new SelectList(ps.GetActive(), "ID", "ProvinceName", item.ProvinceID);
            ViewBag.TownID = new SelectList(ts.GetActive(), "ID", "TownName", item.TownID);
        

            AppUser guncellenecek = aus.GetByID(item.ID);
            guncellenecek.Name = item.Name;
            guncellenecek.Password = item.Password;
            guncellenecek.Sex = item.Sex;
            guncellenecek.Surname = item.Surname;
            guncellenecek.UserName = item.UserName;
            guncellenecek.EmailAdress = item.EmailAdress;
            guncellenecek.BirthDate = item.BirthDate;
            guncellenecek.TownID = item.TownID;
            guncellenecek.ProvinceID = item.ProvinceID;


            bool sonuc = aus.Update(guncellenecek);
            if (sonuc)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "Güncelleme işlemi esnasında bir problem yaşandı";
            }
            return RedirectToAction("Index", "Home");
        }


        public ActionResult Logout()
        {
            ViewData["Categories"] = cs.GetActive();
            ViewData["SubCategories"] = sub.GetActive();
            ViewData["SubSubCategories"] = subsub.GetActive();
            ViewData["Cart"] = cart.GetActive();
            ViewData["AppUser"] = aus.GetActive();
            ViewData["Order"] = os.GetActive();
            ViewData["Province"] = ps.GetActive();
            ViewData["Town"] = ts.GetActive();

           
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}