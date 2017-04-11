using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBVN
{
    public class StaffADProfile
    {
        public string employee_number { get; set; }
        public string branch_name { get; set; }
        public string branch_code { get; set; }
        public string branch_address { get; set; }
        public string mobile_phone { get; set; }
        public string gsm { get; set; }
        public string jobtitle { get; set; }
        public string office_ext { get; set; }
        public string department { get; set; }
        public string user_logon_name { get; set; }
        public string email { get; set; }
        public List<string> membership { get; set; }
        public string hodeptcode { get; set; }
        public string hodeptname { get; set; }
        public string appperiod { get; set; }

        /***New Staff Input Fields***/
        [Display(Name = "Staff Number")]
        public string in_StaffNumber { get; set; }

        [Display(Name = "Staff Name")]
        public string in_StaffName { get; set; }

        [Display(Name = "Staff Grade")]
        public string in_StaffGrade { get; set; }
    }
}
