using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace A4VG.Models
{
	[Table("tblDoctors")]
	public class Doctor
	{
		public int Id { get; set; }

		[MaxLength(50, ErrorMessage = "{0} cannot be longer than {1} characters")]
		public string Office { get; set; }

		[Required(ErrorMessage = "Enter the doctor's name")]
		[MaxLength(50, ErrorMessage = "{0} cannot be longer than {1} characters")]
		public string Name { get; set; }

		[MaxLength(50, ErrorMessage = "{0} cannot be longer than {1} characters")]
		[EmailAddress(ErrorMessage = "Enter a valid email address")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Enter the doctor's phone number")]
		[MaxLength(50, ErrorMessage = "{0} cannot be longer than {1} characters")]
		public string Telephone { get; set; }

		[MaxLength(50, ErrorMessage = "{0} cannot be longer than {1} characters")]
		[Required(ErrorMessage = "Enter the doctor's address")]
		public string Address { get; set; }
	}
}