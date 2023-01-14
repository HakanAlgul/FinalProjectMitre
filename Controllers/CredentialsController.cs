using FinalProjectMitre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProjectMitre.Controllers
{
    public class CredentialsController : Controller
    {


        // GET: Credentials
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult History()
        {
            MitreEntities db = new MitreEntities();
            List<Credentials_From_Password_Stores> credentialsList = db.Credentials_From_Password_Stores.ToList();
            return View(credentialsList);
        }
        public ActionResult Test()
        {
            return View();
        }
    }
}