using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Core.Model;
using ERP.Data.DataRepository.HomeDataDapperRepository;
using ERP.API.Common;
using ERP.Data.DataRepository.SecurityDataDapperRepositor;
using ERP.Application.Repositories.SecuritySetupService;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System.Net.Http;
using Microsoft.AspNetCore.Cors;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using static System.Net.Mime.MediaTypeNames;

namespace ERP.API.Controllers
{
   
    [EnableCors("Security")]
    [Route("api/[controller]")]
    [ApiController]
    public class HRMSControllerController : ControllerBase
    {
        private readonly IHRMSSetupService _hrmsService;
        private readonly byte[] fileBytes;
        public IHostingEnvironment hostingEnvironment;

        public HRMSControllerController(IHRMSSetupService hrmsService, IHostingEnvironment hostingEnv)
        {

            _hrmsService = hrmsService;
            hostingEnvironment = hostingEnv;

        }


        #region Employee Screen

        [HttpGet("GetAllEmployees")]
        public async Task<IEnumerable<Employee>> GetAllEmployees(int pageSize,int employeeId,int roleId)
        {
            return await _hrmsService.GetAllEmployeesService(pageSize, employeeId, roleId);
        }

        [HttpGet("GetAllEmployeesByEmployeeId")]
        public async Task<Employee> GetAllEmployeesByEmployeeId(int employeeId)
        {
            return await _hrmsService.GetAllEmployeeByEmployeeIdService(employeeId);
        }
        [HttpGet("GetAllEmployeesByDepartmentId")]
        public async Task<IEnumerable<Employee>> GetAllEmployeesByDepartmentId(int departmentId)
        {
            return await _hrmsService.GetAllEmployeeByDepartmentIdService(departmentId);
        }

        [HttpGet("GetProfilePictureByEmployeeId")]
        public async Task<Employee> GetProfilePictureByEmployeeId(int employeeId)
        {
            return await _hrmsService.GetProfilePictureByEmployeeIdService(employeeId);
        }
        [HttpGet("GetDocumentByEmployeeId")]
        public async Task<IEnumerable<HRMS_EmployeeDocuments>> GetDocumentByEmployeeId(int employeeId)
        {
            return await _hrmsService.GetDocumentByEmployeeIdService(employeeId);
        }

        [HttpPut("SearchEmployees")]
        public async Task<IEnumerable<Employee>> SearchEmployees(
           SearchEmployee searchParam)
        {
            return await _hrmsService.SearchAllEmployeesService(searchParam);
        }

