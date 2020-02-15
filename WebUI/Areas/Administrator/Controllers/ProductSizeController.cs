using Model.Entities;
using Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Areas.Administrator.Controllers
{
    public class ProductSizeController : Controller
    {
        ProductSizeService pss = new ProductSizeService();
        public ActionResult Index()
        {
            return View(pss.GetActive());
        }
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(ProductSize item)
        {
            bool sonuc = pss.Add(item);
            if (sonuc)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Size ekleme işlemi sırasında bir hata oluştu";
            }

            return View();
        }
        public ActionResult Update(Guid id)
        {
            return View(pss.GetByID(id));
        }
        [HttpPost]
        public ActionResult Update(ProductSize item)
        {
            ProductSize size = pss.GetByID(item.ID);
            size.Size = item.Size;
            bool sonuc = pss.Update(item);
            if (sonuc)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Size güncelleme işlemi sırasında bir hata oluştu";
            }

            return View();
        }
        public ActionResult Delete(Guid id)
        {
            pss.Remove(id);
            return RedirectToAction("Index");
        }
    }
}