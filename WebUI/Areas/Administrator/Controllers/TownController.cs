using Model.Entities;
using Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Areas.Administrator.Controllers
{
    public class TownController : Controller
    {
        TownService ts = new TownService();
        ProvinceService ps = new ProvinceService();
        public ActionResult Index()
        {
            return View(ts.GetAll());
        }
        
        public ActionResult Insert()
        {
            
            
            ViewBag.ProvinceID = new SelectList(ps.GetActive(), "ID", "ProvinceName");
            return View();
        }
        [HttpPost]
        public ActionResult Insert(Town item)
        {
            ViewBag.ProvinceID = new SelectList(ps.GetActive(), "ID","ProvinceName",item.ProvinceID);
            bool sonuc = ts.Add(item);
            if (sonuc)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "İlçe ekleme işlemi sırasında bir hata oluştu";
            }
            return View();
        }
        public ActionResult Update(Guid id)
        {
            Town guncellenecek = ts.GetByID(id);
            ViewBag.ProvinceID = new SelectList(ps.GetActive(), "ID", "ProvinceName", guncellenecek.ProvinceID);
            return View(guncellenecek);
        }
        [HttpPost]
        public ActionResult Update(Town item)
        {
            ViewBag.ProvinceID = new SelectList(ps.GetActive(), "ID", "ProvinceName", item.ProvinceID);
            Town guncellenecek = ts.GetByID(item.ID);
            guncellenecek.TownName = item.TownName;
            guncellenecek.ProvinceID = item.ProvinceID;

            bool sonuc = ts.Update(guncellenecek);
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
            ts.Remove(id);
            return RedirectToAction("Index");
        }
    }
}