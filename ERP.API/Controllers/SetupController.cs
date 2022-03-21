using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Application.Repositories.HomeService;
using ERP.Core.Model;
using ERP.Data.DataRepository.HomeDataDapperRepository;
using ERP.API.Common;
using ERP.Data.DataRepository.SecurityDataDapperRepositor;
using ERP.Application.Repositories.SetupService;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System.Net.Http;
using Microsoft.AspNetCore.Cors;
using Hangfire.Annotations;
using System.Globalization;

namespace ERP.API.Controllers
{
  
    [EnableCors("Security")]
    [Route("api/[controller]")]
    [ApiController]
    public class SetupController : ControllerBase
    {
        private readonly ISetupService _SetupService;

        public SetupController(ISetupService SetupService)
        {

            _SetupService = SetupService;

        }

        #region Bank
        [HttpGet("Banks")]
        public async Task<IEnumerable<Bank>> Banks()
        {
            return await _SetupService.GetBankService();
        }

        //[HttpGet("SearchBank/{bankPrefix?}/{bankDescription?}")]
        [HttpGet("SearchBank/{bankDescription}")]
        public async Task<IEnumerable<Bank>> SearchBank( string? bankDescription=null)
        {
            return await _SetupService.SearchBankService( bankDescription);
        }


        [HttpPut("DeleteBank")]
        public async void DeleteBank(Bank input)
        {
            _SetupService.DeleteBankService(input);
        }


        [HttpPut("UpdateBank")]
        public async void UpdateBank(Bank input)
        {
            _SetupService.UpdateBankService(input);
        }

        [HttpPost("CreateBank")]
        public async void CreateBank(Bank input)
        {
            _SetupService.CreateBankService(input);
        }

        #endregion

        #region Business Unit
        [HttpGet("BusinessUnit")]
        public async Task<IEnumerable<BusinessUnits>> BusinessUnit()
        {
            return await _SetupService.GetBusinessUnitService();
        }

        [HttpGet("SearchBusinessUnit/{businessUnit}")]
        public async Task<IEnumerable<BusinessUnits>> SearchBusinessUnit(string? businessUnit)
        {
            return await _SetupService.SearchBusinessUnitService(businessUnit);
        }


        [HttpPut("DeleteBusinessUnit")]
        public async void DeleteBusinessUnit(BusinessUnits input)
        {
            _SetupService.DeleteBusinessUnitService(input);
        }


        [HttpPut("UpdateBusinessUnit")]
        public async void UpdateBusinessUnit(BusinessUnits input)
        {
            _SetupService.UpdateBusinessUnitService(input);
        }

        [HttpPost("CreateBusinessUnit")]
        public async void CreateBusinessUnit(BusinessUnits input)
        {
            _SetupService.CreateBusinessUnitService(input);
        }

        #endregion

        #region Menus Item
        [HttpGet("Menus")]
        public async Task<IEnumerable<MenuItem>> Menus()
        {
            return await _SetupService.GetMenuService();
        }

        [HttpGet("MenuListInApplication")]
        public async Task<IEnumerable<MenuItem>> MenuListInApplication()
        {
            return await _SetupService.GetMenuListInApplicationService();
        }

        [HttpGet("ParentMenus")]
        public async Task<IEnumerable<MenuItem>> ParentMenus()
        {
            return await _SetupService.GetParentMenuService();
        }

        [HttpGet("Applications")]
        public async Task<IEnumerable<Applications>> Applications()
        {
            return await _SetupService.GetApplicationService();
        }

        [HttpGet("SearchMenu/{menuName}")]
        public async Task<IEnumerable<MenuItem>> SearchMenu(string menuName)
        {
            return await _SetupService.SearchMenuService(menuName);
        }


        [HttpPut("DeleteMenu")]
        public async void DeleteMenu(MenuItem input)
        {
            _SetupService.DeleteMenuService(input);
        }


        [HttpPut("UpdateMenu")]
        public async void UpdateMenu(MenuItem input)
        {
            _SetupService.UpdateMenuService(input);
        }

        [HttpPost("CreateMenu")]
        public async void CreateMenu(MenuItem input)
        {
            _SetupService.CreateMenuService(input);
        }

        #endregion

        #region Feature
        [HttpGet("Features")]
        public async Task<IEnumerable<MenuItemFeature>> Features()
        {
            return await _SetupService.GetFeatureService();
        }

        
        [HttpGet("SearchFeature/{featureName}")]
        public async Task<IEnumerable<MenuItemFeature>> SearchFeature(string? featureName = null)
        {
            return await _SetupService.SearchFeatureService(featureName);
        }


