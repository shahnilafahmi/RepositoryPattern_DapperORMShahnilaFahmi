using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Core.Model;
using ERP.Data.DataRepository.HomeDataDapperRepository;
using ERP.Data.DataRepository.SecurityDataDapperRepositor;
using ERP.Data.DataRepository.SetupDataDapperRepository;

namespace ERP.Application.Repositories.SetupService
{
    public interface ISetupService
    {
        Task<IEnumerable<Bank>> GetBankService();
        Task<IEnumerable<Bank>> SearchBankService( string bankDescription);
        void UpdateBankService(Bank model);
        void CreateBankService(Bank model);
        void DeleteBankService(Bank model);

        Task<IEnumerable<BusinessUnits>> GetBusinessUnitService();

        Task<IEnumerable<BusinessUnits>> SearchBusinessUnitService(string businessUnit);

        void UpdateBusinessUnitService(BusinessUnits model);

        void CreateBusinessUnitService(BusinessUnits model);

        void DeleteBusinessUnitService(BusinessUnits model);

        Task<IEnumerable<MenuItem>> GetMenuService();

        Task<IEnumerable<MenuItem>> SearchMenuService(string menuName);

        void UpdateMenuService(MenuItem model);

        void CreateMenuService(MenuItem model);

        void DeleteMenuService(MenuItem model);

        Task<IEnumerable<MenuItem>> GetParentMenuService();

        Task<IEnumerable<Applications>> GetApplicationService();

        Task<IEnumerable<MenuItemFeature>> GetFeatureService();

        Task<IEnumerable<MenuItemFeature>> SearchFeatureService(string featureName);

        void UpdateFeatureService(MenuItemFeature model);

        void CreateFeatureService(MenuItemFeature model);

        void DeleteFeatureService(MenuItemFeature model);

        Task<IEnumerable<MenuFeatureMapping>> GetFeatureByMenuService(int menuId);

        void DeleteFeatureByMenuService(int MenuItemFeatureId);

        Task<IEnumerable<Department>> GetDepartmentService();
        Task<IEnumerable<Department>> GetDepartmentByCompanyIdService(
            int companyId);
        Task<IEnumerable<Department>> SearchDepartmentService(string featureName);

        void UpdateDepartmentService(Department model);
        void CreateDepartmentService(Department model);

        void DeleteDepartmentService(Department model);

        Task<IEnumerable<City>> GetCityService(int stateId);
        Task<IEnumerable<City>> GetAllCityService();
        Task<IEnumerable<City>> SearchCityService(string cityName);
        void UpdateCityService(City model);
        void CreateCityService(City model);
        void DeleteCityService(City model);
      
        Task<IEnumerable<Campaign>> GetCampaignService();
        Task<IEnumerable<Campaign>> SearchCampaignService(string campaignName);
        void UpdateCampaignService(Campaign model);
        void CreateCampaignService(Campaign model);
        void DeleteCampaignService(Campaign model);
        Task<IEnumerable<Currency>> GetCurrencyService();
        Task<IEnumerable<Currency>> SearchCurrencyService(string campaignName);
        void UpdateCurrencyService(Currency model);
        void CreateCurrencyService(Currency model);
        void DeleteCurrencyService(Currency model);
 
        Task<IEnumerable<CostCenter>> GetCostCenterService();
        Task<IEnumerable<CostCenter>> SearchCostCenterService(string searchKeyWord);
        void UpdateCostCenterService(CostCenter model);
        void CreateCostCenterService(CostCenter model);
        void DeleteCostCenterService(CostCenter model);
       
        Task<IEnumerable<DocumentSubType>> GetDocumentSubTypeService();
        Task<IEnumerable<DocumentSubType>> SearchDocumentSubTypeService(string searchKeyWord);
        void UpdateDocumentSubTypeService(DocumentSubType model);
        void CreateDocumentSubTypeService(DocumentSubType model);
        void DeleteDocumentSubTypeService(DocumentSubType model);
        Task<IEnumerable<Domain>> GetDomainService();
        Task<IEnumerable<Domain>> SearchDomainService(string searchKeyWord);
        void UpdateDomainService(Domain model);
        void CreateDomainService(Domain model);
        void DeleteDomainService(Domain model);
    
