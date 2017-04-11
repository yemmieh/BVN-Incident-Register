using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreBVN.BVNService;

namespace CoreBVN
{
    public class OpenEntry
    {
        public Account getaccountdetails(string BVN)
        {

            Account acc = new Account();
             BVNService.Service d = new BVNService.Service();
             if (BVN == "")
             {
                 BVN = "0";
             }
            var ss = d.isBVNValid(BVN, "057");
            acc.BVN = ss.BVN;
            acc.Firstname = ss.FirstName;
            acc.LastName = ss.LastName;
            acc.MiddleName = ss.MiddleName;
            acc.EnrrolmentBank = ss.EnrollmentBank;
            acc.EnrrolmentBranch = ss.EnrollmentBranch;
            acc.dateOfBirth = ss.DOB;
            return acc;
            
          
        }

    }
}
