using A4VG.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace A4VG.Controllers
{
	public class DoctorController : Controller
	{
		Context ctx = new Context();
		public ActionResult Index()
		{
			return View(new Context().Doctors);
		}

		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(Doctor doctor)
		{
			try
			{
				ctx.Doctors.Add(doctor);
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
			return ViewFromId(id);
		}

		[HttpGet]
		public ActionResult Edit(int id)
		{
			return ViewFromId(id);
		}

		[HttpPost]
		public ActionResult Edit(Doctor doctor)
		{
			try
			{
				ctx.Entry(doctor).State = EntityState.Modified;
				ctx.SaveChanges();
			}
			catch (Exception e)
			{
				System.Diagnostics.Debug.WriteLine(e.Message);
			}
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
			Doctor doctor = ctx.Doctors.Single(x => x.Id == id);
			ctx.Doctors.Remove(doctor);
			ctx.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult ViewFromId(int id)
		{
			Doctor doctor = ctx.Doctors.Single(x => x.Id == id); //or context.Doctors.Find(id);
			return View(doctor);
		}

	}
}