        [HttpPut("DeleteFeature")]
        public async void DeleteFeature(MenuItemFeature input)
        {
            _SetupService.DeleteFeatureService(input);
        }


        [HttpPut("UpdateFeature")]
        public async void UpdateFeature(MenuItemFeature input)
        {
            _SetupService.UpdateFeatureService(input);
        }

        [HttpPost("CreateFeature")]
        public async void CreateFeature(MenuItemFeature input)
        {
            _SetupService.CreateFeatureService(input);
        }

        #endregion

        #region MenuItemFeatureMapping
        [HttpGet("GetFeatureByMenu/{menuId}")]
        public async Task<IEnumerable<MenuFeatureMapping>> GetFeatureByMenu(int menuId)
        {
            return await _SetupService.GetFeatureByMenuService(menuId);
        }
        [HttpDelete("DeleteMenuItemFeatureMapping/{MenuItemFeatureId}")]
        public async void DeleteMenuItemFeatureMapping(int MenuItemFeatureId)
        {
              _SetupService.DeleteFeatureByMenuService(MenuItemFeatureId);
        }
        [HttpGet("GetFeatureMappingByMenuId/{menuId}")]
        public async Task<IEnumerable<MenuFeatureMapping>> GetFeatureMappingByMenuId(int menuId)
        {
            return await _SetupService.GetMenuItemFeatureMappingService(menuId);
        }
        [HttpPost("CreateMenuItemFeatureMapping")]
        public async void CreateMenuItemFeatureMapping(MenuFeatureMapping model)
        {
            _SetupService.CreateMenuFeatureMappingService(model);
        }
        [HttpGet("IsFeatureMappingAlreadyExist/{menuId}/{featureId}")]
        public async Task<bool> IsFeatureMappingAlreadyExist(int menuId, int featureId)
        {
            return await _SetupService.GetMenuItemFeatureMappingAlreadyExistService(menuId, featureId);
        }
        #endregion

        #region Department
        [HttpGet("Department")]
        public async Task<IEnumerable<Department>> Departments()
        {
            return await _SetupService.GetDepartmentService();
        }
        [HttpGet("DepartmentByCompany")]
        public async Task<IEnumerable<Department>> DepartmentByCompany(int companyId)
        {
            return await _SetupService.GetDepartmentByCompanyIdService(companyId);
        }


        [HttpGet("SearchDepartment/{departmentName}")]
        public async Task<IEnumerable<Department>> SearchDepartment(string? departmentName = null)
        {
            return await _SetupService.SearchDepartmentService(departmentName);
        }


        [HttpPut("DeleteDepartment")]
        public async void DeleteDepartment(Department input)
        {
            _SetupService.DeleteDepartmentService(input);
        }


        [HttpPut("UpdateDepartment")]
        public async void UpdateDepartment(Department input)
        {
            _SetupService.UpdateDepartmentService(input);
        }

        [HttpPost("CreateDepartment")]
        public async void CreateDepartment(Department input)
        {
            _SetupService.CreateDepartmentService(input);
        }

        #endregion

        #region State
        [HttpGet("State")]
        public async Task<IEnumerable<State>> State(int? countryId = null)
        {
            return await _SetupService.GetStateService(countryId);
        }


        [HttpGet("SearchState/{stateName}")]
        public async Task<IEnumerable<State>> SearchState(string? stateName = null)
        {
            return await _SetupService.SearchStateService(stateName);
        }


        [HttpPut("DeleteState")]
        public async void DeleteState(State input)
        {
            _SetupService.DeleteStateService(input);
        }


        [HttpPut("UpdateState")]
        public async void UpdateState(State input)
        {
            _SetupService.UpdateStateService(input);
        }

        [HttpPost("CreateState")]
        public async void CreateState(State input)
        {
            _SetupService.CreateStateService(input);
        }
        #endregion

        #region City
        [HttpGet("AllCity")]
        public async Task<IEnumerable<City>> AllCity()
        {
            return await _SetupService.GetAllCityService();
        }
        [HttpGet("City")]
        public async Task<IEnumerable<City>> City(int stateId)
        {
            return await _SetupService.GetCityService(stateId);
        }


        [HttpGet("SearchCity/{cityName}")]
        public async Task<IEnumerable<City>> SearchCity(string? cityName = null)
        {
            return await _SetupService.SearchCityService(cityName);
        }