        Task<IEnumerable<Designation>> GetDesignationService();
        Task<IEnumerable<Designation>> SearchDesignationService(string searchKeyWord);
        void UpdateDesignationService(Designation model);
        void DeleteDesignationService(Designation model);
        void CreateDesignationService(Designation model);
      
        Task<IEnumerable<EmployeeType>> GetEmployeeTypeService();
        Task<IEnumerable<EmployeeType>> SearchEmployeeTypeService(string searchKeyWord);
        void UpdateEmployeeTypeService(EmployeeType model);
        void CreateEmployeeTypeService(EmployeeType model);
        void DeleteEmployeeTypeService(EmployeeType model);
     

        Task<IEnumerable<MenuItem>> GetMenuListInApplicationService();
        Task<IEnumerable<MenuFeatureMapping>> GetMenuItemFeatureMappingService(int menuId);
        void CreateMenuFeatureMappingService(MenuFeatureMapping model);

        Task<bool> GetMenuItemFeatureMappingAlreadyExistService(int menuId, int featureId);

        #region Setup Master
        Task<IEnumerable<SetupMaster>> GetSetupMasterService();
        Task<IEnumerable<SetupMasterDetail>> GetSetupDetailService(int masterId);
        void DeleteSetupDetailService(SetupMasterDetail model);
        void CreateSetupDetailDataDapperService(SetupMasterDetail model);
        void UpdateSetupDetailDataDapperService(SetupMasterDetail model);
        #endregion
        Task<IEnumerable<SetupMasterDetail>> GetEducationScoreService();
        Task<IEnumerable<SetupMasterDetail>> GetGenderService();
        Task<IEnumerable<SetupMasterDetail>> GetQualificationService();
        Task<IEnumerable<SetupMasterDetail>> GetNationalityService();
        Task<IEnumerable<SetupMasterDetail>> GetMaritalStatusService();
        Task<IEnumerable<SetupMasterDetail>> GetReligionService();
        Task<IEnumerable<SetupMasterDetail>> GetEducationStatusService();
        Task<IEnumerable<SetupMasterDetail>> GetEducationTypeService();
        Task<IEnumerable<SetupMasterDetail>> GetCompanyService();
        Task<IEnumerable<SetupMasterDetail>> GetLocationService();
        Task<IEnumerable<SetupMasterDetail>> GetBuildingService();
        Task<IEnumerable<SetupMasterDetail>> GetFloorService();
        Task<IEnumerable<SetupMasterDetail>> GetAreaService();
        Task<IEnumerable<SetupMasterDetail>> GetTMSShiftService(
            int companyId);
        Task<IEnumerable<EmployeePersonal>> GetHODService(
            int? designationId = null);
        Task<IEnumerable<EmployeePersonal>> GetManagerService(
            int? designationId = null);
        Task<IEnumerable<EmployeePersonal>> GetInchargeNameService(
          int? designationId = null);
        Task<IEnumerable<SetupMasterDetail>> GetJobCategoryService();
        Task<IEnumerable<SetupMasterDetail>> GetCountryService();
        Task<IEnumerable<SetupMasterDetail>> GetDocumentTypeService();
        Task<IEnumerable<SetupMasterDetail>> GetRelationShipService();

        #region State
        Task<IEnumerable<State>> GetStateService(int? countryId = null);
        Task<IEnumerable<State>> SearchStateService(string stateName);
        void UpdateStateService(State model);
        void CreateStateService(State model);
        void DeleteStateService(State model);

        #endregion

        Task<IEnumerable<UserLocationMapping>> GetUserRoleService();
        void CreateUserLocationMappingService(
            UserLocationMapping model);

        void DeleteUserLocationMappingService(
            UserLocationMapping model);

        void CreateUserBusinessUnitMappingService(
            UserBusinessUnitMapping model);

