using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CoreBVN
{
    public class ProcessEntry
    {
        public List<InputClass> GetMyIncidentEntry(StaffADProfile staffADProfile)
        {
            List<InputClass> RequestList = new List<InputClass>();
            try
            {
                BVNDataContext projectconn = new BVNDataContext();
                var Projectinfo = (from distinct in projectconn.Tb_BvnIncidents
                                   where (distinct.StaffNumber == staffADProfile.employee_number)
                                   select
                                   new
                                   {
                                       RequestID = distinct.DocumentID,
                                       InitiatorName = distinct.StaffName,
                                       AccountName = distinct.AccountName,
                                       AccountNumber = distinct.AccountNumber,
                                       InitiatorBranch = distinct.StaffBranch,
                                       RequestStage = distinct.InputStage,
                                       date_Submitted = distinct.DateSubmitted  ,
                                       accountNameArray = distinct.AccountNameArray,
                                       accountNumberArray = distinct.AccountNumberArray,
                                       accountStatusArrary = distinct.AccountStatusArray,
                                       BVN   = distinct.BVN
   
                                   });
                foreach (var requestList in Projectinfo)
                {
                    InputClass Myrequest = new InputClass();
                    Profile profile = new Profile();
                    Account account = new Account();


                    profile.StaffName = requestList.InitiatorName;
                    profile.Branch = requestList.InitiatorBranch;  
                 
                    account.AccountName = requestList.AccountName;
                    account.AccountNumber = requestList.AccountNumber;
                    account.AccountName = (requestList.accountNameArray == null) ? "" : requestList.accountNameArray.Replace(";", "<BR><hr><BR>");

                    account.AccountNumber = (requestList.accountNumberArray == null) ? "" : requestList.accountNumberArray.Replace(";", "<BR><hr><BR>");
                    account.AccountStatus = (requestList.accountStatusArrary == null) ? "" : requestList.accountStatusArrary.Replace(";", "<BR><hr><BR>");

                    account.BVN = requestList.BVN;
             

                    Myrequest.RequesterDetails = profile;
                    Myrequest.AccountDetials= account;


                    Myrequest.InputStage = "IC & A Review";
                    Myrequest.DateSubmitted = requestList.date_Submitted;

                    Myrequest.DocumentID = requestList.RequestID;
                    RequestList.Add(Myrequest);
                }
            }
            catch (Exception ex)
            {
                // return ex.Message;
            }
            return RequestList;
        }



        public List<InputClass> SearchBranchRequest(string BranchCode)
        {
            List<InputClass> RequestList = new List<InputClass>();
            try
            {
                BVNDataContext projectconn = new BVNDataContext();
                var Projectinfo = (from distinct in projectconn.Tb_BvnIncidents
                                   where (distinct.StaffBranchCode == int.Parse(BranchCode.ToString()))
                                   select
                                   new
                                   {
                                       RequestID = distinct.DocumentID,
                                       InitiatorName = distinct.StaffName,
                                       AccountName = distinct.AccountName,
                                       AccountNumber = distinct.AccountNumber,
                                       InitiatorBranch = distinct.StaffBranch,
                                       RequestStage = distinct.InputStage,
                                       date_Submitted = distinct.DateSubmitted,
                                       accountNameArray = distinct.AccountNameArray,
                                       accountNumberArray = distinct.AccountNumberArray,
                                       accountStatusArrary = distinct.AccountStatusArray,
                                       BVN = distinct.BVN     
                                   });
                foreach (var requestList in Projectinfo)
                {
                    InputClass Myrequest = new InputClass();
                    Profile profile = new Profile();
                    Account account = new Account();


                    profile.StaffName = requestList.InitiatorName;
                    profile.Branch = requestList.InitiatorBranch;  
                 
                    account.AccountName = requestList.AccountName;
                    account.AccountNumber = requestList.AccountNumber;
                    account.AccountName = (requestList.accountNameArray == null) ? "" : requestList.accountNameArray.Replace(";", "<BR><hr><BR>");

                    account.AccountNumber = (requestList.accountNumberArray == null) ? "" : requestList.accountNumberArray.Replace(";", "<BR><hr><BR>");
                    account.AccountStatus = (requestList.accountStatusArrary == null) ? "" : requestList.accountStatusArrary.Replace(";", "<BR><hr><BR>");

                    account.BVN = requestList.BVN;
             

                    Myrequest.RequesterDetails = profile;
                    Myrequest.AccountDetials= account;


                    Myrequest.InputStage = "IC & A Review";
                    Myrequest.DateSubmitted = requestList.date_Submitted;

                    Myrequest.DocumentID = requestList.RequestID;

                    RequestList.Add(Myrequest);

                }
            }
            catch (Exception ex)
            {
                // return ex.Message;
            }
            return RequestList;
        }

        

        public List<InputClass> GetEntry(string DocumentID)
        {
            List<InputClass> RequestList = new List<InputClass>();
            try
            {
                BVNDataContext projectconn = new BVNDataContext();
                var Projectinfo = (from distinct in projectconn.Tb_BvnIncidents
                                   where (distinct.DocumentID == DocumentID)
                                   select
                                   new
                                   {

                                       RequestID = distinct.DocumentID,
                                       Irregularity = distinct.Irregularity,
                                       IrregularityDetails = distinct.Nature_Of_The_Irregular,
                                       DateSubmitted = distinct.DateSubmitted,


                                       Staffname = distinct.StaffName,
                                       StaffNo = distinct.StaffNumber,
                                       InitiatorBranchName = distinct.StaffBranch,
                                       JobTitle = distinct.StaffTitle,
                                       Email = distinct.Email,


                                       AccountNo = distinct.AccountNumber,
                                       AccountName = distinct.AccountName,
                                       CustomerName = distinct.CustomerNames,

                                       Firstname = distinct.Firstname,
                                       LastName = distinct.LastName,
                                       MiddleName = distinct.MiddleName,

                                       DOB = distinct.dateOfBirth,
                                       AccountnameArray = distinct.AccountNameArray,
                                       AccountNumberArray = distinct.AccountNumberArray,
                                       AccountStatusArray = distinct.AccountStatusArray,

                                       Comment = distinct.Comment,


                                       DomicileBranch = distinct.DomicileBranch,
                                       IsAccountClosed = distinct.IsAccountClose,
                                       BVN = distinct.BVN
                                   });
                foreach (var requestList in Projectinfo)
                {
                    InputClass Myrequest    = new InputClass();
                    Profile profile         = new Profile();
                    Account account         = new Account();


                    profile.StaffName       = requestList.Staffname;
                    profile.Branch          = requestList.InitiatorBranchName;
                    profile.JobTitle        = requestList.JobTitle;
                    profile.Email           = requestList.Email;
                    profile.StaffNo         = requestList.StaffNo;

                    account.AccountName     = requestList.AccountName;
                    account.AccountNumber   = requestList.AccountNo;
                    account.customerNames   = requestList.CustomerName;
                    account.BVN             = requestList.BVN;
                    account.DomicileBranch  = requestList.DomicileBranch;
                    account.Firstname       = requestList.Firstname;
                    account.MiddleName      = requestList.MiddleName;
                    account.LastName        = requestList.LastName;
                    account.dateOfBirth     = requestList.DOB;
                    //account.IsAccountClosed = (requestList.IsAccountClosed == 1) ? true : false;
                    account.IsAccountClosed = requestList.IsAccountClosed;


                    Myrequest.RequesterDetails = profile;
                    Myrequest.AccountDetials = account;

                   
                    Myrequest.DateSubmitted = requestList.DateSubmitted;
                    Myrequest.Irregularity  = requestList.Irregularity;
                    Myrequest.IrregularityDetails = requestList.IrregularityDetails;

                    Myrequest.DocumentID    = requestList.RequestID;
                     Myrequest.Comment    = requestList.Comment;
                    

                     if (requestList.AccountnameArray != null)
                     {
                         List<Account> AccountNamelist = new List<Account>();
                         string[] availabledcard = requestList.AccountnameArray.Split(';');
                         string[] availabledAccNumber = requestList.AccountNumberArray.Split(';');
                         string[] availabledStatusNumber = requestList.AccountStatusArray.Split(';');
                         for (int i = 0; i < availabledcard.Count(); i++)
                         {
                             Account card = new Account();
                             card.AccountName = availabledcard[i];
                             card.AccountNumber = availabledAccNumber[i];
                             card.AccountStatus = availabledStatusNumber[i];
                             AccountNamelist.Add(card);
                         }
                         Myrequest.accountNamelist = AccountNamelist;
                     }                   

                    RequestList.Add(Myrequest);



                }
            }
            catch (Exception ex)
            {
                // return ex.Message;
            }
            return RequestList;
        }

        public XElement getApprovalHistory(string workflowid)
        {
            AppraisalConnectionStringDataContext workflowcnxn = new AppraisalConnectionStringDataContext();
            var entries = (from w in workflowcnxn.zib_workflow_masters
                           where w.workflowid.Equals(workflowid)
                           select w.approvalhistory).First();
            return entries;
        }


    }
}
