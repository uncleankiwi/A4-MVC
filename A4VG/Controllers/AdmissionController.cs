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
	public class AdmissionController : Controller
	{
		readonly Context ctx = new Context();

		// GET: Admission
		public PartialViewResult Index(Patient patient)
		{
			patient = Consts.LoadAdmissionsList(patient);
			return PartialView("~/Views/Admission/_Index.cshtml", patient);
		}

		// GET: Admission/Details/5
		public PartialViewResult Details(Patient p)	//int id
		{
			p.AdmissionLookup = AdmissionFromId(p.AdmissionLookupId);
			return PartialView(p);
		}

		//// GET: Admission/Create
		//public PartialViewResult Create()
		//{
		//	Admission admission = new Admission
		//	{
		//		Admitted = DateTime.Now
		//	};
		//	admission.InitDateTime();
		//	return PartialView(admission);
		//}

		//// POST: Admission/Create
		//[HttpPost]
		//public PartialViewResult Create(Admission admission, int patientId)
		//{
		//	try
		//	{
		//		admission.PatientId = patientId;
		//		admission.ParseDateTime();
		//		ctx.Admissions.Add(admission);
		//		ctx.SaveChanges();

		//	}
		//	catch (Exception e)
		//	{
		//		System.Diagnostics.Debug.WriteLine("Error creating an admission: " + e.GetBaseException().ToString());
		//	}
		//	return Index(patientId);
		//}

		//// GET: Admission/Edit/5
		//public PartialViewResult Edit(int id)
		//{
		//	Admission admission = AdmissionFromId(id);
		//	admission.InitDateTime();
		//	return PartialView(admission);
		//}

		//// POST: Admission/Edit/5
		//[HttpPost]
		//public PartialViewResult Edit(Admission admission, int patientId)
		//{
		//	try
		//	{
		//		admission.PatientId = patientId;
		//		admission.ParseDateTime();
		//		ctx.Entry(admission).State = EntityState.Modified;
		//		ctx.SaveChanges();
		//	}
		//	catch (Exception e)
		//	{
		//		System.Diagnostics.Debug.WriteLine("Error editing an admission: " + e.GetBaseException().ToString());
		//	}
		//	return Index(patientId);
		//}

		//// GET: Admission/Delete/5
		//public PartialViewResult Delete(int id)
		//{
		//	return PartialView("", AdmissionFromId(id));
		//}

		//// POST: Admission/Delete/5
		//[HttpPost, ActionName("Delete")]
		//public PartialViewResult DeleteConfirm(int id, int patientId)
		//{
		//	try
		//	{
		//		Admission admission = ctx.Admissions.Single(x => x.Id == id);
		//		ctx.Admissions.Remove(admission);
		//		ctx.SaveChanges();
		//		return Index();
		//	}
		//	catch (Exception e)
		//	{
		//		System.Diagnostics.Debug.WriteLine("Error deleting an admission: " + e.GetBaseException().ToString());
		//	}
		//	return Index(patientId);
		//}

		// ============ utility methods ============ 

		private Admission AdmissionFromId(int id)
		{
			return ctx.Admissions
				.Single(x => x.Id == id);
		}
	}
}