        void DeleteUserBusinessUnitMappingService(
            UserBusinessUnitMapping model);

        Task<IEnumerable<UserBusinessUnitMapping>> GetUserBusinessUnitService();

  

    }
    public class SetupService : ISetupService
    {
        private readonly ISetupDataDapperRepository _setupDataDapperRepositor;

        public SetupService(
          ISetupDataDapperRepository setupDataDapperRepositor)

        {
            _setupDataDapperRepositor = setupDataDapperRepositor;
        }

         #region Bank Service
        public async Task<IEnumerable<Bank>> GetBankService()
        {
            return await _setupDataDapperRepositor.GetBankDapper();
        }

        public async Task<IEnumerable<Bank>> SearchBankService( string bankDescription)
        {
            return await _setupDataDapperRepositor.SearchBankDapper( bankDescription);
        }

        public async void UpdateBankService(Bank model)
        {
            _setupDataDapperRepositor.UpdateBankDataDapper(model);

        }

        public async void CreateBankService(Bank model)
        {
            _setupDataDapperRepositor.CreateBankDataDapper(model);

        }
        public async void DeleteBankService(Bank model)
        {
            _setupDataDapperRepositor.DeleteBankDapper(model);

        }
        #endregion

        #region Business Unit
        public async Task<IEnumerable<BusinessUnits>> GetBusinessUnitService()
        {
            return await _setupDataDapperRepositor.GetBusinessUnitDapper();
        }

        public async Task<IEnumerable<BusinessUnits>> SearchBusinessUnitService(string businessUnit)
        {
            return await _setupDataDapperRepositor.SearchBussinessUnitDapper(businessUnit);
        }

        public async void UpdateBusinessUnitService(BusinessUnits model)
        {
            _setupDataDapperRepositor.UpdateBusinessUnitDataDapper(model);

        }

        public async void CreateBusinessUnitService(BusinessUnits model)
        {
            _setupDataDapperRepositor.CreateBusinessUnitDataDapper(model);

        }
        public async void DeleteBusinessUnitService(BusinessUnits model)
        {
            _setupDataDapperRepositor.DeleteBusinessDataDapper(model);

        }
        #endregion

        #region MenuItem Setup
        public async Task<IEnumerable<MenuItem>> GetMenuService()
        {
            return await _setupDataDapperRepositor.GetMenuDapper();
        }

        public async Task<IEnumerable<MenuItem>> GetMenuListInApplicationService()
        {
            return await _setupDataDapperRepositor.GetMenuListInApplicationDapper();
        }

        public async Task<IEnumerable<MenuItem>> GetParentMenuService()
        {
            return await _setupDataDapperRepositor.GetParentMenuDapper();
        }
        public async Task<IEnumerable<Applications>> GetApplicationService()
        {
            return await _setupDataDapperRepositor.GetApplicationDapper();
        }

        public async Task<IEnumerable<MenuItem>> SearchMenuService(string menuName)
        {
            return await _setupDataDapperRepositor.SearchMenuDapper(menuName);
        }

        public async void UpdateMenuService(MenuItem model)
        {
            _setupDataDapperRepositor.UpdateMenuDataDapper(model);

        }

        public async void CreateMenuService(MenuItem model)
        {
            _setupDataDapperRepositor.CreateMenuDataDapper(model);

        }
        public async void DeleteMenuService(MenuItem model)
        {
            _setupDataDapperRepositor.DeleteMenuDapper(model);

        }
        #endregion

        #region Feature Service
        public async Task<IEnumerable<MenuItemFeature>> GetFeatureService()
        {
            return await _setupDataDapperRepositor.GetFeatureDapper();
        }

        public async Task<IEnumerable<MenuItemFeature>> SearchFeatureService(string featureName)
        {
            return await _setupDataDapperRepositor.SearchFeatureDapper(featureName);
        }

        public async void UpdateFeatureService(MenuItemFeature model)
        {
            _setupDataDapperRepositor.UpdateFeatureDataDapper(model);

        }

