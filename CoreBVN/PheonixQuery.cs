using Sybase.Data.AseClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CoreBVN
{
    public class PheonixQuery
    {
        [Authorize]
        public List<Account> getAccounts(string BVN)
        {
           // BVN = "2014225";
            LogWriter logWriter = new LogWriter();
           
            AseCommand cmd = null;
            AseConnection conn = null;          
            string sqlquery = null;
        
            string cnstring = ConfigurationManager.ConnectionStrings["phoenixConnectionString"].ConnectionString;
            List<Account> accountDetailList = new List<Account>();           
            try
            {
                
                conn = new AseConnection(cnstring);

              //  sqlquery = "select acct_no as AcctNo, Acct_name as AcctName from zenbase..zib_kyc_cust_information where bvn = '" + BVN + "' union select acct_no as AcctNo , Acct_name as AcctName from zenbase..zib_kyc_cust_information_wk where bvn = '" + BVN + "'";
                sqlquery = "select acct_no as AcctNo, Acct_name as AcctName from zenbase..zib_kyc_cust_information where bvn = '" + BVN + "'" ;

                    cmd = new AseCommand(sqlquery, conn);
                    cmd.CommandTimeout = 0;
                    logWriter.WriteErrorLog(string.Format("Exception Message! / {0}", "before conn open"));
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        logWriter.WriteErrorLog(string.Format("Conection section / {0}", "connection open"));
                    }else{
                        logWriter.WriteErrorLog(string.Format("Conection section / {0}", "connection closed"));
                    }
                    logWriter.WriteErrorLog(string.Format("execute Section  / {0}", "Before execute"));
                    AseDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    logWriter.WriteErrorLog(string.Format("execute Section  / {0}", "after execute"));
                    if (reader == null)
                    {
                        logWriter.WriteErrorLog(string.Format("reader section / {0}", "Reader is null"));
                    }
                    else
                    {
                        logWriter.WriteErrorLog(string.Format("reader section / {0}", "Reader is not null"));
                    }
                    while (reader.Read())
                    {
                        Account account = new Account();
                       // account.AccountNo = AcctNo;
                        account.AccountNumber = reader["AcctNo"].ToString();
                        account.AccountName = reader["AcctName"].ToString();
                        if (account.AccountNumber != "" || account.AccountNumber != null)
                        {
                            account.AccountStatus = getAccountStatus(account.AccountNumber).AccountStatus;
                        }
                        else
                        {
                            account.AccountStatus = "";
                        }
                       
                        
                        accountDetailList.Add(account);
                    }
            }

            catch (Exception ex)
            {
                logWriter.WriteErrorLog(string.Format("Exception Message! / {0}", ex.Message));
            }
            finally
            {
                //cmd.Dispose();

                if (conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }


            return accountDetailList;
        }


        public Account getAccountStatus(string AcctNo)
        {
            // BVN = "2014225";
            Account account = new Account();
            //string result = "";
            LogWriter logWriter = new LogWriter();

            AseCommand cmd = null;
            AseConnection conn = null;
            string sqlquery = null;

            string cnstring = ConfigurationManager.ConnectionStrings["phoenixConnectionString"].ConnectionString;
            List<Account> accountDetailList = new List<Account>();
            try
            {

                conn = new AseConnection(cnstring);

                sqlquery = " SELECT  status as status from phoenix..dp_acct WHERE acct_no  = '" + AcctNo + "'";
                               
                               
                cmd = new AseCommand(sqlquery, conn);
                cmd.CommandTimeout = 0;
                conn.Open();
                AseDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader == null)
                {
                    logWriter.WriteErrorLog(string.Format("Reader empty !", "reader is empty"));
                    account.AccountStatus = "";
                }

                    while (reader.Read())
                    {
                       account.AccountStatus = reader["status"].ToString();
                    }              
               
            }

            catch (Exception ex)
            {
                logWriter.WriteErrorLog(string.Format("Exception Message! / {0}", ex.Message));
            }
            finally
            {
                //cmd.Dispose();

                if (conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }


            return account;
        }
    }
}
