using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBVN
{
    public class SearchViewModel
    {
        public string StaffNo { get; set; }
        public string StaffName { get; set; }
        public string Branch { get; set; }
        public int? BranchCode { get; set; }
        public string Dept { get; set; }
        public string DeptID { get; set; }
        public string unitname { get; set; }
        public string unitcode { get; set; }
        public string level { get; set; }     
        public string JobTitle { get; set; }
        public string Job_Function { get; set; }
        public int? Job_Function_id { get; set; }
        public string Job_Category_id { get; set; }
        public string Job_Category { get; set; }
        public string Email { get; set; }

        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string DomicileBranch { get; set; }
        public string DomicileBranchCode { get; set; }

        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public string BVN { get; set; }
        public string customerNames { get; set; }

        public string Irregularity { get; set; }
        public string IrregularityDetails { get; set; }
        public bool ExportToExport { get; set; }
        public int? IsAccountClosed { get;set;}      
        public DateTime? Date_From { get; set; }
        public DateTime? Date_To { get; set; }
        public IEnumerable<InputClass> inputlist { get; set; }
     
    }
}
