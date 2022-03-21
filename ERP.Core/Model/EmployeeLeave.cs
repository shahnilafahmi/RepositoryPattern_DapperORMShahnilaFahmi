using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Model
{
    public class EmployeeLeave
    {
        public int EmployeeLeaveID { get; set; }
        public int EmployeeID { get; set; }
        public int LeaveID { get; set; }
        public int Code_ID { get; set; }
        public string Remarks { get; set; }
        public int AnualLeaves { get; set; }
        public int SickLeaves { get; set; }
        public int CasualLeaves { get; set; }
        public int MaternityLeaves { get; set; }
        public int DefaultLeaves { get; set; }
        public int AnualLeavesRemain { get; set; }
        public int SickLeavesRemin { get; set; }

        public int CasualLeavesRemain { get; set; }
        public int MaternityLeavesRemain { get; set; }
        public int DefaultLeavesRemain { get; set; }

        public Boolean IsNewTMS { get; set; }


        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public Boolean IsActive { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int ModifiedBy { get; set; }

        public string UserIP { get; set; }
    }
}
