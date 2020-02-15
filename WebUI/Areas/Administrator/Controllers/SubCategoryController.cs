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
    public class SubCategoryController : Controller
    {
        SubCategoryService ssc = new SubCategoryService();
        CategoryService cs = new CategoryService();
        public ActionResult Index()
        {
            return View(ssc.GetAll());
        }

        public ActionResult Insert()
        {
         ViewBag.CategoryID = new SelectList(cs.GetActive(), "ID", "CategoryName");
            return View();
        }
        [HttpPost]
        public ActionResult Insert(SubCategory item,HttpPostedFileBase fluResim)
        {
            ViewBag.CategoryID = new SelectList(cs.GetActive(), "ID", "CategoryName", item.CategoryID);
            if (ModelState.IsValid)
            {
                bool sonuc;
                string fileResult = FxFunction.ImageUpload(fluResim, FolderPath.SubCategory, out sonuc);
                if (sonuc)
                {
                    item.ImagePath = fileResult;
                }
                else
                {
                    ViewBag.Message = fileResult;
                }
                bool eklemeSonucu = ssc.Add(item);
                if (eklemeSonucu)
                {
                    ViewBag.Message = "Ekleme başarıyla gerçekleşti";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = "Ekleme sırasında bir hata oluştu.";
                }
            }
            return View();
        }

        public ActionResult Update(Guid id)
        {
            SubCategory subcat = ssc.GetByID(id);
            ViewBag.CategoryID = new SelectList(cs.GetActive(), "ID", "CategoryName", subcat.CategoryID);
            return View(ssc.GetByID(id));
        }
        [HttpPost]
        public ActionResult Update(SubCategory item ,HttpPostedFileBase fluResim)
        {
            ViewBag.CategoryID = new SelectList(cs.GetActive(), "ID", "CategoryName", item.CategoryID);
            SubCategory guncellenecek = ssc.GetByID(item.ID);
            guncellenecek.SubCategoryName = item.SubCategoryName;
            guncellenecek.Description = item.Description;
            guncellenecek.CategoryID = item.CategoryID;
            if (ModelState.IsValid)
            {
                if (fluResim != null)
                {
                    bool sonuc;
                    string fileResult = FxFunction.ImageUpload(fluResim, FolderPath.SubCategory, out sonuc);
                    if (sonuc)
                    {
                        guncellenecek.ImagePath = fileResult;
                    }
                }
                bool eklemeSonucu = ssc.Update(guncellenecek);
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
            ssc.Remove(id);
            return RedirectToAction("Index");
        }
    }
}