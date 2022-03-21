using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Core.Model;
using ERP.Data.DataRepository.HomeDataDapperRepository;
using ERP.Data.DataRepository.SecurityDataDapperRepositor;

namespace ERP.Application.Repositories.SecuritySetupService
{
    public interface IHRMSSetupService
    {
      

        #region Employee Screen
        Task<IEnumerable<Employee>> GetAllEmployeesService(int pagesize, int employeeId,int roleId);
        Task<Employee> GetAllEmployeeByEmployeeIdService(int employeeId);
        Task<IEnumerable<Employee>> GetAllEmployeeByDepartmentIdService(
            int departmentId);
        Task<Employee> GetProfilePictureByEmployeeIdService(int employeeId);
        Task<IEnumerable<HRMS_EmployeeDocuments>> GetDocumentByEmployeeIdService(int employeeId);
        Task<IEnumerable<Employee>> SearchAllEmployeesService(
            SearchEmployee searchParam);

        void CreateEmployeeService(Employee model);
        void UpdateEmployeePersonalInfoService(Employee model);
        void UpdateEmployeeService(EmployeePersonal model);
        void UpdateEmployeeContactDetailService(EmployeeContactDetail model);
        Task<IEnumerable<Location>> GetLocationService();
        Task<IEnumerable<HRMS_EmployeeEducation>> GetEmployeeEducationByEmployeeIdService(
            int employeeId);

        void DeleteEmployeeEducationService(HRMS_EmployeeEducation model);

        void UpdateEmployeeEducationService(HRMS_EmployeeEducation model);

        void CreateEmployeeEducationService(HRMS_EmployeeEducation model);
        void UpdateEmployeePersonalityDetailService(Employee model);


        #endregion
        #region HRMS - Employee Experience
        Task<IEnumerable<HRMS_EmployeeExperience>> GetEmployeeExperienceByEmployeeIdService(
            int employeeId);
        void DeleteEmployeeExperienceService(HRMS_EmployeeExperience model);
        void UpdateEmployeeExperienceService(HRMS_EmployeeExperience model);
        void CreateEmployeeExperienceService(HRMS_EmployeeExperience model);

        #endregion

        #region HRMS - Employee Professional Reference
        Task<IEnumerable<HRMS_EmployeeProfessionalReference>> GetEmployeeProfessionalReferenceByEmployeeIdService(
            int employeeId);

        void DeleteEmployeeProfessionalReferenceService(
            HRMS_EmployeeProfessionalReference model);

        void UpdateEmployeeProfessionalReferenceService(
            HRMS_EmployeeProfessionalReference model);

        void CreateEmployeeProfessionalReferenceService(
            HRMS_EmployeeProfessionalReference model);
        #endregion

        #region HRMS - Employee Professional Documents
        Task<IEnumerable<HRMS_EmployeeDocuments>> GetEmployeeDocumentByEmployeeIdService(
            int employeeId);

        void DeleteEmployeeDocumentsService(
            HRMS_EmployeeDocuments model);

        void UpdateEmployeeDocumentService(
            HRMS_EmployeeDocuments model);

        void CreateEmployeeDocumentsService(
            HRMS_EmployeeDocuments model);

        void UpdateEmployeePersonalPictureService(
            int employeeId,
            string pictureName);

        void UpdateEmployeeDocumentFileService(
            int employeeId, string fileName);

        #endregion

        #region HRMS - Employee Bank Details
        Task<IEnumerable<HRMS_EmployeeBankDetails>> GetEmployeeBankDetailService(
           int employeeId);
        void DeleteEmployeeBankDetailService(
            HRMS_EmployeeBankDetails model);
        void UpdateEmployeeBankDetailService(
            HRMS_EmployeeBankDetails model);
        void CreateEmployeeBankDetailService(
            HRMS_EmployeeBankDetails model);
        #endregion

