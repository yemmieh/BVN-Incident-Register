using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBVN
{
    public class ApproverInfo
    {
        [Key]
        public string StaffNumber { get; set; }
        public string name { get; set; }
        public string Email { get; set; }
        public string Branch { get; set; }
        public string Jobtitle { get; set; }
        public string Grade { get; set; }
        public bool IsAdmin { get; set; }
        public string DeptTitle { get; set; }
    }
}
