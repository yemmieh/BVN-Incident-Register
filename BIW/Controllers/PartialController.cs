using CoreBVN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace BIW.Controllers
{
    public class PartialController : Controller
    {
        string errorResult = "";
        public ActionResult HistoryIndex(string id)
        {
            // List<ApprovalDetails> History = new List<ApprovalDetails>();
            //History = new AppClass().getHistory(id);


            XElement ApprovalHistory = new ProcessEntry().getApprovalHistory(id);
            XDocument xDocument = DataHandlers.ToXDocument(ApprovalHistory);

            List<ApprovalDetails> approvalHistory = xDocument.Descendants("Approvals")
                .Select(det => new ApprovalDetails
                {
                    ApproverNames = det.Element("ApproverName").Value,
                    ApproverStaffNumbers = det.Element("ApproverStaffNumber").Value,
                    ApprovedStages = det.Element("ApprovedStage").Value,
                    ApproverAction = det.Element("ApproverAction").Value,
                    ApprovalDateTime = det.Element("ApprovalDateTime").Value,
                    ApproverComment = det.Element("ApproverComment").Value.Equals("") ? "None" : det.Element("ApproverComment").Value,
                })
                .ToList();


            return PartialView("HistoryIndex", approvalHistory);
        }

        public ActionResult GetAccountInfo(string BVN)
        {
            
            StaffADProfile staffADProfile = new StaffADProfile();
            // staffADProfile.user_logon_name = Environment.UserName;
            staffADProfile.user_logon_name = User.Identity.Name;

            //AD
            ActiveDirectoryQuery activeDirectoryQuery = new ActiveDirectoryQuery(staffADProfile);
            staffADProfile = activeDirectoryQuery.GetStaffProfile();
            Profile profile = new Profile();
            profile = new LinqCalls().getProfile(staffADProfile.employee_number);
            if (profile.JobTitle == "HEAD OF OPERATIONS" || profile.JobTitle == "ACTING HEAD OF OPERATIONS")
            {
                ViewData["HopUser"] = true;
                ViewData["ICA"] = false;

                List<Account> details = new List<Account>();

                details = new PheonixQuery().getAccounts(BVN);

                if (details == null)
                {
                    errorResult = string.Format(errorResult, "Error", "No Account");
                    return Content(errorResult, "application/json");
                }
                else
                {

                    return PartialView("GetAccountInfo", details);
                }
            }
            else
            {
                ViewData["HopUser"] = false;
                ViewData["ICA"] = false;
                TempData["ErrorMessage"] = "You are not Authorized to view this page";
                //TempData["Approvernames"] = string.Join("\\n", approverNames);               
                return RedirectToAction("ErrorPage");
            }

            
        }


    }
}