using A4VG.Globals;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace A4VG.Models
{
	[Table("tblPatients")]
	public class Patient
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Telephone { get; set; }
		public string Address { get; set; }
		[Display(Name = "Doctor")]
		public int DoctorId { get; set; }
		[DataType(DataType.Date),
			DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
		public DateTime DOB { get; set; }
		public Doctor Doctor { get; set; }
		public IEnumerable<SelectListItem> DoctorsList { get; set; }
	}
}