using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBVN
{
   public class IC_A_Users
    {

        public List<ApproverInfo> GetApproverList()
        {
            List<ApproverInfo> ApproverList = new List<ApproverInfo>();
            try
            {
                ApprovalListConnectionDataContext projectconn = new ApprovalListConnectionDataContext();
                var Projectinfo = (from distinct in projectconn.IC_A_Users
                                   select
                                   new
                                   {
                                       StaffNo = distinct.StaffNumber,
                                       Staffname = distinct.StaffName,
                                       Email = distinct.Emails,
                                       Branch = distinct.Branch,
                                       Grade = distinct.Grade,
                                       Jobtitle = distinct.Jobtitle,
                                       Dept = distinct.DeptTitle
                                   });
                foreach (var approverlist in Projectinfo)
                {
                    ApproverInfo approver = new ApproverInfo();
                    approver.StaffNumber = approverlist.StaffNo;
                    approver.name = approverlist.Staffname;
                    approver.Email = approverlist.Email;
                    approver.Branch = approverlist.Branch;
                    approver.Jobtitle = approverlist.Jobtitle;
                    approver.Grade = approverlist.Grade;
                    approver.DeptTitle = approverlist.Dept;
                    ApproverList.Add(approver);
                }
            }
            catch (Exception ex)
            {
                // return ex.Message;
            }
            return ApproverList;
        }



        public List<ApproverInfo> GetApproverDetails(string StaffNumber)
        {
            List<ApproverInfo> List_of_Approver = new List<ApproverInfo>();
            ApprovalListConnectionDataContext projectconn = new ApprovalListConnectionDataContext();
            var ApproverList = (from distinct in projectconn.IC_A_Users
                                where distinct.StaffNumber == StaffNumber
                                select
                                new ApproverInfo
                                {
                                    StaffNumber = distinct.StaffNumber,
                                    name = distinct.StaffName,
                                    Email = distinct.Emails,
                                    Grade = distinct.Grade,
                                    Branch = distinct.Branch,
                                    DeptTitle = distinct.DeptTitle,
                                    Jobtitle = distinct.Jobtitle,
                                    IsAdmin = (distinct.AdminRole == 1) ? true : false
                                });
            foreach (var approvelist in ApproverList)
            {
                ApproverInfo approve = new ApproverInfo();
                approve.StaffNumber = approvelist.StaffNumber;
                approve.name = approvelist.name;
                approve.Email = approvelist.Email;
                approve.Grade = approvelist.Grade;
                approve.Jobtitle = approvelist.Jobtitle;
                approve.DeptTitle = approvelist.DeptTitle;
                approve.Branch = approvelist.Branch;
                approve.IsAdmin = approvelist.IsAdmin;
                List_of_Approver.Add(approve);
            }
            return List_of_Approver;
        }
        public string AddApprover(ApproverInfo Approver)
        {
            string ConnString = "TravelConnection";
            string retVal = "";
            string connString = new ProcessSubmit().getConnectionString(ConnString);
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmnd = new SqlCommand();
            int IsAdmin = (Approver.IsAdmin != true) ? 0 : 1;
            try
            {
                cmnd.Connection = conn;
                cmnd.CommandType = CommandType.StoredProcedure;
                cmnd.CommandText = "zsp_Manage_IC_A_Users";
                cmnd.Parameters.Add("@StaffNumber", SqlDbType.VarChar).Value = Approver.StaffNumber;
                cmnd.Parameters.Add("@StaffName", SqlDbType.VarChar).Value = Approver.name;
                cmnd.Parameters.Add("@Email", SqlDbType.VarChar).Value = Approver.Email;
                cmnd.Parameters.Add("@Grade", SqlDbType.VarChar).Value = Approver.Grade;
                cmnd.Parameters.Add("@Branch", SqlDbType.VarChar).Value = Approver.Branch;
                cmnd.Parameters.Add("@Jobtitle", SqlDbType.VarChar).Value = Approver.Jobtitle;
                cmnd.Parameters.Add("@DeptTitle", SqlDbType.VarChar).Value = Approver.DeptTitle;
                cmnd.Parameters.Add("@AdminRole", SqlDbType.Int).Value = IsAdmin;
                cmnd.Parameters.Add("@Mode", SqlDbType.VarChar).Value = "ADD";
                cmnd.Parameters.Add("@ErrorCode", SqlDbType.Int, 6).Direction = ParameterDirection.Output;
                cmnd.Parameters.Add("@ErrorText", SqlDbType.VarChar, 250).Direction = ParameterDirection.Output;


                SqlDataReader dr;

                // Open the data connection
                cmnd.Connection = conn;
                conn.Open();

                // Execute the command
                dr = cmnd.ExecuteReader();

                string retCode = cmnd.Parameters["@ErrorCode"].Value.ToString();
                retVal = retCode + "|" + cmnd.Parameters["@ErrorText"].Value.ToString();
            }
            catch (SqlException ex)
            {

                if (ex.Number != 0)
                {
                    retVal = ex.Number + "|" + ex.Message;
                }

            }
            finally
            {
                if (conn != null)
                    ((IDisposable)conn).Dispose();
            }

            return retVal;
        }

        public string UpdateApprover(ApproverInfo Approver)
        {
            string ConnString = "TravelConnection";
            string retVal = "";
            string connString = new ProcessSubmit().getConnectionString(ConnString);
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmnd = new SqlCommand();
            int IsAdmin = (Approver.IsAdmin != true) ? 0 : 1;
            try
            {
                cmnd.Connection = conn;
                cmnd.CommandType = CommandType.StoredProcedure;
                cmnd.CommandText = "zsp_Manage_IC_A_Users";
                cmnd.Parameters.Add("@StaffNumber", SqlDbType.VarChar).Value = Approver.StaffNumber;
                cmnd.Parameters.Add("@StaffName", SqlDbType.VarChar).Value = Approver.name;
                cmnd.Parameters.Add("@Email", SqlDbType.VarChar).Value = Approver.Email;
                cmnd.Parameters.Add("@Grade", SqlDbType.VarChar).Value = Approver.Grade;
                cmnd.Parameters.Add("@Branch", SqlDbType.VarChar).Value = Approver.Branch;
                cmnd.Parameters.Add("@Jobtitle", SqlDbType.VarChar).Value = Approver.Jobtitle;
                cmnd.Parameters.Add("@DeptTitle", SqlDbType.VarChar).Value = Approver.DeptTitle;
                cmnd.Parameters.Add("@AdminRole", SqlDbType.Int).Value = IsAdmin;
                cmnd.Parameters.Add("@Mode", SqlDbType.VarChar).Value = "UPDATE";
                cmnd.Parameters.Add("@ErrorCode", SqlDbType.Int, 6).Direction = ParameterDirection.Output;
                cmnd.Parameters.Add("@ErrorText", SqlDbType.VarChar, 250).Direction = ParameterDirection.Output;


                SqlDataReader dr;

                // Open the data connection
                cmnd.Connection = conn;
                conn.Open();

                // Execute the command
                dr = cmnd.ExecuteReader();

                string retCode = cmnd.Parameters["@ErrorCode"].Value.ToString();
                retVal = retCode + "|" + cmnd.Parameters["@ErrorText"].Value.ToString();
            }
            catch (SqlException ex)
            {

                if (ex.Number != 0)
                {
                    retVal = ex.Number + "|" + ex.Message;
                }

            }
            finally
            {
                if (conn != null)
                    ((IDisposable)conn).Dispose();
            }

            return retVal;
        }

        public string DeleteApprover(string StaffNumber)
        {
            string ConnString = "TravelConnection";
            string retVal = "";
            string connString = new ProcessSubmit().getConnectionString(ConnString);
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmnd = new SqlCommand();
            try
            {
                cmnd.Connection = conn;
                cmnd.CommandType = CommandType.StoredProcedure;
                cmnd.CommandText = "zsp_Manage_IC_A_Users";
                cmnd.Parameters.Add("@StaffNumber", SqlDbType.VarChar).Value = StaffNumber;
                cmnd.Parameters.Add("@Mode", SqlDbType.VarChar).Value = "DELETE";
                cmnd.Parameters.Add("@ErrorCode", SqlDbType.Int, 6).Direction = ParameterDirection.Output;
                cmnd.Parameters.Add("@ErrorText", SqlDbType.VarChar, 250).Direction = ParameterDirection.Output;
                SqlDataReader dr;

                // Open the data connection
                cmnd.Connection = conn;
                conn.Open();
                // Execute the command
                dr = cmnd.ExecuteReader();
                string retCode = cmnd.Parameters["@ErrorCode"].Value.ToString();
                retVal = retCode + "|" + cmnd.Parameters["@ErrorText"].Value.ToString();
            }
            catch (SqlException ex)
            {
                if (ex.Number != 0)
                {
                    retVal = ex.Number + "|" + ex.Message;
                }
            }
            finally
            {
                if (conn != null)
                    ((IDisposable)conn).Dispose();
            }

            return retVal;
        }



        public bool ValidateCheckApproverUser(string UserNo)
        {
            ApprovalListConnectionDataContext approval = new ApprovalListConnectionDataContext();
            var approvalname = (from distinct in approval.IC_A_Users
                                where distinct.StaffNumber == UserNo && distinct.AdminRole == 0
                                select
                                new
                                {
                                    StaffName = distinct.StaffName
                                });
            if (approvalname.Count() < 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public List<ApproverInfo> getApproverInfo()
        {
            ApprovalListConnectionDataContext approval = new ApprovalListConnectionDataContext();
            var approvalinfo = (from distinct in approval.IC_A_Users where distinct.AdminRole==0
                                select
                                new
                                {
                                    StaffName = distinct.StaffName,
                                    StaffNo = distinct.StaffNumber,
                                    Email = distinct.Emails
                                });
            List<ApproverInfo> ApproverList = new List<ApproverInfo>();
            foreach (var info in approvalinfo)
            {
                ApproverInfo approver = new ApproverInfo();
                approver.name = info.StaffName;
                approver.StaffNumber = info.StaffNo;
                approver.Email = info.Email;
                ApproverList.Add(approver);

            }
            return ApproverList;
        }

        public List<string> getApprovernames()
        {
            ApprovalListConnectionDataContext approval = new ApprovalListConnectionDataContext();
            var approvalinfo = from distinct in approval.IC_A_Users
                               select distinct.StaffName;
            return approvalinfo.ToList();
        }

        public bool ValidateAdminUser(string UserNo)
        {
            ApprovalListConnectionDataContext approval = new ApprovalListConnectionDataContext();
            var approvalname = (from distinct in approval.IC_A_Users
                                where distinct.StaffNumber == UserNo && distinct.AdminRole == 1
                                select
                                new
                                {
                                    StaffName = distinct.StaffName
                                });
            if (approvalname.Count() < 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }




        public ApproverInfo getApproverProfile(string AcctNo)
        {
            ApproverInfo profile = new ApproverInfo();

            var a1 = new int[] { 1 };

            XceedDataContext xceed = new XceedDataContext();
            var Profileinfo = (from distinct in xceed.vw_employeeinfos
                               where (distinct.employee_number == AcctNo)
                               select
                               new
                               {
                                   BranchName = distinct.Branch,
                                   BranchCode = distinct.Branch_code,
                                   StaffNumber = distinct.employee_number,
                                   StaffName = distinct.name,
                                   Level = distinct.grade,
                                   Email = distinct.email,
                                   Dept = distinct.dept,
                                   Dept_id = distinct.department_id,
                                   jobtitle = distinct.jobtitle,
                                   confirm = distinct.emp_confirm
                               }).Distinct();

            foreach (var Profiles in Profileinfo)
            {
                profile.Branch = Profiles.BranchName;

                profile.StaffNumber = Profiles.StaffNumber;
                profile.name = Profiles.StaffName;
                profile.Grade = Profiles.Level;
                profile.Email = Profiles.Email;
                profile.DeptTitle = Profiles.Dept;

                profile.Jobtitle = Profiles.jobtitle;

            }


            return profile;

        }



    }
}