        [HttpPost("CreateEmployee")]
        public async void CreateEmployee(Employee input)
        {
            _hrmsService.CreateEmployeeService(input);
        }
        [HttpPut("UpdateEmployeePersonalInfo")]
        public async void UpdateEmployeePersonalInfo(Employee input)
        {
            _hrmsService.UpdateEmployeePersonalInfoService(input);
        }
        [HttpPut("UpdateEmployee")]
        public async void UpdateEmployee(EmployeePersonal input)
        {
            _hrmsService.UpdateEmployeeService(input);
        }
        [HttpPut("UpdateEmployeeContactDetails")]
        public async void UpdateEmployeeContactDetails(EmployeeContactDetail input)
        {
            _hrmsService.UpdateEmployeeContactDetailService(input);
        }
        [HttpPost("UpdateEmployeePersonalPictureInfo/{employeeId}/{pictureName}")]
        public async void UpdateEmployeePersonalPictureInfo(int employeeId, string pictureName)
        {
            //Save Image in .NET Core folder

            var files = HttpContext.Request.Form.Files;
            if(files != null && files.Count > 0)
            {
                foreach(var file in files)
                {
                    FileInfo fi = new FileInfo(file.FileName);
                    //var newfileName = "Image_" + DateTime.Now.TimeOfDay.Milliseconds + fi.Extension;
                    var newfileName = pictureName ;
                    var path = Path.Combine("", hostingEnvironment.ContentRootPath + "/wwwroot/Images/HRMS/" + newfileName);
                    using (var stream = new FileStream(path,FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
            }
           
            _hrmsService.UpdateEmployeePersonalPictureService(employeeId, pictureName);
        }

        [HttpGet("GetLocation")]
        public async Task<IEnumerable<Location>> GetLocation()
        {
            return await _hrmsService.GetLocationService();
        }


        [HttpPut("UpdateEmployeePersonalityDetail")]
        public async void UpdateEmployeePersonalityDetail(Employee input)
        {
            _hrmsService.UpdateEmployeePersonalityDetailService(input);
        }
        #endregion

        #region Employee Education
        [HttpGet("Employeeeducation")]
        public async Task<IEnumerable<HRMS_EmployeeEducation>> Employeeeducation(int employeeId)
        {
            return await _hrmsService.GetEmployeeEducationByEmployeeIdService(employeeId);
        }

        [HttpPut("DeleteEmployeeEducation")]
        public async void DeleteEmployeeEducation(HRMS_EmployeeEducation input)
        {
            _hrmsService.DeleteEmployeeEducationService(input);
        }
        [HttpPut("UpdateEmployeeEducation")]
        public async void UpdateEmployeeEducation(HRMS_EmployeeEducation input)
        {
            _hrmsService.UpdateEmployeeEducationService(input);
        }
        [HttpPost("CreateEmployeeEducation")]
        public async void CreateEmployeeEducation(HRMS_EmployeeEducation input)
        {
            _hrmsService.CreateEmployeeEducationService(input);
        }
        #endregion

        #region Employee Experience
        [HttpGet("EmployeeExperience")]
        public async Task<IEnumerable<HRMS_EmployeeExperience>> EmployeeExperience(int employeeId)
        {
            return await _hrmsService.GetEmployeeExperienceByEmployeeIdService(employeeId);
        }

        [HttpPut("DeleteEmployeeExperience")]
        public async void DeleteEmployeeExperience(HRMS_EmployeeExperience input)
        {
            _hrmsService.DeleteEmployeeExperienceService(input);
        }
        [HttpPut("UpdateEmployeeExperience")]
        public async void UpdateEmployeeExperience(HRMS_EmployeeExperience input)
        {
            _hrmsService.UpdateEmployeeExperienceService(input);
        }
        [HttpPost("CreateEmployeeExperience")]
        public async void CreateEmployeeExperience(HRMS_EmployeeExperience input)
        {
            _hrmsService.CreateEmployeeExperienceService(input);
        }
        #endregion

        #region HRMS - Employee Professional Reference
        [HttpGet("EmployeeProfessionalReference")]
        public async Task<IEnumerable<HRMS_EmployeeProfessionalReference>> EmployeeProfessionalReference(
            int employeeId)
        {
            return await _hrmsService.GetEmployeeProfessionalReferenceByEmployeeIdService(employeeId);
        }

        [HttpPut("DeleteProfessionalReference")]
        public async void DeleteProfessionalReference(HRMS_EmployeeProfessionalReference input)
        {
            _hrmsService.DeleteEmployeeProfessionalReferenceService(input);
        }
        [HttpPut("UpdateProfessionalReference")]
        public async void UpdateProfessionalReference(HRMS_EmployeeProfessionalReference input)
        {
            _hrmsService.UpdateEmployeeProfessionalReferenceService(input);
        }
        [HttpPost("CreateProfessionalReference")]
        public async void CreateProfessionalReference(HRMS_EmployeeProfessionalReference input)
        {
            _hrmsService.CreateEmployeeProfessionalReferenceService(input);
        }
        #endregion

        #region HRMS - Employee Documents
        [HttpGet("EmployeeDocuments")]
        public async Task<IEnumerable<HRMS_EmployeeDocuments>> EmployeeDocuments(
           int employeeId)
        {
            return await _hrmsService.GetEmployeeDocumentByEmployeeIdService(employeeId);
        }

        [HttpPut("DeleteDocuments")]
        public async void DeleteDocuments(HRMS_EmployeeDocuments input)
        {
            _hrmsService.DeleteEmployeeDocumentsService(input);
        }
        [HttpPut("UpdateDocuments")]
        public async void UpdateDocuments(HRMS_EmployeeDocuments input)
        {
            _hrmsService.UpdateEmployeeDocumentService(input);
        }
        [HttpPost("CreateDocument")]
        public async void CreateDocument(HRMS_EmployeeDocuments input)
        {
            _hrmsService.CreateEmployeeDocumentsService(input);
        }

        [HttpPost("UpdateEmployeeDocumentInfo/{employeeId}/{fileName}")]
        public async void UpdateEmployeeDocumentInfo(int employeeId, string fileName)
        {
            //Save Image in .NET Core folder

            var files = HttpContext.Request.Form.Files;
            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                    FileInfo fi = new FileInfo(file.FileName);
                    //var newfileName = "Image_" + DateTime.Now.TimeOfDay.Milliseconds + fi.Extension;
                    var newfileName = fileName;
                    var path = Path.Combine("", hostingEnvironment.ContentRootPath + "/wwwroot/Documents/HRMS/" + newfileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
            }

            _hrmsService.UpdateEmployeeDocumentFileService(employeeId, fileName);
        }
        #endregion

        #region HRMS - Employee Bank Details
        [HttpGet("EmployeeBankDetail")]
        public async Task<IEnumerable<HRMS_EmployeeBankDetails>> EmployeeBankDetail(
            int employeeId)
        {
            return await _hrmsService.GetEmployeeBankDetailService(employeeId);
        }

        [HttpPut("DeleteBankDetail")]
        public async void DeleteBankDetail(HRMS_EmployeeBankDetails input)
        {
            _hrmsService.DeleteEmployeeBankDetailService(input);
        }
        [HttpPut("UpdateBankDetail")]
        public async void UpdateBankDetail(HRMS_EmployeeBankDetails input)
        {
            _hrmsService.UpdateEmployeeBankDetailService(input);
        }
        [HttpPost("CreateBankDetail")]
        public async void CreateBankDetail(HRMS_EmployeeBankDetails input)
        {
            _hrmsService.CreateEmployeeBankDetailService(input);
        }
        #endregion

        #region HRMS - Employee Life Insurance Details
        [HttpGet("Witness")]
        public async Task<IEnumerable<Employee>> Witness()
        {
            return await _hrmsService.GetWitnessService();
        }
        [HttpGet("EmployeeLifeInsuranceDetail")]
        public async Task<IEnumerable<HRMS_EmployeeLifeInsurance>> EmployeeLifeInsuranceDetail(
          int employeeId)
        {
            return await _hrmsService.GetEmployeeLifeInsuranceDetailService(employeeId);
        }

        [HttpPut("DeleteLifeInsuranceDetail")]
        public async void DeleteLifeInsuranceDetail(HRMS_EmployeeLifeInsurance input)
        {
            _hrmsService.DeleteEmployeeLifeInsuranceDetailService(input);
        }
        [HttpPut("UpdateLifeInsuranceDetail")]
        public async void UpdateLifeInsuranceDetail(HRMS_EmployeeLifeInsurance input)
        {
            _hrmsService.UpdateEmployeeLifeInsuranceDetailService(input);
        }
        [HttpPost("CreateLifeInsuranceDetail")]
        public async void CreateLifeInsuranceDetail(HRMS_EmployeeLifeInsurance input)
        {
            _hrmsService.CreateEmployeeLifeInsuranceDetailService(input);
        }
        #endregion

        #region HRMS - Employee Medical Insurance
        [HttpGet("MedicalInsuranceDetail")]
        public async Task<IEnumerable<HRMS_EmployeeMedicalInsurance>> MedicalInsuranceDetail(
            int employeeId)
        {
            return await _hrmsService.GetEmployeeMedicalInsuranceService(employeeId);
        }

        [HttpPut("DeleteMedicalInsurance")]
        public async void DeleteMedicalInsurance(HRMS_EmployeeMedicalInsurance input)
        {
            _hrmsService.DeleteEmployeeMedicalInsuranceService(input);
        }
        [HttpPut("UpdateMedicalInsurance")]
        public async void UpdateMedicalInsurance(HRMS_EmployeeMedicalInsurance input)
        {
            _hrmsService.UpdateEmployeeMedicalInsuranceService(input);
        }
        [HttpPost("CreateMedicalInsuranceDetail")]
        public async void CreateMedicalInsuranceDetail(HRMS_EmployeeMedicalInsurance input)
        {
            _hrmsService.CreateEmployeeMedicalInsuranceService(input);
        }
        #endregion

        #region HRMS - Employee Provident Fund Details
        
        [HttpGet("EmployeeProvidentFundDetail")]
        public async Task<IEnumerable<HRMS_EmployeeProvidentFund>> EmployeeProvidentFundDetail(
          int employeeId)
        {
            return await _hrmsService.GetEmployeeProvidentFundDetailService(employeeId);
        }

        [HttpPut("DeleteProvidentFundDetail")]
        public async void DeleteProvidentFundDetail(HRMS_EmployeeProvidentFund input)
        {
            _hrmsService.DeleteEmployeeProvidentFundDetailService(input);
        }
        [HttpPut("UpdateProvidentFundDetail")]
        public async void UpdateProvidentFundDetail(HRMS_EmployeeProvidentFund input)
        {
            _hrmsService.UpdateEmployeeProvidentFundDetailService(input);
        }
        [HttpPost("CreateProvidentFundDetail")]
        public async void CreateProvidentFundDetail(HRMS_EmployeeProvidentFund input)
        {
            _hrmsService.CreateEmployeeProvidentFundDetailService(input);
        }
        #endregion

        #region HRMS - Employee Personal Info

        [HttpGet("EmployeePersonalInfoDetail")]
        public async Task<IEnumerable<HRMS_EmployeePersonalInfo>> EmployeePersonalInfoDetail(
          int employeeId)
        {
            return await _hrmsService.GetEmployeePersonalInfoDetailService(employeeId);
        }

        [HttpPut("DeletePersonalInfoDetail")]
        public async void DeletePersonalInfoDetail(HRMS_EmployeePersonalInfo input)
        {
            _hrmsService.DeleteEmployeePersonalInfoDetailService(input);
        }
        [HttpPut("UpdatePersonalInfoDetail")]
        public async void UpdatePersonalInfoDetail(HRMS_EmployeePersonalInfo input)
        {
            _hrmsService.UpdateEmployeePersonalInfoDetailService(input);
        }
        [HttpPost("CreatePersonalInfoDetail")]
        public async void CreatePersonalInfoDetail(HRMS_EmployeePersonalInfo input)
        {
            _hrmsService.CreateEmployeePersonalInfoDetailService(input);
        }
        #endregion

        #region HRMS - Employee Emergency Contact Detail

        [HttpGet("EmployeeEmergencyContactDetail")]
        public async Task<IEnumerable<HRMS_EmployeeEmergencyContactDetail>> EmployeeEmergencyContactDetail(
          int employeeId)
        {
            return await _hrmsService.GetEmployeeEmergencyContactDetailService(employeeId);
        }

        [HttpPut("DeleteEmergencyContactDetail")]
        public async void DeleteEmergencyContactDetail(HRMS_EmployeeEmergencyContactDetail input)
        {
            _hrmsService.DeleteEmployeeEmergencyContactDetailService(input);
        }
        [HttpPut("UpdateEmergencyContactDetail")]
        public async void UpdateEmergencyContactDetail(HRMS_EmployeeEmergencyContactDetail input)
        {
            _hrmsService.UpdateEmployeeEmergencyContactDetailService(input);
        }
        [HttpPost("CreateEmergencyContactDetail")]
        public async void CreateEmergencyContactDetail(HRMS_EmployeeEmergencyContactDetail input)
        {
            _hrmsService.CreateEmployeeEmergencyContactDetailService(input);
        }
        #endregion

        #region HRMS - Employee Family Member Info

        [HttpGet("EmployeeFamilyMember")]
        public async Task<IEnumerable<HRMS_EmployeeFamilyInformation>> EmployeeFamilyMember(
          int employeeId)
        {
            return await _hrmsService.GetEmployeeFamilyMemberService(employeeId);
        }

        [HttpPut("DeleteFamilyMember")]
        public async void DeleteFamilyMember(HRMS_EmployeeFamilyInformation input)
        {
            _hrmsService.DeleteEmployeeFamilyMemberService(input);
        }
        [HttpPut("UpdateFamilyMember")]
        public async void UpdateFamilyMember(HRMS_EmployeeFamilyInformation input)
        {
            _hrmsService.UpdateEmployeeFamilyMemberService(input);
        }
        [HttpPost("CreateFamilyMember")]
        public async void CreateFamilyMember(HRMS_EmployeeFamilyInformation input)
        {
            _hrmsService.CreateEmployeeFamilyMemberService(input);
        }
        #endregion

        #region HRMS - Employee Benefits
        [HttpGet("EmployeeBenefits")]
        public async Task<IEnumerable<HRMS_EmployeeBenefits>> EmployeeBenefits(
          int employeeId)
        {
            return await _hrmsService.GetEmployeeBenefitsService(employeeId);
        }
        #endregion

        #region HRMS - Employee Benefits Mapping
        [HttpGet("EmployeeBenefitsMapping")]
        public async Task<IEnumerable<HRMS_EmployeeBenefitMapping>> EmployeeBenefitsMapping(
          int employeeId)
        {
            return await _hrmsService.GetEmployeeBenefitsMappingService(employeeId);
        }

        [HttpPost("CreateBenefitMapping")]
        public async void CreateBenefitMapping(List<HRMS_EmployeeBenefitMapping> input)
        {
            _hrmsService.CreateEmployeeBenefitService(input);
        }
        [HttpDelete("DeleteBenefitMapping")]
        public async void DeleteBenefitMapping(long employeeId)
        {
            _hrmsService.DeleteEmployeeBenefitMappingService(employeeId);
        }
        #endregion

    }
}
