using Model.Entities;
using Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Areas.Administrator.Controllers
{
    public class SiteEmployeeController : Controller
    {
        SiteEmployeeService ec = new SiteEmployeeService();
        ProvinceService ps = new ProvinceService();
        TownService ts = new TownService();
        public ActionResult Index()
        {
            return View(ec.GetActive());
        }
        public ActionResult Insert()
        {
            ViewBag.ProvinceID = new SelectList(ps.GetActive(), "ID", "ProvinceName");
            ViewBag.TownID = new SelectList(ts.GetActive(), "ID", "TownName");
            return View();
        }
        [HttpPost]
        public ActionResult Insert(SiteEmployee item)
        {
            ViewBag.ProvinceID = new SelectList(ps.GetActive(), "ID", "ProvinceName", item.ProvinceID);
            ViewBag.TownID = new SelectList(ts.GetActive(), "ID", "TownName", item.TownID);

            if (ModelState.IsValid)
            {
                bool sonuc = ec.Add(item);
                if (sonuc)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = "Çalışan ekleme işleminde bir hata oluştu";
                }
            }
            else
            {
                ViewBag.Message = "Çalışan ekleme işleminde bir hata oluştu";
            }
            return View();
        }
        public ActionResult Update(Guid id)
        {
            SiteEmployee guncellenecek = ec.GetByID(id);
            ViewBag.ProvinceID = new SelectList(ps.GetActive(), "ID", "ProvinceName", guncellenecek.ProvinceID);
            ViewBag.TownID = new SelectList(ts.GetActive(), "ID", "TownName", guncellenecek.TownID);

            return View(ec.GetByID(id));
        }
        [HttpPost]
        public ActionResult Update(SiteEmployee item)
        {
            ViewBag.ProvinceID = new SelectList(ps.GetActive(), "ID", "ProvinceName", item.ProvinceID);
            ViewBag.TownID = new SelectList(ts.GetActive(), "ID", "TownName", item.TownID);

            SiteEmployee guncellenecek = ec.GetByID(item.ID);
            guncellenecek.Name = item.Name;
            guncellenecek.LastName = item.LastName;
            guncellenecek.HireDate = item.HireDate;
            guncellenecek.BirthDate = item.BirthDate;
            guncellenecek.Profession = item.Profession;
            guncellenecek.ProvinceID = item.ProvinceID;
            guncellenecek.TownID = item.TownID;
            
            if (ModelState.IsValid)
            {
                bool sonuc = ec.Update(guncellenecek);
                if (sonuc)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = "Çalışan güncelleme işleminde bir hata oluştu";
                }
            }
            else
            {
                ViewBag.Message = "Çalışan güncelleme işleminde bir hata oluştu";
            }
            return View();
        }
        public ActionResult Delete(Guid id)
        {
            ec.Remove(id);
            return RedirectToAction("Index");
        }

    }
}