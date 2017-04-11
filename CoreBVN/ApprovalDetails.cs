using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBVN
{
    public class ApprovalDetails
    {
        //public string Approver{ get;set;}
        public string ApproverNames { get; set; }
        public string ApproverStaffNumbers { get; set; }
        public string ApprovedStages { get; set; }
        public string ApproverAction { get; set; }
        public string ApproverComment { get; set; }
        public string ApprovalDateTime { get; set; }
        public IEnumerable<ApprovalDetails> ApprovalHistory { get; set; }
    }
}
