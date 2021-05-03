using A4VG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using A4VG.Globals;

namespace A4VG.Controllers
{
	public class VisitController : Controller
	{
		readonly Context ctx = new Context();

		public ActionResult Index(string searchBy, string search)
		{
			Consts.CheckIfLoggedIn(System.Web.HttpContext.Current);
			if (searchBy == "Complaint")
			{
				return View(ctx.Visits.Where(x => x.Complaint.StartsWith(search) || search == null).Include(x => x.Doctor).Include(x => x.Patient));
			}
            else
            {
				return View(ctx.Visits.Where(x => x.Patient.Name.StartsWith(search) || search == null).Include(x => x.Doctor).Include(x => x.Patient));
			}
		}

		[HttpGet]
		public ActionResult Create()
		{
			Consts.CheckIfLoggedIn(System.Web.HttpContext.Current);

			Visit visit = new Visit
			{
				DateAndTime = DateTime.Now
			};
			visit.InitDateTime();
			return View(LoadDDLOptions(visit));
		}

		[HttpPost]
		public ActionResult Create(Visit visit)
		{
			Consts.CheckIfLoggedIn(System.Web.HttpContext.Current);

			try
			{
				if (ModelState.IsValid)
				{
					visit.ParseDateTime();
					ctx.Visits.Add(visit);
					ctx.SaveChanges();
				}
				else
				{
					return Create();
				}
				
			}
			catch (Exception e)
			{
				System.Diagnostics.Debug.WriteLine("Error creating a visit: " + e.GetBaseException().ToString());
			}
			return RedirectToAction("Index");
		}

		public ActionResult Details(int id)
		{
			Consts.CheckIfLoggedIn(System.Web.HttpContext.Current);

			return View(VisitFromId(id));
		}

		[HttpGet]
		public ActionResult Edit(int id)
		{
			Consts.CheckIfLoggedIn(System.Web.HttpContext.Current);
			Visit visit = LoadMainDoctorDDLOptions(VisitFromId(id));
			visit.InitDateTime();
			return View(visit);
		}

		[HttpPost]
		public ActionResult Edit(Visit visit)
		{
			Consts.CheckIfLoggedIn(System.Web.HttpContext.Current);

			try
			{
				if (ModelState.IsValid)
				{
					visit.ParseDateTime();
					ctx.Entry(visit).State = EntityState.Modified;
					ctx.SaveChanges();
				}
				else
				{
					return Edit(visit.Id);
				}
			}
			catch(Exception e)
			{
				System.Diagnostics.Debug.WriteLine("Error editing a visit: " + e.GetBaseException().ToString());
			}

			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult Delete(int id)
		{
			Consts.CheckIfLoggedIn(System.Web.HttpContext.Current);

			return View(VisitFromId(id));
		}

		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirm(int id)
		{
			Consts.CheckIfLoggedIn(System.Web.HttpContext.Current);
			try
			{
				
			Visit visit = ctx.Visits.Single(x => x.Id == id);
			ctx.Visits.Remove(visit);
			ctx.SaveChanges();
			return RedirectToAction("Index");
			}
			catch (Exception e)
			{
				System.Diagnostics.Debug.WriteLine("Error deleting a visit: " + e.GetBaseException().ToString());
			}
			return RedirectToAction("Index");
		}

		private Visit VisitFromId(int id)
		{
			return ctx.Visits
				.Include(x => x.Patient)
				.Include(x => x.Doctor)
				.Single(x => x.Id == id);
		}

		//loads lists of patients and doctors who can be assigned to a visit
		private Visit LoadDDLOptions(Visit v)
		{
			v.PatientsList = Consts.GetPatientsDDL();
			v.DoctorsList = Consts.GetDoctorsDDL();
			return v;
		}

		//loads lists of patients and doctors who can be assigned to a visit
		//but this one also adds (main) prefix to a patient's main doctor

		private Visit LoadMainDoctorDDLOptions(Visit v)
		{
			v.PatientsList = Consts.GetPatientsDDL();
			v.DoctorsList = Consts.GetDoctorsDDLWithMainDoctor(v.Patient);
			return v;
		}
	}
}