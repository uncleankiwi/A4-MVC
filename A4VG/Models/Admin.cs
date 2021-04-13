using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace A4VG.Models
{
	[Table("tblAdmins")]
	public class Admin
	{
		public int Id { get; set; }
		[Display(Name = "Username")]
		public String AdminName { get; set; }
		[Display(Name = "Password")]
		public String AdminPass { get; set; }
		[NotMapped]
		public String ErrorMessage { get; set; }
	}
}