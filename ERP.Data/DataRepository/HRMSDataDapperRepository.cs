using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Model;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using ERP.Application.Interface;
using ERP.Application.Manager.DapperManager;
using ERP.Application.BaseRepository.Repository;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Management;
using ERP.Core.Utilities;
using ERP.Core.Utilities.EmailSecuritySetUp;
using System.Web.Script.Serialization;

namespace ERP.Data.DataRepository.SecurityDataDapperRepositor
{
    public interface IHRMSDataDapperRepositor
    {
       


        #region Employee Module
        Task<IEnumerable<Employee>> GetAllEmployees(int pagesize, int employeeId, int roleId);
        Task<Employee> GetAllEmployeeByEmployeeId(int employeeId);
        Task<IEnumerable<Employee>> GetAllEmployeeByDepartmentId(
            int departmentId);
        void UpdateEmployeeDataDapper(EmployeePersonal model);
        void UpdateEmployeeCompanyDetailDataDapper(EmployeeContactDetail model);
        Task<Employee> GetProfilePictureByEmployeeId(int employeeId);
        Task<IEnumerable<HRMS_EmployeeDocuments>> GetDocumentByEmployeeId(int employeeId);
        Task<IEnumerable<Employee>> SearchAllEmployees(
            SearchEmployee searchParam);

        void CreateEmployeeDataDapper(
            Employee model);

         void UpdateEmployeePersonalInfoDataDapper(
             Employee model);
        Task<IEnumerable<Location>> GetLocation();

        void UpdateEmployeeProfilePictureDataDapper(
            int employeeId,
            string pictureName);

        void UpdateEmployeePersonalityDetailDataDapper(Employee model);


        #endregion

        #region EmployeeEducation
        Task<IEnumerable<HRMS_EmployeeEducation>> GetEmployeeEducationByEmployeeIdDapper(int employeeId);
        void DeleteEmployeeEducationDapper(HRMS_EmployeeEducation model);
        void UpdateEmployeeEducationDataDapper(HRMS_EmployeeEducation model);
        void CreateEmployeeEducationDataDapper(HRMS_EmployeeEducation model);
        #endregion

        #region Employee Experience
        Task<IEnumerable<HRMS_EmployeeExperience>> GetEmployeeExperienceByEmployeeIdDapper(int employeeId);
        void DeleteEmployeeExperienceDapper(HRMS_EmployeeExperience model);
        void UpdateEmployeeExperienceDataDapper(HRMS_EmployeeExperience model);
        void CreateEmployeeExperienceDataDapper(HRMS_EmployeeExperience model);
        #endregion

        #region HRMS - Professional Reference
        Task<IEnumerable<HRMS_EmployeeProfessionalReference>> GetEmployeeProfessionalReferenceByEmployeeIdDapper(
            int employeeId);
        void DeleteEmployeeProfessionalReferenceDapper(
            HRMS_EmployeeProfessionalReference model);

        void UpdateEmployeeProfessionalReferenceDataDapper(
            HRMS_EmployeeProfessionalReference model);

        void CreateEmployeeProfessionalReferenceDataDapper(
            HRMS_EmployeeProfessionalReference model);


        #endregion

        #region HRMS - Employee Documents
        Task<IEnumerable<HRMS_EmployeeDocuments>> GetEmployeeDocumentByEmployeeIdDapper(
         int employeeId);

        void DeleteEmployeeDocumentsDapper(
            HRMS_EmployeeDocuments model);

        void UpdateEmployeeDocumentDataDapper(
            HRMS_EmployeeDocuments model);

        void CreateEmployeeDocumentsDataDapper(
            HRMS_EmployeeDocuments model);

        void UpdateEmployeeDocumentDataDapper(
            int employeeId, 
            string fileName);
        #endregion

        #region HRMS - Bank Details
        Task<IEnumerable<HRMS_EmployeeBankDetails>> GetEmployeeBankDetailDapper(
          int employeeId);
        void DeleteEmployeeBankDetailDapper(HRMS_EmployeeBankDetails model);
        void UpdateEmployeeBankDetailDataDapper(HRMS_EmployeeBankDetails model);
        void CreateEmployeeBankDetailDataDapper(HRMS_EmployeeBankDetails model);
        #endregion

        #region HRMS - Life Insurance
        Task<IEnumerable<Employee>> GetWitnessDapper();
        Task<IEnumerable<HRMS_EmployeeLifeInsurance>> GetEmployeeLifeInsuranceDetailDapper(
         int employeeId);
        void DeleteEmployeeLifeInsuranceDetailDapper(HRMS_EmployeeLifeInsurance model);
        void UpdateEmployeeLifeInsuranceDetailDataDapper(HRMS_EmployeeLifeInsurance model);
        void CreateEmployeeLifeInsuranceDetailDataDapper(HRMS_EmployeeLifeInsurance model);

        #endregion

        #region HRMS - Medical Insurance
        Task<IEnumerable<HRMS_EmployeeMedicalInsurance>> GetEmployeeMedicalInsuranceDetailDapper(
        int employeeId);
        void DeleteEmployeeMedicalInsuranceDetailDapper(HRMS_EmployeeMedicalInsurance model);
        void UpdateEmployeeMedicalInsuranceDetailDataDapper(HRMS_EmployeeMedicalInsurance model);
        void CreateEmployeeMedicalInsuranceDetailDataDapper(HRMS_EmployeeMedicalInsurance model);
        #endregion

        #region HRMS - Employee Provident Fund detail
        Task<IEnumerable<HRMS_EmployeeProvidentFund>> GetEmployeeProvidentFundDetailDapper(
         int employeeId);
        void DeleteEmployeeProvidentFundDetailDapper(HRMS_EmployeeProvidentFund model);
        void UpdateEmployeeProvidentFundDetailDataDapper(HRMS_EmployeeProvidentFund model);
        void CreateEmployeeProvidentFundDetailDataDapper(HRMS_EmployeeProvidentFund model);
        #endregion

        #region HRMS - Employee Personal Info
        Task<IEnumerable<HRMS_EmployeePersonalInfo>> GetEmployeePersonalInfoDetailDapper(
        int employeeId);
        void DeleteEmployeePersonalInfoDetailDapper(HRMS_EmployeePersonalInfo model);
        void UpdateEmployeePersonalInfoDetailDataDapper(HRMS_EmployeePersonalInfo model);
        void CreateEmployeePersonalInfoDetailDataDapper(HRMS_EmployeePersonalInfo model);
        #endregion

        #region HRMS - Employee Emergency contact Detail
        Task<IEnumerable<HRMS_EmployeeEmergencyContactDetail>> GetEmployeeEmergencyContactDetailDapper(
        int employeeId);
        void DeleteEmployeeEmergencyContactDetailDapper(
            HRMS_EmployeeEmergencyContactDetail model);

