using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoreBVN;

namespace BIW.Controllers
{
    public class IncidentController : Controller
    {
        string errorResult = null;
      //  private static string mailTo = "oyeyemi.oyetoro@zenithbank.com";

         [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult MyInicidentEntry()
        {
            StaffADProfile staffADProfile = new StaffADProfile();
            // staffADProfile.user_logon_name = Environment.UserName;
            staffADProfile.user_logon_name  =  User.Identity.Name;

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
               // ViewData["Admin"] = false;
                ViewData["HopUser"] = true;
               // ViewData["ICA"] = false;
                var EntryList = new ProcessEntry().GetMyIncidentEntry(staffADProfile);
                ViewBag.coInit = (String.IsNullOrEmpty(TempData["ErrorMessage"] as string)) ?
                   "" : "<script type='text/javascript'>alert('" + TempData["ErrorMessage"] + "');</script>";
                return View(EntryList);
            }
            else
            {
              //  ViewData["Admin"] = false;
                ViewData["HopUser"] = false;
                //ViewData["ICA"] = false;
                TempData["ErrorMessage"] = "You are not Authorized to view this page";
                //TempData["Approvernames"] = string.Join("\\n", approverNames);               
                return RedirectToAction("ErrorPage");
            }
            
        }


        [Authorize]
        public ActionResult NewIncident()
        {

             long ticks = DateTime.Now.Ticks;
            byte[] bytes = BitConverter.GetBytes(ticks);
            string id = Convert.ToBase64String(bytes)
                                    .Replace('+', '_')
                                    .Replace('/', '-')
                                    .TrimEnd('=');

            StaffADProfile staffADProfile = new StaffADProfile();
            // staffADProfile.user_logon_name = Environment.UserName;
            staffADProfile.user_logon_name = User.Identity.Name;

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
                

                InputClass input = new InputClass();
                Account account = new Account();
                input.RequesterDetails = profile;
                input.RequesterDetails.JobTitle = profile.JobTitle;
                input.RequesterDetails.Job_Category = profile.JobTitle;
                input.AccountDetials = account;
                input.RequesterDetails.Email = staffADProfile.email;
                input.DocumentID = profile.StaffNo + "BVNINCIDENT" + id;

                return View(input);

            }
            else
            {
               
                ViewData["HopUser"] = false;
                
                TempData["ErrorMessage"] = "You are not Authorized to view this page";
                return RedirectToAction("ErrorPage");
            }

           
            //AD
          
            
        }

        [Authorize]
        public ActionResult SaveBVNIncident(InputClass incidentInput)
        {


            StaffADProfile staffADProfile = new StaffADProfile();
            // staffADProfile.user_logon_name = Environment.UserName;
            staffADProfile.user_logon_name = User.Identity.Name;

            //AD
            ActiveDirectoryQuery activeDirectoryQuery = new ActiveDirectoryQuery(staffADProfile);
            staffADProfile = activeDirectoryQuery.GetStaffProfile();
            Profile profile = new Profile();
            profile = new LinqCalls().getProfile(staffADProfile.employee_number);
            bool checkICA = new IC_A_Users().ValidateCheckApproverUser(staffADProfile.employee_number);
            ViewData["ICA"] = checkICA;
            bool checkAdmin = new IC_A_Users().ValidateAdminUser(staffADProfile.employee_number);
            ViewData["Admin"] = checkAdmin;


            if (incidentInput.Comment == "" || incidentInput.Comment == null)
            {
                incidentInput.Comment = "none";
            }
            if (profile.JobTitle == "HEAD OF OPERATIONS" || profile.JobTitle == "ACTING HEAD OF OPERATIONS" || checkAdmin == true)
            {
                
                ViewData["HopUser"] = true;
                

                //string[] Irregularityarray = incidentInput.Irregularity.Split(':');
                //incidentInput.Irregularity = Irregularityarray[0];

                if (incidentInput.IrregularityDetails == null)
                {
                    incidentInput.IrregularityDetails = "";
                }
                var initiateIncidental = new ProcessSubmit().initiateIncident(incidentInput, "AppraisalDbConnectionString");
                string[] result = initiateIncidental.ToString().Split('|');

                if (result[0] != "0")
                {

                   
                    ViewData["HopUser"] = true;

                    TempData["ErrorMessage"] = result[1];
                    //TempData["TravelRequest"] = incidentInput;
                    return RedirectToAction("ErrorPage");

                }
                else
                { 
                   // List<ApproverInfo> approversnames = new List<ApproverInfo>();
                    List<ApproverInfo> approvers = new List<ApproverInfo>();
                    approvers = new IC_A_Users().getApproverInfo();
                    var approverNames = new IC_A_Users().getApprovernames();
                    foreach (var approver in approvers)
                    {
                        SendEmail newmail = new SendEmail();
                        newmail.sendEmail(approver.Email, incidentInput.AccountDetials.Firstname, incidentInput.AccountDetials.LastName, incidentInput.AccountDetials.AccountName, incidentInput.AccountDetials.BVN, incidentInput.Irregularity, incidentInput.Comment, incidentInput.RequesterDetails.Branch, incidentInput.RequesterDetails.StaffName);
                    }
                        TempData["Key"] = "Insert";
                    TempData["ErrorMessage"] = "You have successfully submitted your Entry";
                   
                    TempData["TravelRequest"] = incidentInput;
                    return RedirectToAction("MyInicidentEntry");
                }
            }
            else
            {
                ViewData["HopUser"] = false;
               
                TempData["ErrorMessage"] = "You are not Authorized to view this page";
                //TempData["Approvernames"] = string.Join("\\n", approverNames);               
                return RedirectToAction("ErrorPage");
            }        
                      

        }


