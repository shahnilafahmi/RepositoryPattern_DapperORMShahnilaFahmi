using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Model
{
    public class HRMS_EmployeeExperience
    {
        public int EmployeeExperienceId { get; set; }

        public int EmployeeId { get; set; }

        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Designation { get; set; }
        public Decimal InitialSalary { get; set; }
        public int InitialSalaryCurrencyId { get; set; }
        public Decimal LastSalary { get; set; }
        public int LastSalaryCurrencyId { get; set; }

        public string JobResponsibility { get; set; }
        public string Accomplishments { get; set; }
        public Boolean IsStillEmployeed { get; set; }
        public string ReasonForLeaving { get; set; }
        public DateTime TenureFrom { get; set; }
        public DateTime TenureTo { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public Boolean IsActive { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int ModifiedBy { get; set; }

        public string UserIP { get; set; }
    }
}
