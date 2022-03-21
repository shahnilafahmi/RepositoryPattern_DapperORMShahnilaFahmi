using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Model
{
    public class HRMS_EmployeeEmergencyContactDetail
    {
        public int EmergencyContactDetailId { get; set; }

        public int EmployeeId { get; set; }
        public int StateId { get; set; }

        public string Name { get; set; }
        public string Country { get; set; }
        public string CityName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string PhoneNo { get; set; }
        public string CellNo { get; set; }
        public int RelationshipId { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public Boolean IsActive { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int ModifiedBy { get; set; }

        public string UserIP { get; set; }
    }
}
