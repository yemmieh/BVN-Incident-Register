using CoreBVN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIW.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

         [Authorize]
        public ActionResult Index()
        {
            return View();
        }


         [Authorize]
        public ActionResult ApproverList()
        {
            try
            {
                StaffADProfile staffADProfile = new StaffADProfile();
               
                staffADProfile.user_logon_name = User.Identity.Name;

                ActiveDirectoryQuery activeDirectoryQuery = new ActiveDirectoryQuery(staffADProfile);

                staffADProfile = activeDirectoryQuery.GetStaffProfile();
             
                List<ApproverInfo> approverList = new List<ApproverInfo>();
                // bool checkApprover = new AppClass().ValidateCurrentUser(currentuser);

                //bool checkApproverUser = new IC_A_Users().ValidateCheckApproverUser(staffADProfile.employee_number);
                //ViewData["checkApproverUser"] = checkApproverUser;

                bool checkICA = new IC_A_Users().ValidateCheckApproverUser(staffADProfile.employee_number);
                ViewData["ICA"] = checkICA;
                bool checkAdmin = new IC_A_Users().ValidateAdminUser(staffADProfile.employee_number);
                ViewData["Admin"] = checkAdmin;

                if (staffADProfile.jobtitle == "HEAD OF OPERATIONS" || staffADProfile.jobtitle == "ACTING HEAD OF OPERATIONS")
                {
                    ViewData["HopUser"] = true;
                }
                else
                {
                    ViewData["HopUser"] = false;
                }

                if (checkAdmin != false)
                {
                    approverList = new IC_A_Users().GetApproverList();
                    ViewBag.coInit = (String.IsNullOrEmpty(TempData["ErrorMessage"] as string)) ?
               "" : "<script type='text/javascript'>alert('" + TempData["ErrorMessage"] + "');</script>";
                    return View(approverList);
                }
                else
                {
                    ViewBag.coInit = (String.IsNullOrEmpty(TempData["ErrorMessage"] as string)) ?
               "" : "<script type='text/javascript'>alert('" + TempData["ErrorMessage"] + "');</script>";
                    return View(approverList);
                }
            }
            catch (Exception ex)
            {
                ViewBag.coInit = (String.IsNullOrEmpty(TempData["ErrorMessage"] as string)) ?
               "" : "<script type='text/javascript'>alert('" + TempData["ErrorMessage"] + "');</script>";
                return View(ex.Message);
            }


            return View();
        }
        [Authorize]
        public ActionResult Manage_Approval_List()
        {

            StaffADProfile staffADProfile = new StaffADProfile();
            //CurrentUser currentuser = new CurrentUser();
            staffADProfile.user_logon_name = User.Identity.Name;

            ActiveDirectoryQuery activeDirectoryQuery = new ActiveDirectoryQuery(staffADProfile);

            staffADProfile = activeDirectoryQuery.GetStaffProfile();
           

            bool checkICA = new IC_A_Users().ValidateCheckApproverUser(staffADProfile.employee_number);
            ViewData["ICA"] = checkICA;
            bool checkAdmin = new IC_A_Users().ValidateAdminUser(staffADProfile.employee_number);
            ViewData["Admin"] = checkAdmin;
            Profile profile = new Profile();
            profile = new LinqCalls().getProfile(staffADProfile.employee_number);
            if (profile.JobTitle == "HEAD OF OPERATIONS" || profile.JobTitle == "ACTING HEAD OF OPERATIONS")
            {
                ViewData["HopUser"] = true;
            }
            else
            {
                ViewData["HopUser"] = false;
            }


            if (!checkAdmin)
            {
                TempData["ErrorMessage"] = "";
                return RedirectToAction("ErrorPage");
            }
            else
            {
                ApproverInfo approvers = new ApproverInfo();
                //approvers = new AdminClass().GetApproverList();
                ViewBag.ErrorMessage = TempData["ErrorMessage"] as string;
                return View(approvers);
            }
            //List<ApproverInfo> approvers = new List<ApproverInfo>();

        }

        [Authorize]
        public ActionResult getProfileDetails(string StaffNumber)
        {
            string errorResult = "{{\"employee_number\":\"{0}\",\"name\":\"{1}\"}}";
            ApproverInfo approver = new ApproverInfo();
            approver.StaffNumber = StaffNumber;
            approver = new IC_A_Users().getApproverProfile(StaffNumber);

            if (approver.name == null)
            {
                errorResult = string.Format(errorResult, "Error", "No records found for the staff number");
                return Content(errorResult, "application/json");
            }
            else
            {
                return Json(approver, JsonRequestBehavior.AllowGet);
            }
        }


        
        [Authorize]
        public ActionResult InsertApprover(ApproverInfo approver)
        {
            try
            {
                StaffADProfile staffADProfile = new StaffADProfile();
                //CurrentUser currentuser = new CurrentUser();
                staffADProfile.user_logon_name = User.Identity.Name;

                ActiveDirectoryQuery activeDirectoryQuery = new ActiveDirectoryQuery(staffADProfile);

                staffADProfile = activeDirectoryQuery.GetStaffProfile();
              
                bool checkICA = new IC_A_Users().ValidateCheckApproverUser(staffADProfile.employee_number);
                ViewData["ICA"] = checkICA;
                bool checkAdmin = new IC_A_Users().ValidateAdminUser(staffADProfile.employee_number);
                ViewData["Admin"] = checkAdmin;

                Profile profile = new Profile();
                profile = new LinqCalls().getProfile(staffADProfile.employee_number);
                if (profile.JobTitle == "HEAD OF OPERATIONS" || profile.JobTitle == "ACTING HEAD OF OPERATIONS")
                {
                    ViewData["HopUser"] = true;
                }
                else
                {
                    ViewData["HopUser"] = false;
                }


                if (!checkAdmin)
                {
                    TempData["ErrorMessage"] = "You are not authorized to Perform these operation";
                    TempData["TravelRequest"] = approver;
                    return RedirectToAction("Manage_Approval_List");
                }
                else
                {

                    var insert = approver.name = new IC_A_Users().AddApprover(approver);
                    string[] result = insert.ToString().Split('|');

                    if (result[0] != "0")
                    {
                        if (result[0] == "2627")
                        {
                            TempData["ErrorMessage"] = "User Already Existed on Approver list";
                            // TempData["TravelRequest"] = approver;
                            return RedirectToAction("Manage_Approval_List");
                        }
                        else
                        {
                            TempData["ErrorMessage"] = result[1];
                            TempData["TravelRequest"] = approver;
                            return RedirectToAction("Manage_Approval_List");
                        }

                    }
                    else
                    {
                        TempData["ErrorMessage"] = "You have successfully added a new Approver";
                        //  TempData["Approvernames"] = string.Join("\\n", approverNames);             
                        return RedirectToAction("ApproverList");
                    }

                }

            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }


        [Authorize]
        public ActionResult Edit_Approver(string StaffNumber)
        {
            try
            {
                StaffADProfile staffADProfile = new StaffADProfile();
             //   CurrentUser currentuser = new CurrentUser();
                staffADProfile.user_logon_name = User.Identity.Name;

                ActiveDirectoryQuery activeDirectoryQuery = new ActiveDirectoryQuery(staffADProfile);

                staffADProfile = activeDirectoryQuery.GetStaffProfile();
                //currentuser.UserNo = staffADProfile.employee_number;

                //bool checkApproverUser = new IC_A_Users().ValidateCheckApproverUser(staffADProfile.employee_number);
                //ViewData["checkApproverUser"] = checkApproverUser;


                bool checkICA = new IC_A_Users().ValidateCheckApproverUser(staffADProfile.employee_number);
                ViewData["ICA"] = checkICA;
                bool checkAdmin = new IC_A_Users().ValidateAdminUser(staffADProfile.employee_number);
                ViewData["Admin"] = checkAdmin;

                Profile profile = new Profile();
                profile = new LinqCalls().getProfile(staffADProfile.employee_number);
                if (profile.JobTitle == "HEAD OF OPERATIONS" || profile.JobTitle == "ACTING HEAD OF OPERATIONS")
                {
                    ViewData["HopUser"] = true;
                }
                else
                {
                    ViewData["HopUser"] = false;
                }

                if (!checkAdmin)
                {
                    TempData["ErrorMessage"] = "You are not authorized to Perform these operation";
                    //TempData["TravelRequest"] = approver;
                    return RedirectToAction("Manage_Approval_List");
                }
                else
                {
                    ApproverInfo approvers = new ApproverInfo();
                    approvers = new IC_A_Users().GetApproverDetails(StaffNumber).First();
                    ViewBag.ErrorMessage = TempData["ErrorMessage"] as string;
                    return View(approvers);
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Edit_Approver");
            }

        }

        [Authorize]
        public ActionResult UpdateApprover(ApproverInfo approver)
        {
            try
            {
                StaffADProfile staffADProfile = new StaffADProfile();
              //  CurrentUser currentuser = new CurrentUser();
                staffADProfile.user_logon_name = User.Identity.Name;

                ActiveDirectoryQuery activeDirectoryQuery = new ActiveDirectoryQuery(staffADProfile);

                staffADProfile = activeDirectoryQuery.GetStaffProfile();
               // currentuser.UserNo = staffADProfile.employee_number;

                //bool checkApproverUser = new IC_A_Users().ValidateCheckApproverUser(staffADProfile.employee_number);
                //ViewData["checkApproverUser"] = checkApproverUser;

                //bool checkAdmin = new IC_A_Users().ValidateAdminUser(staffADProfile.employee_number);
                //ViewData["checkAdmin"] = checkAdmin;

                bool checkICA = new IC_A_Users().ValidateCheckApproverUser(staffADProfile.employee_number);
                ViewData["ICA"] = checkICA;
                bool checkAdmin = new IC_A_Users().ValidateAdminUser(staffADProfile.employee_number);
                ViewData["Admin"] = checkAdmin;

                Profile profile = new Profile();
                profile = new LinqCalls().getProfile(staffADProfile.employee_number);
                if (profile.JobTitle == "HEAD OF OPERATIONS" || profile.JobTitle == "ACTING HEAD OF OPERATIONS")
                {
                    ViewData["HopUser"] = true;
                }
                else
                {
                    ViewData["HopUser"] = false;
                }

                if (!checkAdmin)
                {
                    TempData["ErrorMessage"] = "You are not authorized to Perform these operation";
                    TempData["TravelRequest"] = approver;
                    return RedirectToAction("Manage_Approval_List");
                }
                else
                {
                    var Update = new IC_A_Users().UpdateApprover(approver);
                    string[] result = Update.ToString().Split('|');

                    if (result[0] != "0")
                    {
                        if (result[0] == "2627")
                        {
                            TempData["ErrorMessage"] = "User Already Existed on Approver list";
                            // TempData["TravelRequest"] = approver;
                            return RedirectToAction("EditApprover");
                        }
                        else
                        {
                            TempData["ErrorMessage"] = result[1];
                            //TempData["TravelRequest"] = approver;
                            return RedirectToAction("EditApprover");
                        }
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "You have successfully Updated ApproverName";
                        //  TempData["Approvernames"] = string.Join("\\n", approverNames);             
                        return RedirectToAction("ApproverList");
                    }
                }
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        [Authorize]
        public ActionResult DeleteApprover(string Approver_ID)
        {
            try
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
                if (profile.JobTitle == "HEAD OF OPERATIONS" || profile.JobTitle == "ACTING HEAD OF OPERATIONS")
                {
                    ViewData["HopUser"] = true;
                }
                else
                {
                    ViewData["HopUser"] = false;
                }

                if (!checkAdmin)
                {
                    TempData["ErrorMessage"] = "You are not authorized to Perform these operation";
                    //TempData["TravelRequest"] = approver;
                    return RedirectToAction("Manage_Approval_List");
                }
                else
                {

                    var delete = new IC_A_Users().DeleteApprover(Approver_ID);
                    string[] result = delete.ToString().Split('|');

                    if (result[0] != "0")
                    {
                        if (result[0] == "2627")
                        {
                            TempData["ErrorMessage"] = result[1];
                            // TempData["TravelRequest"] = approver;
                            return RedirectToAction("ApproverList");
                        }
                        else
                        {
                            TempData["ErrorMessage"] = result[1];
                            // TempData["TravelRequest"] = approver;
                            return RedirectToAction("ApproverList");
                        }

                    }
                    else
                    {
                        TempData["ErrorMessage"] = "You have successfully Updated ApproverName";
                        //  TempData["Approvernames"] = string.Join("\\n", approverNames);             
                        return RedirectToAction("ApproverList");
                    }
                }
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
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
            if (profile.JobTitle == "HEAD OF OPERATIONS" || profile.JobTitle == "ACTING HEAD OF OPERATIONS")
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