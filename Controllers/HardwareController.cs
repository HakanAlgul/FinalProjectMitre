using FinalProjectMitre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using System.Web.Security;
using System.Runtime.InteropServices;

namespace FinalProjectMitre
{
    public class HardwareController : Controller
    {
        MitreEntities db = new MitreEntities();

        protected string checkMac(string mac)
        {
            try
            {
                if (db.MAC_Addresses.Any(m => m.mac_address == mac))
                {
                    return "safe";
                }
                else
                {
                    return "dangerous";
                }
            }
            catch (Exception error)
            {
                Debug.WriteLine(error.Message);
                return "failed";
            }
        }

        // GET: Hardware
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult History()
        {
            try
            {
                List<Hardware_Additions> hardwareList = db.Hardware_Additions.ToList();
                return View(hardwareList);
            }
            catch (Exception error)
            {
                Debug.WriteLine(error.Message);
                return View();
            }
        }
        public ActionResult Test()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Test(string mac)
        {
            try
            {
                string username = HttpContext.User.Identity.Name;
                Accounts account = db.Accounts.Where(a => a.username == username).FirstOrDefault();
                Customers customer = db.Customers.Where(c => c.account_id == account.id).FirstOrDefault();
                Hardware_Additions hardwareTest = new Hardware_Additions();
                hardwareTest.checked_device = mac;
                string isMacSafe = checkMac(mac);
                hardwareTest.result = isMacSafe;
                hardwareTest.customer_id = customer.id;
                DateTime now = DateTime.Now;
                hardwareTest.date = now;
                Hardware_Additions newHardwareTest = db.Hardware_Additions.Add(hardwareTest);
                db.SaveChanges();
                return View(newHardwareTest);
            }
            catch (Exception)
            {
                string isMacSafe = "failed";
                return View(isMacSafe);
            }
        }

        public ActionResult Failed()
        {
            return View();
        }
    }
}