        [Authorize]
        public ActionResult BranchEntry(string BranchCode)
        {

            StaffADProfile staffADProfile = new StaffADProfile();
            // staffADProfile.user_logon_name = Environment.UserName;
            staffADProfile.user_logon_name = User.Identity.Name;

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
               
                var EntryList = new ProcessEntry().SearchBranchRequest(BranchCode);
                return View(EntryList);
            }
            else
            {
                ViewData["HopUser"] = false;
               
                TempData["ErrorMessage"] = "You are not Authorized to view this page";
                //TempData["Approvernames"] = string.Join("\\n", approverNames);               
                return RedirectToAction("ErrorPage");
            }        
                      
          
        }


        [Authorize]
        public ActionResult MyBranchEntry()
        {

            StaffADProfile staffADProfile = new StaffADProfile();
            // staffADProfile.user_logon_name = Environment.UserName;
            staffADProfile.user_logon_name = User.Identity.Name;

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
                
                var EntryList = new ProcessEntry().SearchBranchRequest(profile.BranchCode.ToString());
                return View(EntryList);
            }
            else
            {
               
                ViewData["HopUser"] = false;
               
                TempData["ErrorMessage"] = "You are not Authorized to view this page";
                //TempData["Approvernames"] = string.Join("\\n", approverNames);               
                return RedirectToAction("ErrorPage");
            }     
            

        }

        [Authorize]
        public ActionResult OpenIncident(string DocumentID)
        {
            StaffADProfile staffADProfile = new StaffADProfile();
            // staffADProfile.user_logon_name = Environment.UserName;
            staffADProfile.user_logon_name = User.Identity.Name;

            //AD
            ActiveDirectoryQuery activeDirectoryQuery = new ActiveDirectoryQuery(staffADProfile);
            staffADProfile = activeDirectoryQuery.GetStaffProfile();
            Profile profile = new Profile();
            profile = new LinqCalls().getProfile(staffADProfile.employee_number);
            bool checkICA = new IC_A_Users().ValidateCheckApproverUser(staffADProfile.employee_number);
            ViewData["ICA"] = checkICA;
            bool checkAdmin = new IC_A_Users().ValidateAdminUser(staffADProfile.employee_number);
            ViewData["Admin"] = checkAdmin;

            if (profile.JobTitle == "HEAD OF OPERATIONS" || profile.JobTitle == "ACTING HEAD OF OPERATIONS" || checkAdmin == true || checkICA == true)
            {
                if (profile.JobTitle == "HEAD OF OPERATIONS" || profile.JobTitle == "ACTING HEAD OF OPERATIONS" || checkAdmin == true)
                {
                    
                    ViewData["HopUser"] = true;
                    
                }
                else
                {
                   
                    ViewData["HopUser"] = false;
                   
                }
               InputClass Entry = new InputClass();
                 Entry = new ProcessEntry().GetEntry(DocumentID).First();
                 ViewBag.date = Entry.DateSubmitted;
                return View(Entry);
            }
            else
            {
               
                ViewData["HopUser"] = false;
                
                TempData["ErrorMessage"] = "You are not Authorized to view this page";                           
                return RedirectToAction("ErrorPage");
            }    
            
        }


        public ActionResult getActDetails(string AccNo)
        {
            Account details = new Account();
            details = new OpenEntry().getaccountdetails(AccNo);
            if (details == null)
            {
                errorResult = string.Format(errorResult, "Error", "No records found for the Account number");
                return Content(errorResult, "application/json");
            }
            else
            {
                return Json(details, JsonRequestBehavior.AllowGet);
            }
        }

         [Authorize]
        public ActionResult ErrorPage()
        {
            StaffADProfile staffADProfile = new StaffADProfile();
            // CurrentUser currentuser = new CurrentUser();
            staffADProfile.user_logon_name = User.Identity.Name;

            ActiveDirectoryQuery activeDirectoryQuery = new ActiveDirectoryQuery(staffADProfile);

            staffADProfile = activeDirectoryQuery.GetStaffProfile();
            //currentuser.UserNo = staffADProfile.employee_number;
            //bool checkAdmin = new IC_A_Users().ValidateAdminUser(staffADProfile.employee_number);
            ////ViewData["checkAdmin"] = checkAdmin;

            //bool checkApproverUser = new IC_A_Users().ValidateCheckApproverUser(staffADProfile.employee_number);
            //ViewData["checkApproverUser"] = checkApproverUser;

            bool checkICA = new IC_A_Users().ValidateCheckApproverUser(staffADProfile.employee_number);
            ViewData["ICA"] = checkICA;
            bool checkAdmin = new IC_A_Users().ValidateAdminUser(staffADProfile.employee_number);
            ViewData["Admin"] = checkAdmin;

            Profile profile = new Profile();
            profile = new LinqCalls().getProfile(staffADProfile.employee_number);
            if (profile.JobTitle == "HEAD OF OPERATIONS" || profile.JobTitle == "ACTING HEAD OF OPERATIONS" || checkAdmin == true)
            {
                ViewData["HopUser"] = true;
            }
            else
            {
                ViewData["HopUser"] = false;
            }
            ViewBag.ErrorMessage = TempData["ErrorMessage"] as string;
            return View();
        }
    }
}