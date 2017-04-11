using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CoreBVN
{
    public class InputClass
    {
        [Key]
        public string DocumentID { get; set; }
        public string appId { get; set; }
        
        public string Action { get; set; }
        public string Status { get; set; }
        public string Eligibilty { get; set; }
        public string InputStage { get; set; }
        public int InputStageId { get; set; }
        public string Comment { get; set; }
        public DateTime? DateSubmitted { get; set; }
        public Profile RequesterDetails { get; set; }
        public Account AccountDetials { get; set; }
        public string Irregularity { get; set; }
        public string IrregularityDetails { get; set; }

        public IEnumerable<Account> accountNamelist { get; set; }

        public IEnumerable<Account> accountNumberlist { get; set; }

    }
}
