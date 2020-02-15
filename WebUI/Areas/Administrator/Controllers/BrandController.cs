using Model.Entities;
using Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Areas.Administrator.Controllers
{
    public class BrandController : Controller
    {
        BrandService bs = new BrandService();
        public ActionResult Index()
        {
            return View(bs.GetAll());
        }
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Insert(Brand item,HttpPostedFileBase fluResim)
        {
           if (ModelState.IsValid)
            {
                bool sonuc;
                string fileResult = FxFunction.ImageUpload(fluResim, FolderPath.Brand, out sonuc);
               
                if (sonuc)
                {
                    item.ImagePath = fileResult;
                    bool eklemeSonucu = bs.Add(item);
                    if (eklemeSonucu)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Message = "Ekleme sırasında bir hata oluştu.";
                    }

                }
                else
                {
                    ViewBag.Message = fileResult;
                }
            }

            return View();
        }

        public ActionResult Update(Guid id)
        {
            return View(bs.GetByID(id));
        }
        [HttpPost]

        public ActionResult Update(Brand item,HttpPostedFileBase fluResim)
        {
            Brand guncellenecek = bs.GetByID(item.ID);
            guncellenecek.BrandName = item.BrandName;
            guncellenecek.Description = item.Description;
            if (fluResim != null)
            {
                bool sonuc;
                string fileResult = FxFunction.ImageUpload(fluResim, FolderPath.Category, out sonuc);
                if (sonuc)
                {
                    guncellenecek.ImagePath = fileResult;
                }
            }
            bool eklemeSonucu = bs.Update(guncellenecek);
            if (eklemeSonucu)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Categori güncelleme işleminde bir hata oluştu";
            }
            return View();
        }
          
        public ActionResult Delete(Guid id)
        {
            bs.Remove(id);
            return RedirectToAction("Index");
        }
    }
}