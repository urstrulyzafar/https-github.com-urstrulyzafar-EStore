using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingStore.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult List()
        {
            return View();
        }


        public ActionResult AddNewProduct()
        {
            return View();
        }

        public ActionResult EditProduct()
        {
            return View();
        }

        public ActionResult DeleteProduct()
        {
            return View();
        }









    }
}