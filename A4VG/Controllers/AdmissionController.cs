using A4VG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using A4VG.Globals;

//view to view:
//patient details	-patient--> index

//action to action:
//index				----pid---> create
//					----aid---> details
//					----aid---> edit
//					----aid---> delete


namespace A4VG.Controllers
{
	public class AdmissionController : Controller
	{
		readonly Context ctx = new Context();

		// GET: Admission
		public PartialViewResult Index(int patientId)
		{
			try 
			{
				Patient patient = Consts.PatientFromId(patientId);
				patient = LoadAdmissionsList(patient);
				return PartialView("~/Views/Patient/Admission/_Index.cshtml", patient);
			}
			catch (Exception e)
			{
				System.Diagnostics.Debug.WriteLine("Error listing admissions: " + e.GetBaseException().ToString());
			}
			return null;
		}

		// GET: Admission/Details/5
		public PartialViewResult Details(int admissionId)
		{
			return PartialView("~/Views/Patient/Admission/_Details.cshtml", AdmissionFromId(admissionId));
		}

		// GET: Admission/Create
		public PartialViewResult Create(int patientId)
		{
			Admission admission = new Admission
			{
				Admitted = DateTime.Now
			};
			admission.InitDateTime();
			admission.PatientId = patientId;
			return PartialView("~/Views/Patient/Admission/_Create.cshtml", admission);

		}

		// POST: Admission/Create
		[HttpPost]
		public PartialViewResult Create(Admission admission)
		{
			
			try
			{
				if (ModelState.IsValid)
				{
					//TODO sad
				}
				else
				{

				}
				int patientId = admission.PatientId;
				admission.ParseDateTime();
				ctx.Admissions.Add(admission);
				ctx.SaveChanges();
				return Index(patientId);
			}
			catch (Exception e)
			{
				System.Diagnostics.Debug.WriteLine("Error creating an admission: " + e.GetBaseException().ToString());
			}
			return null;
		}

		// GET: Admission/Edit/5
		public PartialViewResult Edit(int admissionId)
		{
			Admission admission = AdmissionFromId(admissionId);
			admission.InitDateTime();
			return PartialView("~/Views/Patient/Admission/_Edit.cshtml", admission);
		}

		// POST: Admission/Edit/5
		[HttpPost]
		public PartialViewResult Edit(Admission admission)
		{
			try
			{
				if (ModelState.IsValid)
				{
					//TODO sadasf
				}
				else
				{

				}
				int patientId = admission.PatientId;
				patientId = admission.PatientId;
				admission.ParseDateTime();
				ctx.Entry(admission).State = EntityState.Modified;
				ctx.SaveChanges();
				return Index(patientId);
			}
			catch (Exception e)
			{
				System.Diagnostics.Debug.WriteLine("Error editing an admission: " + e.GetBaseException().ToString());
			}
			return null;
		}

		// GET: Admission/Delete/5
		public PartialViewResult Delete(int admissionId)
		{
			return PartialView("~/Views/Patient/Admission/_Delete.cshtml", AdmissionFromId(admissionId));
		}

		// POST: Admission/Delete/5
		[HttpPost, ActionName("Delete")]
		public PartialViewResult DeleteConfirm(int admissionId)
		{
			try
			{
				Admission admission = ctx.Admissions.Single(x => x.Id == admissionId);
				int patientId = admission.PatientId;
				ctx.Admissions.Remove(admission);
				ctx.SaveChanges();
				return Index(patientId);
			}
			catch (Exception e)
			{
				System.Diagnostics.Debug.WriteLine("Error deleting an admission: " + e.GetBaseException().ToString());
			}
			return null;
		}

		// ============ utility methods ============ 

		private Admission AdmissionFromId(int id)
		{
			return ctx.Admissions
				.Single(x => x.Id == id);
		}

		public Patient LoadAdmissionsList(Patient p)
		{
			try
			{
				p.Admissions = ctx.Admissions
				.Where(x => x.PatientId == p.Id)
				.ToList();
				return p;

			}
			catch (Exception e)
			{
				System.Diagnostics.Debug.WriteLine("Error loading admissions list: " + e.GetBaseException().ToString());
				return null;
			}
		}
	}
}
