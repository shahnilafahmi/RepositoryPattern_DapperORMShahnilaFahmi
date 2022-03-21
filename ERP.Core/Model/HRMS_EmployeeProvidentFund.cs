using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Model
{
    public class HRMS_EmployeeProvidentFund
    {
        public int ProvidentFundDetailId { get; set; }

        public int EmployeeId { get; set; }

        public string NomineeName { get; set; }
        public string Relationship { get; set; }
        public string WitnessPerson { get; set; }

        public string NomineeAddress { get; set; }

        public string NomineeCNIC { get; set; }
        public int RelationshipId { get; set; }

        public string Percentage { get; set; }
        public Boolean IsMinor { get; set; }

        public int WitnessId { get; set; }
        public string NomineeMinorAddress { get; set; }
        public string NomineeNameForMinor { get; set; }
        public int NomineeAgeForMinor { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public Boolean IsActive { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int ModifiedBy { get; set; }

        public string UserIP { get; set; }
    }
}
