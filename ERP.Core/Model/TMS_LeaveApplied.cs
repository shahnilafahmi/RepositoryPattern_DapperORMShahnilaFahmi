using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Model
{
    public class TMS_LeaveApplied
    {
        public int LeaveAppliedId { get; set; }

        public int EmployeeId { get; set; }

        public int LeaveStatusId { get; set; }
        public string EmployeeReason { get; set; }

        public int LeaveTypeId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int Duration { get; set; }
        public int Offset { get; set; }
        public int NoOfDays { get; set; }
        public int InchargeId { get; set; }
        public string InchargeReason { get; set; }
        public int WithoutPay { get; set; }
       
        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public Boolean IsActive { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int ModifiedBy { get; set; }

        public string UserIP { get; set; }
    }
}
