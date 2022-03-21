using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Model
{
    public class HRMS_EmployeePersonalInfo
    {
        public int PersonalContactDetailId { get; set; }

        public int EmployeeId { get; set; }
        public int StateId { get; set; }
        public string Country { get; set; }
        public string CityName { get; set; }

        public string OfficeEmail { get; set; }

        public string PersonalEmail { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string OfficeMobileNo { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public string PermanentAddress { get; set; }
        public string PresentAddress { get; set; }
       

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public Boolean IsActive { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int ModifiedBy { get; set; }

        public string UserIP { get; set; }
    }
}
