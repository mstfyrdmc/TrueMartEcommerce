using Core.Entity.Enum;
using Model.Entities;
using Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        List<Sepetim> sepetim;
        ProductService ps = new ProductService();
        CartService cs = new CartService();
        AppUserService ap = new AppUserService();
        CategoryService css = new CategoryService();
        SubCategoryService sub = new SubCategoryService();
        SubSubCategoryService subsub = new SubSubCategoryService();
        ImageService imser = new ImageService();
        OrderService os = new OrderService();

        public ActionResult CartList()
        {
            ViewData["Categories"] = css.GetActive();
            ViewData["SubCategories"] = sub.GetActive();
            ViewData["SubSubCategories"] = subsub.GetActive();
            ViewData["Order"] = os.GetActive();
            ViewData["Image"] = imser.GetActive();
            ViewData["Cart"] = cs.GetActive();
            ViewData["AppUser"] = ap.GetActive();
            ViewData["Product"] = ps.GetActive();
            ViewData["Order"] = os.GetActive();

            cs.GetAll();
            AppUser gelen = (AppUser)Session["oturum"];
            return View((List<Sepetim>)Session["sepetim"]);

        }

        public ActionResult AddToCart(Guid id, Cart item, string detay)
        {
            ViewData["Categories"] = css.GetActive();
            ViewData["SubCategories"] = sub.GetActive();
            ViewData["SubSubCategories"] = subsub.GetActive();
            ViewData["Order"] = os.GetActive();
            ViewData["Image"] = imser.GetActive();
            ViewData["Cart"] = cs.GetActive();
            ViewData["AppUser"] = ap.GetActive();
            ViewData["Product"] = ps.GetActive();
            ViewData["Order"] = os.GetActive();


            AppUser gelen = (AppUser)Session["oturum"];
            Product gelenUrun = ps.GetByID(id);

            List<Sepetim> sepetim;
            if (Session["sepetim"] == null)
            {
                sepetim = new List<Sepetim>();
            }
            else
            {
                sepetim = (List<Sepetim>)Session["sepetim"];

            }


            if (sepetim.Count < 1 || sepetim.FirstOrDefault(m => m.ID == gelenUrun.ID) == null)
            {
                Sepetim urun = new Sepetim();
                urun.ID = gelenUrun.ID;
                urun.UrunAdi = gelenUrun.ProductName;
                //urun.Adet = 1;
                urun.Fiyati = gelenUrun.Price;
                foreach (Image x in (List<Image>)ViewData["Image"])
                {
                    if (x.ProductID == urun.ID)
                    {
                        urun.Resim = x.ImagePath;
                    }
                }
                urun.Adet = 1;
                sepetim.Add(urun);

                ViewBag.Message = "Ürün Sepete Eklendi";


                //yeni
                if (Session["oturum"] != null)
                {
                    Cart yeni = new Cart();
                    yeni.AppUserID = gelen.ID;
                    yeni.ProductID = gelenUrun.ID;
                    yeni.ProductName = gelenUrun.ProductName;
                    yeni.Price = gelenUrun.Price;
                    yeni.Quentity = 1;
                    foreach (Image x in imser.GetAll())
                    {
                        if (x.ProductID == gelenUrun.ID)
                        {
                            yeni.ImagePath = x.ImagePath;
                        }
                    }

                    bool sonuc = cs.Add(yeni);
                    if (sonuc)
                    {
                        ViewBag.Message = "Ürün Eklendi";
                    }
                    else
                    {
                        ViewBag.Message = "Ürün Eklenemedi";
                    }
                }

            }
            else
            {
                Sepetim guncelle = sepetim.FirstOrDefault(m => m.ID == gelenUrun.ID);

                if (detay != null)
                {
                    switch (detay)
                    {
                        case "arti":
                            if (Session["oturum"] != null)
                            {
                                Cart guncellenecek = cs.GetByDefault(m => m.ProductID == gelenUrun.ID);

                                guncellenecek.ProductName = gelenUrun.ProductName;
                                guncellenecek.Quentity = guncelle.Adet++;
                                guncellenecek.Price = gelenUrun.Price * guncellenecek.Quentity;

                                foreach (Image h in imser.GetAll())
                                {
                                    if (h.ProductID == gelenUrun.ID)
                                    {
                                        guncellenecek.ImagePath = h.ImagePath;
                                    }
                                }

                                bool sonuc = cs.Update(guncellenecek);
                                if (sonuc)
                                {
                                    ViewBag.Message = "Ürün Güncellendi";
                                }
                                else
                                {
                                    ViewBag.Message = "Ürün Güncellenemedi";
                                }
                            }
                            Session["sepetim"] = sepetim;
                            return Json("", JsonRequestBehavior.AllowGet);

                        case "eksi":
                            if (Session["oturum"] != null)
                            {

                                Cart guncellenecek = cs.GetByDefault(m => m.ProductID == gelenUrun.ID);
                                if (guncellenecek.Quentity < 1)
                                {
                                    if (Session["oturum"] != null)
                                    {
                                        sepetim = (List<Sepetim>)Session["sepetim"];
                                        Sepetim sil = sepetim.FirstOrDefault(m => m.ID == id);
                                        sepetim.Remove(sil);
                                        if (sepetim.Count < 1)
                                        {
                                            Session.Remove("sepetim");
                                        }
                                        else
                                        {
                                            sepetim.RemoveAll(x => x.ID == id);
                                            return RedirectToAction("CartList");
                                        }
                                    }
                                    return RedirectToAction("CartList");
                                }
                                guncellenecek.ProductName = gelenUrun.ProductName;
                                guncellenecek.Quentity = guncelle.Adet--;
                                guncellenecek.Price = gelenUrun.Price * guncellenecek.Quentity;

                                foreach (Image h in imser.GetAll())
                                {
                                    if (h.ProductID == gelenUrun.ID)
                                    {
                                        guncellenecek.ImagePath = h.ImagePath;
                                    }
                                }

                                bool sonuc = cs.Update(guncellenecek);
                                if (sonuc)
                                {
                                    ViewBag.Message = "Ürün Güncellendi";
                                }
                                else
                                {
                                    ViewBag.Message = "Ürün Güncellenemedi";
                                }
                            }
                            Session["sepetim"] = sepetim;
                            return Json("", JsonRequestBehavior.AllowGet);

                    }
                }
                else
                {
                    if (Session["oturum"] != null)
                    {
                        Cart guncellenecek = cs.GetByDefault(m => m.ProductID == gelenUrun.ID);
                        guncellenecek.ProductName = gelenUrun.ProductName;
                        guncellenecek.Quentity = guncelle.Adet++;
                        guncellenecek.Price = gelenUrun.Price * guncellenecek.Quentity;

                        foreach (Image h in imser.GetAll())
                        {
                            if (h.ProductID == gelenUrun.ID)
                            {
                                guncellenecek.ImagePath = h.ImagePath;
                            }
                        }

                        bool sonuc = cs.Update(guncellenecek);
                        if (sonuc)
                        {
                            ViewBag.Message = "Ürün Güncellendi";
                        }
                        else
                        {
                            ViewBag.Message = "Ürün Güncellenemedi";
                        }
                    }

                }


                ViewBag.Message = "Sepet Güncellendi";

            }

            Session["sepetim"] = sepetim;
            return RedirectToAction("CartList", "ShoppingCart");

        }

        public ActionResult Delete(Guid id, Cart item)
        {
            Product gelenUrun = ps.GetByID(id);

            if (Session["oturum"] != null)
            {
                sepetim = (List<Sepetim>)Session["sepetim"];
                Sepetim sil = sepetim.FirstOrDefault(m => m.ID == id);
                sepetim.Remove(sil);
                if (sepetim.Count < 1)
                {
                    Session.Remove("sepetim");

                }
                else
                {
                    sepetim.RemoveAll(x => x.ID == id);
                    return RedirectToAction("CartList");
                }
                
            }
            return RedirectToAction("CartList");
        }
    }
}