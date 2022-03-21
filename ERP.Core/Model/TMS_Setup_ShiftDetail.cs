using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Model
{
    public class TMS_Setup_ShiftDetail
    {
        public int ShiftDetailId { get; set; }

        public int ShiftId { get; set; }

        public string ShiftName { get; set; }
        public string ShiftDescription { get; set; }
        public string ShiftDayTypeName { get; set; }



        public int DayInt { get; set; }
        public int ShiftDayTypeId { get; set; }
        public string StartTimeSt { get; set; }
        public string EndTimeSt { get; set; }
        public string BreakTimeSt { get; set; }
        public int BreakTimeInt { get; set; }
        public int EndTimeInt { get; set; }
        public int StartTimeInt { get; set; }
        public string FlixeInSt { get; set; }
        public int FlixeInInt { get; set; }
        public string FlixeOutSt { get; set; }
        public int FlixeOutInt { get; set; }
        public int SiteId { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public Boolean IsActive { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int ModifiedBy { get; set; }

        public string UserIP { get; set; }
    }
}
