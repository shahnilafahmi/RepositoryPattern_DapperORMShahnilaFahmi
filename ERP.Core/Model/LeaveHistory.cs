using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Model
{
    public class LeaveHistory
    {
       
        public int LeaveAppliedId { get; set; }
        public int EmployeeId { get; set; }
        public int NoOfDays { get; set; }
        public string LeaveTypeName { get; set; }
        public DateTime DateApplied { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime LeaveCreationDate { get; set; }
        public DateTime ApproveDate { get; set; }

        public string InchargeReason { get; set; }

        public string StatusName { get; set; }

        public string EmployeeReason { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public Boolean IsActive { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int ModifiedBy { get; set; }

        public string UserIP { get; set; }
    }
}