        public async void CreateFeatureService(MenuItemFeature model)
        {
            _setupDataDapperRepositor.CreateFeatureDataDapper(model);

        }
        public async void DeleteFeatureService(MenuItemFeature model)
        {
            _setupDataDapperRepositor.DeleteFeatureDapper(model);

        }
        #endregion

        #region MenuItemFeatureMapping
        public async Task<IEnumerable<MenuFeatureMapping>> GetFeatureByMenuService(int menuId)
        {
            return await _setupDataDapperRepositor.GetFeatureByMenuDapper(menuId);
        }

        public async void DeleteFeatureByMenuService(int MenuItemFeatureId)
        {
            _setupDataDapperRepositor.DeleteMenuItemFeatureMappingDapper(MenuItemFeatureId);

        }

        public async Task<IEnumerable<MenuFeatureMapping>> GetMenuItemFeatureMappingService(int menuId)
        {
            return await _setupDataDapperRepositor.GetMenuItemFeatureMappingDapper(menuId);
        }
        public async void CreateMenuFeatureMappingService(MenuFeatureMapping model)
        {
            _setupDataDapperRepositor.CreateMenuFeatureMappingDataDapper(model);

        }
        public async Task<bool> GetMenuItemFeatureMappingAlreadyExistService(int menuId,int featureId)
        {
            return await  _setupDataDapperRepositor.GetMenuItemFeatureMappingAlreadyExistDapper(menuId, featureId);

        }
        #endregion

        #region Department Service
        public async Task<IEnumerable<Department>> GetDepartmentService()
        {
            return await _setupDataDapperRepositor.GetDepartmentDapper();
        }
        public async Task<IEnumerable<Department>> GetDepartmentByCompanyIdService(int companyId)
        {
            return await _setupDataDapperRepositor.GetDepartmentByCompanyIdDapper(companyId);
        }

        public async Task<IEnumerable<Department>> SearchDepartmentService(string departmentName)
        {
            return await _setupDataDapperRepositor.SearchDepartmentDapper(departmentName);
        }

        public async void UpdateDepartmentService(Department model)
        {
            _setupDataDapperRepositor.UpdateDepartmentDataDapper(model);

        }

        public async void CreateDepartmentService(Department model)
        {
            _setupDataDapperRepositor.CreateDepartmentDataDapper(model);

        }
        public async void DeleteDepartmentService(Department model)
        {
            _setupDataDapperRepositor.DeleteDepartmentDapper(model);

        }
        #endregion

        #region City Service
        public async Task<IEnumerable<City>> GetAllCityService()
        {
            return await _setupDataDapperRepositor.GetAllCityDapper();
        }
        public async Task<IEnumerable<City>> GetCityService(int stateId)
        {
            return await _setupDataDapperRepositor.GetCityDapper(stateId);
        }
        public async Task<IEnumerable<City>> SearchCityService(string cityName)
        {
            return await _setupDataDapperRepositor.SearchCityDapper(cityName);
        }

        public async void UpdateCityService(City model)
        {
            _setupDataDapperRepositor.UpdateCityDataDapper(model);

        }

        public async void CreateCityService(City model)
        {
            _setupDataDapperRepositor.CreateCityDataDapper(model);

        }
        public async void DeleteCityService(City model)
        {
            _setupDataDapperRepositor.DeleteCityDapper(model);

        }
        #endregion

        #region State Service
        public async Task<IEnumerable<State>> GetStateService(int? countryId = null)
        {
            return await _setupDataDapperRepositor.GetStateDapper(countryId);
        }
        public async Task<IEnumerable<State>> SearchStateService(string stateName)
        {
            return await _setupDataDapperRepositor.SearchStateDapper(stateName);
        }

        public async void UpdateStateService(State model)
        {
            _setupDataDapperRepositor.UpdateStateDataDapper(model);

        }

        public async void CreateStateService(State model)
        {
            _setupDataDapperRepositor.CreateStateDataDapper(model);

        }
        public async void DeleteStateService(State model)
        {
            _setupDataDapperRepositor.DeleteStateDapper(model);

        }
        #endregion



