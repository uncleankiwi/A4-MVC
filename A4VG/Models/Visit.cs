using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace A4VG.Models
{
	[Table("tblVisits")]
	public class Visit
	{
		public int Id { get; set; }
		[Display(Name = "Doctor")]
		public int DoctorId { get; set; }
		[Display(Name = "Patient")]
		public int PatientId { get; set; }
		[Display(Name = "Date and Time"),
			DataType(DataType.DateTime),
			DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
		public DateTime DateAndTime { get; set; }
		public string Complaint { get; set; }

		public Doctor Doctor { get; set; }
		public Patient Patient { get; set; }
		public IEnumerable<SelectListItem> PatientsList { get; set; }
		public IEnumerable<SelectListItem> DoctorsList { get; set; }
	}
}