using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBVN
{
    public static class staticClass
    {
        public static bool CompareMultiple(this string data, StringComparison compareType, params string[] compareValues)
        {
            foreach (string s in compareValues)
            {
                if (data.Equals(s, compareType))
                {
                    return true;
                }
            }
            return false;
        }

        public static string ConCatAccountNumber(Account arg)
        {
            return arg.AccountNumber.ToString();
        }
        public static string ConCatAccountName(Account arg)
        {
            return arg.AccountName.ToString();
        }

        public static string ConCatAccountStatus(Account arg)
        {
            return arg.AccountStatus.ToString();
        }
       
    }
}