        #region HRMS Employee Life Insurance Detail
        Task<IEnumerable<Employee>> GetWitnessService();
        Task<IEnumerable<HRMS_EmployeeLifeInsurance>> GetEmployeeLifeInsuranceDetailService(
          int employeeId);
        void DeleteEmployeeLifeInsuranceDetailService(
            HRMS_EmployeeLifeInsurance model);
        void UpdateEmployeeLifeInsuranceDetailService(
            HRMS_EmployeeLifeInsurance model);
        void CreateEmployeeLifeInsuranceDetailService(
            HRMS_EmployeeLifeInsurance model);
        #endregion

        #region HRMS -Employee Medical Insurance
        Task<IEnumerable<HRMS_EmployeeMedicalInsurance>> GetEmployeeMedicalInsuranceService(
          int employeeId);

        void DeleteEmployeeMedicalInsuranceService(
            HRMS_EmployeeMedicalInsurance model);

        void UpdateEmployeeMedicalInsuranceService(
            HRMS_EmployeeMedicalInsurance model);

        void CreateEmployeeMedicalInsuranceService(
            HRMS_EmployeeMedicalInsurance model);
        #endregion

        #region HRMS - EMployee Provident Fund
        Task<IEnumerable<HRMS_EmployeeProvidentFund>> GetEmployeeProvidentFundDetailService(
          int employeeId);
        void DeleteEmployeeProvidentFundDetailService(
            HRMS_EmployeeProvidentFund model);

        void UpdateEmployeeProvidentFundDetailService(
            HRMS_EmployeeProvidentFund model);

        void CreateEmployeeProvidentFundDetailService(
            HRMS_EmployeeProvidentFund model);
        #endregion

        #region HRMS - Employee Personal Info
        Task<IEnumerable<HRMS_EmployeePersonalInfo>> GetEmployeePersonalInfoDetailService(
          int employeeId);
        void DeleteEmployeePersonalInfoDetailService(
            HRMS_EmployeePersonalInfo model);

        void UpdateEmployeePersonalInfoDetailService(
            HRMS_EmployeePersonalInfo model);

        void CreateEmployeePersonalInfoDetailService(
            HRMS_EmployeePersonalInfo model);
        #endregion

        #region HRMS - Employee Emergency Contact Detail
        Task<IEnumerable<HRMS_EmployeeEmergencyContactDetail>> GetEmployeeEmergencyContactDetailService(
          int employeeId);

        void DeleteEmployeeEmergencyContactDetailService(
            HRMS_EmployeeEmergencyContactDetail model);
        void UpdateEmployeeEmergencyContactDetailService(
            HRMS_EmployeeEmergencyContactDetail model);
        void CreateEmployeeEmergencyContactDetailService(
            HRMS_EmployeeEmergencyContactDetail model);
        #endregion

        #region HRMS - Employee Family Member Info
        Task<IEnumerable<HRMS_EmployeeFamilyInformation>> GetEmployeeFamilyMemberService(
          int employeeId);
        void DeleteEmployeeFamilyMemberService(
            HRMS_EmployeeFamilyInformation model);
        void UpdateEmployeeFamilyMemberService(
           HRMS_EmployeeFamilyInformation model);
        void CreateEmployeeFamilyMemberService(
            HRMS_EmployeeFamilyInformation model);
        #endregion

        #region HRMS - Employee Benefits
        Task<IEnumerable<HRMS_EmployeeBenefits>> GetEmployeeBenefitsService(
         int employeeId);
        #endregion

        #region HRMS - Employee Benefits Mapping
        Task<IEnumerable<HRMS_EmployeeBenefitMapping>> GetEmployeeBenefitsMappingService(
         int employeeId);
        void CreateEmployeeBenefitService(
           List<HRMS_EmployeeBenefitMapping> model);

        void DeleteEmployeeBenefitMappingService(long
         employeeId);
        #endregion
    }
    public class HRMSSetupService : IHRMSSetupService
    {
        private readonly IHRMSDataDapperRepositor _hrmsDataDapperRepositor;

