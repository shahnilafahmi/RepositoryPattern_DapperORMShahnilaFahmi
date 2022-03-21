using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Model
{
    public class EmployeePersonal
    {
        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public int ReligionId { get; set; }
        public int GenderId { get; set; }
        public int NationalityID { get; set; }
        public int MatrialStatusId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CountryOfBirthId { get; set; }
        public int StateId { get; set; }
        public string BirthPlace { get; set; }
        public string CNIC { get; set; }
        public DateTime CNICIssueDate { get; set; }
        public DateTime CNICExpiryDate { get; set; }
        public string DrivingLicence { get; set; }
        public string NTN { get; set; }
        public string SSN { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public Boolean IsActive { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int ModifiedBy { get; set; }

        public string UserIP { get; set; }
    }
}
