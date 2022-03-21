using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Model
{
    public class EmployeeContactDetail
    {
        public int EmployeeId { get; set; }

        public int LocationId { get; set; }

        public int BuildingId { get; set; }
        public int FloorId { get; set; }
        public int AreaId { get; set; }
        public string OfficeExtension { get; set; }
        public int DesignationId { get; set; }
        public int JobcategoryId { get; set; }
        public int BusinessUnitId { get; set; }
        public int DepartmentId { get; set; }
        public int CampaignId { get; set; }
        public int CostCenterId { get; set; }
        public int EmployeeTypeId { get; set; }
        public int TMSShiftId { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime ConfirmationDate { get; set; }
        public DateTime PriodEndDate { get; set; }
        public DateTime ProbationEndDate { get; set; }
        public int ProbationPeriodDays { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }
        public int HODCompanyId { get; set; }
        public int HODJobCategoryId { get; set; }
        public int HODDesignationId { get; set; }
        public int HODNameId { get; set; }
        public int ManagerCompanyId { get; set; }
        public int ManagerJobCategoryId { get; set; }
        public int ManagerDesignationId { get; set; }
        public int ManagerNameId { get; set; }
        public int InChargeCompanyId { get; set; }
        public int InChargeJobCategoryId { get; set; }
        public int InChargeDesignationId { get; set; }
        public int InChargeNameId { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public Boolean IsActive { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int ModifiedBy { get; set; }

        public string UserIP { get; set; }
    }
}