        public HRMSSetupService(
          IHRMSDataDapperRepositor hrmsDataDapperRepositor)

        {
            _hrmsDataDapperRepositor = hrmsDataDapperRepositor;
        }

        #region Employee Screen
        public async Task<IEnumerable<Employee>> GetAllEmployeesService(int pagesize,int employeeId, int roleId)
        {
            return await _hrmsDataDapperRepositor.GetAllEmployees(pagesize, employeeId, roleId);
        }
        public async Task<Employee> GetAllEmployeeByEmployeeIdService(int employeeId)
        {
            return await _hrmsDataDapperRepositor.GetAllEmployeeByEmployeeId(employeeId);
        }
        public async Task<IEnumerable<Employee>> GetAllEmployeeByDepartmentIdService(int departmentId)
        {
            return await _hrmsDataDapperRepositor.GetAllEmployeeByDepartmentId(departmentId);
        }
        public async Task<Employee> GetProfilePictureByEmployeeIdService(int employeeId)
        {
            return await _hrmsDataDapperRepositor.GetProfilePictureByEmployeeId(employeeId);
        }
        public async Task<IEnumerable<HRMS_EmployeeDocuments>> GetDocumentByEmployeeIdService(int employeeId)
        {
            return await _hrmsDataDapperRepositor.GetDocumentByEmployeeId(employeeId);
        }

        public async Task<IEnumerable<Employee>> SearchAllEmployeesService(SearchEmployee searchParam)
        {
            return await _hrmsDataDapperRepositor.SearchAllEmployees(searchParam);
        }

        public async void CreateEmployeeService(Employee model)
        {
            _hrmsDataDapperRepositor.CreateEmployeeDataDapper(model);
        }
        public async void UpdateEmployeePersonalInfoService(Employee model)
        {
            _hrmsDataDapperRepositor.UpdateEmployeePersonalInfoDataDapper(model);
        }
        public async void UpdateEmployeeService(EmployeePersonal model)
        {
            _hrmsDataDapperRepositor.UpdateEmployeeDataDapper(model);
        }
        public async void UpdateEmployeeContactDetailService(EmployeeContactDetail model)
        {
            _hrmsDataDapperRepositor.UpdateEmployeeCompanyDetailDataDapper(model);
        }
        public async void UpdateEmployeePersonalityDetailService(Employee model)
        {
            _hrmsDataDapperRepositor.UpdateEmployeePersonalityDetailDataDapper(model);
        }
        public async void UpdateEmployeePersonalPictureService(int employeeId, string pictureName)
        {
            _hrmsDataDapperRepositor.UpdateEmployeeProfilePictureDataDapper(employeeId,pictureName);
        }
        public async Task<IEnumerable<Location>> GetLocationService()
        {
            return await _hrmsDataDapperRepositor.GetLocation();
        }


        #endregion
        #region Employee Education
        public async Task<IEnumerable<HRMS_EmployeeEducation>> GetEmployeeEducationByEmployeeIdService(int employeeId)
        {
            return await _hrmsDataDapperRepositor.GetEmployeeEducationByEmployeeIdDapper(employeeId);
        }
        public async void DeleteEmployeeEducationService(HRMS_EmployeeEducation model)
        {
            _hrmsDataDapperRepositor.DeleteEmployeeEducationDapper(model);
        }
        public async void UpdateEmployeeEducationService(HRMS_EmployeeEducation model)
        {
            _hrmsDataDapperRepositor.UpdateEmployeeEducationDataDapper(model);
        }
        public async void CreateEmployeeEducationService(HRMS_EmployeeEducation model)
        {
            _hrmsDataDapperRepositor.CreateEmployeeEducationDataDapper(model);
        }
        #endregion

