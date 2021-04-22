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

		[Required(ErrorMessage = "Enter the patient's name")]
		[MaxLength(50)]
		public string Name { get; set; }

		[MaxLength(50)]
		[EmailAddress(ErrorMessage = "Enter a valid email address")]
		public string Email { get; set; }

		[MaxLength(50)]
		public string Telephone { get; set; }

		[MaxLength(50)]
		public string Address { get; set; }

		[Display(Name = "Doctor")]
		public int DoctorId { get; set; }

		[Required(ErrorMessage = "Enter the patient's date of birth")]
		[DataType(DataType.Date)]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
		public DateTime DOB { get; set; }

		//---------------------------viewmodel attributes below---------------------------
		//--------------------------------------------------------------------------------
		public Doctor Doctor { get; set; }
		public IEnumerable<SelectListItem> DoctorsList { get; set; }
		public List<Admission> Admissions { get; set; }

		[NotMapped]
		public Admission AdmissionLookup { get; set; }
		//for the partial views in patient details that are of Patient model but must
		//lookup a certain Admission
		[NotMapped]
		public int AdmissionLookupId { get; set; }
	}
}