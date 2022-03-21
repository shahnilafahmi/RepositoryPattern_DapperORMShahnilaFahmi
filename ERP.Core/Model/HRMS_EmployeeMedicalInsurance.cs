using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Model
{
    public class HRMS_EmployeeMedicalInsurance
    {
        public int MedicalInsuranceDetailId { get; set; }

        public int EmployeeId { get; set; }

        public string Name { get; set; }

        public string CNIC { get; set; }
        public string Occupation { get; set; }
        public int RelationshipId { get; set; }
        public string Relationship { get; set; }
        public DateTime DOB { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public Boolean IsActive { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int ModifiedBy { get; set; }

        public string UserIP { get; set; }
    }
}
