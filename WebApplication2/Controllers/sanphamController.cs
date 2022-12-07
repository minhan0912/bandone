using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Context;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class sanphamController : Controller
    {
        // GET: sanpham
        QUANLITHOITRANGEntities objQUANLITHOITRANGEntities = new QUANLITHOITRANGEntities();
        public ActionResult Index()
        {
            var lstproduct = objQUANLITHOITRANGEntities.products.ToList();
            return View(lstproduct);
        }
    }
}