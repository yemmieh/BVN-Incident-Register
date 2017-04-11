using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBVN
{
    public class Account
    {

        public Account()
        {
            AccountName = "";
            AccountNumber = "";
            DomicileBranch = "";


            Firstname = "";
            LastName = "";
            MiddleName = "";


            DomicileBranchCode = "0";
            BVN = "";
            customerNames = "";
        }
        public string AccountName { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string EnrrolmentBranch { get; set; }
        public string EnrrolmentBank { get; set; }
        public string AccountNumber { get; set; }
        public string DomicileBranch { get; set; }
        public string DomicileBranchCode { get; set; }
        public string BVN { get; set; }
        public string customerNames { get; set; }
        public string dateOfBirth { get; set; }
        public string AccountStatus { get; set; }
        public string AccountNameArray { get; set; }
        public string AccountNumberArray { get; set; }
        public string AccountStatusArray { get; set; }
        public int? IsAccountClosed { get; set; }
        public string IsAccountClosedString { get; set; }

     

    }
}
