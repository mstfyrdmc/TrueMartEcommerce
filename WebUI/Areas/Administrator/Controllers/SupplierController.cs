using Model.Context;
using Model.Entities;
using Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Areas.Administrator.Controllers
{
    public class SupplierController : Controller
    {
        SupplierService sc = new SupplierService();
        TownService ts = new TownService();
        ProvinceService ps = new ProvinceService();
        ProjectContext db = new ProjectContext();
        public ActionResult Index()
        {
           
            return View(sc.GetActive());
        }
        public ActionResult Insert()
        {
            
            ViewBag.ProvinceID = new SelectList(ps.GetActive(), "ID", "ProvinceName");
            ViewBag.TownID = new SelectList(ts.GetActive(), "ID", "TownName");

            return View();
        }
        [HttpPost]
        public ActionResult Insert(Supplier item)
        {
            ViewBag.ProvinceID = new SelectList(ps.GetActive(), "ID", "ProvinceName", item.ProvinceID);
            ViewBag.Town = new SelectList(ts.GetActive(), "ID", "TownName", item.TownID);

            if (ModelState.IsValid)
            {
                bool sonuc = sc.Add(item);
                if (sonuc)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = "Tedarikçi ekleme işleminde bir hata oluştu";
                }
            }
            else
            {
                ViewBag.Message = "Tedarikçi ekleme işleminde bir hata oluştu";
            }
            return View();
        }


        public JsonResult GetTownByProvince(Guid id)
        {
            List<Town> towns = new List<Town>();
            if (id !=null)
            {
               
                towns = db.Towns.Where(m => m.ProvinceID == id).ToList();
            }
            else
            {
                towns.Insert(0, new Town { TownName = "--Select a town first--" });
            }
            var result = (from r in towns
                          select new
                          {
                              id = r.ID,
                              name = r.TownName
                          }).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Update(Guid id)
        {
            ViewBag.ProvinceID = new SelectList(ps.GetActive(), "ID", "ProvinceName");
            ViewBag.TownID = new SelectList(ts.GetActive(), "ID", "TownName");

            return View(sc.GetByID(id));
        }

       

        [HttpPost]
        public ActionResult Update(Supplier item)
        {
            ViewBag.ProvinceID = new SelectList(ps.GetActive(), "ID", "ProvinceName", item.ProvinceID);
            ViewBag.TownID = new SelectList(ps.GetActive(), "ID", "TownName", item.TownID);

            Supplier guncellenecek = sc.GetByID(item.ID);
            guncellenecek.CompanyName = item.CompanyName;
            guncellenecek.ContactName = item.ContactName;
            guncellenecek.ProvinceID = item.ProvinceID;
            guncellenecek.TownID = item.TownID;

          
            if (ModelState.IsValid)
            {
                bool sonuc = sc.Update(guncellenecek);
                if (sonuc)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = "Tedarikçi güncelleme işleminde bir hata oluştu";
                }
            }
            else
            {
                ViewBag.Message = "Tedarikçi güncelleme işleminde bir hata oluştu";
            }
            return View();
        }
        public ActionResult Delete(Guid id)
        {
            sc.Remove(id);
            return RedirectToAction("Index");
        }
    }
}