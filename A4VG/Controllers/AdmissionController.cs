using A4VG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace A4VG.Controllers
{
	public class AdmissionController : Controller
	{
		readonly Context ctx = new Context();

		// GET: Admission
		public ActionResult Index()
		{
			return View();
		}

		// GET: Admission/Details/5
		public ActionResult Details(int id)
		{
			return View(AdmissionFromId(id));
		}

		// GET: Admission/Create
		public ActionResult Create()
		{
			Admission admission = new Admission();
			admission.Admitted = DateTime.Now;
			admission.InitDateTime();
			return View(admission);
		}

		// POST: Admission/Create
		[HttpPost]
		public ActionResult Create(Admission admission)
		{
			try
			{
				admission.ParseDateTime();
				ctx.Admissions.Add(admission);
				ctx.SaveChanges();
				
			}
			catch (Exception e)
			{
				System.Diagnostics.Debug.WriteLine("Error creating an admission: " + e.GetBaseException().ToString());
			}
			return RedirectToAction("Index");
		}

		// GET: Admission/Edit/5
		public ActionResult Edit(int id)
		{
			Admission admission = AdmissionFromId(id);
			admission.InitDateTime();
			return View(admission);
		}

		// POST: Admission/Edit/5
		[HttpPost]
		public ActionResult Edit(Admission admission)
		{
			try
			{
				admission.ParseDateTime();
				ctx.Entry(admission).State = EntityState.Modified;
				ctx.SaveChanges();
			}
			catch (Exception e)
			{
				System.Diagnostics.Debug.WriteLine("Error editing an admission: " + e.GetBaseException().ToString());
			}
			return RedirectToAction("Index");
		}

		// GET: Admission/Delete/5
		public ActionResult Delete(int id)
		{
			return View(AdmissionFromId(id));
		}

		// POST: Admission/Delete/5
		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirm(int id)
		{
			try
			{
				Admission admission = ctx.Admissions.Single(x => x.Id == id);
				ctx.Admissions.Remove(admission);
				ctx.SaveChanges();
				return RedirectToAction("Index");
			}
			catch (Exception e)
			{
				System.Diagnostics.Debug.WriteLine("Error deleting an admission: " + e.GetBaseException().ToString());
			}
			return RedirectToAction("Index");
		}

		// ============ utility methods ============ 

		private Admission AdmissionFromId(int id)
		{
			return ctx.Admissions
				.Include(x => x.Patient)
				.Single(x => x.Id == id);
		}
	}
}
