using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Context;

namespace WebApplication2.Controllers
{
    public class CataloguserController : Controller
    {
        // GET: Cataloguser
        QUANLITHOITRANGEntities objQUANLITHOITRANGEntities = new QUANLITHOITRANGEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductCatalog( int id)
        {
            var lstproduct = objQUANLITHOITRANGEntities.products.Where(n => n.catalog_id == id).ToList();
            return View(lstproduct);
        }
    }
}