﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Context;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class DieuKhoanController : Controller
    {
        QUANLITHOITRANGEntities objQUANLITHOITRANGEntities = new QUANLITHOITRANGEntities();
        // GET: DieuKhoan
        public ActionResult Index()
        {


            return View();
        }
    }
}