        #region HRMS- Employee Experience
        public async Task<IEnumerable<HRMS_EmployeeExperience>> GetEmployeeExperienceByEmployeeIdService(int employeeId)
        {
            return await _hrmsDataDapperRepositor.GetEmployeeExperienceByEmployeeIdDapper(employeeId);
        }
        public async void DeleteEmployeeExperienceService(HRMS_EmployeeExperience model)
        {
            _hrmsDataDapperRepositor.DeleteEmployeeExperienceDapper(model);
        }
        public async void UpdateEmployeeExperienceService(HRMS_EmployeeExperience model)
        {
            _hrmsDataDapperRepositor.UpdateEmployeeExperienceDataDapper(model);
        }
        public async void CreateEmployeeExperienceService(HRMS_EmployeeExperience model)
        {
            _hrmsDataDapperRepositor.CreateEmployeeExperienceDataDapper(model);
        }
        #endregion

        #region HRMS - Employee Professional Reference
        public async Task<IEnumerable<HRMS_EmployeeProfessionalReference>> GetEmployeeProfessionalReferenceByEmployeeIdService(
            int employeeId)
        {
            return await _hrmsDataDapperRepositor.GetEmployeeProfessionalReferenceByEmployeeIdDapper(employeeId);
        }
        public async void DeleteEmployeeProfessionalReferenceService(
            HRMS_EmployeeProfessionalReference model)
        {
            _hrmsDataDapperRepositor.DeleteEmployeeProfessionalReferenceDapper(model);
        }
        public async void UpdateEmployeeProfessionalReferenceService(
            HRMS_EmployeeProfessionalReference model)
        {
            _hrmsDataDapperRepositor.UpdateEmployeeProfessionalReferenceDataDapper(model);
        }
        public async void CreateEmployeeProfessionalReferenceService(
            HRMS_EmployeeProfessionalReference model)
        {
            _hrmsDataDapperRepositor.CreateEmployeeProfessionalReferenceDataDapper(model);
        }

        #endregion


        #region HRMS - Employee Professional Documents
        public async Task<IEnumerable<HRMS_EmployeeDocuments>> GetEmployeeDocumentByEmployeeIdService(
            int employeeId)
        {
            return await _hrmsDataDapperRepositor.GetEmployeeDocumentByEmployeeIdDapper(employeeId);
        }
        public async void DeleteEmployeeDocumentsService(
            HRMS_EmployeeDocuments model)
        {
            _hrmsDataDapperRepositor.DeleteEmployeeDocumentsDapper(model);
        }
        public async void UpdateEmployeeDocumentService(
            HRMS_EmployeeDocuments model)
        {
            _hrmsDataDapperRepositor.UpdateEmployeeDocumentDataDapper(model);
        }
        public async void CreateEmployeeDocumentsService(
            HRMS_EmployeeDocuments model)
        {
            _hrmsDataDapperRepositor.CreateEmployeeDocumentsDataDapper(model);
        }
        public async void UpdateEmployeeDocumentFileService(
            int employeeId, string fileName)
        {
            _hrmsDataDapperRepositor.UpdateEmployeeDocumentDataDapper(employeeId, fileName);
        }

        #endregion

        #region HRMS - Employee Bank Details
        public async Task<IEnumerable<HRMS_EmployeeBankDetails>> GetEmployeeBankDetailService(
           int employeeId)
        {
            return await _hrmsDataDapperRepositor.GetEmployeeBankDetailDapper(employeeId);
        }
        public async void DeleteEmployeeBankDetailService(
            HRMS_EmployeeBankDetails model)
        {
            _hrmsDataDapperRepositor.DeleteEmployeeBankDetailDapper(model);
        }
        public async void UpdateEmployeeBankDetailService(
            HRMS_EmployeeBankDetails model)
        {
            _hrmsDataDapperRepositor.UpdateEmployeeBankDetailDataDapper(model);
        }
        public async void CreateEmployeeBankDetailService(
            HRMS_EmployeeBankDetails model)
        {
            _hrmsDataDapperRepositor.CreateEmployeeBankDetailDataDapper(model);
        }
        #endregion

