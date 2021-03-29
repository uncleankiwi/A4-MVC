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
	public class PatientController : Controller
	{
		Context ctx = new Context();

		public ActionResult Index()
		{
			return View(ctx.Patients
				.Include(x => x.Doctor));
		}

		[HttpGet]
		public ActionResult Create()
		{
			return View(LoadDDLOptions(new Patient()));
		}

		[HttpPost]
		public ActionResult Create(Patient patient)
		{
			ctx.Patients.Add(patient);
			ctx.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult Details(int id)
		{
			return View(PatientFromId(id));
		}

		[HttpGet]
		public ActionResult Edit(int id)
		{
			return View(LoadDDLOptions(PatientFromId(id)));
		}

		[HttpPost]
		public ActionResult Edit(Patient patient)
		{
			ctx.Entry(patient).State = System.Data.Entity.EntityState.Modified;
			ctx.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult Delete(int id)
		{
			return View(PatientFromId(id));
		}

		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirm(int id)
		{
			Patient patient = ctx.Patients.Single(x => x.Id == id);
			ctx.Patients.Remove(patient);
			ctx.SaveChanges();
			return RedirectToAction("Index");
		}

		public Patient PatientFromId(int id)
		{
			Patient patient = ctx.Patients
				.Include(x => x.Doctor)
				.Single(x => x.Id == id);
			return patient;
		}

		public Patient LoadDDLOptions(Patient p)
		{
			p.DoctorsList = Consts.GetDoctorsDDL();
			return p;
		}

	}
}