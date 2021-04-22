using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace A4VG.Models
{
	[Table("tblAdmissions")]
	public class Admission
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Select a patient")]
		public int PatientId { get; set; }

		[Display(Name = "Admission Date and Time"),
		DataType(DataType.DateTime),
		DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
		public DateTime? Admitted { get; set; }

		[Column(TypeName = "datetime2")]
		[Display(Name = "Discharge Date and Time"),
		DataType(DataType.DateTime),
		DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
		public DateTime? Discharged { get; set; }

		[MaxLength(50)]
		public string Unit { get; set; }

		[MaxLength(50)]
		public string Room { get; set; }

		[MaxLength(50)]
		public string Bed { get; set; }

		//---------------------------viewmodel attributes below---------------------------
		//--------------------------------------------------------------------------------
		[NotMapped]
		[DataType(DataType.Date)]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
		public DateTime? AdmittedDate { get; set; }

		[NotMapped]
		[DataType(DataType.Time)]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
		public DateTime? AdmittedTime { get; set; }

		[NotMapped]
		[DataType(DataType.Date)]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
		public DateTime? DischargedDate { get; set; }

		[NotMapped]
		[DataType(DataType.Time)]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
		public DateTime? DischargedTime { get; set; }

		public Admission()
		{
			InitDateTime();
		}

		//separate DateTime into Date and Time attributes
		public void InitDateTime()
		{
			if (this.Admitted != null)
			{
				this.AdmittedDate = this.Admitted;
				this.AdmittedTime = this.Admitted;
			}
			else
			{
				this.AdmittedDate = null;
				this.AdmittedTime = null;
			}
			if (this.Discharged != null)
			{
				this.DischargedDate = this.Discharged;
				this.DischargedTime = this.Discharged;
			}
			else
			{
				this.DischargedDate = null;
				this.DischargedTime = null;
			}
		}

		//use Date and Time to populate DateTime
		public void ParseDateTime()
		{
			if (this.AdmittedDate != null & this.AdmittedTime != null)
			{
				this.Admitted = this.AdmittedDate + ((DateTime) this.AdmittedTime).TimeOfDay;
			}
			else //clear admitted time
			{
				this.Admitted = null;
			}

			if (this.DischargedDate != null & this.DischargedTime != null)
			{
				this.Discharged = this.DischargedDate + ((DateTime) this.DischargedTime).TimeOfDay;
			}
			else
			{
				this.Discharged = null;
			}
		}

		override
		public string ToString()
		{
			return "[Admission " +
				" id:" + Id + 
				" pid:" + PatientId +
				" admitted:" + Admitted +
				" discharged:" + Discharged +
				" unit:" + Unit +
				" room:" + Room +
				" bed:" + Bed +
				"]";
		}
	}
}