﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Context;

namespace WebApplication2.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        QUANLITHOITRANGEntities objQUANLITHOITRANGEntities = new QUANLITHOITRANGEntities();

        // GET: Admin/HomeAdmin
        public ActionResult Index()
        { 
            return View();
        }

       
    }
}