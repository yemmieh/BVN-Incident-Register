using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBVN
{
    public class Profile
    {
        public Profile()
        {
            StaffNo = "";
            StaffName = "";
            Branch = "";
            BranchCode = 0;
            Dept = "";
            DeptID = "";
            unitname = "";
            unitcode = "";
            level = "";
            Date_of_Employment = DateTime.Now;
            Date_of_Last_Promotion = DateTime.Now;
            Duration_in_present_Grade = 0;
            Confirmation_Status = "";
            Sick_Leave_Days = 0;
            JobTitle = "";
            Job_Function = "";
            Job_Function_id = 0;
            Job_Category_id = "";
            Job_Category = "";
            Email = "";
            UserID = "";
            GradeBand = "";
        }
        public string StaffNo { get; set; }
        public string StaffName { get; set; }
        public string Branch { get; set; }
        public int? BranchCode { get; set; }
        public string Dept { get; set; }
        public string DeptID { get; set; }
        public string unitname { get; set; }
        public string unitcode { get; set; }
        public string level { get; set; }
        public DateTime? Date_of_Employment { get; set; }
        public DateTime? Date_of_Last_Promotion { get; set; }
        public int? Duration_in_present_Grade { get; set; }
        public string Confirmation_Status { get; set; }
        public int? Sick_Leave_Days { get; set; }
        public string JobTitle { get; set; }
        public string Job_Function { get; set; }
        public int? Job_Function_id { get; set; }
        public string Job_Category_id { get; set; }
        public string Job_Category { get; set; }
        public string Email { get; set; }
        public string UserID { get; set; }
        public string GradeBand { get; set; }
    }
}
