﻿using A4VG.Models;
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
		readonly Context ctx = new Context();

		public ActionResult Index()
		{
			Consts.CheckIfLoggedIn(System.Web.HttpContext.Current);

			return View(ctx.Patients
				.Include(x => x.Doctor));
		}

		[HttpGet]
		public ActionResult Create()
		{
			Consts.CheckIfLoggedIn(System.Web.HttpContext.Current);

			Patient patient = new Patient
			{
				DOB = DateTime.Now
			};
			return View(LoadDDLOptions(patient));
		}

		[HttpPost]
		public ActionResult Create(Patient patient)
		{
			Consts.CheckIfLoggedIn(System.Web.HttpContext.Current);

			try
			{
				ctx.Patients.Add(patient);
				ctx.SaveChanges();
			}
			catch (Exception e)
			{
				System.Diagnostics.Debug.WriteLine("Error creating a patient: " + e.GetBaseException().ToString());
			}
			return RedirectToAction("Index");
		}

		public ActionResult Details(int id)
		{
			Consts.CheckIfLoggedIn(System.Web.HttpContext.Current);

			return View(PatientFromId(id));
		}

		[HttpGet]
		public ActionResult Edit(int id)
		{
			Consts.CheckIfLoggedIn(System.Web.HttpContext.Current);

			return View(LoadDDLOptions(PatientFromId(id)));
		}

		[HttpPost]
		public ActionResult Edit(Patient patient)
		{
			Consts.CheckIfLoggedIn(System.Web.HttpContext.Current);

			try
			{
				ctx.Entry(patient).State = System.Data.Entity.EntityState.Modified;
				ctx.SaveChanges();
			}
			catch (Exception e)
			{
				System.Diagnostics.Debug.WriteLine("Error editing a patient: " + e.GetBaseException().ToString());
			}
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult Delete(int id)
		{
			Consts.CheckIfLoggedIn(System.Web.HttpContext.Current);

			return View(PatientFromId(id));
		}

		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirm(int id)
		{
			Consts.CheckIfLoggedIn(System.Web.HttpContext.Current);
			try
			{
				Patient patient = ctx.Patients.Single(x => x.Id == id);
				ctx.Patients.Remove(patient);
				ctx.SaveChanges();
				return RedirectToAction("Index");
			}
			catch (Exception e)
			{
				System.Diagnostics.Debug.WriteLine("Error deleting a patient: " + e.GetBaseException().ToString());
			}
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