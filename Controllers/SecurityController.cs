using FinalProjectMitre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FinalProjectMitre.Controllers
{
    
    public class SecurityController : Controller
    {
        MitreAttackEntities1 db = new MitreAttackEntities1();
        // GET: Security
        [AllowAnonymous]//Security e sadece izin verdi
        public ActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]//Security e sadece izin verdi
        [HttpPost]
        public ActionResult Login(Accounts accounts)
        {
            var accountDb = db.Accounts.FirstOrDefault(x => x.username == accounts.username && x.password == accounts.password);
            if (accountDb != null)
            {
                FormsAuthentication.SetAuthCookie(accounts.username, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Mesaj = "Username or password is incorrect..!";
            }
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}