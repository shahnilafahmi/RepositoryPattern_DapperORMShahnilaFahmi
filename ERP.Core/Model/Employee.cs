using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Model
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public Boolean Status { get; set; }
        
        public int StateId { get; set; }
        public string EmployeeCode { get; set; }

        public string PreviousEmployeeCode { get; set; }
        public int RequisitionId { get; set; }
        public int CardNumber { get; set; }
        public int AccessCardId { get; set; }
        public int CollectReasonId { get; set; }
        public DateTime AccessCardIssueDate { get; set; }
        public DateTime AccessCardCollectDate { get; set; }
        public int CompanyId { get; set; }
        public int EmployeeTypeId { get; set; }
        public int DepartmentId { get; set; }
        public int DesignationId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{MM-dd-yyyy}")]
        public DateTime JoiningDate { get; set; }
        public DateTime PriodEndDate { get; set; }
        public int InchargeId { get; set; }
        public string FatherName { get; set; }
        public string Phone { get; set; }
        public string Cell { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{MM-dd-yyyy}")]
        public DateTime DateOfBirth { get; set; }
        public string CNIC { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalEmailAddress { get; set; }
        public string OfficialEmailAddress { get; set; }

        public int CountryId { get; set; }
        public int CityId { get; set; }
        public int GenderId { get; set; }
        public string Gender { get; set; }
        public string BusinessUnit { get; set; }
        public int MatrialStatusId { get; set; }
        public string BirthPlace { get; set; }

        public int ReligionId { get; set; }
        public string PermanentAddress { get; set; }
        public string PresentAddress { get; set; }
        public string DrivingLicence { get; set; }
        public DateTime CNICIssueDate { get; set; }
        public DateTime CNICExpiryDate { get; set; }
        public string NTN { get; set; }
        public string SSN { get; set; }
        public int NoticePeriodDays { get; set; }
        public int ProbationPeriodDays { get; set; }
        public string Fax { get; set; }
        public int Extension { get; set; }
        public Boolean IsContractual { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }
        public string PersonalityDetail { get; set; }
        public string PictureName { get; set; }
        public int TMSLeaveId { get; set; }

        public DateTime ResignedDate { get; set; }
        public int CostCenterId { get; set; }
        public int NoOfChildren { get; set; }
        public int NationalityID { get; set; }
        public int CountryOfBirthId { get; set; }
        public DateTime LastworkingDate { get; set; }
        public int TerminationTypeId { get; set; }
        public int NoticePeriodTypeId { get; set; }
        public string Remarks { get; set; }

        public string ProfilePic { get; set; }
        public string EmployeeName { get; set; }
        
        public DateTime ConfirmationDate { get; set; }
        public int HODID { get; set; }
        public int LocationId { get; set; }
        public string MiddleName { get; set; }
        public string OfficialMobileNumber { get; set; }
        public int ManagerId { get; set; }
        public int CampaignId { get; set; }
        public Boolean IsFlexiDeduct { get; set; }


        public string DesignationName { get; set; }

        public string DepartmentName { get; set; }
        public string LocationName { get; set; }
        public int GroupId { get; set; }
        public int DomainId { get; set; }
        public int BusinessUnitId { get; set; }
        public int JobCategoryId { get; set; }
        public string PersonalityDescription { get; set; }

        public int BuildingId { get; set; }
        public int FloorId { get; set; }
        public int AreaId { get; set; }
        public string OfficeExtension { get; set; }
        public int TMSShiftId { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime ProbationEndDate { get; set; }
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
        public string InChargeName { get; set; }



        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public Boolean IsActive { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int ModifiedBy { get; set; }

        public string UserIP { get; set; }
    }
}