        void UpdateEmployeeEmergencyContactDetailDataDapper(
            HRMS_EmployeeEmergencyContactDetail model);

        void CreateEmployeeEmergencyContactDetailDataDapper(
            HRMS_EmployeeEmergencyContactDetail model);
        #endregion

        #region HRMS - Employee Family Member Info
        Task<IEnumerable<HRMS_EmployeeFamilyInformation>> GetEmployeeFamilyMemberInfoDapper(
          int employeeId);
        void DeleteEmployeeFamilyMemberInfoDapper(HRMS_EmployeeFamilyInformation model);
        void UpdateEmployeeFamilyMemberInfoDataDapper(HRMS_EmployeeFamilyInformation model);
        void CreateEmployeeFamilyMemberInfoDataDapper(HRMS_EmployeeFamilyInformation model);
        #endregion

        #region HRMS - Employee Benefits
        Task<IEnumerable<HRMS_EmployeeBenefits>> GetEmployeeBenefitsDapper(
          int employeeId);
        #endregion

        #region HRMS - Employee Benefits Mapping
        Task<IEnumerable<HRMS_EmployeeBenefitMapping>> GetEmployeeBenefitsMappingDapper(
        int employeeId);
        void CreateEmployeeBenefitsMappingDapper(
          List<HRMS_EmployeeBenefitMapping>  model);
        void DeleteEmployeeBenefitsMappingDapper(
            long employeeId);
        #endregion
    }

    public class HRMSDataDapperRepository : IHRMSDataDapperRepositor

    {
        private string connectionString = "";
      
        private readonly DapperManager dapperManager;


        public HRMSDataDapperRepository()
        {

            connectionString = GenericConstants.ConnectionStringDB2;
            dapperManager = new DapperManager(connectionString);
        }

        public IDbConnection _Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

        #region HRMS - Employee Screen
        public async Task<IEnumerable<Employee>> GetAllEmployees(int pagesize,int employeeId, int roleId)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@PageSize", pagesize);
            queryParameters.Add("@EmployeeId", employeeId);
            queryParameters.Add("@roleId", roleId);

            var spName = "usp_Employee_GetEmployee";

            Employee model = new Employee();
            IEnumerable<Employee> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }

        public async Task<Employee> GetAllEmployeeByEmployeeId(int employeeId)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@EmployeeId", employeeId);

            var spName = "usp_Employee_GetEmployeeByEmpId";

