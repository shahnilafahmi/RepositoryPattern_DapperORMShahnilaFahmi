using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Model
{
    public class HRMS_EmployeeProfessionalReference
    {
        public int ProfessionalReferenceId { get; set; }
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Instituation { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string OfficialEmailAddress { get; set; }
        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public Boolean IsActive { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int ModifiedBy { get; set; }

        public string UserIP { get; set; }
    }
}
