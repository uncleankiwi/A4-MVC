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
		public int PatientId { get; set; }

		[Display(Name = "Admission Date and Time"),
		DataType(DataType.DateTime),
		DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
		public DateTime? Admitted { get; set; }

		[Column(TypeName = "datetime2")]
		[Display(Name = "Admission Date and Time"),
		DataType(DataType.DateTime),
		DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
		public DateTime? Discharged { get; set; }

		public string Unit { get; set; }
		public string Room { get; set; }
		public string Bed { get; set; }

		[NotMapped]
		[DataType(DataType.Date)]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
		public DateTime AdmittedDate { get; set; }

		[NotMapped]
		[DataType(DataType.Time)]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
		public DateTime AdmittedTime { get; set; }

		[NotMapped]
		[DataType(DataType.Date)]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
		public DateTime DischargedDate { get; set; }

		[NotMapped]
		[DataType(DataType.Time)]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
		public DateTime DischargedTime { get; set; }

		public Admission()
		{
			InitDateTime();
		}

		//separate DateTime into Date and Time attributes
		public void InitDateTime()
		{
			if (this.Admitted != null)
			{
				this.AdmittedDate = (DateTime)this.Admitted;
				this.AdmittedTime = (DateTime)this.Admitted;
			}
			if (this.Discharged != null)
			{
				this.DischargedDate = (DateTime)this.Discharged;
				this.DischargedTime = (DateTime)this.Discharged;
			}
		}

		//use Date and Time to populate DateTime
		public void ParseDateTime()
		{
			if (this.AdmittedDate != null & this.AdmittedTime != null)
			{
				this.Admitted = this.AdmittedDate + this.AdmittedTime.TimeOfDay;
			}

			if (this.DischargedDate != null & this.DischargedTime != null)
			{
				this.Discharged = this.DischargedDate + this.DischargedTime.TimeOfDay;
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