using A4VG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace A4VG.Controllers
{
    public class DoctorController : Controller
    {
        // GET: Doctor
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
		{

		}

        [HttpPost]
        public ActionResult Create(Doctor doctor)
		{

		}

        public ActionResult Details()
		{

		}

        [HttpGet]
        public ActionResult Edit(int id)
		{

		}

        [HttpPost]
        public ActionResult Edit()
		{

		}

        [HttpGet]
        public ActionResult Delete(int id)
		{

		}

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
		{

		}

        public ActionResult ViewFromId(int id)
		{

		}

    }
}