using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CoreBVN
{
    public class DropDownHelper
    {
        public IEnumerable<SelectListItem> getIrregularities()
        {

            IList<SelectListItem> items = new List<SelectListItem> {

                    new SelectListItem{Text = "Visafone", Value = "Visafone"},
                    new SelectListItem{Text = "MTN", Value = "MTN"},
                    new SelectListItem{Text = "Etisalat", Value = "Etisalat"},
                    new SelectListItem{Text = "Airtel", Value = "Airtel"},
                    new SelectListItem{Text = "GLO", Value = "GLO"},
                                     

                };
            return items;
        }

        public IEnumerable<SelectListItem> getBranchesNew()
        {
            XceedDataContext xceed = new XceedDataContext();

            var branchinfo = (from distinct in xceed.vw_employeeinfos
                              where (distinct.org_id == 1)
                              select
                              new
                              {
                                  BranchName = distinct.Branch,
                                  BranchCode = distinct.Branch + ":" + distinct.Branch_code
                              }).Distinct().OrderBy(distinct => distinct.BranchName);

            var BranchList = new SelectList(branchinfo, "BranchCode", "BranchName");
            return BranchList;

        }
    }
}
