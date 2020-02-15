using Model.Entities;
using Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Areas.Administrator.Controllers
{
    public class AppUserController : Controller
    {
        AppUserService ab = new AppUserService();
        ContactInfoService cis = new ContactInfoService();
        ProvinceService ps = new ProvinceService();
        TownService ts = new TownService();
        public ActionResult Index()
        {
            return View(ab.GetAll());

        }
        public ActionResult Insert()
        {
            ViewBag.ProvinceID = new SelectList(ps.GetActive(), "ID", "ProvinceName");
            ViewBag.TownID = new SelectList(ts.GetActive(), "ID", "TownName");
            return View();
        }
        [HttpPost]
        public ActionResult Insert(AppUser item)
        {
            ViewBag.ProvinceID = new SelectList(ps.GetActive(), "ID", "ProvinceName", item.ProvinceID);
            ViewBag.TownID = new SelectList(ts.GetActive(), "ID", "TownName", item.TownID);
            if (ModelState.IsValid)
            {
                bool sonuc = ab.Add(item);
                if (sonuc)
                {
                    return RedirectToAction("Index");
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

        public ActionResult Update(Guid id)
        {
            ViewBag.ProvinceID = new SelectList(ps.GetActive(), "ID", "ProvinceName");
            ViewBag.TownID = new SelectList(ts.GetActive(), "ID", "TownName");
            return View(ab.GetByID(id));
        }
        [HttpPost]
        public ActionResult Update(AppUser item)
        {
            ViewBag.ProvinceID = new SelectList(ps.GetActive(), "ID", "ProvinceName", item.ProvinceID);
            ViewBag.TownID = new SelectList(ts.GetActive(), "ID", "TownName", item.TownID);
            AppUser guncelle = ab.GetByID(item.ID);
            guncelle.Name = item.Name;
            guncelle.Surname = item.Surname;
            guncelle.UserName = item.UserName;
            guncelle.EmailAdress = item.EmailAdress;
            guncelle.Sex = item.Sex;
            guncelle.Password = item.Password;
            guncelle.BirthDate = item.BirthDate;
            guncelle.TownID = item.TownID;
            guncelle.ProvinceID = item.ProvinceID;

            bool sonuc = ab.Update(guncelle);
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
            ab.Remove(id);
            return RedirectToAction("Index");
        }

    }
}