        [HttpPut("DeleteCity")]
        public async void DeleteCity(City input)
        {
            _SetupService.DeleteCityService(input);
        }


        [HttpPut("UpdateCity")]
        public async void UpdateCity(City input)
        {
            _SetupService.UpdateCityService(input);
        }

        [HttpPost("CreateCity")]
        public async void CreateCity(City input)
        {
            _SetupService.CreateCityService(input);
        }
        #endregion
        #region Campaign
        [HttpGet("Campaign")]
        public async Task<IEnumerable<Campaign>> Campaign()
        {
            return await _SetupService.GetCampaignService();
        }


        [HttpGet("SearchCampaign/{campaignName}")]
        public async Task<IEnumerable<Campaign>> SearchCampaign(string? campaignName = null)
        {
            return await _SetupService.SearchCampaignService(campaignName);
        }


        [HttpPut("DeleteCampaign")]
        public async void DeleteCampaign(Campaign input)
        {
            _SetupService.DeleteCampaignService(input);
        }


        [HttpPut("UpdateCampaign")]
        public async void UpdateCampaign(Campaign input)
        {
            _SetupService.UpdateCampaignService(input);
        }

        [HttpPost("CreateCampaign")]
        public async void CreateCampaign(Campaign input)
        {
            _SetupService.CreateCampaignService(input);
        }
        #endregion

        #region Currency
        [HttpGet("Currency")]
        public async Task<IEnumerable<Currency>> Currency()
        {
            return await _SetupService.GetCurrencyService();
        }


        [HttpGet("SearchCurrency/{currencyName}")]
        public async Task<IEnumerable<Currency>> SearchCurrency(string? currencyName = null)
        {
            return await _SetupService.SearchCurrencyService(currencyName);
        }


        [HttpPut("DeleteCurrency")]
        public async void DeleteCurrency(Currency input)
        {
            _SetupService.DeleteCurrencyService(input);
        }


        [HttpPut("UpdateCurrency")]
        public async void UpdateCurrency(Currency input)
        {
            _SetupService.UpdateCurrencyService(input);
        }

        [HttpPost("CreateCurrency")]
        public async void CreateCurrency(Currency input)
        {
            _SetupService.CreateCurrencyService(input);
        }
        #endregion

       
        #region CostCenter
        [HttpGet("CostCenter")]
        public async Task<IEnumerable<CostCenter>> CostCenter()
        {
            return await _SetupService.GetCostCenterService();
        }


        [HttpGet("SearchCostCenter/{searchKeyWord}")]
        public async Task<IEnumerable<CostCenter>> SearchCostCenter(string? searchKeyWord = null)
        {
            return await _SetupService.SearchCostCenterService(searchKeyWord);
        }

        [HttpPost("CreateCostCenter")]
        public async void CreateCostCenter(CostCenter input)
        {
            _SetupService.CreateCostCenterService(input);
        }

        [HttpPut("UpdateCostCenter")]
        public async void UpdateCostCenter(CostCenter input)
        {
            _SetupService.UpdateCostCenterService(input);
        }

        [HttpPut("DeleteCostCenter")]
        public async void DeleteCostCenter(CostCenter input)
        {
            _SetupService.DeleteCostCenterService(input);
        }

        #endregion

        #region DocumentSubType
        [HttpGet("DocumentSubType")]
        public async Task<IEnumerable<DocumentSubType>> DocumentSubType()
        {
            return await _SetupService.GetDocumentSubTypeService();
        }


        [HttpGet("SearchDocumentSubType/{searchKeyWord}")]
        public async Task<IEnumerable<DocumentSubType>> SearchDocumentSubType(string? searchKeyWord = null)
        {
            return await _SetupService.SearchDocumentSubTypeService(searchKeyWord);
        }

        [HttpPost("CreateDocumentSubType")]
        public async void CreateDocumentSubType(DocumentSubType input)
        {
            _SetupService.CreateDocumentSubTypeService(input);
        }

        [HttpPut("UpdateDocumentSubType")]
        public async void UpdateDocumentSubType(DocumentSubType input)
        {
            _SetupService.UpdateDocumentSubTypeService(input);
        }

        [HttpPut("DeleteDocumentSubType")]
        public async void DeleteDocumentSubType(DocumentSubType input)
        {
            _SetupService.DeleteDocumentSubTypeService(input);
        }

        #endregion

        #region Domain
        [HttpGet("Domain")]
        public async Task<IEnumerable<Domain>> Domain()
        {
            return await _SetupService.GetDomainService();
        }


