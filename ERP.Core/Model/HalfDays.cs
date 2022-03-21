using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Model
{
    public class HalfDays
    {
        public string StartTimeSt { get; set; }

        public string EndTimeSt { get; set; }

        public int StartTimeInt { get; set; }
        public int EndTimeInt { get; set; }
        public int ShiftId { get; set; }
        public string FlixeInSt { get; set; }
        public string FlixeOutSt { get; set; }
        public int ShiftReqHours { get; set; }
        public DateTime ShiftStartDateTime { get; set; }
        public DateTime ShiftEndDateTime { get; set; }
        public DateTime FirstHalfStartDateTime { get; set; }
        public DateTime FirstHalfEndDateTime { get; set; }
        public DateTime SecondHalfStartDateTime { get; set; }
        public DateTime SecondHalfStartEndDateTime { get; set; }
        public string FirstHalfStartTime { get; set; }
        public string FirstHalfEndTime { get; set; }
        public string SecondHalfStartTime { get; set; }
        public string SecondHalfEndTime { get; set; }
        public string Days { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public Boolean IsActive { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int ModifiedBy { get; set; }

        public string UserIP { get; set; }
    }
}
