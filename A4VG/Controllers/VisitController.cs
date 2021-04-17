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
		Context ctx = new Context();

		public ActionResult Index()
		{
			Consts.CheckIfLoggedIn(System.Web.HttpContext.Current);

			return View(ctx.Visits
				.Include(x => x.Doctor)
				.Include(x => x.Patient));
		}

		[HttpGet]
		public ActionResult Create()
		{
			Consts.CheckIfLoggedIn(System.Web.HttpContext.Current);

			Visit visit = new Visit();
			visit.DateAndTime = DateTime.Now;
			return View(LoadDDLOptions(visit));
		}

		[HttpPost]
		public ActionResult Create(Visit visit)
		{
			Consts.CheckIfLoggedIn(System.Web.HttpContext.Current);

			try
			{
				ctx.Visits.Add(visit);
				ctx.SaveChanges();
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

			return View(LoadMainDoctorDDLOptions(VisitFromId(id)));
		}

		[HttpPost]
		public ActionResult Edit(Visit visit)
		{
			Consts.CheckIfLoggedIn(System.Web.HttpContext.Current);

			try
			{
				ctx.Entry(visit).State = System.Data.Entity.EntityState.Modified;
				ctx.SaveChanges();
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

		private Visit LoadDDLOptions(Visit v)
		{
			v.PatientsList = Consts.GetPatientsDDL();
			v.DoctorsList = Consts.GetDoctorsDDL();
			return v;
		}

		private Visit LoadMainDoctorDDLOptions(Visit v)
		{
			v.PatientsList = Consts.GetPatientsDDL();
			v.DoctorsList = Consts.GetDoctorsDDLWithMainDoctor(v.Patient);
			return v;
		}
	}
}