using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace A4VG.Models
{
	public class Context : DbContext
	{
		public DbSet<Doctor> Doctors { get; set; }
		public DbSet<Patient> Patients { get; set; }
		public DbSet<Visit> Visits { get; set; }
		public DbSet<Admin> Admins { get; set; }
	}
}