        [HttpGet("SearchDomain/{searchKeyWord}")]
        public async Task<IEnumerable<Domain>> SearchDomain(string? searchKeyWord = null)
        {
            return await _SetupService.SearchDomainService(searchKeyWord);
        }

        [HttpPost("CreateDomain")]
        public async void CreateDomain(Domain input)
        {
            _SetupService.CreateDomainService(input);
        }

        [HttpPut("UpdateDomain")]
        public async void UpdateDomain(Domain input)
        {
            _SetupService.UpdateDomainService(input);
        }

        [HttpPut("DeleteDomain")]
        public async void DeleteDomain(Domain input)
        {
            _SetupService.DeleteDomainService(input);
        }

        #endregion
        #region Designation
        [HttpGet("Designation")]
        public async Task<IEnumerable<Designation>> Designation()
        {
            return await _SetupService.GetDesignationService();
        }


        [HttpGet("SearchDesignation/{searchKeyWord}")]
        public async Task<IEnumerable<Designation>> SearchDesignation(string? searchKeyWord = null)
        {
            return await _SetupService.SearchDesignationService(searchKeyWord);
        }

        [HttpPost("CreateDesignation")]
        public async void CreateDesignation(Designation input)
        {
            _SetupService.CreateDesignationService(input);
        }

        [HttpPut("UpdateDesignation")]
        public async void UpdateDesignation(Designation input)
        {
            _SetupService.UpdateDesignationService(input);
        }

        [HttpPut("DeleteDesignation")]
        public async void DeleteDesignation(Designation input)
        {
            _SetupService.DeleteDesignationService(input);
        }

        #endregion

        #region Education Score and Education Status and Education Type
        [HttpGet("EducationScore")]
        public async Task<IEnumerable<SetupMasterDetail>> EducationScore()
        {
            return await _SetupService.GetEducationScoreService();
        }
        [HttpGet("Qualification")]
        public async Task<IEnumerable<SetupMasterDetail>> Qualification()
        {
            return await _SetupService.GetQualificationService();
        }
        [HttpGet("Nationality")]
        public async Task<IEnumerable<SetupMasterDetail>> Nationality()
        {
            return await _SetupService.GetNationalityService();
        }
        [HttpGet("MaritalStatus")]
        public async Task<IEnumerable<SetupMasterDetail>> MaritalStatus()
        {
            return await _SetupService.GetMaritalStatusService();
        }
        [HttpGet("RelationShips")]
        public async Task<IEnumerable<SetupMasterDetail>> RelationShips()
        {
            return await _SetupService.GetRelationShipService();
        }
        [HttpGet("Religion")]
        public async Task<IEnumerable<SetupMasterDetail>> Religion()
        {
            return await _SetupService.GetReligionService();
        }
        [HttpGet("EducationStatus")]
        public async Task<IEnumerable<SetupMasterDetail>> EducationStatus()
        {
            return await _SetupService.GetEducationStatusService();
        }
        [HttpGet("EducationType")]
        public async Task<IEnumerable<SetupMasterDetail>> EducationType()
        {
            return await _SetupService.GetEducationTypeService();
        }
        [HttpGet("Company")]
        public async Task<IEnumerable<SetupMasterDetail>> Company()
        {
            return await _SetupService.GetCompanyService();
        }
        [HttpGet("GetLocation")]
        public async Task<IEnumerable<SetupMasterDetail>> GetLocation()
        {
            return await _SetupService.GetLocationService();
        }
        [HttpGet("Building")]
        public async Task<IEnumerable<SetupMasterDetail>> Building()
        {
            return await _SetupService.GetBuildingService();
        }
        [HttpGet("Gender")]
        public async Task<IEnumerable<SetupMasterDetail>> Gender()
        {
            return await _SetupService.GetGenderService();
        }
        [HttpGet("Floor")]
        public async Task<IEnumerable<SetupMasterDetail>> Floor()
        {
            return await _SetupService.GetFloorService();
        }
        [HttpGet("Area")]
        public async Task<IEnumerable<SetupMasterDetail>> Area()
        {
            return await _SetupService.GetAreaService();
        }
        [HttpGet("TMSShift")]
        public async Task<IEnumerable<SetupMasterDetail>> TMSShift(int companyId)
        {
            return await _SetupService.GetTMSShiftService(companyId);
        }
        [HttpGet("JobCategory")]
        public async Task<IEnumerable<SetupMasterDetail>> JobCategory()
        {
            return await _SetupService.GetJobCategoryService();
        }
        [HttpGet("Country")]
        public async Task<IEnumerable<SetupMasterDetail>> Country()
        {
            return await _SetupService.GetCountryService();
        }
        [HttpGet("DocumentType")]
        public async Task<IEnumerable<SetupMasterDetail>> DocumentType()
        {
            return await _SetupService.GetDocumentTypeService();
        }
        [HttpGet("HODName")]
        public async Task<IEnumerable<EmployeePersonal>> HODName(int? designationId= null)
        {
            return await _SetupService.GetHODService(designationId);
        }
        [HttpGet("ManagerName")]
        public async Task<IEnumerable<EmployeePersonal>> ManagerName(int? designationId = null)
        {
            return await _SetupService.GetManagerService(designationId);
        }
        [HttpGet("InchargeName")]
        public async Task<IEnumerable<EmployeePersonal>> InchargeName(int? designationId = null)
        {
            return await _SetupService.GetInchargeNameService(designationId);
        }
        #endregion

