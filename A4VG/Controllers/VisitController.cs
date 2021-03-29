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
			return View(ctx.Visits
				.Include(x => x.Doctor)
				.Include(x => x.Patient));
		}

		[HttpGet]
		public ActionResult Create()
		{
			return View(LoadDDLOptions(new Visit()));
		}

		[HttpPost]
		public ActionResult Create(Visit visit)
		{
			try
			{
				ctx.Visits.Add(visit);
				ctx.SaveChanges();
			}
			catch (Exception e)
			{
				System.Diagnostics.Debug.WriteLine(e.Message);
			}
			return RedirectToAction("Index");
		}

		public ActionResult Details(int id)
		{
			return View(VisitFromId(id));
		}

		[HttpGet]
		public ActionResult Edit(int id)
		{
			return View(LoadDDLOptions(VisitFromId(id)));
		}

		[HttpPost]
		public ActionResult Edit(Visit visit)
		{
			try
			{
				ctx.Entry(visit).State = System.Data.Entity.EntityState.Modified;
				ctx.SaveChanges();
			}
			catch(Exception e)
			{
				System.Diagnostics.Debug.WriteLine(e.Message);
			}

			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult Delete(int id)
		{
			return View(VisitFromId(id));
		}

		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirm(int id)
		{
			Visit visit = ctx.Visits.Single(x => x.Id == id);
			ctx.Visits.Remove(visit);
			ctx.SaveChanges();
			return RedirectToAction("Index");
		}

		public Visit VisitFromId(int id)
		{
			return ctx.Visits
				.Include(x => x.Patient)
				.Include(x => x.Doctor)
				.Single(x => x.Id == id);
		}

		public Visit LoadDDLOptions(Visit v)
		{
			v.PatientsList = Consts.GetPatientsDDL();
			v.DoctorsList = Consts.GetDoctorsDDL();
			return v;
		}
	}
}