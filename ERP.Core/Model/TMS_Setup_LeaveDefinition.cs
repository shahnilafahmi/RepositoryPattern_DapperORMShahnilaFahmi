using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Model
{
    public class TMS_Setup_LeaveDefinition
    {
        public int LeaveDefId { get; set; }

        public int CategoryId { get; set; }

        public string Description { get; set; }
        public int AnualLeaves { get; set; }
        public int SickLeaves { get; set; }
        public int CasualLeaves { get; set; }
        public int MaternityLeaves { get; set; }
        public int DefaultLeaves { get; set; }
        public Boolean AnualLeavesForward { get; set; }
        public Boolean SickLeavesForward { get; set; }
        public Boolean MaternityLeavesForward { get; set; }
        public Boolean DefaultLeavesForward { get; set; }
        public Boolean CasualLeavesFarward { get; set; }
        public int CompanyId { get; set; }
      
        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public Boolean IsActive { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int ModifiedBy { get; set; }

        public string UserIP { get; set; }
     
        public int SiteId { get; set; }
        public int GenderId { get; set; }

    }
}
