using FinalProjectMitre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using System.Dynamic;

namespace FinalProjectMitre.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        MitreEntities db = new MitreEntities();

        public ActionResult Index()
        {
            try
            {
                string username = HttpContext.User.Identity.Name;
                Accounts account = db.Accounts.Where(a => a.username == username).FirstOrDefault();
                Customers customer = db.Customers.Where(c => c.account_id == account.id).FirstOrDefault();
                dynamic profile = new ExpandoObject();
                profile.account = account;
                profile.customer = customer;
                return View(profile);
            }
            catch (Exception error)
            {
                Debug.WriteLine(error.Message);
                return View();
            }
        }
        [HttpPost]
        public ActionResult Update(int id, string username, string password, string name, string email, string phone, string confirmPassword)
        {
            try
            {
                Accounts account = db.Accounts.Where(a => a.id == id).FirstOrDefault();
                Customers customer = db.Customers.Where(c => c.account_id == id).FirstOrDefault();
                account.username = username;
                account.password = password;
                customer.name = name;
                customer.email = email;
                customer.phone = phone;
                if(confirmPassword == password)
                {
                    db.SaveChanges();
                }
                return Redirect("/Home");
            }
            catch (Exception error)
            {
                Debug.WriteLine(error.Message);
                return Redirect("/Home");
            }
            return Redirect("/Home");
        }

    }
}