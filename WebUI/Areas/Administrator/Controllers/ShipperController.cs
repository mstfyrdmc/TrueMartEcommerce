using Model.Entities;
using Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Areas.Administrator.Controllers
{
    public class ShipperController : Controller
    {
        ShipperService ss = new ShipperService();
        ProvinceService ps = new ProvinceService();
        TownService ts = new TownService();
        public ActionResult Index()
        {
            return View(ss.GetActive());
        }
        public ActionResult Insert()
        {
            ViewBag.ProvinceID = new SelectList(ps.GetActive(), "ID", "ProvinceName");
            ViewBag.TownID = new SelectList(ts.GetActive(), "ID", "TownName");

            return View();
        }
        [HttpPost]
        public ActionResult Insert(Shipper item)
        {
            ViewBag.ProvinceID = new SelectList(ps.GetActive(), "ID", "ProvinceName",item.ProvinceID);
            ViewBag.TownID = new SelectList(ts.GetActive(), "ID", "TownName",item.TownID);


            if (ModelState.IsValid)
            {
                bool sonuc = ss.Add(item);
                if (sonuc)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = "Kargo şirketi ekleme işleminde bir hata oluştu";
                }
            }
            else
            {
                ViewBag.Message = "Kargo şirketi ekleme işleminde bir hata oluştu";
            }
            return View();
        }
        public ActionResult Update(Guid id)
        {
            Shipper guncellenecek = ss.GetByID(id);
            ViewBag.ProvinceID = new SelectList(ps.GetActive(), "ID", "ProvinceName",guncellenecek.ProvinceID);
            ViewBag.TownID = new SelectList(ts.GetActive(), "ID", "TownName",guncellenecek.TownID);

            return View(ss.GetByID(id));
        }
        [HttpPost]
        public ActionResult Update(Shipper item)
        {
            ViewBag.ProvinceID = new SelectList(ps.GetActive(), "ID", "ProvinceName",item.ProvinceID);
            ViewBag.TownID = new SelectList(ts.GetActive(), "ID", "TownName",item.TownID);

            Shipper guncellenecek = ss.GetByID(item.ID);
            guncellenecek.ShipperName = item.ShipperName;
            guncellenecek.EmailAddress = item.EmailAddress;
            guncellenecek.ProvinceID = item.ProvinceID;
            guncellenecek.TownID = item.TownID;
            

            if (ModelState.IsValid)
            {
                bool sonuc = ss.Update(item);
                if (sonuc)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = "Kargo şirketi güncelleme işleminde bir hata oluştu";
                }
            }
            else
            {
                ViewBag.Message = "Kargo şirketi güncelleme işleminde bir hata oluştu";
            }
            return View();
        }
        public ActionResult Delete(Guid id)
        {
            ss.Remove(id);
            return RedirectToAction("Index");
        }
    }
}