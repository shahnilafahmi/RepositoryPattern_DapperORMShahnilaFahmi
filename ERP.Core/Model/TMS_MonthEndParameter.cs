using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Model
{
    public class TMS_MonthEndParameter
    {
        public int MonthEndParameterId { get; set; }

        public DateTime Created_Date { get; set; }
        public DateTime Modified_Date { get; set; }
        public Boolean Is_PayRoll_Running { get; set; }

        public DateTime Month_End_Process_Date { get; set; }

        public int MonthEnd_StartDate { get; set; }
        public int MonthEnd_EndDate { get; set; }
        public int CompanyId { get; set; }
        public int CurrentMonth { get; set; }
        public int CurrentYear { get; set; }
        public string ImagePath { get; set; }

    }
}
