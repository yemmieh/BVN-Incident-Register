using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBVN
{
    public class LinqCalls
    {
        public Profile getProfile(string AcctNo)
        {
            Profile profile = new Profile();

            XceedDataContext xceed = new XceedDataContext();
            var Profileinfo = (from distinct in xceed.vw_employeeinfos
                               where (distinct.employee_number == AcctNo)
                               select
                               new
                               {
                                   BranchName = distinct.Branch,
                                   BranchCode = distinct.Branch_code,
                                   StaffNumber = distinct.employee_number,
                                   StaffName = distinct.name,
                                   DateOfEmployment = distinct.employment_date,
                                   LastPromotionDate = distinct.last_promo_date,
                                   Level = distinct.grade_code,
                                   Email = distinct.email,
                                   Dept = distinct.dept,

                                   Dept_id = distinct.department_id,
                                   Unit = distinct.unit,
                                   unitCode = distinct.unit,
                                   jobtitle = distinct.jobtitle,
                                   confirm = distinct.emp_confirm,

                               }).Distinct();

            foreach (var Profiles in Profileinfo)
            {
                profile.Branch = Profiles.BranchName;
                profile.BranchCode = int.Parse(Profiles.BranchCode.ToString());
                profile.StaffNo = Profiles.StaffNumber;
                profile.StaffName = Profiles.StaffName;
                profile.level = Profiles.Level;
                profile.Email = Profiles.Email;
                profile.Dept = Profiles.Dept;
                profile.DeptID = Profiles.Dept_id.ToString();
                profile.unitname = Profiles.Unit;
                profile.unitcode = Profiles.unitCode;
                profile.Job_Function = Profiles.jobtitle;
                profile.JobTitle = Profiles.jobtitle;
                profile.Date_of_Employment = Profiles.DateOfEmployment;
                profile.Date_of_Last_Promotion = Profiles.LastPromotionDate;
                profile.Confirmation_Status = (Profiles.confirm.ToString().Equals("1")) ? "Confirmed" : "UnConfirmed";
            }
            return profile;

        }
    }
}
