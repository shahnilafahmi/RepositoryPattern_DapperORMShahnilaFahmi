using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Model
{
    public class TMS_DailyActivity
    {
        public int DailyActivityId { get; set; }
        public Boolean IsMonthWise { get; set; }

        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public string StartTimeHour { get; set; }
        public string StartTimeMinute { get; set; }

        public string EndTimeHour { get; set; }
        public string EndTimeMinute { get; set; }
        public int EmployeeId { get; set; }

        public int Month { get; set; }
        public int Year { get; set; }
        public string EmployeeName { get; set; }
        public Boolean Processed { get; set; }
      
        public string ReaderIn { get; set; }
        public string ReaderOut { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime OrignalCreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime OrignalModifiedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
        public Boolean IsActive { get; set; }
        public TimeSpan ShiftStartTime { get; set; }
        public TimeSpan ShiftEndTime { get; set; }

        public TimeSpan FlexiIn { get; set; }

        public TimeSpan FlexiOut { get; set; }

        public Boolean IsLateIn { get; set; }

        public Boolean IsLateOut { get; set; }

        public int ShiftReqHours { get; set; }

        public int DepartmentID { get; set; }
        public int CostCenterID { get; set; }
        public int DesignationID { get; set; }
        public int CategoryID { get; set; }
        public long LeaveID { get; set; }
        public int ShiftID { get; set; }
        public int CompanyID { get; set; }
        public Boolean IsNewTMS { get; set; }
        public int ManualEntryBy { get; set; }
        public DateTime ManualEntryDateime { get; set; }
        public string UserIp { get; set; }
    }
}
