using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ERP.Core.Model
{
    public class UserLogin
    {
        public int UserId { get; set; }

        //public byte[] Password { get; set; }

        public string Password { get; set; }
        
        public string OldPassword { get; set; }

        public string NewPassword { get; set; }
        public int RoleId { get; set; }
        public int HODDesignationId { get; set; }
        public int ManagerDesignationId { get; set; }
        public int InChargeDesignationId { get; set; }

        public string EmployeeName { get; set; }
        public string ApplicantName { get; set; }

        public string LeaveType { get; set; }


    public DateTime CreatedDate { get; set; }

        public Boolean IsActive { get; set; }

        public int ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string UserIP { get; set; }

        public int EmployeeId { get; set; }

        public string LoginId { get; set; }
        public int CreatedBy { get; set; }

        public Boolean IsLocked { get; set; }

        public string OfficialEmailAddress { get; set; }

        public string Name { get; set; }

        public int ApplicationId { get; set; }

        public int CompanyId { get; set; }

        public string CompanyName { get; set; }
    }
}
