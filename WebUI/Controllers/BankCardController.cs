using Model.Entities;
using Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class BankCardController : Controller
    {
        
        BankCardService bc = new BankCardService();
        AppUserService aus = new AppUserService();
        CategoryService cs = new CategoryService();
        SubCategoryService sub = new SubCategoryService();
        SubSubCategoryService subsub = new SubSubCategoryService();
        OrderService os = new OrderService();
        public ActionResult Index()
        {
            ViewData["Categories"] = cs.GetActive();
            ViewData["SubCategories"] = sub.GetActive();
            ViewData["SubSubCategories"] = subsub.GetActive();
            ViewData["Order"] = os.GetActive();
            ViewData["BankCart"] = bc.GetActive();

            AppUser gelen = (AppUser)Session["oturum"];
            ViewBag.Categories = cs.GetActive();
            ViewBag.SubCategories = sub.GetActive();
            ViewBag.SubSubCategories = subsub.GetActive();
            ViewBag.Order = os.GetActive();
            return View(bc.GetAll());
        }
        public ActionResult Insert()
        {
            ViewData["Categories"] = cs.GetActive();
            ViewData["SubCategories"] = sub.GetActive();
            ViewData["SubSubCategories"] = subsub.GetActive();
            ViewData["Order"] = os.GetActive();
            ViewData["BankCart"] = bc.GetActive();
            ViewBag.AppUserID = new SelectList(aus.GetActive(), "ID", "UserName");
            
            return View();
        }
        [HttpPost]
        public ActionResult Insert(BankCard item)
        {
            ViewData["Categories"] = cs.GetActive();
            ViewData["SubCategories"] = sub.GetActive();
            ViewData["SubSubCategories"] = subsub.GetActive();
            ViewData["Order"] = os.GetActive();
            ViewData["BankCart"] = bc.GetActive();
            AppUser gelen = (AppUser)Session["oturum"];
            if (ModelState.IsValid)
            {
                item.AppUserID = gelen.ID;
                bool sonuc = bc.Add(item);
                if (sonuc)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = "Kredi Kartı ekleme işleminde bir hata oluştu";
                }
            }
            else
            {
                ViewBag.Message = "Kredi Kartı ekleme işleminde bir hata oluştu";
            }
            return View();
        }
        public ActionResult Update(Guid id)
        {
            ViewData["Categories"] = cs.GetActive();
            ViewData["SubCategories"] = sub.GetActive();
            ViewData["SubSubCategories"] = subsub.GetActive();
            ViewData["Order"] = os.GetActive();
            ViewData["BankCart"] = bc.GetActive();
            ViewBag.AppUserID = new SelectList(aus.GetActive(), "ID", "UserName");
            BankCard guncellenecek = bc.GetByID(id);
            return View(bc.GetByID(id));
        }
        [HttpPost]
        public ActionResult Update(BankCard item)
        {
            ViewData["Categories"] = cs.GetActive();
            ViewData["SubCategories"] = sub.GetActive();
            ViewData["SubSubCategories"] = subsub.GetActive();
            ViewData["Order"] = os.GetActive();
            ViewData["BankCart"] = bc.GetActive();
            ViewBag.AppUserID = new SelectList(aus.GetActive(), "ID", "UserName", item.AppUserID);
        

            AppUser gelen = (AppUser)Session["oturum"];
            BankCard guncellenecek = bc.GetByID(item.ID);
            guncellenecek.CardOwnerName = item.CardOwnerName;
            guncellenecek.CardOwnerLastName = item.CardOwnerLastName;
            guncellenecek.CardNo = item.CardNo;
            guncellenecek.CardCVC = item.CardCVC;
            guncellenecek.BestBeforeDate = item.BestBeforeDate;
            guncellenecek.AppUserID = gelen.ID;

            bool sonuc = bc.Update(guncellenecek);
            if (sonuc)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Güncelleme işlemi esnasında bir problem yaşandı";
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(Guid id)
        {
            bc.Remove(id);
            return RedirectToAction("Index");
        }
    }
}