        #region Campaign Service
        public async Task<IEnumerable<Campaign>> GetCampaignService()
        {
            return await _setupDataDapperRepositor.GetCampaignDapper();
        }
        public async Task<IEnumerable<Campaign>> SearchCampaignService(string campaignName)
        {
            return await _setupDataDapperRepositor.SearchCampaignDapper(campaignName);
        }

        public async void UpdateCampaignService(Campaign model)
        {
            _setupDataDapperRepositor.UpdateCampaignDataDapper(model);

        }

        public async void CreateCampaignService(Campaign model)
        {
            _setupDataDapperRepositor.CreateCampaignDataDapper(model);

        }
        public async void DeleteCampaignService(Campaign model)
        {
            _setupDataDapperRepositor.DeleteCampaignDapper(model);

        }
        #endregion

        #region Currency Service
        public async Task<IEnumerable<Currency>> GetCurrencyService()
        {
            return await _setupDataDapperRepositor.GetCurrencyDapper();
        }
        public async Task<IEnumerable<Currency>> SearchCurrencyService(string campaignName)
        {
            return await _setupDataDapperRepositor.SearchCurrencyDapper(campaignName);
        }

        public async void UpdateCurrencyService(Currency model)
        {
            _setupDataDapperRepositor.UpdateCurrencyDataDapper(model);

        }

        public async void CreateCurrencyService(Currency model)
        {
            _setupDataDapperRepositor.CreateCurrencyDataDapper(model);

        }
        public async void DeleteCurrencyService(Currency model)
        {
            _setupDataDapperRepositor.DeleteCurrencyDapper(model);

        }
        #endregion

        #region CostCenter Service
        public async Task<IEnumerable<CostCenter>> GetCostCenterService()
        {
            return await _setupDataDapperRepositor.GetCostCenterDapper();
        }
        public async Task<IEnumerable<CostCenter>> SearchCostCenterService(string searchKeyWord)
        {
            return await _setupDataDapperRepositor.SearchCostCenterDapper(searchKeyWord);
        }

        public async void UpdateCostCenterService(CostCenter model)
        {
            _setupDataDapperRepositor.UpdateCostCenterDataDapper(model);

        }

        public async void CreateCostCenterService(CostCenter model)
        {
            _setupDataDapperRepositor.CreateCostCenterDataDapper(model);

        }
        public async void DeleteCostCenterService(CostCenter model)
        {
            _setupDataDapperRepositor.DeleteCostCenterDapper(model);

        }
        #endregion

        #region DocumentSubType Service
        public async Task<IEnumerable<DocumentSubType>> GetDocumentSubTypeService()
        {
            return await _setupDataDapperRepositor.GetDocumentSubTypeDapper();
        }
        public async Task<IEnumerable<DocumentSubType>> SearchDocumentSubTypeService(string searchKeyWord)
        {
            return await _setupDataDapperRepositor.SearchDocumentSubTypeDapper(searchKeyWord);
        }

        public async void UpdateDocumentSubTypeService(DocumentSubType model)
        {
            _setupDataDapperRepositor.UpdateDocumentSubTypeDataDapper(model);

        }

        public async void CreateDocumentSubTypeService(DocumentSubType model)
        {
            _setupDataDapperRepositor.CreateDocumentSubTypeDataDapper(model);

        }
        public async void DeleteDocumentSubTypeService(DocumentSubType model)
        {
            _setupDataDapperRepositor.DeleteDocumentSubTypeDapper(model);

        }
        #endregion

        #region Domain Service
        public async Task<IEnumerable<Domain>> GetDomainService()
        {
            return await _setupDataDapperRepositor.GetDomainDapper();
        }
        public async Task<IEnumerable<Domain>> SearchDomainService(string searchKeyWord)
        {
            return await _setupDataDapperRepositor.SearchDomainDapper(searchKeyWord);
        }

