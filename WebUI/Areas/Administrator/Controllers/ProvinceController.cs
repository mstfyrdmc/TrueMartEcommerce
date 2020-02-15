using Model.Entities;
using Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Areas.Administrator.Controllers
{
    public class ProvinceController : Controller
    {
        ProvinceService ps = new ProvinceService();
        public ActionResult Index()
        {
            return View(ps.GetAll());
        }
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Province item)
        {
            if (ModelState.IsValid)
            {
                bool sonuc = ps.Add(item);
                if (sonuc)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = "İl ekleme işleminde bir hata oluştu";
                }
            }
            else
            {
                ViewBag.Message = "İl ekleme işleminde bir hata oluştu";
            }
            return View();
        }
        public ActionResult Update(Guid id)
        {
            return View(ps.GetByID(id));
        }

        [HttpPost]
        public ActionResult Update(Province item)
        {
            Province guncellenecek = ps.GetByID(item.ID);
            guncellenecek.ProvinceName = item.ProvinceName;

            if (ModelState.IsValid)
            {
                bool sonuc = ps.Update(item);
                if (sonuc)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = "İl güncelleme işleminde bir hata oluştu";
                }
            }
            else
            {
                ViewBag.Message = "İl güncelleme işleminde bir hata oluştu";
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