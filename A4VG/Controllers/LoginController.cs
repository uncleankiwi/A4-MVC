﻿using A4VG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace A4VG.Controllers
{
	public class LoginController : Controller
	{
		Context ctx = new Context();

		[HttpGet]
		public ActionResult Do()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Do(Admin admin)
		{
			try
			{
				List<Admin> loginMatches = ctx.Admins.Where(x => x.AdminName.Equals(admin.AdminName) &&
				x.AdminPass.Equals(admin.AdminPass)).ToList();

				//if pass is correct, add cookie, redirect to home
				if (loginMatches.Count == 1)
				{
					RedirectToAction("Index", "HomeController");
				}
			}
			//if pass is incorrect, redirect to login, display error message
			catch (Exception e)
			{
				System.Diagnostics.Debug.WriteLine(e.Message);
			}
			Admin errorResult = new Admin();
			errorResult.ErrorMessage = "Username or password incorrect.";
			return View(errorResult);
		}
	}
}