﻿using A4VG.Globals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace A4VG.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Consts.CheckIfLoggedIn(System.Web.HttpContext.Current);

            return View();
        }
    }
}