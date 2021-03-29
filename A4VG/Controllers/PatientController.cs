using A4VG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace A4VG.Controllers
{
	public class PatientController : Controller
	{
		
		public ActionResult Index()
		{
			return View(new Context().Patients
				.Include(x => x.Doctor));
		}

		[HttpGet]
		public ActionResult Create()
		{
			return View(LoadDoctorsList(new Patient()));
		}

		[HttpPost]
		public ActionResult Create(Patient patient)
		{
			Context context = new Context();
			context.Patients.Add(patient);
			context.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult Details(int id)
		{
			return ViewFromId(id);
		}

		[HttpGet]
		public ActionResult Edit(int id)
		{
			return ViewFromId(id);
		}

		[HttpPost]
		public ActionResult Edit(Patient patient)
		{
			Context context = new Context();
			context.Entry(patient).State = System.Data.Entity.EntityState.Modified;
			context.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult Delete(int id)
		{
			return ViewFromId(id);
		}

		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirm(int id)
		{
			Context context = new Context();
			Patient patient = context.Patients.Single(x => x.Id == id);
			context.Patients.Remove(patient);
			context.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult ViewFromId(int id)
		{
			Context context = new Context();
			Patient patient = context.Patients.Single(x => x.Id == id);
			return View(patient);
		}

		public Patient LoadDoctorsList(Patient p)
		{
			SelectList selectList = new SelectList();

			p.DoctorsList = new SelectList(new Context().Doctors.ToList());
			return p;
		}
	}
}