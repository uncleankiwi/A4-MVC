using A4VG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace A4VG.Globals
{
	public class Consts
	{
		//session variable storing the currently logged in admin's username
		public const string ADMIN_NAME = "AdminName";

		readonly static Context ctx = new Context();

		//getting a list of doctors in a drop down list
		public static IEnumerable<SelectListItem> GetDoctorsDDL()
		{
			//.Select() is kind of like .stream()?
			//ToList() returns a List, Select() returns IEnumerable<whatever>
			return ctx.Doctors.ToList().Select(x => new SelectListItem
			{
				Value = x.Id.ToString(),
				Text = x.Id.ToString() + ": " + x.Name
			});
		}

		//getting a list of patients in a drop down list
		public static IEnumerable<SelectListItem> GetPatientsDDL()
		{
			return ctx.Patients.ToList().Select(x => new SelectListItem
			{
				Value = x.Id.ToString(),
				Text = x.Id.ToString() + ": " + x.Name
			});
		}

		//getting a list of doctors in a drop down list, with the indicated patient's main doctor marked with (main)
		public static IEnumerable<SelectListItem> GetDoctorsDDLWithMainDoctor(Patient patient)
		{
			return ctx.Doctors.ToList().Select(x => new SelectListItem
			{
				Value = x.Id.ToString(),
				Text = x.Id.ToString() + ": " + x.Name + (patient.DoctorId == x.Id ? " (main)" : "")
			});
		}

		//check if user is logged in.
		//if not, redirect to login page
		public static void CheckIfLoggedIn(HttpContext httpContext)
		{
			if (httpContext.Session[ADMIN_NAME] == null)
			{
				httpContext.Response.RedirectToRoute(new
				{
					controller = "Login",
					action = "Do"
				});

			}
		}
	}
} 
