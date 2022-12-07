using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Context;

namespace WebApplication2.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        QUANLITHOITRANGEntities objQUANLITHOITRANGEntities = new QUANLITHOITRANGEntities();
        public ActionResult Detail(int id)
        {
            var objproduct = objQUANLITHOITRANGEntities.products.Where(n => n.id == id).FirstOrDefault();
            return View(objproduct);
        }
    }
}