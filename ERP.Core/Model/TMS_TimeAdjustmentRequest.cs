using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Model
{
    public class TMS_TimeAdjustmentRequest
    {
        public int TimeAdjustmentRequestId { get; set; }
        public string EmployeeName { get; set; }

        public string Message { get; set; }

        public int RequestedTimeHour { get; set; }
        public int RequestedTimeMinute { get; set; }

        public long DailyActivityId { get; set; }
        public Boolean IsTimeOutRequest { get; set; }
        public DateTime OriginalDateTime { get; set; }
        public DateTime RequestedDateTime { get; set; }
        public int StatusId { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeComment { get; set; }
        public int ApproverId { get; set; }
        public string ApproverComment { get; set; }
        public int CompanyId { get; set; }
        public DateTime ApprovedDateTime { get; set; }
        public Boolean Processed { get; set; }
        public DateTime ProcessedDateTime { get; set; }
        public Boolean DayEndProcess { get; set; }
        public Boolean IsNewTMS { get; set; }
        public int AdjustmentReasonId { get; set; }
        public int SiteId { get; set; }
        public TimeSpan StartTime { get; set; }

        

        public DateTime Created_Date { get; set; }
        public DateTime Modified_Date { get; set; }
        public Boolean Is_PayRoll_Running { get; set; }

        public DateTime Month_End_Process_Date { get; set; }

        public int MonthEnd_StartDate { get; set; }
        public int MonthEnd_EndDate { get; set; }
     
        public int CurrentMonth { get; set; }
        public int CurrentYear { get; set; }
        public string ImagePath { get; set; }

        public int CreatedBy { get; set; }

        public int ModifiedBy { get; set; }

    }
}
