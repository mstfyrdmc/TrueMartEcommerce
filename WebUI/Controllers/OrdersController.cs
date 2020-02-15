using Core.Entity.Enum;
using Model.Context;
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
    public class OrdersController : Controller
    {
        OrderService os = new OrderService();
        OrderDetailService ods = new OrderDetailService();
        ProductService ps = new ProductService();
        CategoryService cs = new CategoryService();
        SubCategoryService sub = new SubCategoryService();
        SubSubCategoryService subsub = new SubSubCategoryService();
        ImageService img = new ImageService();
        ProductCommentService pcs = new ProductCommentService();
        BrandService bs = new BrandService();
        AppUserService ap = new AppUserService();
        SiteEmployeeService sec = new SiteEmployeeService();
        CartService cart = new CartService();
        ShipperService sc = new ShipperService();
        ContactInfoService info = new ContactInfoService();
        ProvinceService proser = new ProvinceService();
        TownService ts = new TownService();
        ShipperService shipper = new ShipperService();
        //List<Sepetim> sepetim;
        ProjectContext db = new ProjectContext();
        AppUser user;
        public ActionResult Index(Guid id)
        {
            ViewData["Categories"] = cs.GetActive();
            ViewData["SubCategories"] = sub.GetActive();
            ViewData["SubSubCategories"] = subsub.GetActive();
            ViewData["Cart"] = cart.GetActive();
            ViewData["AppUser"] = ap.GetActive();
            ViewData["Order"] = os.GetActive();
            ViewData["Product"] = ps.GetActive();
            ViewData["Town"] = ts.GetActive();
            ViewData["Province"] = proser.GetActive();
            ViewData["Image"] = img.GetActive();
            ViewData["Brands"] = bs.GetActive();
            ViewData["ContactInfo"] = info.GetActive();
            ViewData["OrderDetail"] = ods.GetActive();

            AppUser user = (AppUser)Session["oturum"];
            if (Session["oturum"] != null)
            {

                ViewBag.ShipperID = new SelectList(shipper.GetActive(), "ID", "ShipperName");
                return View(os.GetActive());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        public ActionResult Insert(Guid id)
        {
            ViewData["Categories"] = cs.GetActive();
            ViewData["SubCategories"] = sub.GetActive();
            ViewData["SubSubCategories"] = subsub.GetActive();
            ViewData["Cart"] = cart.GetActive();
            ViewData["AppUser"] = ap.GetActive();
            ViewData["Order"] = os.GetActive();
            ViewData["Product"] = ps.GetActive();
            ViewData["Town"] = ts.GetActive();
            ViewData["Province"] = proser.GetActive();
            ViewData["Image"] = img.GetActive();
            ViewData["Brands"] = bs.GetActive();
            ViewData["ContactInfo"] = info.GetActive();
            ViewData["OrderDetail"] = ods.GetActive();


            ViewBag.ShipperID = new SelectList(shipper.GetActive(), "ID", "ShipperName");

            return View();
        }
        [HttpPost]
        public ActionResult Insert(Sepetim item, Order item1)
        {
            ViewData["Categories"] = cs.GetActive();
            ViewData["SubCategories"] = sub.GetActive();
            ViewData["SubSubCategories"] = subsub.GetActive();
            ViewData["Cart"] = cart.GetActive();
            ViewData["AppUser"] = ap.GetActive();
            ViewData["Order"] = os.GetActive();
            ViewData["Product"] = ps.GetActive();
            ViewData["Town"] = ts.GetActive();
            ViewData["Province"] = proser.GetActive();
            ViewData["Image"] = img.GetActive();
            ViewData["Brands"] = bs.GetActive();
            ViewData["ContactInfo"] = info.GetActive();
            ViewData["OrderDetail"] = ods.GetActive();
            ViewBag.ShipperID = new SelectList(shipper.GetActive(), "ID", "ShipperName", item1.ShipperID);

            List<Sepetim> sepetim = (List<Sepetim>)Session["sepetim"];


            if (Session["oturum"] != null)
            {
                if (ModelState.IsValid)
                {
                    user = (AppUser)Session["oturum"];
                    Order order = new Order();
                    order.OrderDate = DateTime.Now.Date;
                    order.ShippedDate = DateTime.Now.AddDays(5).Date;
                    order.AppUserID = user.ID;
                    order.ShippedAddress = item1.ShippedAddress;
                    order.IsComfirmed = item1.IsComfirmed;
                    order.ShipperID = item1.ShipperID;

                    os.Add(order);


                    ViewBag.OrderID = order.ID;

                    foreach (Sepetim items in sepetim)
                    {
                        OrderDetail detail = new OrderDetail();
                        detail.OrderID = order.ID;
                        detail.ProductID = items.ID;
                        detail.AppUserID = user.ID; detail.Quentity = items.Adet;
                        detail.Price = items.Fiyati * detail.Quentity;
                        Product urun = ps.GetByID((Guid)detail.ProductID);
                        urun.UnitsInStock = urun.UnitsInStock - (int)detail.Quentity;
                        ps.Update(urun);
                        ods.Add(detail);
                        order.OrderDetails.Add(detail);

                    }


                    Session["sepetim"] = null;

                    return RedirectToAction("CartList", "ShoppingCart");
                }

            }

            if (user != null)
            {
                List<Cart> urunler = cart.GetDefault(m => m.AppUserID == user.ID && m.Status != Status.Deleted);
                OrderDetail detail = new OrderDetail();
                foreach (Cart urun in urunler)
                {
                    Product gelenurun = ps.GetByID((Guid)urun.ProductID);
                    Order order = new Order();
                    order.OrderDate = DateTime.Now.Date;
                    order.ShippedDate = DateTime.Now.AddDays(5).Date;
                    order.AppUserID = user.ID;
                    order.ShippedAddress = item1.ShippedAddress;
                    order.IsComfirmed = item1.IsComfirmed;
                    order.ShipperID = item1.ShipperID;
                    os.Add(order);


                    ViewBag.OrderID = order.ID;
                    foreach (Sepetim items in sepetim)
                    {
                        OrderDetail details = new OrderDetail();
                        details.OrderID = order.ID;
                        details.ProductID = items.ID;
                        details.Quentity = items.Adet;
                        details.AppUserID = user.ID;
                        details.Price = items.Fiyati * details.Quentity;
                        Product uruns = ps.GetByID((Guid)details.ProductID);
                        uruns.UnitsInStock = uruns.UnitsInStock - (int)details.Quentity;
                        ps.Update(uruns);
                        ods.Add(details);
                        order.OrderDetails.Add(details);

                    }


                    Session["sepetim"] = null;

                    return RedirectToAction("CartList", "ShoppingCart");
                }
            }
            return View();
        }

        public ActionResult UpdateOrder(Guid id)
        {
            ViewData["Categories"] = cs.GetActive();
            ViewData["SubCategories"] = sub.GetActive();
            ViewData["SubSubCategories"] = subsub.GetActive();
            ViewData["Cart"] = cart.GetActive();
            ViewData["AppUser"] = ap.GetActive();
            ViewData["Order"] = os.GetActive();
            ViewData["Product"] = ps.GetActive();
            ViewData["Town"] = ts.GetActive();
            ViewData["Province"] = proser.GetActive();
            ViewData["Image"] = img.GetActive();
            ViewData["Brands"] = bs.GetActive();
            ViewData["ContactInfo"] = info.GetActive();
            ViewData["OrderDetail"] = ods.GetActive();
            ViewBag.ShipperID = new SelectList(shipper.GetActive(), "ID", "ShipperName");
            AppUser user = (AppUser)Session["oturum"];
            Order guncellenecek = os.GetByID(id);

            return View(os.GetByID(id));
        }

        [HttpPost]
        public ActionResult UpdateOrder(Order item)
        {
            ViewData["Categories"] = cs.GetActive();
            ViewData["SubCategories"] = sub.GetActive();
            ViewData["SubSubCategories"] = subsub.GetActive();
            ViewData["Cart"] = cart.GetActive();
            ViewData["AppUser"] = ap.GetActive();
            ViewData["Order"] = os.GetActive();
            ViewData["Product"] = ps.GetActive();
            ViewData["Town"] = ts.GetActive();
            ViewData["Province"] = proser.GetActive();
            ViewData["Image"] = img.GetActive();
            ViewData["Brands"] = bs.GetActive();
            ViewData["ContactInfo"] = info.GetActive();
            ViewData["OrderDetail"] = ods.GetActive();
            ViewBag.ShipperID = new SelectList(shipper.GetActive(), "ID", "ShipperName", item.ShipperID);
            AppUser user = (AppUser)Session["oturum"];
            List<Sepetim> sepetim = (List<Sepetim>)Session["sepetim"];

            Order guncellenecek = os.GetByID(item.ID);
            guncellenecek.IsComfirmed = item.IsComfirmed;
            guncellenecek.OrderDate = DateTime.Now.Date;
            guncellenecek.ShippedDate = DateTime.Now.AddDays(5).Date;
            guncellenecek.ShipperID = item.ShipperID;
            guncellenecek.AppUserID = item.AppUserID;
            os.Update(guncellenecek);
            ViewBag.OrderID = guncellenecek.ID;

            foreach (Sepetim items in sepetim)
            {
                OrderDetail detail = new OrderDetail();
                detail.OrderID = guncellenecek.ID;
                detail.ProductID = items.ID;
                detail.Quentity = items.Adet;
                detail.Price = items.Fiyati;

                ods.Update(detail);
                guncellenecek.OrderDetails.Add(detail);
            }

            Session["sepetim"] = null;

            return RedirectToAction("CartList", "ShoppingCart");
        }

        public ActionResult Delete(Guid id)
        {
            OrderDetail gelen = ods.GetByID(id);
            ods.Remove(id);
            gelen.Status = Status.Deleted;
            return RedirectToAction("Index", "Home");
        }

    }
}


//public ActionResult Detail(Guid id)
//{
//    ViewBag.Categories = cs.GetActive();
//    ViewBag.SubCategories = sub.GetActive();
//    ViewBag.SubSubCategories = subsub.GetActive();
//    ViewBag.Products = ps.GetActive();
//    ViewBag.Imagess = img.GetActive();
//    ViewBag.Brands = bs.GetActive();
//    ViewBag.Cart = cart.GetActive();
//    ViewBag.AppUser = ap.GetActive();
//    ViewBag.Order = os.GetActive();
//    ViewBag.ContactInfo = info.GetActive();
//    ViewBag.Province = proser.GetActive();
//    ViewBag.Town = ts.GetActive();
//    ViewBag.OrderDetail = ods.GetActive();


//    return View(ods.GetByDefault(m => m.OrderID == id));
//}



//public ActionResult Insert(Order item )
//{
//    ViewBag.Categories = cs.GetActive();
//    ViewBag.SubCategories = sub.GetActive();
//    ViewBag.SubSubCategories = subsub.GetActive();
//    ViewBag.Products = ps.GetActive();
//    ViewBag.Imagess = img.GetActive();
//    ViewBag.Brands = bs.GetActive();
//    ViewBag.Cart = cart.GetActive();
//    ViewBag.AppUser = ap.GetActive();
//    ViewBag.Order = os.GetActive();
//    ViewBag.ContactInfo = info.GetActive();
//    ViewBag.Province = proser.GetActive();
//    ViewBag.Town = ts.GetActive();
//    ViewBag.ShipperID = new SelectList(shipper.GetActive(), "ID", "ShipperName",item.ShipperID);
//    AppUser user =(AppUser) Session["oturum"];

//    //sepetim = (List<Sepetim>)Session["sepetim"];
//    List<Sepetim> sepetim =(List<Sepetim>) Session["sepetim"];


//    if (Session["oturum"] != null)
//    {
//       if (ModelState.IsValid)
//        {
//            Order order = new Order();
//            order.IsComfirmed = item.IsComfirmed;
//            order.ShipperID = item.ShipperID;
//            order.ShippedAddress = item.ShippedAddress;
//            order.AppUserID = user.ID;
//            order.OrderDate = DateTime.Now.Date;
//            order.ShippedDate = DateTime.Now.AddDays(5).Date;
//            bool sonuc = os.Add(order);
//           
//            ViewBag.OrderID = order.ID;
//            //
//            if (sonuc)
//            {
//                //yeni
//                //price ve productID gelmiyor.
//                //OrderDetail detail = new OrderDetail();
//                //detail.Quentity = sepetim.Count();
//                //detail.Order = item;
//                foreach (Sepetim items in sepetim)
//                {
//                    OrderDetail detail = new OrderDetail();
//                    detail.Quentity =  sepetim.Count();
//                    detail.Order = item;
//                    Product sepettekiUrun = ps.GetByID(items.ID);
//                    if (items.ID==sepettekiUrun.ID)
//                    {

//                        detail.Product = sepettekiUrun;
//                        detail.Price = sepettekiUrun.Price;


//                        //if (result)
//                        //{
//                        //    return RedirectToAction("Index", "Orders");
//                        //}
//                        //else
//                        //{
//                        //    ViewBag.Message = "Siparişinizde hata oluştu lütfen tekrar deneyin";
//                        //    return RedirectToAction("CartList", "ShoppingCart");
//                        //}


//                    }
//                    db.OrderDetails.Add(detail);

//                    ods.Add(detail);
//                    order.OrderDetails.Add(detail);

//                    return RedirectToAction("CartList", "ShoppingCart");
//                }



//                //OrderDetail detail = new OrderDetail();
//                //List<Cart> carts = cart.GetActive();
//                //List<OrderDetail> details = new List<OrderDetail>();
//                //foreach (Cart /*Sepetim*/ items in carts /*sepetim*/)
//                //{

//                //    OrderDetail detail = CreateOrderDetailForThisItem(items);

//                //    detail.Quentity = sepetim.Count();

//                //    ods.Add(details);
//                //    bool result= ods.Add(item1);
//                //    if (result)
//                //    {
//                //        return RedirectToAction("Index", "Orders");
//                //    }
//                //    else
//                //    {
//                //        ViewBag.Message = "Siparişinizde hata oluştu lütfen tekrar deneyin";
//                //        return RedirectToAction("CartList", "ShoppingCart");
//                //    }
//                //}


//            }
//            else
//            {
//                ViewBag.Message = "Siparişinizde beklenmeyen bir hata oluştu. Lütfen tekrar deneyin";
//                return RedirectToAction("CartList", "ShoppingCart");
//            }
//        }
//    }
//     return View();
//}

// yeni
//private OrderDetail CreateOrderDetailForThisItem(Cart /*Sepetim*/ Item)
//   {
//       OrderDetail detail = new OrderDetail();
//       detail.Price = Item.Product.Price;
//       detail.Product = Item.Product;

//       return detail;
//   }
