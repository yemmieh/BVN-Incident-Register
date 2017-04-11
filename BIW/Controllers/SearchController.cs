using CoreBVN;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BIW.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        [Authorize]
        public ActionResult SearchPage()
        {
            StaffADProfile staffADProfile = new StaffADProfile();
            //CurrentUser currentuser = new CurrentUser();
            staffADProfile.user_logon_name = User.Identity.Name;

            ActiveDirectoryQuery activeDirectoryQuery = new ActiveDirectoryQuery(staffADProfile);
            staffADProfile = activeDirectoryQuery.GetStaffProfile();         
            Profile profile = new Profile();
            profile = new LinqCalls().getProfile(staffADProfile.employee_number);
            bool checkICA = new IC_A_Users().ValidateCheckApproverUser(staffADProfile.employee_number);
            ViewData["ICA"] = checkICA;
            bool checkAdmin = new IC_A_Users().ValidateAdminUser(staffADProfile.employee_number);
            ViewData["Admin"] = checkAdmin;
            if (checkICA || checkAdmin)
            {
                ViewData["HopUser"] = false;
                //ViewData["ICA"] = true;
              
                return View();
            }
            else
            {
                ViewData["HopUser"] = false;
                //ViewData["ICA"] = false;
                TempData["ErrorMessage"] = "You are not Authorized to view this page";
                //TempData["Approvernames"] = string.Join("\\n", approverNames);               
                return RedirectToAction("ErrorPage");
            }    
        }

          [Authorize]
        public ActionResult SearchResult(SearchViewModel Search)
        {

            if (Search.IsAccountClosed == 9)
            {
                Search.IsAccountClosed = null;
            }
            StaffADProfile staffADProfile = new StaffADProfile();
            //CurrentUser currentuser = new CurrentUser();
            staffADProfile.user_logon_name = User.Identity.Name;

            ActiveDirectoryQuery activeDirectoryQuery = new ActiveDirectoryQuery(staffADProfile);

            staffADProfile = activeDirectoryQuery.GetStaffProfile();
            //currentuser.UserNo = staffADProfile.employee_number;
            //bool checkApproverUser = new AppClass().ValidateCheckApproverUser(currentuser.UserNo);
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

            if (checkICA || checkAdmin)
            {
                if (Search.Branch != null)
                {
                    string[] BranchArray = Search.Branch.Split(':');
                    Search.Branch = BranchArray[0];
                    Search.BranchCode = int.Parse(BranchArray[1]);
                }



                if (Search.Irregularity != null)
                {
                    string[] Irregularity = Search.Irregularity.Split(':');
                    Search.Irregularity = Irregularity[0];
                    // Search.DomicileBranchCode = Irregularity[1];
                }

                if (Search.ExportToExport != true)
                {
                    Search.inputlist = new SearchAppClass().SearchTravelRequest(Search);
                }
                else
                {
                    List<ExcelView> excelresult = new List<ExcelView>();
                    excelresult = new SearchAppClass().SearchTravelRequestExcel(Search);

                    GridView gv = new GridView();
                    gv.DataSource = excelresult;
                    gv.DataBind();
                    Response.ClearContent();
                    Response.Buffer = true;
                    Response.AddHeader("content-disposition", "attachment; filename=BVN_Incident_Report_Excel_'" + DateTime.Now + "'.xls ");
                    Response.AddHeader("Pragma", "public");
                    Response.AddHeader("Cache-Control", "max-age=0");
                    Response.ContentType = "text/html";
                    Response.ContentEncoding = System.Text.Encoding.UTF8;
                    Response.ContentEncoding = System.Text.Encoding.Default;  
                    Response.Charset = "";
                    StringWriter sw = new StringWriter();
                    HtmlTextWriter hw = new HtmlTextWriter(sw);

                    hw.AddAttribute("xmlns:x", "urn:schemas-microsoft-com:office:excel");
                    hw.RenderBeginTag(HtmlTextWriterTag.Html);
                    hw.RenderBeginTag(HtmlTextWriterTag.Head);
                    hw.RenderBeginTag(HtmlTextWriterTag.Style);
                    //hw.Write("br {mso-data-placement:same-cell;}");
                    //hw.RenderEndTag() ;
                    //hw.RenderEndTag();
                    hw.RenderBeginTag(HtmlTextWriterTag.Body);
                    gv.RenderControl(hw);
                    //hw.RenderEndTag();
                    //hw.RenderEndTag();
                    Response.Write(HttpUtility.HtmlDecode(sw.ToString()));
                    Response.Flush();
                    Response.End();
                    return RedirectToAction("SearchPage");
                }
            }
            else
            {

            }
            //Search.Requests = new SearchAppClass().SearchTravelRequest(Search);
            return View("SearchPage", Search);
        }
        [Authorize]
          public ActionResult ErrorPage()
          {
               StaffADProfile staffADProfile = new StaffADProfile();
               // CurrentUser currentuser = new CurrentUser();
                staffADProfile.user_logon_name = User.Identity.Name;

                ActiveDirectoryQuery activeDirectoryQuery = new ActiveDirectoryQuery(staffADProfile);

                staffADProfile = activeDirectoryQuery.GetStaffProfile();
              

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