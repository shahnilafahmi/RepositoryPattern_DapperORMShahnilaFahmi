using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Model
{
    public class ActivityDetail
    {
        public long DailyActivityId { get; set; }

        public int EmployeeId { get; set; }

        public string DailyActivityCreatedDate { get; set; }

        public string EmployeeCode { get; set; }
        public int CardNumber { get; set; }
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public string InchargeName { get; set; }
        public string InTime { get; set; }
        public string ReaderIn { get; set; }
        public string OutTime { get; set; }
        public string ReaderOut { get; set; }
        public string MonthEndProcessed { get; set; }
        public string ShiftName { get; set; }
        public string ShiftDescription { get; set; }
        public string StartTimeSt { get; set; }
        public string EndTimeSt { get; set; }
        public string FlixeInSt { get; set; }
        public string FlixeOutSt { get; set; }
        public string NatureOfDay { get; set; }
        public int DayInt { get; set; }
        public string Day { get; set; }
        public string ShiftStartTime { get; set; }
        public string ShiftEndTime { get; set; }
        public string FlexiIn { get; set; }
        public string FlexiOut { get; set; }
        public string WorkHours { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public Boolean IsActive { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int ModifiedBy { get; set; }

        public string UserIP { get; set; }
    }
}
