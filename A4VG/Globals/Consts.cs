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
		public static List<SelectListItem> GetDoctorsList()
		{
			List<SelectListItem> doctorsList = new List<SelectListItem>();
			List<Doctor> doctors = new Context().Doctors.ToList();
			foreach (Doctor d in doctors)
			{
				doctorsList.Add(new SelectListItem { Text = d.Name, Value = d.Id.ToString() });
			}
			return doctorsList;
		}
	}
}