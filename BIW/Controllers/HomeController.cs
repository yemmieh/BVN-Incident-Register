using CoreBVN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIW.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            
            StaffADProfile staffADProfile = new StaffADProfile();
            // staffADProfile.user_logon_name = Environment.UserName;
            staffADProfile.user_logon_name = User.Identity.Name;

         //   staffADProfile.user_logon_name = "ijeoma.okoye";

            //AD
            ActiveDirectoryQuery activeDirectoryQuery = new ActiveDirectoryQuery(staffADProfile);
            staffADProfile = activeDirectoryQuery.GetStaffProfile();
            Profile profile = new Profile();
            profile = new LinqCalls().getProfile(staffADProfile.employee_number);
            bool checkICA = new IC_A_Users().ValidateCheckApproverUser(staffADProfile.employee_number);
            ViewData["ICA"] = checkICA;
            bool checkAdmin = new IC_A_Users().ValidateAdminUser(staffADProfile.employee_number);
            ViewData["Admin"] = checkAdmin;
            if (profile.JobTitle == "HEAD OF OPERATIONS" || profile.JobTitle == "ACTING HEAD OF OPERATIONS" || checkAdmin == true)
            {
                ViewData["HopUser"] = true;
            }
            else
            {
                ViewData["HopUser"] = false;
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}