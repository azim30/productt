using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using product.Models;
namespace product.Controllers
{
    public class ProductController : Controller
    {
        LTIMVCEntities db = new LTIMVCEntities();
        // GET: Product
        [HttpGet]
        public ActionResult product()
        {
            return View();
        }
        [HttpPost]
        public ActionResult product(Product pro)
        {
            
            pro.ProductName = Request.Form["txtproname"];
            pro.ProductDesc = Request.Form["desc"];
            pro.Manufacturer = Request.Form["man"];
            pro.Price = Convert.ToDecimal(Request.Form["txtpri"]);
            pro.Category = Request.Form["txtCat"];
            ModelState.AddModelError("",  pro.ProductName + " " + pro.ProductDesc + " " + pro.Manufacturer + " " + pro.Price + " " + pro.Category);
            db.Products.Add(pro);
            int res = db.SaveChanges();
            if (res > 0)
            {
                ModelState.AddModelError("", "New Product Inserted");
            }
            return RedirectToAction("GetProduct");
        }
        public ActionResult GetProduct()
        {
            var data = db.Products.ToList();
            return View(data);  //model binding
        }
    }
}