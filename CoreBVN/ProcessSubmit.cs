using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBVN
{
    public class ProcessSubmit
    {
        public string getConnectionString(string serverName)
        {
            string connectionString = "";
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[serverName];
            if (settings != null)
            {
                connectionString = settings.ConnectionString;
            }
            return connectionString;
        }




        public string initiateIncident(InputClass newRequest, string ConnString)
        {

            string retVal = "";
            string connString = getConnectionString(ConnString);

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmnd = new SqlCommand();

            string AccountNameArr = (String.Join(";", new PheonixQuery().getAccounts(newRequest.AccountDetials.BVN).Select(z => staticClass.ConCatAccountName(z))));
            string AccountNumberArr = (String.Join(";", new PheonixQuery().getAccounts(newRequest.AccountDetials.BVN).Select(z => staticClass.ConCatAccountNumber(z))));
            string AccountStatusArr = (String.Join(";", new PheonixQuery().getAccounts(newRequest.AccountDetials.BVN).Select(z => staticClass.ConCatAccountStatus(z))));

           
            newRequest.AccountDetials.AccountNameArray = AccountNameArr;
            newRequest.AccountDetials.AccountNumberArray = AccountNumberArr;
            newRequest.AccountDetials.AccountStatusArray = AccountStatusArr;
         
            try
            {
                cmnd.Connection = conn;
                cmnd.CommandType = CommandType.StoredProcedure;
                cmnd.CommandText = "zb_BVN_PROC";


                cmnd.Parameters.Add("@appid", SqlDbType.VarChar).Value = "BVN_IN_WKF";
                cmnd.Parameters.Add("@DocumentID", SqlDbType.VarChar).Value = newRequest.DocumentID.Trim();
                cmnd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "Submitted";
                cmnd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "Submitted";
                cmnd.Parameters.Add("@StaffName", SqlDbType.VarChar).Value = newRequest.RequesterDetails.StaffName;
                cmnd.Parameters.Add("@StaffNumber", SqlDbType.VarChar).Value = newRequest.RequesterDetails.StaffNo;
                cmnd.Parameters.Add("@StaffBranch", SqlDbType.VarChar).Value = newRequest.RequesterDetails.Branch;
                cmnd.Parameters.Add("@StaffBranchCode", SqlDbType.Int).Value = newRequest.RequesterDetails.BranchCode;
                cmnd.Parameters.Add("@StaffDept", SqlDbType.VarChar).Value = newRequest.RequesterDetails.Dept;
                cmnd.Parameters.Add("@StaffDeptCode", SqlDbType.VarChar).Value = newRequest.RequesterDetails.DeptID;
                cmnd.Parameters.Add("@StaffUnit", SqlDbType.VarChar).Value = newRequest.RequesterDetails.unitname;
                cmnd.Parameters.Add("@StaffUnitcode", SqlDbType.VarChar).Value = newRequest.RequesterDetails.unitcode;
                cmnd.Parameters.Add("@StaffGrade", SqlDbType.VarChar).Value = newRequest.RequesterDetails.level;
                cmnd.Parameters.Add("@StaffTitle", SqlDbType.VarChar).Value = newRequest.RequesterDetails.JobTitle;
                cmnd.Parameters.Add("@Email", SqlDbType.VarChar).Value = newRequest.RequesterDetails.Email;
                cmnd.Parameters.Add("@StaffCategory", SqlDbType.VarChar).Value = newRequest.RequesterDetails.Job_Category;
                cmnd.Parameters.Add("@BVN", SqlDbType.VarChar).Value = newRequest.AccountDetials.BVN;
                cmnd.Parameters.Add("@AccountName", SqlDbType.VarChar).Value = newRequest.AccountDetials.AccountName;
                cmnd.Parameters.Add("@AccountNumber", SqlDbType.VarChar).Value = newRequest.AccountDetials.AccountNumber;
                cmnd.Parameters.Add("@CustomerNames", SqlDbType.VarChar).Value = newRequest.AccountDetials.customerNames;

                cmnd.Parameters.Add("@dateOfBirth", SqlDbType.VarChar).Value = newRequest.AccountDetials.dateOfBirth;
                cmnd.Parameters.Add("@AccountNameArray", SqlDbType.VarChar).Value = newRequest.AccountDetials.AccountNameArray;
                cmnd.Parameters.Add("@AccountNumberArray", SqlDbType.VarChar).Value = newRequest.AccountDetials.AccountNumberArray;
                cmnd.Parameters.Add("@AccountStatusArray", SqlDbType.VarChar).Value = newRequest.AccountDetials.AccountStatusArray;

                cmnd.Parameters.Add("@Firstname", SqlDbType.VarChar).Value = newRequest.AccountDetials.Firstname;
                cmnd.Parameters.Add("@MiddleName", SqlDbType.VarChar).Value = newRequest.AccountDetials.MiddleName;
                cmnd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = newRequest.AccountDetials.LastName;


                cmnd.Parameters.Add("@InputStage", SqlDbType.VarChar).Value = "Initiate";

                cmnd.Parameters.Add("@InputStageId", SqlDbType.Int).Value = 0;
                cmnd.Parameters.Add("@Irregularity", SqlDbType.VarChar).Value = newRequest.Irregularity;
                cmnd.Parameters.Add("@Nature_Of_The_Irregular", SqlDbType.VarChar).Value = newRequest.IrregularityDetails.ToString().Trim();
                cmnd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = newRequest.Comment;
                cmnd.Parameters.Add("@DomicileBranch", SqlDbType.VarChar).Value = "";
                cmnd.Parameters.Add("@DomicileBranchCode", SqlDbType.VarChar).Value = "";
                //cmnd.Parameters.Add("@IsAccountClose", SqlDbType.Int).Value = (newRequest.AccountDetials.IsAccountClosed==true)?1:0;
                cmnd.Parameters.Add("@IsAccountClose", SqlDbType.Int).Value = newRequest.AccountDetials.IsAccountClosed;
                cmnd.Parameters.Add("@DateSubmitted", SqlDbType.DateTime).Value = DateTime.Now;       
               

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

    }
}
