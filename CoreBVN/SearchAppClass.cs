using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBVN
{
    public class SearchAppClass
    {

        public List<InputClass> SearchTravelRequest(SearchViewModel Search)
        {
            List<InputClass> ResultListLists = new List<InputClass>();
            try
            {
                BVNDataContext Travelconn = new BVNDataContext();
                var Projectinfo = (from distinct in Travelconn.Tb_BvnIncidents
                                   where ((Search.AccountName == null || distinct.AccountNameArray.Contains(Search.AccountName)) &&
                                           (Search.AccountNumber == null || distinct.AccountNumberArray.Contains(Search.AccountNumber)) &&
                                           (Search.StaffName == null || distinct.StaffName.Contains(Search.StaffName)) &&
                                           (Search.Firstname == null || distinct.Firstname.Contains(Search.Firstname)) &&
                                           (Search.LastName == null || distinct.LastName.Contains(Search.LastName)) &&
                                           (Search.MiddleName == null || distinct.MiddleName.Contains(Search.MiddleName)) &&
                                           (Search.BVN == null || distinct.BVN == Search.BVN) &&
                                            (Search.IsAccountClosed == null || distinct.IsAccountClose == Search.IsAccountClosed) &&
                                           (Search.StaffNo == null || distinct.StaffNumber == Search.StaffNo) &&
                                         //  (Search.DomicileBranchCode == null || distinct.DomicileBranchCode == Search.DomicileBranchCode) &&
                                           (Search.BranchCode == null || distinct.StaffBranchCode == Search.BranchCode) &&
                                           (Search.Irregularity == null || distinct.Irregularity == Search.Irregularity) &&                                           
                                           (Search.Date_From == null || distinct.DateSubmitted >= Convert.ToDateTime(Search.Date_From) || distinct.DateSubmitted == Convert.ToDateTime(Search.Date_From)) &&
                                           (Search.Date_To == null || distinct.DateSubmitted <= Convert.ToDateTime(Search.Date_To).AddDays(1)))
                                          

                                   select
                                   new
                                   {
                                       RequestID = distinct.DocumentID,
                                       BVN = distinct.BVN,
                                       Staffname = distinct.StaffName,
                                       StaffNo = distinct.StaffNumber,
                                       AccountNo = distinct.AccountNumberArray,
                                       AccountName = distinct.AccountNameArray,
                                       AccountStatus = distinct.AccountStatusArray,
                                       DomicileBranch = distinct.DomicileBranch,
                                       InitiatorBranchName = distinct.StaffBranch,
                                       Irregularity = distinct.Irregularity,
                                       OtherDetails = distinct.Nature_Of_The_Irregular,
                                       FirstName = distinct.Firstname,
                                       MiddleName = distinct.MiddleName,
                                       LastName = distinct.LastName,
                                       IsAccountClosed = distinct.IsAccountClose,
                                       DateSubmitted = distinct.DateSubmitted

                                   });
                foreach (var result_set in Projectinfo)
                {
                    InputClass input = new InputClass();
                    Profile profile = new Profile();
                    Account account = new Account();
                    input.DocumentID = result_set.RequestID;
                    input.Irregularity = (result_set.Irregularity == "Others") ? result_set.OtherDetails : result_set.Irregularity;
                    input.DateSubmitted = result_set.DateSubmitted;
                   
                    profile.StaffName = result_set.Staffname;
                    profile.StaffNo = result_set.StaffNo;
                    profile.Branch = result_set.InitiatorBranchName;

                    account.AccountName = (result_set.AccountNo == null) ? "" : result_set.AccountNo.Replace(";", "<BR><hr><BR>");

                    account.AccountNumber = (result_set.AccountName == null) ? "" : result_set.AccountName.Replace(";", "<BR><hr><BR>");
                    account.AccountStatus = (result_set.AccountStatus == null) ? "" : result_set.AccountStatus.Replace(";", "<BR><hr><BR>");

                    account.DomicileBranch = result_set.DomicileBranch;

                    account.Firstname = result_set.FirstName;
                    account.LastName = result_set.LastName;
                    account.MiddleName = result_set.MiddleName;
                    account.IsAccountClosedString = (result_set.IsAccountClosed == 1) ? "Yes" : "No";

                     

                    account.BVN = result_set.BVN;

                    input.RequesterDetails = profile;
                    input.AccountDetials = account;


                    ResultListLists.Add(input);

                }

            }

            catch (Exception ex)
            {
                // return ex.Message;
            }
            return ResultListLists;
        }




        public List<ExcelView> SearchTravelRequestExcel(SearchViewModel Search)
        {
            List<ExcelView> ResultListLists = new List<ExcelView>();
            int RowNum = 0;
            try
            {
                BVNDataContext Travelconn = new BVNDataContext();
                var Projectinfo = (from distinct in Travelconn.Tb_BvnIncidents
                                   where ((Search.AccountName == null || distinct.AccountNameArray.Contains(Search.AccountName)) &&
                                            (Search.AccountNumber == null || distinct.AccountNumberArray.Contains(Search.AccountNumber)) &&
                                            (Search.StaffName == null || distinct.StaffName.Contains(Search.StaffName)) &&
                                            (Search.Firstname == null || distinct.Firstname.Contains(Search.Firstname)) &&
                                            (Search.LastName == null || distinct.LastName.Contains(Search.LastName)) &&
                                            (Search.MiddleName == null || distinct.MiddleName.Contains(Search.MiddleName)) &&
                                            (Search.BVN == null || distinct.BVN == Search.BVN) &&
                                            (Search.IsAccountClosed == null || distinct.IsAccountClose == Search.IsAccountClosed) &&
                                            (Search.StaffNo == null || distinct.StaffNumber == Search.StaffNo) &&
                                       //  (Search.DomicileBranchCode == null || distinct.DomicileBranchCode == Search.DomicileBranchCode) &&
                                            (Search.BranchCode == null || distinct.StaffBranchCode == Search.BranchCode) &&
                                            (Search.Irregularity == null || distinct.Irregularity == Search.Irregularity) &&
                                            (Search.Date_From == null || distinct.DateSubmitted >= Convert.ToDateTime(Search.Date_From) || distinct.DateSubmitted == Convert.ToDateTime(Search.Date_From)) &&
                                            (Search.Date_To == null || distinct.DateSubmitted <= Convert.ToDateTime(Search.Date_To).AddDays(1)))
                                            
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
                                       JobTitle         = distinct.StaffTitle,
                                       Email        = distinct.Email,


                                       AccountNo = distinct.AccountNumberArray,
                                       AccountName = distinct.AccountNameArray,
                                       AccountStatus = distinct.AccountStatusArray,
                                       dateOfBirth  = distinct.dateOfBirth,
                                       CustomerName = distinct.CustomerNames,

                                       FirstName = distinct.Firstname,
                                       MiddleName = distinct.MiddleName,
                                       LastName = distinct.LastName,
                                       Comment = distinct.Comment,
                                       DomicileBranch = distinct.DomicileBranch,
                                       IsAccountClosed = distinct.IsAccountClose,
                                       BVN = distinct.BVN
                                       
                                       

                                   });
                foreach (var result_set in Projectinfo)
                {
                    ExcelView result = new ExcelView();
        
                    RowNum = RowNum + 1;
                    result.SN = RowNum;
                    result.AccountName = result_set.AccountName;
                   // result.AccountNumber = result_set.AccountNo;
                    result.BVN = result_set.BVN;

                    result.Firstname = result_set.FirstName;
                    result.LastName = result_set.LastName;
                    result.MiddleName = result_set.MiddleName;

                    result.StaffNo = result_set.StaffNo;
                    result.StaffName = result_set.Staffname;
                    result.JobTitle = result_set.JobTitle;
                    result.Branch = result_set.InitiatorBranchName;
                    result.Email = result_set.Email;
                    result.Account_Closed = (result_set.IsAccountClosed == 1) ? "Yes" : "No";
                    result.dateOfBirth = (result_set.dateOfBirth == null) ? "" : result_set.dateOfBirth;

                    result.AccountName = (result_set.AccountName == null) ? "" : result_set.AccountName.Replace(";", "<hr>");

                    result.AccountNumber = (result_set.AccountNo == null) ? "" : result_set.AccountNo.Replace(";", "<hr>");
                    result.AccountStatus = (result_set.AccountStatus == null) ? "" : result_set.AccountStatus.Replace(";", "<hr>");

                    result.Comment = result_set.Comment;

                    result.DateSubmitted = result_set.DateSubmitted;
                    result.Irregularity = result_set.Irregularity.Trim();
                    result.IrregularityDetails = result_set.IrregularityDetails.Trim();             

                    ResultListLists.Add(result);

                }

            }

            catch (Exception ex)
            {
                // return ex.Message;
            }
            return ResultListLists;
        }


    }
}
