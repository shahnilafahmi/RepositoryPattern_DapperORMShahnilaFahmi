using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Model
{
    public class InOutTimming
    {
        public DateTime DateValue { get; set; }

        public int DailyActivityId { get; set; }

        public DateTime CreatedDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int TimeAdjustmentRequestId { get; set; }
        public DateTime RequestedDateTime { get; set; }
        public DateTime OriginalDateTime { get; set; }
        public string TimeAdjStatusNameIn { get; set; }
        public int EmployeeId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int TimeAdjustmentRequestIdOut { get; set; }
        public string TimeAdjStatusNameOut { get; set; }

        public Boolean IsLate_StartTime { get; set; }

        public Boolean IsLate_End_Time { get; set; }
        public Boolean IsPayrolwise { get; set; }



        public int CreatedBy { get; set; }

        public Boolean IsActive { get; set; }

     

        public int ModifiedBy { get; set; }

        public string UserIP { get; set; }
    }
}
