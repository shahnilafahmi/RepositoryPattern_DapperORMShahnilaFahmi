using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Model
{
    public class SearchEmployee
    {
        //public int? groupId { get; set; }
        public int? CompanyId { get; set; }
        public int? LocationId { get; set; }
        public int? BusinessUnitId { get; set; }
        public int? DepartmentId { get; set; }
        public int? CampaignId { get; set; }
        public int? CostCenterId { get; set; }
        public int? DesignationId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? JoiningDate { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Boolean? Status { get; set; }

        
        public string employeeCode { get; set; }

        public string officialEmailAddress { get; set; }

    

    }
}
