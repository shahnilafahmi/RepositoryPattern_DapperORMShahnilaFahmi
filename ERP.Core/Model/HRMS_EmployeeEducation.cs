using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Model
{
    public class HRMS_EmployeeEducation
    {
        public int EmployeeEducationId { get; set; }

        public int EmployeeId { get; set; }

        public int EducationTypeId { get; set; }
        public string Institution { get; set; }
        public string Degree { get; set; }
        public string Percentage { get; set; }
        public int EducationScoreId { get; set; }
        public int EducationStatusId { get; set; }
        public int CountryId { get; set; }

        public string EducationType { get; set; }
        public string EducationScore { get; set; }
        public string EducationStatus { get; set; }
        public string CountryName { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public Boolean IsActive { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int ModifiedBy { get; set; }

        public string UserIP { get; set; }
    }
}
