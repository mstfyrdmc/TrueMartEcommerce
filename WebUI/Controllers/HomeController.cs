using Model.Context;
using Model.Entities;
using Service.Option;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        
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
        OrderService os = new OrderService();
        ProjectContext db = new ProjectContext();
        ProductDetailService pds = new ProductDetailService();
        public ActionResult CommentListByAppUser()
        {
            ViewData["Categories"] = cs.GetActive();
            ViewData["SubCategories"] = sub.GetActive();
            ViewData["SubSubCategories"] = subsub.GetActive();
            ViewData["Brands"] = bs.GetActive();
            ViewData["Products"] = ps.GetActive();
            ViewData["ProductComment"] = pcs.GetActive();
            ViewData["Cart"] = cart.GetActive();
            ViewData["AppUser"] = ap.GetActive();
            ViewData["Order"] = os.GetActive();
            ViewData["ProductDetail"] = pds.GetActive();

            AppUser gelen = (AppUser)Session["oturum"];
            return View(pcs.GetAll());
        }
       

        public ActionResult CommentList2(Guid id)
        {
            
            ViewData["Categories"] = cs.GetActive();
            ViewData["SubCategories"] = sub.GetActive();
            ViewData["SubSubCategories"] = subsub.GetActive();
            ViewData["Brands"] = bs.GetActive();
            ViewData["Products"] = ps.GetActive();
            ViewData["ProductComment"] = pcs.GetActive();
            ViewData["Cart"] = cart.GetActive();
            ViewData["AppUser"] = ap.GetActive();
            ViewData["Order"] = os.GetActive();
            ViewData["ProductDetail"] = pds.GetActive();
            Product urun = ps.GetByID(id);
            
            return View(urun);
        }

        public ActionResult Insert(Guid id)
        {
            
            ViewData["Categories"] = cs.GetActive();
            ViewData["SubCategories"] = sub.GetActive();
            ViewData["SubSubCategories"] = subsub.GetActive();
            ViewData["Brands"] = bs.GetActive();
            ViewData["Products"] = ps.GetActive();
            ViewData["ProductComment"] = pcs.GetActive();
            ViewData["Cart"] = cart.GetActive();
            ViewData["AppUser"] = ap.GetActive();
            ViewData["Order"] = os.GetActive();
            ViewData["ProductDetail"] = pds.GetActive();

            Product urun = ps.GetByID(id);
            return View(Tuple.Create<Product,ProductComment>(ps.GetByID(id), pcs.GetByDefault(m => m.ProductID == id)));
            

        }
        [HttpPost]
        public ActionResult Insert(Guid id, ProductComment item2)
        {
            
            ViewData["Categories"] = cs.GetActive();
            ViewData["SubCategories"] = sub.GetActive();
            ViewData["SubSubCategories"] = subsub.GetActive();
            ViewData["Brands"] = bs.GetActive();
            ViewData["Products"] = ps.GetActive();
            ViewData["ProductComment"] = pcs.GetActive();
            ViewData["Cart"] = cart.GetActive();
            ViewData["AppUser"] = ap.GetActive();
            ViewData["Order"] = os.GetActive();
            ViewData["ProductDetail"] = pds.GetActive();

            Product urun = ps.GetByID(id);
            AppUser gelen = (AppUser)Session["oturum"];

            if (ModelState.IsValid)
            {
                ProductComment yorum = new ProductComment();
                item2.AppUserID = gelen.ID;
                item2.ProductID = urun.ID;
                yorum.Comment = item2.Comment; 
                yorum.ProductLikes = item2.ProductLikes;
                
                yorum.AppUserID = item2.AppUserID;
                yorum.ProductID = item2.ProductID;
               
                bool sonuc = pcs.Add(yorum);
                if (sonuc)
                {
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ViewBag.Message = "Ürün Yorumu ekleme işleminde bir hata oluştu";
                    RedirectToAction("CartList", "ShoppingCart");
                }
                
            }
            else
            {
                ViewBag.Message = "Ürün Yorumu işleminde bir hata oluştu";
            }
            
            return RedirectToAction("Product", "Home");


        }
        //public ActionResult Search(string searching,bool durum)
        //{
            
        //    ViewData["Categories"] = cs.GetActive();
        //    ViewData["SubCategories"] = sub.GetActive();
        //    ViewData["SubSubCategories"] = subsub.GetActive();
        //    ViewData["Brands"] = bs.GetActive();
        //    ViewData["Products"] = ps.GetActive();
        //    ViewData["ProductComment"] = pcs.GetActive();
        //    ViewData["Cart"] = cart.GetActive();
        //    ViewData["AppUser"] = ap.GetActive();
        //    ViewData["Order"] = os.GetActive();
        //    ViewData["ProductDetail"] = pds.GetActive();
        //    ViewData["Image"] = img.GetActive();

        //    return View(db.Products.Where(x => x.ProductName.Contains(searching) || searching == null).ToList());
        //}
        public ActionResult Index(string searching)
        {
            
            ViewData["Categories"] = cs.GetActive();
            ViewData["SubCategories"] = sub.GetActive();
            ViewData["SubSubCategories"] = subsub.GetActive();
            ViewData["Brands"] = bs.GetActive();
            ViewData["Products"] = ps.GetActive();
            ViewData["ProductComment"] = pcs.GetActive();
            ViewData["Cart"] = cart.GetActive();
            ViewData["AppUser"] = ap.GetActive();
            ViewData["Order"] = os.GetActive();
            ViewData["ProductDetail"] = pds.GetActive();
            ViewData["Image"] = img.GetActive();

            return View(db.Products.Where(x => x.ProductName.Contains(searching) || searching == null).ToList());
        }
        
        public ActionResult Product(Guid id,string searching)
        {
           
            ViewData["Categories"] = cs.GetActive();
            ViewData["SubCategories"] = sub.GetActive();
            ViewData["SubSubCategories"] = subsub.GetActive();
            ViewData["Brands"] = bs.GetActive();
            ViewData["Products"] = ps.GetActive();
            ViewData["ProductComment"] = pcs.GetActive();
            ViewData["Cart"] = cart.GetActive();
            ViewData["AppUser"] = ap.GetActive();
            ViewData["Order"] = os.GetActive();
            ViewData["ProductDetail"] = pds.GetActive();
            ViewData["Image"] = img.GetActive();
            Product urun = ps.GetByID(id);
            

            
            return View(Tuple.Create<Product, List<ProductComment>>(ps.GetByID(id), pcs.GetDefault(m => m.ProductID == id)));
        }

        
        public ActionResult Products(Guid id)
        {

            ViewData["Categories"] = cs.GetActive();
            ViewData["SubCategories"] = sub.GetActive();
            ViewData["SubSubCategories"] = subsub.GetActive();
            ViewData["Brands"] = bs.GetActive();
            ViewData["Products"] = ps.GetActive();
            ViewData["ProductComment"] = pcs.GetActive();
            ViewData["Cart"] = cart.GetActive();
            ViewData["AppUser"] = ap.GetActive();
            ViewData["Order"] = os.GetActive();
            ViewData["ProductDetail"] = pds.GetActive();
            ViewData["Image"] = img.GetActive();
            Category gelen = cs.GetByID(id);
           
            return View(gelen);

        }
       
        public ActionResult Contact()
        {
            ViewData["Categories"] = cs.GetActive();
            ViewData["SubCategories"] = sub.GetActive();
            ViewData["SubSubCategories"] = subsub.GetActive();
            ViewData["Brands"] = bs.GetActive();
            ViewData["Products"] = ps.GetActive();
            ViewData["ProductComment"] = pcs.GetActive();
            ViewData["Cart"] = cart.GetActive();
            ViewData["AppUser"] = ap.GetActive();
            ViewData["Order"] = os.GetActive();
            ViewData["ProductDetail"] = pds.GetActive();
            ViewData["Image"] = img.GetActive();
            return View();
        }
        public ActionResult About()
        {
            ViewData["Categories"] = cs.GetActive();
            ViewData["SubCategories"] = sub.GetActive();
            ViewData["SubSubCategories"] = subsub.GetActive();
            ViewData["Brands"] = bs.GetActive();
            ViewData["Products"] = ps.GetActive();
            ViewData["ProductComment"] = pcs.GetActive();
            ViewData["Cart"] = cart.GetActive();
            ViewData["AppUser"] = ap.GetActive();
            ViewData["Order"] = os.GetActive();
            ViewData["ProductDetail"] = pds.GetActive();
            ViewData["Image"] = img.GetActive();
            ViewData["Employee"] = sec.GetActive();
            return View();
        }
    }
}