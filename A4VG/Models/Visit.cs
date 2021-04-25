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

		[Required(ErrorMessage = "Select a patient")]
		[Display(Name = "Patient")]
		public int PatientId { get; set; }

		[Display(Name = "Date and Time"),
			DataType(DataType.DateTime),
			DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
		public DateTime DateAndTime { get; set; }

		[MaxLength(300, ErrorMessage = "{0} cannot be longer than {1} characters")]
		public string Complaint { get; set; }


		//---------------------------viewmodel attributes below---------------------------
		//--------------------------------------------------------------------------------
		
		//doctor object referenced by doctorId
		public Doctor Doctor { get; set; }

		//patient object referenced by patientId
		public Patient Patient { get; set; }

		//list of patients who can be assigned to this visit
		public IEnumerable<SelectListItem> PatientsList { get; set; }

		//list of doctors who can be assigned to this visit
		public IEnumerable<SelectListItem> DoctorsList { get; set; }

		//visit DateTime is split into the following two for editing/creation, then put back together in the db
		[NotMapped]
		[DataType(DataType.Date)]
		[Required(ErrorMessage = "Enter a valid date for the visit")]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
		public DateTime Date { get; set; }

		[NotMapped]
		[DataType(DataType.Time)]
		[Required(ErrorMessage = "Enter a valid time for the visit")]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
		public DateTime Time { get; set; }
		public Visit()
		{
			InitDateTime();
		}

		//separate DateTime into Date and Time attributes
		public void InitDateTime()
		{
			if (this.DateAndTime != null)
			{
				this.Date = this.DateAndTime;
				this.Time = this.DateAndTime;
			}
		}

		//use Date and Time to populate DateTime
		public void ParseDateTime()
		{
			if (this.Date != null & this.Time != null)
			{
				this.DateAndTime = this.Date + this.Time.TimeOfDay;
			}
		}
	}
}