        #region HRMS - Employee Life Insurance Detail
        public async Task<IEnumerable<Employee>> GetWitnessService()
        {
            return await _hrmsDataDapperRepositor.GetWitnessDapper();
        }
        public async Task<IEnumerable<HRMS_EmployeeLifeInsurance>> GetEmployeeLifeInsuranceDetailService(
          int employeeId)
        {
            return await _hrmsDataDapperRepositor.GetEmployeeLifeInsuranceDetailDapper(employeeId);
        }
        public async void DeleteEmployeeLifeInsuranceDetailService(
            HRMS_EmployeeLifeInsurance model)
        {
            _hrmsDataDapperRepositor.DeleteEmployeeLifeInsuranceDetailDapper(model);
        }
        public async void UpdateEmployeeLifeInsuranceDetailService(
            HRMS_EmployeeLifeInsurance model)
        {
            _hrmsDataDapperRepositor.UpdateEmployeeLifeInsuranceDetailDataDapper(model);
        }
        public async void CreateEmployeeLifeInsuranceDetailService(
            HRMS_EmployeeLifeInsurance model)
        {
            _hrmsDataDapperRepositor.CreateEmployeeLifeInsuranceDetailDataDapper(model);
        }
        #endregion

        #region HRMS - Employee Medical Insurance Detail
        public async Task<IEnumerable<HRMS_EmployeeMedicalInsurance>> GetEmployeeMedicalInsuranceService(
          int employeeId)
        {
            return await _hrmsDataDapperRepositor.GetEmployeeMedicalInsuranceDetailDapper(employeeId);
        }
        public async void DeleteEmployeeMedicalInsuranceService(
            HRMS_EmployeeMedicalInsurance model)
        {
            _hrmsDataDapperRepositor.DeleteEmployeeMedicalInsuranceDetailDapper(model);
        }
        public async void UpdateEmployeeMedicalInsuranceService(
            HRMS_EmployeeMedicalInsurance model)
        {
            _hrmsDataDapperRepositor.UpdateEmployeeMedicalInsuranceDetailDataDapper(model);
        }
        public async void CreateEmployeeMedicalInsuranceService(
            HRMS_EmployeeMedicalInsurance model)
        {
            _hrmsDataDapperRepositor.CreateEmployeeMedicalInsuranceDetailDataDapper(model);
        }
        #endregion

        #region HRMS - Employee Provident Fund Detail
       
        public async Task<IEnumerable<HRMS_EmployeeProvidentFund>> GetEmployeeProvidentFundDetailService(
          int employeeId)
        {
            return await _hrmsDataDapperRepositor.GetEmployeeProvidentFundDetailDapper(employeeId);
        }
        public async void DeleteEmployeeProvidentFundDetailService(
            HRMS_EmployeeProvidentFund model)
        {
            _hrmsDataDapperRepositor.DeleteEmployeeProvidentFundDetailDapper(model);
        }
        public async void UpdateEmployeeProvidentFundDetailService(
            HRMS_EmployeeProvidentFund model)
        {
            _hrmsDataDapperRepositor.UpdateEmployeeProvidentFundDetailDataDapper(model);
        }
        public async void CreateEmployeeProvidentFundDetailService(
            HRMS_EmployeeProvidentFund model)
        {
            _hrmsDataDapperRepositor.CreateEmployeeProvidentFundDetailDataDapper(model);
        }
        #endregion

        #region HRMS - Employee Personal Info

