using FinalProjectMitre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

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
            try
            {
                MitreEntities db = new MitreEntities();
                Accounts account = new Accounts();
                Customers customer = new Customers();
                account.username = form["username"].Trim();
                account.password = form["password"].Trim();
                customer.email = form["email"].Trim();
                customer.name = form["companyName"].Trim();
                customer.phone = form["phone"].Trim();
                Accounts newAccount = db.Accounts.Add(account);
                db.SaveChanges();
                customer.account_id = newAccount.id;
                db.Customers.Add(customer);
                db.SaveChanges();
            }
            catch (Exception error)
            {
                Debug.WriteLine(error.Message);
            }
            return View();
        }
    }

    
    
}