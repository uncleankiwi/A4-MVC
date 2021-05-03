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
		[MaxLength(50, ErrorMessage = "{0} cannot be longer than {1} characters")]
		public string Name { get; set; }

		[MaxLength(50, ErrorMessage = "{0} cannot be longer than {1} characters")]
		[EmailAddress(ErrorMessage = "Enter a valid email address")]
		public string Email { get; set; }

		[MaxLength(50, ErrorMessage = "{0} cannot be longer than {1} characters")]
		public string Telephone { get; set; }

		[MaxLength(50, ErrorMessage = "{0} cannot be longer than {1} characters")]
		public string Address { get; set; }

		[Display(Name = "Doctor")]
		public int DoctorId { get; set; }

		[Required(ErrorMessage = "Enter the patient's date of birth")]
		[DataType(DataType.Date)]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
		public DateTime DOB { get; set; }

		//---------------------------viewmodel attributes below---------------------------
		//--------------------------------------------------------------------------------
		
		//the patient's main doctor, as object
		public Doctor Doctor { get; set; }

		//drop down list of doctors who can be assigned to this patient
		public IEnumerable<SelectListItem> DoctorsList { get; set; }
		
		//list of this patient's admissions in the past
		public List<Admission> Admissions { get; set; }

		//for the partial views in patient details that are of Patient model but must
		//lookup a certain Admission
		[NotMapped]
		public int AdmissionLookupId { get; set; }
	}
}