        public async Task<IEnumerable<HRMS_EmployeePersonalInfo>> GetEmployeePersonalInfoDetailService(
          int employeeId)
        {
            return await _hrmsDataDapperRepositor.GetEmployeePersonalInfoDetailDapper(employeeId);
        }
        public async void DeleteEmployeePersonalInfoDetailService(
            HRMS_EmployeePersonalInfo model)
        {
            _hrmsDataDapperRepositor.DeleteEmployeePersonalInfoDetailDapper(model);
        }
        public async void UpdateEmployeePersonalInfoDetailService(
            HRMS_EmployeePersonalInfo model)
        {
            _hrmsDataDapperRepositor.UpdateEmployeePersonalInfoDetailDataDapper(model);
        }
        public async void CreateEmployeePersonalInfoDetailService(
            HRMS_EmployeePersonalInfo model)
        {
            _hrmsDataDapperRepositor.CreateEmployeePersonalInfoDetailDataDapper(model);
        }
        #endregion

        #region HRMS - Employee Emergency Contact Detail

        public async Task<IEnumerable<HRMS_EmployeeEmergencyContactDetail>> GetEmployeeEmergencyContactDetailService(
          int employeeId)
        {
            return await _hrmsDataDapperRepositor.GetEmployeeEmergencyContactDetailDapper(employeeId);
        }
        public async void DeleteEmployeeEmergencyContactDetailService(
            HRMS_EmployeeEmergencyContactDetail model)
        {
            _hrmsDataDapperRepositor.DeleteEmployeeEmergencyContactDetailDapper(model);
        }
        public async void UpdateEmployeeEmergencyContactDetailService(
            HRMS_EmployeeEmergencyContactDetail model)
        {
            _hrmsDataDapperRepositor.UpdateEmployeeEmergencyContactDetailDataDapper(model);
        }
        public async void CreateEmployeeEmergencyContactDetailService(
            HRMS_EmployeeEmergencyContactDetail model)
        {
            _hrmsDataDapperRepositor.CreateEmployeeEmergencyContactDetailDataDapper(model);
        }
        #endregion

        #region HRMS - Employee Family Member Info

        public async Task<IEnumerable<HRMS_EmployeeFamilyInformation>> GetEmployeeFamilyMemberService(
          int employeeId)
        {
            return await _hrmsDataDapperRepositor.GetEmployeeFamilyMemberInfoDapper(employeeId);
        }
        public async void DeleteEmployeeFamilyMemberService(
            HRMS_EmployeeFamilyInformation model)
        {
            _hrmsDataDapperRepositor.DeleteEmployeeFamilyMemberInfoDapper(model);
        }
        public async void UpdateEmployeeFamilyMemberService(
            HRMS_EmployeeFamilyInformation model)
        {
            _hrmsDataDapperRepositor.UpdateEmployeeFamilyMemberInfoDataDapper(model);
        }
        public async void CreateEmployeeFamilyMemberService(
            HRMS_EmployeeFamilyInformation model)
        {
            _hrmsDataDapperRepositor.CreateEmployeeFamilyMemberInfoDataDapper(model);
        }
        #endregion

        #region HRMS - Employee Benefits
        public async Task<IEnumerable<HRMS_EmployeeBenefits>> GetEmployeeBenefitsService(
         int employeeId)
        {
            return await _hrmsDataDapperRepositor.GetEmployeeBenefitsDapper(employeeId);
        }
        #endregion
        #region HRMS - Employee Benefits Mapping
        public async Task<IEnumerable<HRMS_EmployeeBenefitMapping>> GetEmployeeBenefitsMappingService(
         int employeeId)
        {
            return await _hrmsDataDapperRepositor.GetEmployeeBenefitsMappingDapper(employeeId);
        }
        public async void CreateEmployeeBenefitService(
           List<HRMS_EmployeeBenefitMapping> model)
        {
            _hrmsDataDapperRepositor.CreateEmployeeBenefitsMappingDapper(model);
        }
        public async void DeleteEmployeeBenefitMappingService(
         long employeeId)
        {
            _hrmsDataDapperRepositor.DeleteEmployeeBenefitsMappingDapper(employeeId);
        }
        #endregion

       

     }
}
