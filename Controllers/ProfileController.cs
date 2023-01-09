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
        MitreAttackEntities1 db = new MitreAttackEntities1();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CustomerInfo(int id)
        {
            var customer = db.Customers.Find(customer_id);
            return View("P");
        }

    }
}