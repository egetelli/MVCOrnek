using MVCOrnek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCOrnek.Controllers
{
    public class RentController : Controller
    {
        private supercarEntities db = new supercarEntities();
        // GET: Rent
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetCar()
        {
            var car = db.carreg.ToList(); 
            return Json(car, JsonRequestBehavior.AllowGet);
        }

    }
}