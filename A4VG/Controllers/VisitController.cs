using A4VG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace A4VG.Controllers
{
    public class VisitController : Controller
    {
        public ActionResult Index()
        {
            return View(new Context().Visits
                .Include(x => x.Doctor)
                .Include(x => x.Patient));
        }

        [HttpGet]
        public ActionResult Create()
		{
            return View();
		}

        [HttpPost]
        public ActionResult Create(Visit visit)
		{
            Context context = new Context();
            context.Visits.Add(visit);
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
        public ActionResult Edit(Visit visit)
		{
            Context context = new Context();
            context.Entry(visit).State = System.Data.Entity.EntityState.Modified;
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
            Visit visit = context.Visits.Single(x => x.Id == id);
            context.Visits.Remove(visit);
            context.SaveChanges();
            return RedirectToAction("Index");
		}

        public ActionResult ViewFromId(int id)
		{
            Context context = new Context();
            Visit visit = context.Visits.Single(x => x.Id == id);
            return View(visit);
		}
    }
}