using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBVN
{
    public class ExcelView
    {
        public ExcelView()
        {
        AccountName = "";      
        BVN = "";      
        StaffNo = "";
        StaffName = "";
        Branch = "";       
        JobTitle = "";
        Email = "";

        Firstname = "";
        LastName = "";
        MiddleName = "";


        Irregularity = "";
        IrregularityDetails= "";
        Comment = "";            
        }

        public int SN { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string AccountStatus { get; set; }       
        public string BVN { get; set; }        

        public string StaffNo { get; set; }
        public string StaffName { get; set; }
        public string Branch { get; set; }        
        public string JobTitle { get; set; }
        public string Email { get; set; }
        public string Account_Closed { get; set; }

        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public string dateOfBirth { get; set; }


        public string Irregularity { get; set; }
        public string IrregularityDetails { get; set; }
        public string Comment { get; set; }
        public DateTime? DateSubmitted { get; set; }
       

        
    }
}
