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
    public class CategoryController : Controller
    {
        CategoryService cs = new CategoryService();
        public ActionResult Index()
        {
            return View(cs.GetActive());
        }
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(Category item, HttpPostedFileBase fluResim)
        {

            if (ModelState.IsValid)
            {
                bool sonuc;
                string fileResult = FxFunction.ImageUpload(fluResim, FolderPath.Category, out sonuc);
                if (sonuc)
                {
                    item.ImagePath = fileResult;
                    bool eklemeSonucu = cs.Add(item);
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
            return View(cs.GetByID(id));
        }
        [HttpPost]
        public ActionResult Update(Category item, HttpPostedFileBase fluResim)
        {
            Category guncellenecek = cs.GetByID(item.ID);
            guncellenecek.CategoryName = item.CategoryName;
            guncellenecek.Description = item.Description;
            if (ModelState.IsValid)
            {
                if (fluResim != null)
                {
                    bool sonuc;
                    string fileResult = FxFunction.ImageUpload(fluResim, FolderPath.Category, out sonuc);
                    if (sonuc)
                    {
                        guncellenecek.ImagePath = fileResult;
                    }
                }
                bool eklemeSonucu = cs.Update(guncellenecek);
                if (eklemeSonucu)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = "Categori güncelleme işleminde bir hata oluştu";
                }
            }
            else
            {
                ViewBag.Message = "Girmiş olduğunuz bilgileri kontrol ediniz";
            }
            return View();
        }
        public ActionResult Delete(Guid id)
        {
            cs.Remove(id);
            return RedirectToAction("Index");
        }
    }
}