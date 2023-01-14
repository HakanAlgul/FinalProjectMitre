using FinalProjectMitre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

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
                string isMacSafe = checkMac(mac);
                return View(isMacSafe);
            }
            catch (Exception)
            {
                string isMacSafe = "failed";
                return View(isMacSafe);
            }
        }
    }
}