            Employee model = new Employee();
            Employee results = await dapperManager.QueryFirstOrDefault(model, spName, queryParameters);
            return results;

        }
        public async Task<IEnumerable<Employee>> GetAllEmployeeByDepartmentId(int departmentId)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@DepartmentId", departmentId);

            var spName = "usp_Employee_GetEmployeeByDepartmentId";

            Employee model = new Employee();
            IEnumerable<Employee>   results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }
        public async Task<Employee> GetProfilePictureByEmployeeId(int employeeId)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@EmployeeId", employeeId);

            var spName = "usp_Employee_GetEmployeeProfilePictureByEmpId";

            Employee model = new Employee();
            Employee results = await dapperManager.QueryFirstOrDefault(model, spName, queryParameters);
            return results;

        }
        public async Task<IEnumerable<HRMS_EmployeeDocuments>> GetDocumentByEmployeeId(int employeeId)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@EmployeeId", employeeId);

            var spName = "usp_Employee_GetEmployeeDocumentByEmpId";

            HRMS_EmployeeDocuments model = new HRMS_EmployeeDocuments();
            IEnumerable<HRMS_EmployeeDocuments> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }
        public async Task<IEnumerable<Location>> GetLocation()
        {
            var queryParameters = new DynamicParameters();

            var spName = "usp_Location_GetLocation";

            Location model = new Location();
            IEnumerable<Location> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }
        //public async Task<IEnumerable<Employee>> SearchAllEmployees(string employeeCode = null, string officialEmailAddress = null,int? groupId = 0)
        public async Task<IEnumerable<Employee>> SearchAllEmployees(SearchEmployee searchParam)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@EmployeeCode", searchParam.employeeCode);
            queryParameters.Add("@OfficialEmailAddress", searchParam.officialEmailAddress);
            //queryParameters.Add("@GroupId", searchParam.groupId);
            queryParameters.Add("@CompanyId", searchParam.CompanyId);
            queryParameters.Add("@LocationId", searchParam.LocationId);
            queryParameters.Add("@BusinessUnitId", searchParam.BusinessUnitId);
            queryParameters.Add("@DepartmentId", searchParam.DepartmentId);
            queryParameters.Add("@CampaignId", searchParam.CampaignId);
            queryParameters.Add("@CostCenterId", searchParam.CostCenterId);
            queryParameters.Add("@DesignationId", searchParam.DesignationId);
            queryParameters.Add("@FirstName", searchParam.FirstName);
            queryParameters.Add("@LastName", searchParam.LastName);
            queryParameters.Add("@JoiningDate", searchParam.JoiningDate);
            queryParameters.Add("@DateOfBirth", searchParam.DateOfBirth);
            queryParameters.Add("@Status", searchParam.Status);
           

            var spName = "usp_Employee_SearchEmployee";

            Employee model = new Employee();
            IEnumerable<Employee> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;
        }

        public async void CreateEmployeeDataDapper(Employee model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();

           
            queryParameters.Add("@CompanyId", model.CompanyId);
            queryParameters.Add("@LocationId", model.LocationId);
            queryParameters.Add("@DomainId", model.DomainId);
            queryParameters.Add("@BusinessUnitId", model.BusinessUnitId);
            queryParameters.Add("@DepartmentId", model.DepartmentId);
            queryParameters.Add("@CampaignId", model.CampaignId);
            queryParameters.Add("@JobcategoryId", model.JobCategoryId);
            queryParameters.Add("@DesignationId", model.DesignationId);
            queryParameters.Add("@CostCenterId", model.CostCenterId);
            queryParameters.Add("@FirstName", model.FirstName);
            queryParameters.Add("@CNIC", model.CNIC);
            queryParameters.Add("@MiddleName", model.MiddleName);
            queryParameters.Add("@LastName", model.LastName);
            queryParameters.Add("@DateOfBirth", model.DateOfBirth);
            queryParameters.Add("@GenderId", model.GenderId);
            queryParameters.Add("@StateId", model.StateId);
            queryParameters.Add("@FatherName", model.FatherName);
            queryParameters.Add("@JoiningDate", model.JoiningDate);
            queryParameters.Add("@PersonalEmailAddress", model.PersonalEmailAddress);
            queryParameters.Add("@OfficialEmailAddress", model.OfficialEmailAddress);


            queryParameters.Add("@CreatedBy", model.CreatedBy);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_Employee_CreateEmployee";

            dapperManager.InsertQuery(spName, queryParameters);
        }

        public async void UpdateEmployeePersonalInfoDataDapper(Employee model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();

            queryParameters.Add("@EmployeeId", model.EmployeeId);
            queryParameters.Add("@CompanyId", model.CompanyId);
            queryParameters.Add("@LocationId", model.LocationId);
            queryParameters.Add("@DomainId", model.DomainId);
            queryParameters.Add("@BusinessUnitId", model.BusinessUnitId);
            queryParameters.Add("@DepartmentId", model.DepartmentId);
            queryParameters.Add("@CampaignId", model.CampaignId);
            queryParameters.Add("@JobcategoryId", model.JobCategoryId);
            queryParameters.Add("@DesignationId", model.DesignationId);
            queryParameters.Add("@CostCenterId", model.CostCenterId);
            queryParameters.Add("@FirstName", model.FirstName);
            queryParameters.Add("@CNIC", model.CNIC);
            queryParameters.Add("@MiddleName", model.MiddleName);
            queryParameters.Add("@LastName", model.LastName);
            queryParameters.Add("@DateOfBirth", model.DateOfBirth);
            queryParameters.Add("@GenderId", model.GenderId);
            queryParameters.Add("@FatherName", model.FatherName);
            queryParameters.Add("@JoiningDate", model.JoiningDate);
            queryParameters.Add("@PersonalEmailAddress", model.PersonalEmailAddress);


          
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_Employee_UpdateEmployeePersonalInfo";

            dapperManager.UpdateRecord(spName, queryParameters);
        }

        public async void UpdateEmployeeDataDapper(EmployeePersonal model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();

            queryParameters.Add("@EmployeeId", model.EmployeeId);
            queryParameters.Add("@FirstName", model.FirstName);
            queryParameters.Add("@MiddleName", model.MiddleName);
            queryParameters.Add("@LastName", model.LastName);
            queryParameters.Add("@FatherName", model.FatherName);
            queryParameters.Add("@ReligionId", model.ReligionId);
            queryParameters.Add("@GenderId", model.GenderId);
            queryParameters.Add("@NationalityID", model.NationalityID);
            queryParameters.Add("@MatrialStatusId", model.MatrialStatusId);
            queryParameters.Add("@DateOfBirth", model.DateOfBirth);
            queryParameters.Add("@CountryOfBirthId", model.CountryOfBirthId);
            queryParameters.Add("@StateId", model.StateId);
            queryParameters.Add("@BirthPlace", model.BirthPlace);
            queryParameters.Add("@CNIC", model.CNIC);
            queryParameters.Add("@CNICIssueDate", model.CNICIssueDate);
            queryParameters.Add("@CNICExpiryDate", model.CNICExpiryDate);
            queryParameters.Add("@DrivingLicence", model.DrivingLicence);
            queryParameters.Add("@NTN", model.NTN);
            queryParameters.Add("@SSN", model.SSN);
           
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_Employee_UpdateEmployee";

            dapperManager.UpdateRecord(spName, queryParameters);
        }

        public async void UpdateEmployeeCompanyDetailDataDapper(EmployeeContactDetail model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();

            queryParameters.Add("@EmployeeId", model.EmployeeId);
            queryParameters.Add("@LocationId", model.LocationId);
            queryParameters.Add("@OfficeExtension", model.OfficeExtension);
            queryParameters.Add("@DesignationId", model.DesignationId);
            queryParameters.Add("@JobcategoryId", model.JobcategoryId);
            queryParameters.Add("@BusinessUnitId", model.BusinessUnitId);
            queryParameters.Add("@DepartmentId", model.DepartmentId);
            queryParameters.Add("@CampaignId", model.CampaignId);
            queryParameters.Add("@CostCenterId", model.CostCenterId);
            queryParameters.Add("@EmployeeTypeId", model.EmployeeTypeId);
            queryParameters.Add("@TMSShiftId", model.TMSShiftId);
            queryParameters.Add("@LeaveTypeId", model.LeaveTypeId);
            queryParameters.Add("@JoiningDate", model.JoiningDate);
            queryParameters.Add("@ConfirmationDate", model.ConfirmationDate);
            queryParameters.Add("@PriodEndDate", model.PriodEndDate);
            queryParameters.Add("@ProbationEndDate", model.ProbationEndDate);
            queryParameters.Add("@ProbationPeriodDays", model.ProbationPeriodDays);
            queryParameters.Add("@ContractStartDate", model.ContractStartDate);
            queryParameters.Add("@ContractEndDate", model.ContractEndDate);
            queryParameters.Add("@HODCompanyId", model.HODCompanyId);
            queryParameters.Add("@HODJobCategoryId", model.HODJobCategoryId);
            queryParameters.Add("@HODDesignationId", model.HODDesignationId);
            queryParameters.Add("@HODNameId", model.HODNameId);
            queryParameters.Add("@ManagerCompanyId", model.ManagerCompanyId);
            queryParameters.Add("@ManagerJobCategoryId", model.ManagerJobCategoryId);
            queryParameters.Add("@ManagerDesignationId", model.ManagerDesignationId);
            queryParameters.Add("@ManagerNameId", model.ManagerNameId);
            queryParameters.Add("@InChargeCompanyId", model.InChargeCompanyId);
            queryParameters.Add("@InChargeJobCategoryId", model.InChargeJobCategoryId);
            queryParameters.Add("@InChargeDesignationId", model.InChargeDesignationId);
            queryParameters.Add("@InChargeNameId", model.InChargeNameId);
            

            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_Employee_UpdateEmployeeContactDetail";

            dapperManager.UpdateRecord(spName, queryParameters);
        }

        public async void UpdateEmployeePersonalityDetailDataDapper(Employee model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();

            queryParameters.Add("@EmployeeId", model.EmployeeId);
            queryParameters.Add("@PersonalityDescription", model.PersonalityDescription);
         
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_Employee_UpdateEmployeePersonalityDetail";

            dapperManager.UpdateRecord(spName, queryParameters);
        }

        public async void UpdateEmployeeProfilePictureDataDapper(int employeeId  ,string pictureName)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();

            queryParameters.Add("@EmployeeId", employeeId);
            queryParameters.Add("@PictureName", pictureName);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_Employee_UpdateEmployeProfilePicture";

            dapperManager.UpdateRecord(spName, queryParameters);
        }
        #endregion

        #region HRMS - Employee Academic
        public async Task<IEnumerable<HRMS_EmployeeEducation>>  GetEmployeeEducationByEmployeeIdDapper(int employeeId)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@EmployeeId", employeeId);

            var spName = "usp_Employee_GetEmployeeEducationByEmployeeId";


            HRMS_EmployeeEducation model = new HRMS_EmployeeEducation();
            IEnumerable<HRMS_EmployeeEducation> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }
        public async void DeleteEmployeeEducationDapper(HRMS_EmployeeEducation model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@EmployeeEducationId", model.EmployeeEducationId);
            queryParameters.Add("@UserIp", UserIP);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);

            var spName = "usp_EmployeeEducation_DeleteEmployeeEducation";

            dapperManager.UpdateRecord(spName, queryParameters);
        }

        public async void UpdateEmployeeEducationDataDapper(HRMS_EmployeeEducation model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@EmployeeEducationId", model.EmployeeEducationId);
            queryParameters.Add("@EducationTypeId", model.EducationTypeId);
            queryParameters.Add("@Institution", model.Institution);
            queryParameters.Add("@Degree", model.Degree);
            queryParameters.Add("@Percentage", model.Percentage);
            queryParameters.Add("@EducationScoreId", model.EducationScoreId);
            queryParameters.Add("@EducationStatusId", model.EducationStatusId);
            queryParameters.Add("@CountryId", model.CountryId);
            queryParameters.Add("@FromDate", model.FromDate);
            queryParameters.Add("@ToDate", model.ToDate);

            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_EmployeeEducation_UpdateEmployeeEducation";

            dapperManager.UpdateRecord(spName, queryParameters);
        }

        public async void CreateEmployeeEducationDataDapper(HRMS_EmployeeEducation model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();

            queryParameters.Add("@EducationTypeId", model.EducationTypeId);
            queryParameters.Add("@EmployeeId", model.EmployeeId);
            queryParameters.Add("@Institution", model.Institution);
            queryParameters.Add("@Degree", model.Degree);
            queryParameters.Add("@Percentage", model.Percentage);
            queryParameters.Add("@EducationScoreId", model.EducationScoreId);
            queryParameters.Add("@EducationStatusId", model.EducationStatusId);
            queryParameters.Add("@CountryId", model.CountryId);
            queryParameters.Add("@FromDate", model.FromDate);
            queryParameters.Add("@ToDate", model.ToDate);

            queryParameters.Add("@CreatedBy", model.CreatedBy);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_EmployeeEducation_CreateEmployeeEducation";

            dapperManager.InsertQuery(spName, queryParameters);
        }
        #endregion

        #region HRMS - Experience Screen
        public async Task<IEnumerable<HRMS_EmployeeExperience>> GetEmployeeExperienceByEmployeeIdDapper(int employeeId)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@EmployeeId", employeeId);

            var spName = "usp_Employee_GetEmployeeExperienceByEmployeeId";


            HRMS_EmployeeExperience model = new HRMS_EmployeeExperience();
            IEnumerable<HRMS_EmployeeExperience> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }
        public async void DeleteEmployeeExperienceDapper(HRMS_EmployeeExperience model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@EmployeeExperienceId", model.EmployeeExperienceId);
            queryParameters.Add("@UserIp", UserIP);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);

            var spName = "usp_EmployeeExperience_DeleteEmployeeExperience";

            dapperManager.UpdateRecord(spName, queryParameters);
        }

        public async void UpdateEmployeeExperienceDataDapper(HRMS_EmployeeExperience model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@EmployeeExperienceId", model.EmployeeExperienceId);
            queryParameters.Add("@EmployeeId", model.EmployeeId);
            queryParameters.Add("@CompanyName", model.CompanyName);
            queryParameters.Add("@Address", model.Address);
            queryParameters.Add("@Designation", model.Designation);
            queryParameters.Add("@JobResponsibility", model.JobResponsibility);
            queryParameters.Add("@Accomplishments", model.Accomplishments);
            queryParameters.Add("@InitialSalary", model.InitialSalary);
            queryParameters.Add("@InitialSalaryCurrencyId", model.InitialSalaryCurrencyId);
            queryParameters.Add("@LastSalary", model.LastSalary);
            queryParameters.Add("@LastSalaryCurrencyId", model.LastSalaryCurrencyId);
            queryParameters.Add("@ReasonForLeaving", model.ReasonForLeaving);
            queryParameters.Add("@TenureFrom", model.TenureFrom);
            queryParameters.Add("@TenureTo", model.TenureTo);
            queryParameters.Add("@IsStillEmployeed", model.IsStillEmployeed);


            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_EmployeeExperience_UpdateEmployeeExperience";

            dapperManager.UpdateRecord(spName, queryParameters);
        }

        public async void CreateEmployeeExperienceDataDapper(HRMS_EmployeeExperience model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();

            queryParameters.Add("@EmployeeId", model.EmployeeId);
            queryParameters.Add("@CompanyName", model.CompanyName);
            queryParameters.Add("@Address", model.Address);
            queryParameters.Add("@Designation", model.Designation);
            queryParameters.Add("@JobResponsibility", model.JobResponsibility);
            queryParameters.Add("@Accomplishments", model.Accomplishments);
            queryParameters.Add("@InitialSalary", model.InitialSalary);
            queryParameters.Add("@InitialSalaryCurrencyId", model.InitialSalaryCurrencyId);
            queryParameters.Add("@LastSalary", model.LastSalary);
            queryParameters.Add("@LastSalaryCurrencyId", model.LastSalaryCurrencyId);
            queryParameters.Add("@ReasonForLeaving", model.ReasonForLeaving);
            queryParameters.Add("@TenureFrom", model.TenureFrom);
            queryParameters.Add("@TenureTo", model.TenureTo);
            queryParameters.Add("@IsStillEmployeed", model.IsStillEmployeed);


            queryParameters.Add("@CreatedBy", model.CreatedBy);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_EmployeeExperience_CreateEmployeeExperience";

            dapperManager.InsertQuery(spName, queryParameters);
        }
        #endregion

        #region HRMS - Professional Reference Screen
        public async Task<IEnumerable<HRMS_EmployeeProfessionalReference>> GetEmployeeProfessionalReferenceByEmployeeIdDapper(
            int employeeId)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@EmployeeId", employeeId);

            var spName = "usp_Employee_GetEmployeeProfessionalReferenceByEmployeeId";


            HRMS_EmployeeProfessionalReference model = new HRMS_EmployeeProfessionalReference();
            IEnumerable<HRMS_EmployeeProfessionalReference> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }

        public async void DeleteEmployeeProfessionalReferenceDapper(HRMS_EmployeeProfessionalReference model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@ProfessionalReferenceId", model.ProfessionalReferenceId);
            queryParameters.Add("@UserIp", UserIP);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);

            var spName = "usp_EmployeeReference_DeleteEmployeeProfessionalReference";

            dapperManager.UpdateRecord(spName, queryParameters);
        }

        public async void UpdateEmployeeProfessionalReferenceDataDapper(HRMS_EmployeeProfessionalReference model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@ProfessionalReferenceId", model.ProfessionalReferenceId);
            queryParameters.Add("@EmployeeId", model.EmployeeId);
            queryParameters.Add("@Name", model.Name);
            queryParameters.Add("@Address", model.Address);
            queryParameters.Add("@Instituation", model.Instituation);
            queryParameters.Add("@Address", model.Address);
            queryParameters.Add("@Phone", model.Phone);
            queryParameters.Add("@OfficialEmailAddress", model.OfficialEmailAddress);
           
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_EmployeeReference_UpdateEmployeeProfessionalReference";

            dapperManager.UpdateRecord(spName, queryParameters);
        }

        public async void CreateEmployeeProfessionalReferenceDataDapper(HRMS_EmployeeProfessionalReference model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();

            queryParameters.Add("@EmployeeId", model.EmployeeId);
            queryParameters.Add("@Name", model.Name);
            queryParameters.Add("@Instituation", model.Instituation);
            queryParameters.Add("@Address", model.Address);
            queryParameters.Add("@Phone", model.Phone);
            queryParameters.Add("@OfficialEmailAddress", model.OfficialEmailAddress);
          
            queryParameters.Add("@CreatedBy", model.CreatedBy);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_Employee_CreateEmployeeProfessionalReference";

            dapperManager.InsertQuery(spName, queryParameters);
        }

        #endregion

        #region HRMS - Professional Document Attachment
        public async Task<IEnumerable<HRMS_EmployeeDocuments>> GetEmployeeDocumentByEmployeeIdDapper(
          int employeeId)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@EmployeeId", employeeId);

            var spName = "usp_Employee_GetEmployeeDocumentsByEmployeeId";

            HRMS_EmployeeDocuments model = new HRMS_EmployeeDocuments();
            IEnumerable<HRMS_EmployeeDocuments> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }
        public async void DeleteEmployeeDocumentsDapper(
            HRMS_EmployeeDocuments model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@EmployeeDocumentId", model.EmployeeDocumentId);
            queryParameters.Add("@UserIp", UserIP);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);

            var spName = "usp_Employee_DeleteEmployeeDocuments";

            dapperManager.UpdateRecord(spName, queryParameters);
        }

        public async void UpdateEmployeeDocumentDataDapper(
            HRMS_EmployeeDocuments model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@EmployeeDocumentId", model.EmployeeDocumentId);
            queryParameters.Add("@EmployeeId", model.EmployeeId);
            queryParameters.Add("@FileName", model.FileName);
            queryParameters.Add("@FileComments", model.FileComments);
            queryParameters.Add("@FileType", model.FileType);
            queryParameters.Add("@FileOriginalName", model.FileOriginalName);
           
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_Employee_UpdateEmployeeDocuments";

            dapperManager.UpdateRecord(spName, queryParameters);
        }

        public async void CreateEmployeeDocumentsDataDapper(
            HRMS_EmployeeDocuments model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();

            queryParameters.Add("@EmployeeId", model.EmployeeId);
            queryParameters.Add("@FileName", model.FileName);
            queryParameters.Add("@FileComments", model.FileComments);
            queryParameters.Add("@FileType", model.FileType);
            queryParameters.Add("@FileOriginalName", model.FileOriginalName);
           
            queryParameters.Add("@CreatedBy", model.CreatedBy);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_Employee_CreateEmployeeDocuments";

            dapperManager.InsertQuery(spName, queryParameters);
        }



        public async void UpdateEmployeeDocumentDataDapper(int employeeId, string fileName)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();

            queryParameters.Add("@EmployeeId", employeeId);
            queryParameters.Add("@FileName", fileName);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_Employee_UpdateDocument";

            dapperManager.UpdateRecord(spName, queryParameters);
        }
        #endregion

        #region HRMS - Employee Bank Detail
        public async Task<IEnumerable<HRMS_EmployeeBankDetails>> GetEmployeeBankDetailDapper(
          int employeeId)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@EmployeeId", employeeId);

            var spName = "usp_Employee_GetEmployeeBankDetail";


            HRMS_EmployeeBankDetails model = new HRMS_EmployeeBankDetails();
            IEnumerable<HRMS_EmployeeBankDetails> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }

        public async void DeleteEmployeeBankDetailDapper(HRMS_EmployeeBankDetails model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@BankDetailId", model.BankDetailId);
            queryParameters.Add("@UserIp", UserIP);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);

            var spName = "usp_Employee_DeleteEmployeeBankDetail";

            dapperManager.UpdateRecord(spName, queryParameters);
        }

        public async void UpdateEmployeeBankDetailDataDapper(HRMS_EmployeeBankDetails model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@BankDetailId", model.BankDetailId);
            queryParameters.Add("@EmployeeId", model.EmployeeId);
            queryParameters.Add("@BankName", model.BankName);
            queryParameters.Add("@AccountNo", model.AccountNo);
            queryParameters.Add("@DefaultBank", model.DefaultBank);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_Employee_UpdateEmployeeBankDetail";

            dapperManager.UpdateRecord(spName, queryParameters);
        }

        public async void CreateEmployeeBankDetailDataDapper(HRMS_EmployeeBankDetails model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();

            queryParameters.Add("@EmployeeId", model.EmployeeId);
            queryParameters.Add("@BankName", model.BankName);
            queryParameters.Add("@AccountNo", model.AccountNo);
            queryParameters.Add("@DefaultBank", model.DefaultBank);
           

            queryParameters.Add("@CreatedBy", model.CreatedBy);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_Employee_CreateEmployeeBankDetail";

            dapperManager.InsertQuery(spName, queryParameters);
        }
        #endregion

        #region HRMS - Employee Life Insurance Details
        public async Task<IEnumerable<Employee>> GetWitnessDapper()
        {
            var queryParameters = new DynamicParameters();

            var spName = "usp_HR_Get_Witness";

            Employee model = new Employee();
            IEnumerable<Employee> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }
        public async Task<IEnumerable<HRMS_EmployeeLifeInsurance>> GetEmployeeLifeInsuranceDetailDapper(
         int employeeId)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@EmployeeId", employeeId);

            var spName = "usp_Employee_GetEmployeeLifeInsuranceDetail";


            HRMS_EmployeeLifeInsurance model = new HRMS_EmployeeLifeInsurance();
            IEnumerable<HRMS_EmployeeLifeInsurance> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }

        public async void DeleteEmployeeLifeInsuranceDetailDapper(HRMS_EmployeeLifeInsurance model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@LifeInsuranceDetailId", model.LifeInsuranceDetailId);
            queryParameters.Add("@UserIp", UserIP);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);

            var spName = "usp_Employee_DeleteEmployeeLifeInsuranceDetail";

            dapperManager.UpdateRecord(spName, queryParameters);
        }

        public async void UpdateEmployeeLifeInsuranceDetailDataDapper(HRMS_EmployeeLifeInsurance model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@LifeInsuranceDetailId", model.LifeInsuranceDetailId);
            queryParameters.Add("@EmployeeId", model.EmployeeId);
            queryParameters.Add("@NomineeName", model.NomineeName);
            queryParameters.Add("@NomineeCNIC", model.NomineeCNIC);
            queryParameters.Add("@RelationshipId", model.RelationshipId);
            queryParameters.Add("@Percentage", model.Percentage);
            queryParameters.Add("@IsMinor", model.IsMinor);
            queryParameters.Add("@WitnessId", model.WitnessId);
            queryParameters.Add("@NomineeMinorAddress", model.NomineeMinorAddress);
            queryParameters.Add("@NomineeNameForMinor", model.NomineeNameForMinor);
            queryParameters.Add("@NomineeAgeForMinor", model.NomineeAgeForMinor);
            queryParameters.Add("@NomineeAddress", model.NomineeAddress);

            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_Employee_UpdateEmployeeLifeInsuranceDetail";

            dapperManager.UpdateRecord(spName, queryParameters);
        }

        public async void CreateEmployeeLifeInsuranceDetailDataDapper(HRMS_EmployeeLifeInsurance model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();

            queryParameters.Add("@EmployeeId", model.EmployeeId);
            queryParameters.Add("@NomineeName", model.NomineeName);
            queryParameters.Add("@NomineeCNIC", model.NomineeCNIC);
            queryParameters.Add("@RelationshipId", model.RelationshipId);
            queryParameters.Add("@Percentage", model.Percentage);
            queryParameters.Add("@IsMinor", model.IsMinor);
            queryParameters.Add("@WitnessId", model.WitnessId);
            queryParameters.Add("@NomineeMinorAddress", model.NomineeMinorAddress);
            queryParameters.Add("@NomineeNameForMinor", model.NomineeNameForMinor);
            queryParameters.Add("@NomineeAgeForMinor", model.NomineeAgeForMinor);
            queryParameters.Add("@NomineeAddress", model.NomineeAddress);


            queryParameters.Add("@CreatedBy", model.CreatedBy);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_Employee_CreateEmployeeLifeInsuranceDetail";

            dapperManager.InsertQuery(spName, queryParameters);
        }
        #endregion

        #region HRMS - Employee Medical Insurance Details
        public async Task<IEnumerable<HRMS_EmployeeMedicalInsurance>> GetEmployeeMedicalInsuranceDetailDapper(
        int employeeId)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@EmployeeId", employeeId);

            var spName = "usp_Employee_GetEmployeeMedicalInsuranceDetail";


            HRMS_EmployeeMedicalInsurance model = new HRMS_EmployeeMedicalInsurance();
            IEnumerable<HRMS_EmployeeMedicalInsurance> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }

        public async void DeleteEmployeeMedicalInsuranceDetailDapper(HRMS_EmployeeMedicalInsurance model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@MedicalInsuranceDetailId", model.MedicalInsuranceDetailId);
            queryParameters.Add("@UserIp", UserIP);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);

            var spName = "usp_Employee_DeleteEmployeeMedicalInsuranceDetail";

            dapperManager.UpdateRecord(spName, queryParameters);
        }

        public async void UpdateEmployeeMedicalInsuranceDetailDataDapper(HRMS_EmployeeMedicalInsurance model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@MedicalInsuranceDetailId", model.MedicalInsuranceDetailId);
            queryParameters.Add("@EmployeeId", model.EmployeeId);
            queryParameters.Add("@Name", model.Name);
            queryParameters.Add("@CNIC", model.CNIC);
            queryParameters.Add("@RelationshipId", model.RelationshipId);
            queryParameters.Add("@DOB", model.DOB);
            queryParameters.Add("@Occupation", model.Occupation);

            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_Employee_UpdateEmployeeMedicalInsuranceDetail";

            dapperManager.UpdateRecord(spName, queryParameters);
        }

        public async void CreateEmployeeMedicalInsuranceDetailDataDapper(HRMS_EmployeeMedicalInsurance model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();

            queryParameters.Add("@EmployeeId", model.EmployeeId);
            queryParameters.Add("@Name", model.Name);
            queryParameters.Add("@CNIC", model.CNIC);
            queryParameters.Add("@RelationshipId", model.RelationshipId);
            queryParameters.Add("@DOB", model.DOB);
            queryParameters.Add("@Occupation", model.Occupation);


            queryParameters.Add("@CreatedBy", model.CreatedBy);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_Employee_CreateEmployeeMedicalInsuranceDetail";

            dapperManager.InsertQuery(spName, queryParameters);
        }
        #endregion

        #region HRMS - Employee Provident Fund Details
       
        public async Task<IEnumerable<HRMS_EmployeeProvidentFund>> GetEmployeeProvidentFundDetailDapper(
         int employeeId)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@EmployeeId", employeeId);

            var spName = "usp_Employee_GetEmployeeProvidentFundDetail";


            HRMS_EmployeeProvidentFund model = new HRMS_EmployeeProvidentFund();
            IEnumerable<HRMS_EmployeeProvidentFund> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }

        public async void DeleteEmployeeProvidentFundDetailDapper(HRMS_EmployeeProvidentFund model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@ProvidentFundDetailId", model.ProvidentFundDetailId);
            queryParameters.Add("@UserIp", UserIP);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);

            var spName = "usp_Employee_DeleteEmployeeProvidentFundDetail";

            dapperManager.UpdateRecord(spName, queryParameters);
        }

        public async void UpdateEmployeeProvidentFundDetailDataDapper(HRMS_EmployeeProvidentFund model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@ProvidentFundDetailId", model.ProvidentFundDetailId);
            queryParameters.Add("@EmployeeId", model.EmployeeId);
            queryParameters.Add("@NomineeName", model.NomineeName);
            queryParameters.Add("@NomineeCNIC", model.NomineeCNIC);
            queryParameters.Add("@RelationshipId", model.RelationshipId);
            queryParameters.Add("@Percentage", model.Percentage);
            queryParameters.Add("@IsMinor", model.IsMinor);
            queryParameters.Add("@WitnessId", model.WitnessId);
            queryParameters.Add("@NomineeMinorAddress", model.NomineeMinorAddress);
            queryParameters.Add("@NomineeNameForMinor", model.NomineeNameForMinor);
            queryParameters.Add("@NomineeAgeForMinor", model.NomineeAgeForMinor);
            queryParameters.Add("@NomineeAddress", model.NomineeAddress);

            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_Employee_UpdateEmployeeProvidentFundDetail";

            dapperManager.UpdateRecord(spName, queryParameters);
        }

        public async void CreateEmployeeProvidentFundDetailDataDapper(HRMS_EmployeeProvidentFund model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();

            queryParameters.Add("@EmployeeId", model.EmployeeId);
            queryParameters.Add("@NomineeName", model.NomineeName);
            queryParameters.Add("@NomineeCNIC", model.NomineeCNIC);
            queryParameters.Add("@RelationshipId", model.RelationshipId);
            queryParameters.Add("@Percentage", model.Percentage);
            queryParameters.Add("@IsMinor", model.IsMinor);
            queryParameters.Add("@WitnessId", model.WitnessId);
            queryParameters.Add("@NomineeMinorAddress", model.NomineeMinorAddress);
            queryParameters.Add("@NomineeNameForMinor", model.NomineeNameForMinor);
            queryParameters.Add("@NomineeAgeForMinor", model.NomineeAgeForMinor);
            queryParameters.Add("@NomineeAddress", model.NomineeAddress);


            queryParameters.Add("@CreatedBy", model.CreatedBy);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_Employee_CreateEmployeeProvidentFundDetail";

            dapperManager.InsertQuery(spName, queryParameters);
        }
        #endregion

        #region HRMS - Employee Personal Info

        public async Task<IEnumerable<HRMS_EmployeePersonalInfo>> GetEmployeePersonalInfoDetailDapper(
         int employeeId)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@EmployeeId", employeeId);

            var spName = "usp_Employee_GetEmployeePersonalInfo";


            HRMS_EmployeePersonalInfo model = new HRMS_EmployeePersonalInfo();
            IEnumerable<HRMS_EmployeePersonalInfo> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }

        public async void DeleteEmployeePersonalInfoDetailDapper(HRMS_EmployeePersonalInfo model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@PersonalContactDetailId", model.PersonalContactDetailId);
            queryParameters.Add("@UserIp", UserIP);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);

            var spName = "usp_Employee_DeleteEmployeePersonalInfo";

            dapperManager.UpdateRecord(spName, queryParameters);
        }

        public async void UpdateEmployeePersonalInfoDetailDataDapper(HRMS_EmployeePersonalInfo model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@PersonalContactDetailId", model.PersonalContactDetailId);
            queryParameters.Add("@EmployeeId", model.EmployeeId);
            queryParameters.Add("@OfficeEmail", model.OfficeEmail);
            queryParameters.Add("@PersonalEmail", model.PersonalEmail);
            queryParameters.Add("@HomePhone", model.HomePhone);
            queryParameters.Add("@MobilePhone", model.MobilePhone);
            queryParameters.Add("@OfficeMobileNo", model.OfficeMobileNo);
            queryParameters.Add("@CountryId", model.CountryId);
            queryParameters.Add("@StateId", model.StateId);
            queryParameters.Add("@CityId", model.CityId);
            queryParameters.Add("@PermanentAddress", model.PermanentAddress);
            queryParameters.Add("@PresentAddress", model.PresentAddress);
           
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_Employee_UpdateEmployeePersoanlInfo";

            dapperManager.UpdateRecord(spName, queryParameters);
        }

        public async void CreateEmployeePersonalInfoDetailDataDapper(HRMS_EmployeePersonalInfo model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();

            queryParameters.Add("@EmployeeId", model.EmployeeId);
            queryParameters.Add("@OfficeEmail", model.OfficeEmail);
            queryParameters.Add("@PersonalEmail", model.PersonalEmail);
            queryParameters.Add("@HomePhone", model.HomePhone);
            queryParameters.Add("@MobilePhone", model.MobilePhone);
            queryParameters.Add("@OfficeMobileNo", model.OfficeMobileNo);
            queryParameters.Add("@CountryId", model.CountryId);
            queryParameters.Add("@StateId", model.StateId);
            queryParameters.Add("@CityId", model.CityId);
            queryParameters.Add("@PermanentAddress", model.PermanentAddress);
            queryParameters.Add("@PresentAddress", model.PresentAddress);
          

            queryParameters.Add("@CreatedBy", model.CreatedBy);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_Employee_CreateEmployeePersonalInfo";

            dapperManager.InsertQuery(spName, queryParameters);
        }
        #endregion

        #region HRMS - Employee Emergency Contact Detail

        public async Task<IEnumerable<HRMS_EmployeeEmergencyContactDetail>> GetEmployeeEmergencyContactDetailDapper(
         int employeeId)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@EmployeeId", employeeId);

            var spName = "usp_Employee_GetEmployeeEmergencyContactDetail";


            HRMS_EmployeeEmergencyContactDetail model = new HRMS_EmployeeEmergencyContactDetail();
            IEnumerable<HRMS_EmployeeEmergencyContactDetail> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }

        public async void DeleteEmployeeEmergencyContactDetailDapper(HRMS_EmployeeEmergencyContactDetail model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@EmergencyContactDetailId", model.EmergencyContactDetailId);
            queryParameters.Add("@UserIp", UserIP);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);

            var spName = "usp_Employee_DeleteEmployeeEmergencyContactDetail";

            dapperManager.UpdateRecord(spName, queryParameters);
        }

        public async void UpdateEmployeeEmergencyContactDetailDataDapper(HRMS_EmployeeEmergencyContactDetail model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@EmergencyContactDetailId", model.EmergencyContactDetailId);
            queryParameters.Add("@EmployeeId", model.EmployeeId);
            queryParameters.Add("@FirstName", model.FirstName);
            queryParameters.Add("@LastName", model.LastName);
            queryParameters.Add("@PhoneNo", model.PhoneNo);
            queryParameters.Add("@CellNo", model.CellNo);
            queryParameters.Add("@RelationshipId", model.RelationshipId);
            queryParameters.Add("@CountryId", model.CountryId);
            queryParameters.Add("@StateId", model.StateId);
            queryParameters.Add("@CityId", model.CityId);
            queryParameters.Add("@EmailAddress", model.EmailAddress);
            queryParameters.Add("@Address", model.Address);

            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_Employee_UpdateEmployeeEmergencyContactDetail";

            dapperManager.UpdateRecord(spName, queryParameters);
        }

        public async void CreateEmployeeEmergencyContactDetailDataDapper(HRMS_EmployeeEmergencyContactDetail model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();

            queryParameters.Add("@EmployeeId", model.EmployeeId);
            queryParameters.Add("@FirstName", model.FirstName);
            queryParameters.Add("@LastName", model.LastName);
            queryParameters.Add("@PhoneNo", model.PhoneNo);
            queryParameters.Add("@CellNo", model.CellNo);
            queryParameters.Add("@RelationshipId", model.RelationshipId);
            queryParameters.Add("@CountryId", model.CountryId);
            queryParameters.Add("@StateId", model.StateId);
            queryParameters.Add("@CityId", model.CityId);
            queryParameters.Add("@EmailAddress", model.EmailAddress);
            queryParameters.Add("@Address", model.Address);


            queryParameters.Add("@CreatedBy", model.CreatedBy);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_Employee_CreateEmployeeEmergencyContactDetail";

            dapperManager.InsertQuery(spName, queryParameters);
        }
        #endregion


        #region HRMS - Family Member Information

        public async Task<IEnumerable<HRMS_EmployeeFamilyInformation>> GetEmployeeFamilyMemberInfoDapper(
         int employeeId)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@EmployeeId", employeeId);

            var spName = "usp_Employee_GetEmployeeFamilyMemberInfo";


            HRMS_EmployeeFamilyInformation model = new HRMS_EmployeeFamilyInformation();
            IEnumerable<HRMS_EmployeeFamilyInformation> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }

        public async void DeleteEmployeeFamilyMemberInfoDapper(HRMS_EmployeeFamilyInformation model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@FamilyMemberInfoId", model.FamilyMemberInfoId);
            queryParameters.Add("@UserIp", UserIP);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);

            var spName = "usp_Employee_DeleteEmployeeFamilyMemberInfo";

            dapperManager.UpdateRecord(spName, queryParameters);
        }

        public async void UpdateEmployeeFamilyMemberInfoDataDapper(HRMS_EmployeeFamilyInformation model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@FamilyMemberInfoId", model.FamilyMemberInfoId);
            queryParameters.Add("@EmployeeId", model.EmployeeId);
            queryParameters.Add("@Name", model.Name);
            queryParameters.Add("@RelationshipId", model.RelationshipId);
            queryParameters.Add("@DOB", model.DOB);
            queryParameters.Add("@QualificationId", model.QualificationId);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_Employee_UpdateEmployeeFamilyMemberInfo";

            dapperManager.UpdateRecord(spName, queryParameters);
        }

        public async void CreateEmployeeFamilyMemberInfoDataDapper(HRMS_EmployeeFamilyInformation model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();

            queryParameters.Add("@EmployeeId", model.EmployeeId);
            queryParameters.Add("@Name", model.Name);
            queryParameters.Add("@RelationshipId", model.RelationshipId);
            queryParameters.Add("@DOB", model.DOB);
            queryParameters.Add("@QualificationId", model.QualificationId);
            
            queryParameters.Add("@CreatedBy", model.CreatedBy);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_Employee_CreateEmployeeFamilyMemberInfo";

            dapperManager.InsertQuery(spName, queryParameters);
        }
        #endregion

        #region HRMS - Employee Benefits
        public async Task<IEnumerable<HRMS_EmployeeBenefits>> GetEmployeeBenefitsDapper(
         int employeeId)
        {
            List<HRMS_EmployeeBenefits> nodes = new List<HRMS_EmployeeBenefits>();
            HRMS_EmployeeBenefits parent = new HRMS_EmployeeBenefits();
            HRMS_EmployeeBenefits model = new HRMS_EmployeeBenefits();

           

            //Main Benefit

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@EmployeeId", employeeId);

            var spName = "usp_Employee_GetEmployeeBenefits";
           
            IEnumerable<HRMS_EmployeeBenefits> resultsBenefits = await dapperManager.QueryList(model, spName, queryParameters);
            foreach (HRMS_EmployeeBenefits type in resultsBenefits)
            {
                //Mapping
                var queryParamMapping = new DynamicParameters();
                queryParamMapping.Add("@EmployeeId", employeeId);
                queryParamMapping.Add("@BenefitId", type.BenefitId);
                
                var spMapping = "usp_Employee_GetEmployeeBenefitsMapping";
                HRMS_EmployeeBenefits results = await dapperManager.QueryFirstOrDefault(model, spMapping, queryParamMapping);
                if (results != null)
                {
                    parent = new HRMS_EmployeeBenefits() { BenefitId = type.BenefitId,EmployeeId = type.EmployeeId , GrossSalary = results.GrossSalary, BenefitName = type.BenefitName, Checked = true };
                    //Get Child Node Name from Below Line
                    nodes.Add(parent);
                }
                else
                {
                    parent = new HRMS_EmployeeBenefits() { BenefitId = type.BenefitId, EmployeeId = type.EmployeeId, GrossSalary = type.GrossSalary, BenefitName = type.BenefitName, Checked = false };
                    //Get Child Node Name from Below Line
                    nodes.Add(parent);
                }


            }
            return nodes.Distinct().ToList();

        }
        #endregion

        #region HRMS - Employee Benefits Mapping
        public async Task<IEnumerable<HRMS_EmployeeBenefitMapping>> GetEmployeeBenefitsMappingDapper(
        int employeeId)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@EmployeeId", employeeId);

            var spName = "usp_Employee_GetEmployeeBenefitsMapping";


            HRMS_EmployeeBenefitMapping model = new HRMS_EmployeeBenefitMapping();
            IEnumerable<HRMS_EmployeeBenefitMapping> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }
        public async void CreateEmployeeBenefitsMappingDapper(List<HRMS_EmployeeBenefitMapping> model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            foreach (var item in model) // Loop through List with foreach
            {
                if (item.Checked == true)
                {
                    queryParameters.Add("@EmployeeId", item.EmployeeId);
                    queryParameters.Add("@BenefitId", item.BenefitId);
                    queryParameters.Add("@GrossSalary", item.GrossSalary);

                    queryParameters.Add("@CreatedBy", item.CreatedBy);
                    queryParameters.Add("@ModifiedBy", item.ModifiedBy);
                    queryParameters.Add("@UserIP", UserIP);
                    var spName = "usp_Employee_CreateEmployeeBenefitsMapping";

                    dapperManager.InsertQuery(spName, queryParameters);
                }
            }
               
           

           

           
        }
        public async void DeleteEmployeeBenefitsMappingDapper(long employeeId)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@EmployeeId", employeeId);

            var spName = "usp_Employee_DeleteEmployeeBenefitMapping";

            dapperManager.UpdateRecord(spName, queryParameters);
        }
        #endregion

    
    }
}

