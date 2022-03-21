using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Model
{
    public class HRMS_EmployeeFamilyInformation
    {
        public int FamilyMemberInfoId { get; set; }

        public int EmployeeId { get; set; }

        public string Name { get; set; }
        public string Relationship { get; set; }
        public string Qualification { get; set; }

        public int RelationshipId { get; set; }
        public DateTime DOB { get; set; }
        public int QualificationId { get; set; }
      
        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public Boolean IsActive { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int ModifiedBy { get; set; }

        public string UserIP { get; set; }
    }
}
