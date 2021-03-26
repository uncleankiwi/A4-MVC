using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace A4VG.Models
{
	[Table("tblVisits")]
	public class Visit
	{
		public int Id { get; set; }
		public int DoctorId { get; set; }
		public int PatientId { get; set; }
		public DateTime DateAndTime { get; set; }
		public string Complaint { get; set; }

		public Doctor Doctor { get; set; }
		public Patient Patient { get; set; }
	}
}