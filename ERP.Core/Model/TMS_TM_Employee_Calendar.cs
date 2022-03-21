using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Model
{
    public class TMS_TM_Employee_Calendar
    {
        public int Record_ID { get; set; }

        public int EmployeeID { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int DAY1 { get; set; }
        public int DAY2 { get; set; }
        public int DAY3 { get; set; }
        public int DAY4 { get; set; }
        public int DAY5 { get; set; }
        public int DAY6 { get; set; }
        public int DAY7 { get; set; }
        public int DAY8 { get; set; }
        public int DAY9 { get; set; }
        public int DAY10 { get; set; }
        public int DAY11 { get; set; }
        public int DAY12 { get; set; }
        public int DAY13 { get; set; }
        public int DAY14 { get; set; }
        public int DAY15 { get; set; }
        public int DAY16 { get; set; }
        public int DAY17 { get; set; }
        public int DAY18 { get; set; }
        public int DAY19 { get; set; }
        public int DAY20 { get; set; }
        public int DAY21 { get; set; }
        public int DAY22 { get; set; }
        public int DAY23 { get; set; }
        public int DAY24 { get; set; }
        public int DAY25 { get; set; }
        public int DAY26 { get; set; }
        public int DAY27 { get; set; }
        public int DAY28 { get; set; }
        public int DAY29 { get; set; }
        public int DAY30 { get; set; }
        public int DAY31 { get; set; }
        public Boolean IsNewTMS { get; set; }
        

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public Boolean IsActive { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int ModifiedBy { get; set; }

        public string UserIP { get; set; }
    }
}