        public async void UpdateDomainService(Domain model)
        {
            _setupDataDapperRepositor.UpdateDomainDataDapper(model);

        }

        public async void CreateDomainService(Domain model)
        {
            _setupDataDapperRepositor.CreateDomainDataDapper(model);

        }
        public async void DeleteDomainService(Domain model)
        {
            _setupDataDapperRepositor.DeleteDomainDapper(model);

        }
        #endregion

        #region Designation Service
        public async Task<IEnumerable<Designation>> GetDesignationService()
        {
            return await _setupDataDapperRepositor.GetDesignationDapper();
        }
        public async Task<IEnumerable<Designation>> SearchDesignationService(string searchKeyWord)
        {
            return await _setupDataDapperRepositor.SearchDesignationDapper(searchKeyWord);
        }

        public async void UpdateDesignationService(Designation model)
        {
            _setupDataDapperRepositor.UpdateDesignationDataDapper(model);

        }

        public async void CreateDesignationService(Designation model)
        {
            _setupDataDapperRepositor.CreateDesignationDataDapper(model);

        }
        public async void DeleteDesignationService(Designation model)
        {
            _setupDataDapperRepositor.DeleteDesignationDapper(model);

        }
        #endregion

        #region Education Score and Education Status and EducationType
        public async Task<IEnumerable<SetupMasterDetail>> GetEducationScoreService()
        {
            return await _setupDataDapperRepositor.GetEducationScoreDapper();
        }
        public async Task<IEnumerable<SetupMasterDetail>> GetGenderService()
        {
            return await _setupDataDapperRepositor.GetGenderDapper();
        }
        public async Task<IEnumerable<SetupMasterDetail>> GetQualificationService()
        {
            return await _setupDataDapperRepositor.GetQualificationDapper();
        }
        public async Task<IEnumerable<SetupMasterDetail>> GetNationalityService()
        {
            return await _setupDataDapperRepositor.GetNationalityDapper();
        }
        public async Task<IEnumerable<SetupMasterDetail>> GetMaritalStatusService()
        {
            return await _setupDataDapperRepositor.GetMaritalStatusDapper();
        }
        public async Task<IEnumerable<SetupMasterDetail>> GetReligionService()
        {
            return await _setupDataDapperRepositor.GetReligionDapper();
        }
        public async Task<IEnumerable<SetupMasterDetail>> GetRelationShipService()
        {
            return await _setupDataDapperRepositor.GetRelationShipDapper();
        }
        public async Task<IEnumerable<SetupMasterDetail>> GetEducationStatusService()
        {
            return await _setupDataDapperRepositor.GetEducationStatusDapper();
        }
        public async Task<IEnumerable<SetupMasterDetail>> GetEducationTypeService()
        {
            return await _setupDataDapperRepositor.GetEducationTypeDapper();
        }
        public async Task<IEnumerable<SetupMasterDetail>> GetCompanyService()
        {
            return await _setupDataDapperRepositor.GetCompanyDapper();
        }
        public async Task<IEnumerable<SetupMasterDetail>> GetLocationService()
        {
            return await _setupDataDapperRepositor.GetLocationDapper();
        }
        public async Task<IEnumerable<SetupMasterDetail>> GetBuildingService()
        {
            return await _setupDataDapperRepositor.GetBuildingDapper();
        }
        public async Task<IEnumerable<SetupMasterDetail>> GetFloorService()
        {
            return await _setupDataDapperRepositor.GetFloorDapper();
        }
        public async Task<IEnumerable<SetupMasterDetail>> GetAreaService()
        {
            return await _setupDataDapperRepositor.GetAreaDapper();
        }
        public async Task<IEnumerable<SetupMasterDetail>> GetTMSShiftService(int companyId)
        {
            return await _setupDataDapperRepositor.GetTMSShiftDapper(companyId);
        }
        public async Task<IEnumerable<EmployeePersonal>> GetHODService(int? designationId = null)
        {
            return await _setupDataDapperRepositor.GetHODNameDapper(designationId);
        }
        public async Task<IEnumerable<EmployeePersonal>> GetManagerService(int? designationId = null)
        {
            return await _setupDataDapperRepositor.GetManagerNameDapper(designationId);
        }
        public async Task<IEnumerable<EmployeePersonal>> GetInchargeNameService(int? designationId = null)
        {
            return await _setupDataDapperRepositor.GetInchargeNameDapper(designationId);
        }
        