        #region UserLoaction Mapping
        [HttpGet("GetUserLocation")]
        public async Task<IEnumerable<UserLocationMapping>> GetUserLocation()
        {
            return await _SetupService.GetUserRoleService();
        }

        [HttpPost("CreateUserLocationMapping")]
        public async void CreateUserLocationMapping(UserLocationMapping input)
        {
            _SetupService.CreateUserLocationMappingService(input);
        }


        [HttpPut("DeleteUserLocationMapping")]
        public async void DeleteUserLocationMapping(UserLocationMapping input)
        {
            _SetupService.DeleteUserLocationMappingService(input);
        }
        #endregion


        #region User BusinessUnit Mapping
        [HttpGet("GetUserBusinessUnit")]
        public async Task<IEnumerable<UserBusinessUnitMapping>> GetUserBusinessUnit()
        {
            return await _SetupService.GetUserBusinessUnitService();
        }

        [HttpPost("CreateUserBusinessUnitMapping")]
        public async void CreateUserBusinessUnitMapping(UserBusinessUnitMapping input)
        {
            _SetupService.CreateUserBusinessUnitMappingService(input);
           
        }
        

        [HttpPut("DeleteUserBusinessUnitMapping")]
        public async void DeleteUserBusinessUnitMapping(UserBusinessUnitMapping input)
        {
            _SetupService.DeleteUserBusinessUnitMappingService(input);
        }
        #endregion

        #region EmployeeType
        [HttpGet("EmployeeType")]
        public async Task<IEnumerable<EmployeeType>> EmployeeType()
        {
            return await _SetupService.GetEmployeeTypeService();
        }


        [HttpGet("SearchEmployeeType/{searchKeyWord}")]
        public async Task<IEnumerable<EmployeeType>> SearchEmployeeType(string? searchKeyWord = null)
        {
            return await _SetupService.SearchEmployeeTypeService(searchKeyWord);
        }

        [HttpPost("CreateEmployeeType")]
        public async void CreateEmployeeType(EmployeeType input)
        {
            _SetupService.CreateEmployeeTypeService(input);
        }

        [HttpPut("UpdateEmployeeType")]
        public async void UpdateEmployeeType(EmployeeType input)
        {
            _SetupService.UpdateEmployeeTypeService(input);
        }

        [HttpPut("DeleteEmployeeType")]
        public async void DeleteEmployeeType(EmployeeType input)
        {
            _SetupService.DeleteEmployeeTypeService(input);
        }

        #endregion

        #region General Setup Form
        [HttpGet("SetupMaster")]
        public async Task<IEnumerable<SetupMaster>> SetupMaster()
        {
            return await _SetupService.GetSetupMasterService();
        }

        [HttpGet("SetupDetails")]
        public async Task<IEnumerable<SetupMasterDetail>> SetupDetails(int masterId)
        {
            return await _SetupService.GetSetupDetailService(masterId);
        }
        [HttpPut("DeleteSetupMasterDetail")]
        public async void DeleteSetupMasterDetail(SetupMasterDetail input)
        {
            _SetupService.DeleteSetupDetailService(input);
        }
        [HttpPost("CreateSetupMasterDetail")]
        public async void CreateSetupMasterDetail(SetupMasterDetail input)
        {
            _SetupService.CreateSetupDetailDataDapperService(input);
        }
        [HttpPut("UpdateSetupMasterDetail")]
        public async void UpdateSetupMasterDetail(SetupMasterDetail input)
        {
            _SetupService.UpdateSetupDetailDataDapperService(input);
        }

        #endregion

      

    }
}
