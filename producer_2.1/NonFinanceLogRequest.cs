using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ms_common_model.nonFinanceLog
{
    public class NonFinanceLogRequest 

    {

        public string Event { get; set; }

        public string CIF { get; set; }

        public string Username { get; set; }

        public string Description { get; set; }

        public string Remarks { get; set; }

    }
}
