using A4VG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace A4VG.Globals
{
	public class Consts
	{
		public static IEnumerable<SelectListItem> GetDoctorsDDL()
		{
			//.Select() is kind of like .stream()?
			//ToList() returns a List, Select() returns IEnumerable<whatever>
			return new Context().Doctors.ToList().Select(x => new SelectListItem
			{
				Value = x.Id.ToString(),
				Text = x.Id.ToString() + ": " + x.Name
			});
		}

		public static IEnumerable<SelectListItem> GetPatientsDDL()
		{
			return new Context().Patients.ToList().Select(x => new SelectListItem
			{
				Value = x.Id.ToString(),
				Text = x.Id.ToString() + ": " + x.Name
			});
		}
	}
}