        public async Task<IEnumerable<SetupMasterDetail>> GetJobCategoryService()
        {
            return await _setupDataDapperRepositor.GetJobCategoryDapper();
        }
        public async Task<IEnumerable<SetupMasterDetail>> GetCountryService()
        {
            return await _setupDataDapperRepositor.GetCountryDapper();
        }
        public async Task<IEnumerable<SetupMasterDetail>> GetDocumentTypeService()
        {
            return await _setupDataDapperRepositor.GetDocumentTypeDapper();
        }
        #endregion

        #region UserLocationMapping
        public async void CreateUserLocationMappingService(UserLocationMapping model)
        {
            _setupDataDapperRepositor.CreateUserLocationMappingDataDapper(model);
        }
        public async void DeleteUserLocationMappingService(UserLocationMapping model)
        {
            _setupDataDapperRepositor.DeleteUserLocationDataDapper(model);
        }
        public async Task<IEnumerable<UserLocationMapping>> GetUserRoleService()
        {
            return await _setupDataDapperRepositor.GetUserRoleDetailDapper();
        }
        #endregion

        #region UserBusinessUnitMapping
        public async void CreateUserBusinessUnitMappingService(UserBusinessUnitMapping model)
        {
            _setupDataDapperRepositor.CreateUserBusinessUnitMappingDataDapper(model);
        }
        public async void DeleteUserBusinessUnitMappingService(UserBusinessUnitMapping model)
        {
            _setupDataDapperRepositor.DeleteUserBusinessUnitDataDapper(model);
        }
        public async Task<IEnumerable<UserBusinessUnitMapping>> GetUserBusinessUnitService()
        {
            return await _setupDataDapperRepositor.GetUserBusinessUnitDetailDapper();
        }
        #endregion

        #region EmployeeType
        public async Task<IEnumerable<EmployeeType>> GetEmployeeTypeService()
        {
            return await _setupDataDapperRepositor.GetEmployeeTypeDapper();
        }
        public async Task<IEnumerable<EmployeeType>> SearchEmployeeTypeService(string searchKeyWord)
        {
            return await _setupDataDapperRepositor.SearchEmployeeTypeDapper(searchKeyWord);
        }

        public async void UpdateEmployeeTypeService(EmployeeType model)
        {
            _setupDataDapperRepositor.UpdateEmployeeTypeDataDapper(model);

        }

        public async void CreateEmployeeTypeService(EmployeeType model)
        {
            _setupDataDapperRepositor.CreateEmployeeTypeDataDapper(model);

        }
        public async void DeleteEmployeeTypeService(EmployeeType model)
        {
            _setupDataDapperRepositor.DeleteEmployeeTypeDapper(model);

        }
        #endregion


        #region Setup Master
        public async Task<IEnumerable<SetupMaster>> GetSetupMasterService()
        {
            return await _setupDataDapperRepositor.GetSetUpMasterDapper();
        }
        public async Task<IEnumerable<SetupMasterDetail>> GetSetupDetailService(int masterId)
        {
            return await _setupDataDapperRepositor.GetSetupDetailDapper(masterId);
        }
        public async void DeleteSetupDetailService(SetupMasterDetail model)
        {
           _setupDataDapperRepositor.DeleteSetupDetailDapper(model);
        }
        public async void CreateSetupDetailDataDapperService(SetupMasterDetail model)
        {
            _setupDataDapperRepositor.CreateSetupDetailDataDapper(model);
        }
        public async void UpdateSetupDetailDataDapperService(SetupMasterDetail model)
        {
            _setupDataDapperRepositor.UpdateSetupDetailDataDapper(model);
        }
        #endregion

       


    }
}
