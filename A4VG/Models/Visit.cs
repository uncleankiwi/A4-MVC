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
		public Doctor Doctor { get; set; }
		public Patient Patient { get; set; }
		public IEnumerable<SelectListItem> PatientsList { get; set; }
		public IEnumerable<SelectListItem> DoctorsList { get; set; }

		[NotMapped]
		[DataType(DataType.Date)]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
		public DateTime Date { get; set; }

		[NotMapped]
		[DataType(DataType.Time)]
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