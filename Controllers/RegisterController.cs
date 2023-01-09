using FinalProjectMitre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProjectMitre.Controllers
{
    [AllowAnonymous]// izin verir
    public class RegisterController : Controller
    {
        // GET: Register

       
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            MitreAttackEntities1 db = new MitreAttackEntities1();
            Accounts model = new Accounts();
            Customers models = new Customers();
            model.username = form["UserName"].Trim();
            model.password = form["Password"].Trim();
            models.email = form["Email"].Trim();
            models.name = form["CompanyName"].Trim();
            models.phone = form["PhoneNumber"].Trim();
            db.Accounts.Add(model);
            db.Customers.Add(models);
            db.SaveChanges();

            return View();
        }
    }

    
    
}