using A4VG.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace A4VG.Controllers
{
    public class DoctorController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
		{
            return View();
		}

        [HttpPost]
        public ActionResult Create(Doctor doctor)
		{
            Context context = new Context();
            context.Doctors.Add(doctor);
            context.SaveChanges();
            return RedirectToAction("Index");
		}

        public ActionResult Details(int id)
		{
            return ViewFromId(id);
        }

        [HttpGet]
        public ActionResult Edit(int id)
		{
            return ViewFromId(id);
        }

        [HttpPost]
        public ActionResult Edit(Doctor doctor)
		{
            Context context = new Context();
            context.Entry(doctor).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
		{
            return ViewFromId(id);
		}

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
		{
            Context context = new Context();
            Doctor doctor = context.Doctors.Single(x => x.Id == id);
            context.Doctors.Remove(doctor);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ViewFromId(int id)
		{
            Context context = new Context();
            Doctor doctor = context.Doctors.Single(x => x.Id == id); //or context.Doctors.Find(id);
            return View(doctor);
		}

    }
}