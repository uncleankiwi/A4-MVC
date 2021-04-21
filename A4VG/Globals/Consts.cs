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
		public const string ADMIN_NAME = "AdminName";
		readonly static Context ctx = new Context();

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

		public static IEnumerable<SelectListItem> GetPatientsDDL()
		{
			return ctx.Patients.ToList().Select(x => new SelectListItem
			{
				Value = x.Id.ToString(),
				Text = x.Id.ToString() + ": " + x.Name
			});
		}

		public static IEnumerable<SelectListItem> GetDoctorsDDLWithMainDoctor(Patient patient)
		{
			return ctx.Doctors.ToList().Select(x => new SelectListItem
			{
				Value = x.Id.ToString(),
				Text = x.Id.ToString() + ": " + x.Name + (patient.DoctorId == x.Id ? " (main)" : "")
			});
		}

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

		public static Patient PatientFromId(int id)
		{
			Patient patient = ctx.Patients
				.Include(x => x.Doctor)
				.Single(x => x.Id == id);
			return patient;
		}
	}
} 
