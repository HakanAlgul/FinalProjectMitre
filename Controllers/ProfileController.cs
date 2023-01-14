using FinalProjectMitre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProjectMitre.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        MitreEntities db = new MitreEntities();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CustomerInfo(int id)
        {
            var customer = db.Customers.Find(id);
            return View("P");
        }

    }
}