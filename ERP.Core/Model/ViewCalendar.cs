using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Model
{
    public class ViewCalendar
    {
        public int EmployeeID { get; set; }

        public DateTime Date { get; set; }

        public int ShiftDayTypeId { get; set; }

        public string ShiftDayTypeName { get; set; }

        public string ShiftTimming { get; set; }

        public int TMSShiftId { get; set; }
        public string ShiftName { get; set; }
        


    }
}
