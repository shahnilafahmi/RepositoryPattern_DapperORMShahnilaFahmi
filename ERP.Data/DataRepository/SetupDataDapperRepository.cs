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

namespace ERP.Data.DataRepository.SetupDataDapperRepository
{
    public interface ISetupDataDapperRepository
    {
        Task<IEnumerable<Bank>> GetBankDapper();

        Task<IEnumerable<Bank>> SearchBankDapper( string bankDescription);

        void CreateBankDataDapper(Bank model);

        void UpdateBankDataDapper(Bank model);

        void DeleteBankDapper(Bank model);

        Task<IEnumerable<BusinessUnits>> GetBusinessUnitDapper();

        Task<IEnumerable<BusinessUnits>> SearchBussinessUnitDapper(string businessUnit);

        void  CreateBusinessUnitDataDapper(BusinessUnits model);
        void UpdateBusinessUnitDataDapper(BusinessUnits model);

        void DeleteBusinessDataDapper(BusinessUnits model);

        Task<IEnumerable<MenuItem>> GetMenuDapper();

        Task<IEnumerable<MenuItem>> SearchMenuDapper(string menuName);

        void CreateMenuDataDapper(MenuItem model);

        void UpdateMenuDataDapper(MenuItem model);

        void DeleteMenuDapper(MenuItem model);

        Task<IEnumerable<MenuItem>> GetParentMenuDapper();

        Task<IEnumerable<Applications>> GetApplicationDapper();

        Task<IEnumerable<MenuItemFeature>> GetFeatureDapper();

        Task<IEnumerable<MenuItemFeature>> SearchFeatureDapper(string featureName);

        void CreateFeatureDataDapper(MenuItemFeature model);

        void UpdateFeatureDataDapper(MenuItemFeature model);

        void DeleteFeatureDapper(MenuItemFeature model);

        Task<IEnumerable<MenuFeatureMapping>> GetFeatureByMenuDapper(int menuId);

        void DeleteMenuItemFeatureMappingDapper(int menuItemFeatureId);

      
        Task<IEnumerable<Department>> GetDepartmentDapper();
        Task<IEnumerable<Department>> GetDepartmentByCompanyIdDapper(
            int companyId);

        Task<IEnumerable<Department>> SearchDepartmentDapper(string departmentName);

        void CreateDepartmentDataDapper(Department model);
        void UpdateDepartmentDataDapper(Department model);

        void DeleteDepartmentDapper(Department model);
        Task<IEnumerable<City>> GetCityDapper(int stateId);
        Task<IEnumerable<City>> GetAllCityDapper();
        Task<IEnumerable<City>> SearchCityDapper(string cityName);
        void CreateCityDataDapper(City model);
        void UpdateCityDataDapper(City model);
        void DeleteCityDapper(City model);
     
        Task<IEnumerable<Campaign>> GetCampaignDapper();
        Task<IEnumerable<Campaign>> SearchCampaignDapper(string campaignName);
        void CreateCampaignDataDapper(Campaign model);
        void UpdateCampaignDataDapper(Campaign model);
        void DeleteCampaignDapper(Campaign model);
        Task<IEnumerable<Currency>> GetCurrencyDapper();
        Task<IEnumerable<Currency>> SearchCurrencyDapper(string currencyName);
        void CreateCurrencyDataDapper(Currency model);
        void UpdateCurrencyDataDapper(Currency model);
        void DeleteCurrencyDapper(Currency model);
        Task<IEnumerable<VisaType>> GetVisaTypeDapper();
        Task<IEnumerable<VisaType>> SearchVisaTypeDapper(string visaTypeName);
        void CreateVisaTypeDataDapper(VisaType model);
        void UpdateVisaTypeDataDapper(VisaType model);
        void DeleteVisaTypeDapper(VisaType model);
        Task<IEnumerable<CostCenter>> GetCostCenterDapper();
        Task<IEnumerable<CostCenter>> SearchCostCenterDapper(string costCenterName);
        void CreateCostCenterDataDapper(CostCenter model);
        void UpdateCostCenterDataDapper(CostCenter model);
        void DeleteCostCenterDapper(CostCenter model);
       
        Task<IEnumerable<DocumentSubType>> GetDocumentSubTypeDapper();
        Task<IEnumerable<DocumentSubType>> SearchDocumentSubTypeDapper(string documentsubType);
        void CreateDocumentSubTypeDataDapper(DocumentSubType model);
        void UpdateDocumentSubTypeDataDapper(DocumentSubType model);
        void DeleteDocumentSubTypeDapper(DocumentSubType model);
        Task<IEnumerable<Domain>> GetDomainDapper();
        Task<IEnumerable<Domain>> SearchDomainDapper(string searchKeyword);
        void CreateDomainDataDapper(Domain model);
        void UpdateDomainDataDapper(Domain model);
        void DeleteDomainDapper(Domain model);
      
        Task<IEnumerable<Designation>> GetDesignationDapper();
        Task<IEnumerable<Designation>> SearchDesignationDapper(string searchKeyword);
        void CreateDesignationDataDapper(Designation model);
        void DeleteDesignationDapper(Designation model);
        void UpdateDesignationDataDapper(Designation model);
     
      
        Task<IEnumerable<EmployeeType>> GetEmployeeTypeDapper();
        Task<IEnumerable<EmployeeType>> SearchEmployeeTypeDapper(string searchKeyword);
        void CreateEmployeeTypeDataDapper(EmployeeType model);
        void UpdateEmployeeTypeDataDapper(EmployeeType model);
        void DeleteEmployeeTypeDapper(EmployeeType model);
    
      
        Task<IEnumerable<MenuItem>> GetMenuListInApplicationDapper();
        Task<IEnumerable<MenuFeatureMapping>> GetMenuItemFeatureMappingDapper(int menuId);
        void CreateMenuFeatureMappingDataDapper(MenuFeatureMapping model);
        Task<Boolean> GetMenuItemFeatureMappingAlreadyExistDapper(int menuItemId, int featureId);

        #region SetupMaster
        Task<IEnumerable<SetupMaster>> GetSetUpMasterDapper();
        Task<IEnumerable<SetupMasterDetail>> GetSetupDetailDapper(int masterId);
        void DeleteSetupDetailDapper(SetupMasterDetail model);
        void CreateSetupDetailDataDapper(SetupMasterDetail model);
        void UpdateSetupDetailDataDapper(SetupMasterDetail model);
        #endregion

        Task<IEnumerable<SetupMasterDetail>> GetEducationScoreDapper();
        Task<IEnumerable<SetupMasterDetail>> GetGenderDapper();
        Task<IEnumerable<SetupMasterDetail>> GetQualificationDapper();
        Task<IEnumerable<SetupMasterDetail>> GetNationalityDapper();
        Task<IEnumerable<SetupMasterDetail>> GetReligionDapper();
        Task<IEnumerable<SetupMasterDetail>> GetMaritalStatusDapper();
        Task<IEnumerable<SetupMasterDetail>> GetEducationStatusDapper();
        Task<IEnumerable<SetupMasterDetail>> GetEducationTypeDapper();
        Task<IEnumerable<SetupMasterDetail>> GetCompanyDapper();
        Task<IEnumerable<SetupMasterDetail>> GetLocationDapper();
        Task<IEnumerable<SetupMasterDetail>> GetBuildingDapper(); 
        Task<IEnumerable<SetupMasterDetail>> GetFloorDapper();
        Task<IEnumerable<SetupMasterDetail>> GetAreaDapper();
        Task<IEnumerable<SetupMasterDetail>> GetTMSShiftDapper(
            int companyId);
        Task<IEnumerable<EmployeePersonal>> GetHODNameDapper(
            int? designationId = null);
        Task<IEnumerable<EmployeePersonal>> GetManagerNameDapper(
            int? designationId = null);
        Task<IEnumerable<EmployeePersonal>> GetInchargeNameDapper(
            int? designationId = null);
    
        Task<IEnumerable<SetupMasterDetail>> GetJobCategoryDapper();
        Task<IEnumerable<SetupMasterDetail>> GetCountryDapper();
        Task<IEnumerable<SetupMasterDetail>> GetDocumentTypeDapper();
        Task<IEnumerable<SetupMasterDetail>> GetRelationShipDapper();

        #region State
        Task<IEnumerable<State>> GetStateDapper(int? countryId = null);
        Task<IEnumerable<State>> SearchStateDapper(string stateName);
        void CreateStateDataDapper(State model);
        void UpdateStateDataDapper(State model);
        void DeleteStateDapper(State model);

        #endregion

        #region UserLocationMapping
        void CreateUserLocationMappingDataDapper(
            UserLocationMapping model);

        Task<IEnumerable<UserLocationMapping>> GetUserRoleDetailDapper();

        void DeleteUserLocationDataDapper(
            UserLocationMapping model);
        #endregion

        #region UserBusinessUnitMapping
        void CreateUserBusinessUnitMappingDataDapper(
            UserBusinessUnitMapping model);

        Task<IEnumerable<UserBusinessUnitMapping>> GetUserBusinessUnitDetailDapper();

        void DeleteUserBusinessUnitDataDapper(UserBusinessUnitMapping model);

        #endregion

 
    }

    public class SetupDataDapperRepository : ISetupDataDapperRepository

    {
        private string connectionString = "";

        private readonly DapperManager dapperManager;


        public SetupDataDapperRepository()
        {

            connectionString = GenericConstants.ConnectionStringDB1;
            dapperManager = new DapperManager(connectionString);
        }

        public IDbConnection _Connection
        {
            get {
                return new SqlConnection(connectionString);
            }
        }

        #region Bank
        public async Task<IEnumerable<Bank>> GetBankDapper()
        {
            var queryParameters = new DynamicParameters();
            var spName = "usp_Bank_Get_BankList";

            Bank role = new Bank();
            IEnumerable<Bank> results = await dapperManager.QueryList(role, spName, queryParameters);
            return results;

        }
        public async Task<IEnumerable<Bank>> SearchBankDapper( string bankDescription)
        {
            var queryParameters = new DynamicParameters();
          
            queryParameters.Add("@BankDescription", bankDescription);

            var spName = "usp_Bank_Get_SearchBank";

            Bank role = new Bank();
            IEnumerable<Bank> results = await dapperManager.QueryList(role, spName, queryParameters);
            return results;

        }

        public async void CreateBankDataDapper(Bank model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
           
            queryParameters.Add("@BankPrefix", model.BankPrefix);
            queryParameters.Add("@BankDescription", model.BankDescription);
            queryParameters.Add("@CreatedBy", model.CreatedBy);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_Bank_CreateBank";

            dapperManager.InsertQuery(spName, queryParameters);
        }

        public async void UpdateBankDataDapper(Bank model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@BankId", model.BankId);
            queryParameters.Add("@BankPrefix", model.BankPrefix);
            queryParameters.Add("@BankDescription", model.BankDescription);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_Bank_UpdateBank";

            dapperManager.UpdateRecord(spName, queryParameters);
        }

        public async void DeleteBankDapper(Bank model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@BankId", model.BankId);
            queryParameters.Add("@UserIp", UserIP);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@ModifiedDate", model.ModifiedDate);

            var spName = "usp_Bank_DeleteBank";

            dapperManager.UpdateRecord(spName, queryParameters);
        }
        #endregion

        #region Business Unit
        public async Task<IEnumerable<BusinessUnits>> GetBusinessUnitDapper()
        {
            var queryParameters = new DynamicParameters();
            var spName = "usp_BusinessUnit_Get_BUList";

            BusinessUnits model = new BusinessUnits();
            IEnumerable<BusinessUnits> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }
        public async Task<IEnumerable<BusinessUnits>> SearchBussinessUnitDapper(string businessUnit)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@BusinessUnit", businessUnit);
          

            var spName = "usp_BusinessUnit_Get_SearchBU";

            BusinessUnits model = new BusinessUnits();
            IEnumerable<BusinessUnits> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }

        public async void CreateBusinessUnitDataDapper(BusinessUnits model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();

            queryParameters.Add("@CompanyId", model.CompanyId);
            queryParameters.Add("@BusinessUnit", model.BusinessUnit);
            queryParameters.Add("@CreatedBy", model.CreatedBy);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_BusinessUnit_CreateBusinessUnit";

            dapperManager.InsertQuery(spName, queryParameters);
        }

        public async void UpdateBusinessUnitDataDapper(BusinessUnits model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@BusinessUnitId", model.BusinessUnitId);
            queryParameters.Add("@CompanyId", model.CompanyId);
            queryParameters.Add("@BusinessUnit", model.BusinessUnit);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_BusinessUnit_UpdateBU";

            dapperManager.UpdateRecord(spName, queryParameters);
        }

        public async void DeleteBusinessDataDapper(BusinessUnits model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@BusinessUnitId", model.BusinessUnitId);
            queryParameters.Add("@UserIp", UserIP);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
           
            var spName = "usp_BusinessUnit_DeleteBusinessUnit";

            dapperManager.UpdateRecord(spName, queryParameters);
        }
        #endregion

        #region Menu Item
        public async Task<IEnumerable<MenuItem>> GetMenuDapper()
        {
            var queryParameters = new DynamicParameters();
            var spName = "usp_MenuItem_Get_MenuItemList";

            MenuItem model = new MenuItem();
            IEnumerable<MenuItem> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }
        public async Task<IEnumerable<MenuItem>> GetMenuListInApplicationDapper()
        {
            var queryParameters = new DynamicParameters();
            var spName = "usp_MenuItem_Get_MenuItem";

            MenuItem model = new MenuItem();
            IEnumerable<MenuItem> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }
        public async Task<IEnumerable<Applications>> GetApplicationDapper()
        {
            var queryParameters = new DynamicParameters();
            var spName = "usp_Application_Get_ApplicationList";

            Applications model = new Applications();
            IEnumerable<Applications> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }
        public async Task<IEnumerable<MenuItem>> GetParentMenuDapper()
        {
            var queryParameters = new DynamicParameters();
            var spName = "usp_MenuItem_Get_ParentMenuItemList";

            MenuItem model = new MenuItem();
            IEnumerable<MenuItem> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }
        public async Task<IEnumerable<MenuItem>> SearchMenuDapper(string menuName)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@MenuName", menuName);

            var spName = "usp_MenuItem_Get_SearchMenu";

            MenuItem model = new MenuItem();
            IEnumerable<MenuItem> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }

        public async void CreateMenuDataDapper(MenuItem model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

           
            if (model.ParentId != null || model.ParentId > 0)
            {
                model.SubNode = "###";
            }
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@MenuName", model.MenuName);
            queryParameters.Add("@MenuURL", model.MenuURL);
            queryParameters.Add("@ParentId", model.ParentId);
            queryParameters.Add("@SubNode", model.SubNode);
            queryParameters.Add("@SortOrder", model.SortOrder);
            queryParameters.Add("@CreatedBy", model.CreatedBy);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);
            queryParameters.Add("@ApplicationId", model.ApplicationId);

            var spName = "usp_MenuItem_CreateMenuItem";

            dapperManager.InsertQuery(spName, queryParameters);
        }

        public async void UpdateMenuDataDapper(MenuItem model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            if (model.ParentId != null || model.ParentId > 0)
            {
                model.SubNode = "###";
            }

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@MenuId", model.MenuId);
            queryParameters.Add("@MenuName", model.MenuName);
            queryParameters.Add("@ParentId", model.ParentId);
            queryParameters.Add("@SubNode", model.SubNode);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);
            queryParameters.Add("@ApplicationId", model.ApplicationId);
            
            var spName = "usp_MenuItem_UpdateMenuItem";

            dapperManager.UpdateRecord(spName, queryParameters);
        }

        public async void DeleteMenuDapper(MenuItem model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@MenuId", model.MenuId);
            queryParameters.Add("@UserIp", UserIP);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
           
           var spName = "usp_MenuItem_DeleteMenuItem";

            dapperManager.UpdateRecord(spName, queryParameters);
        }
        #endregion

        #region Feature Setup
        public async Task<IEnumerable<MenuItemFeature>> GetFeatureDapper()
        {
            var queryParameters = new DynamicParameters();
            var spName = "usp_Feature_Get_FeatureList";

            MenuItemFeature model = new MenuItemFeature();
            IEnumerable<MenuItemFeature> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }
        public async Task<IEnumerable<MenuItemFeature>> SearchFeatureDapper(string featureName)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@Feature", featureName);

            var spName = "usp_MenuItemFeature_Get_SearchMenuItemFeature";

            MenuItemFeature model = new MenuItemFeature();
            IEnumerable<MenuItemFeature> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }

        public async void CreateFeatureDataDapper(MenuItemFeature model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();

            queryParameters.Add("@Feature", model.Feature);
            queryParameters.Add("@CreatedBy", model.CreatedBy);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_MenuItemFeature_CreateMenuItemFeature";

            dapperManager.InsertQuery(spName, queryParameters);
        }

        public async void UpdateFeatureDataDapper(MenuItemFeature model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@FeatureId", model.FeatureId);
            queryParameters.Add("@Feature", model.Feature);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_MenuItemFeature_UpdateMenuItemFeature";

            dapperManager.UpdateRecord(spName, queryParameters);
        }

        public async void DeleteFeatureDapper(MenuItemFeature model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@FeatureId", model.FeatureId);
            queryParameters.Add("@UserIp", UserIP);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
          
            var spName = "usp_MenuItemFeature_DeleteMenuItemFeature";

            dapperManager.UpdateRecord(spName, queryParameters);
        }
        #endregion

        #region MenuFeatureMapping
        public async Task<IEnumerable<MenuFeatureMapping>> GetFeatureByMenuDapper(int menuId)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@MenuId", menuId);

            var spName = "usp_MenuItemFeature_GetMenuItemFeatureMapping";

            MenuFeatureMapping model = new MenuFeatureMapping();
            IEnumerable<MenuFeatureMapping> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }

        public async void DeleteMenuItemFeatureMappingDapper(int menuItemFeatureId)
        {
           
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@MenuItemFeatureId", menuItemFeatureId);
           

            var spName = "usp_MenuItemFeature_DeleteMenuItemFeatureMapping";

            dapperManager.DeleteRecord(spName, queryParameters);
        }
        #endregion

        #region Department Setup
        public async Task<IEnumerable<Department>> GetDepartmentDapper()
        {
            var queryParameters = new DynamicParameters();
            var spName = "usp_Department_Get_DepartmentList";

            Department model = new Department();
            IEnumerable<Department> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }
        public async Task<IEnumerable<Department>> GetDepartmentByCompanyIdDapper(int companyId)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@CompanyId ", companyId);

            var spName = "usp_Department_Get_DepartmentNyCompnayId";

            Department model = new Department();
            IEnumerable<Department> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }
        public async Task<IEnumerable<Department>> SearchDepartmentDapper(string departmentName)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@DepartmentName", departmentName);

            var spName = "usp_Department_Get_Search_Department";

            Department model = new Department();
            IEnumerable<Department> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }

        public async void CreateDepartmentDataDapper(Department model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();

            queryParameters.Add("@DepartmentName", model.DepartmentName);
            queryParameters.Add("@BusinessUnitId", model.BusinessUnitId);
            queryParameters.Add("@CompanyId", model.CompanyId);
            queryParameters.Add("@CreatedBy", model.CreatedBy);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_Department_CreateDepartment";

            dapperManager.InsertQuery(spName, queryParameters);
        }

        public async void UpdateDepartmentDataDapper(Department model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@DepartmentId", model.DepartmentId);
            queryParameters.Add("@BusinessUnitId", model.BusinessUnitId);
            queryParameters.Add("@DepartmentName", model.DepartmentName);
            queryParameters.Add("@CompanyId", model.CompanyId);
            
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_Department_UpdateDepartment";

            dapperManager.UpdateRecord(spName, queryParameters);
        }

        public async void DeleteDepartmentDapper(Department model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@DepartmentId", model.DepartmentId);
            queryParameters.Add("@UserIp", UserIP);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);

            var spName = "usp_Department_DeleteDepartment";

            dapperManager.UpdateRecord(spName, queryParameters);
        }
        #endregion



        #region City Setup
        public async Task<IEnumerable<City>> GetCityDapper(int stateId)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@StateId", stateId);
            var spName = "usp_City_Get_CityList";

            City model = new City();
            IEnumerable<City> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }
        public async Task<IEnumerable<City>> GetAllCityDapper()
        {
            var queryParameters = new DynamicParameters();
            
            var spName = "usp_City_GetAll_CityList";

            City model = new City();
            IEnumerable<City> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }

        public async Task<IEnumerable<City>> SearchCityDapper(string cityName)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@CityName", cityName);

            var spName = "usp_City_Get_Search_City";

            City model = new City();
            IEnumerable<City> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }

        public async void CreateCityDataDapper(City model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();

            queryParameters.Add("@CityName", model.CityName);
            queryParameters.Add("@StateId", model.StateId);
            queryParameters.Add("@CreatedBy", model.CreatedBy);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_City_CreateCity";

            dapperManager.InsertQuery(spName, queryParameters);
        }

        public async void UpdateCityDataDapper(City model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@CityId", model.CityId);
            queryParameters.Add("@StateId", model.StateId);
            queryParameters.Add("@CityName", model.CityName);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_City_UpdateCity";

            dapperManager.UpdateRecord(spName, queryParameters);
        }

        public async void DeleteCityDapper(City model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@CityId", model.CityId);
            queryParameters.Add("@UserIp", UserIP);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);

            var spName = "usp_City_DeleteCity";

            dapperManager.UpdateRecord(spName, queryParameters);
        }
        #endregion

        #region State Setup
        public async Task<IEnumerable<State>> GetAllStateDapper()
        {
            var queryParameters = new DynamicParameters();
            var spName = "usp_State_Get_StateList"; 

            State model = new State();
            IEnumerable<State> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }
        public async Task<IEnumerable<State>> GetStateDapper(int? countryId = null)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@CountryId", countryId);

            var spName = "usp_State_Get_StateList";

            State model = new State();
            IEnumerable<State> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }

        public async Task<IEnumerable<State>> SearchStateDapper(string stateName)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@StateName", stateName);

            var spName = "usp_State_Get_Search_State";

            State model = new State();
            IEnumerable<State> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }

        public async void CreateStateDataDapper(State model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();

            queryParameters.Add("@StateName", model.StateName);
            queryParameters.Add("@CountryId", model.CountryId);
            queryParameters.Add("@CreatedBy", model.CreatedBy);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_State_CreateState";

            dapperManager.InsertQuery(spName, queryParameters);
        }

        public async void UpdateStateDataDapper(State model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@StateId", model.StateId);
            queryParameters.Add("@CountryId", model.CountryId);
            queryParameters.Add("@StateName", model.StateName);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_State_UpdateState";

            dapperManager.UpdateRecord(spName, queryParameters);
        }

        public async void DeleteStateDapper(State model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@StateId", model.StateId);
            queryParameters.Add("@UserIp", UserIP);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);

            var spName = "usp_State_DeleteState";

            dapperManager.UpdateRecord(spName, queryParameters);
        }
        #endregion

        #region Campaign Setup
        public async Task<IEnumerable<Campaign>> GetCampaignDapper()
        {
            var queryParameters = new DynamicParameters();
            var spName = "usp_Campaign_Get_CampaignList";

            Campaign model = new Campaign();
            IEnumerable<Campaign> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }

        public async Task<IEnumerable<Campaign>> SearchCampaignDapper(string campaignName)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@CampaignName", campaignName);

            var spName = "usp_Campaign_Get_Search_Campaign";

            Campaign model = new Campaign();
            IEnumerable<Campaign> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }

        public async void CreateCampaignDataDapper(Campaign model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();

            queryParameters.Add("@CampaignName", model.CampaignName);
            queryParameters.Add("@DepartmentId", model.DepartmentId);
            queryParameters.Add("@CreatedBy", model.CreatedBy);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_Campaign_CreateCampaign";

            dapperManager.InsertQuery(spName, queryParameters);
        }

        public async void UpdateCampaignDataDapper(Campaign model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@CampaignId", model.CampaignId);
            queryParameters.Add("@DepartmentId", model.DepartmentId);
            queryParameters.Add("@CampaignName", model.CampaignName);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_Campaign_UpdateCampaign";

            dapperManager.UpdateRecord(spName, queryParameters);
        }

        public async void DeleteCampaignDapper(Campaign model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@CampaignId", model.CampaignId);
            queryParameters.Add("@UserIp", UserIP);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);

            var spName = "usp_Campaign_DeleteCampaign";

            dapperManager.UpdateRecord(spName, queryParameters);
        }
        #endregion

        #region Currency Setup
        public async Task<IEnumerable<Currency>> GetCurrencyDapper()
        {
            var queryParameters = new DynamicParameters();
            var spName = "usp_Currency_Get_CurrencyList";

            Currency model = new Currency();
            IEnumerable<Currency> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }

        public async Task<IEnumerable<Currency>> SearchCurrencyDapper(string currencyName)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@CurrencyName", currencyName);

            var spName = "usp_Currency_Get_Search_Currency";

            Currency model = new Currency();
            IEnumerable<Currency> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }

        public async void CreateCurrencyDataDapper(Currency model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();

            queryParameters.Add("@CurrencyName", model.CurrencyName);
            queryParameters.Add("@CurrencyCode", model.CurrencyCode);
            queryParameters.Add("@ExchangeRate", model.ExchangeRate);
            queryParameters.Add("@CreatedBy", model.CreatedBy);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_Currency_CreateCurrency";

            dapperManager.InsertQuery(spName, queryParameters);
        }

        public async void UpdateCurrencyDataDapper(Currency model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@CurrencyId", model.CurrencyId);
            queryParameters.Add("@CurrencyName", model.CurrencyName);
            queryParameters.Add("@CurrencyCode", model.CurrencyCode);
            queryParameters.Add("@ExchangeRate", model.ExchangeRate);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_Currency_UpdateCurrency";

            dapperManager.UpdateRecord(spName, queryParameters);
        }

        public async void DeleteCurrencyDapper(Currency model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@CurrencyId", model.CurrencyId);
            queryParameters.Add("@UserIp", UserIP);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);

            var spName = "usp_Currency_DeleteCurrency";

            dapperManager.UpdateRecord(spName, queryParameters);
        }
        #endregion

        #region VisaType Setup
        public async Task<IEnumerable<VisaType>> GetVisaTypeDapper()
        {
            var queryParameters = new DynamicParameters();
            var spName = "usp_VisaType_Get_VisaTypeList";

            VisaType model = new VisaType();
            IEnumerable<VisaType> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }

        public async Task<IEnumerable<VisaType>> SearchVisaTypeDapper(string visaTypeName)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@VisaName", visaTypeName);

            var spName = "usp_VisaType_Get_Search_VisaType";

            VisaType model = new VisaType();
            IEnumerable<VisaType> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }

        public async void CreateVisaTypeDataDapper(VisaType model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();

            queryParameters.Add("@VisaName", model.VisaName);
            queryParameters.Add("@CreatedBy", model.CreatedBy);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_VisaType_CreateVisaType";

            dapperManager.InsertQuery(spName, queryParameters);
        }

        public async void UpdateVisaTypeDataDapper(VisaType model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@VisaTypeId", model.VisaTypeId);
            queryParameters.Add("@VisaName", model.VisaName);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_VisaType_UpdateVisaType";

            dapperManager.UpdateRecord(spName, queryParameters);
        }

        public async void DeleteVisaTypeDapper(VisaType model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@VisaTypeId", model.VisaTypeId);
            queryParameters.Add("@UserIp", UserIP);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);

            var spName = "usp_VisaType_DeleteVisaType";

            dapperManager.UpdateRecord(spName, queryParameters);
        }
        #endregion

        #region CostCenter Setup
        public async Task<IEnumerable<CostCenter>> GetCostCenterDapper()
        {
            var queryParameters = new DynamicParameters();
            var spName = "usp_CostCenter_Get_CostCenterList";

            CostCenter model = new CostCenter();
            IEnumerable<CostCenter> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }

        public async Task<IEnumerable<CostCenter>> SearchCostCenterDapper(string searchKeyWord)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@Search", searchKeyWord);

            var spName = "usp_CostCenter_Get_Search_CostCenter";

            CostCenter model = new CostCenter();
            IEnumerable<CostCenter> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }

        public async void CreateCostCenterDataDapper(CostCenter model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();

            queryParameters.Add("@CostCenterName", model.CostCenterName);
            queryParameters.Add("@CostCenterCode", model.CostCenterCode);
            queryParameters.Add("@CompanyId", model.CompanyId);
            queryParameters.Add("@CreatedBy", model.CreatedBy);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_CostCenter_CreateCostCenter";

            dapperManager.InsertQuery(spName, queryParameters);
        }

        public async void UpdateCostCenterDataDapper(CostCenter model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@CostCenterId", model.CostCenterId);
            queryParameters.Add("@CompanyId", model.CompanyId);
            queryParameters.Add("@CostCenterName", model.CostCenterName);
            queryParameters.Add("@CostCenterCode", model.CostCenterCode);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_CostCenter_UpdateCostCenter";

            dapperManager.UpdateRecord(spName, queryParameters);
        }

        public async void DeleteCostCenterDapper(CostCenter model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@CostCenterId", model.CostCenterId);
            queryParameters.Add("@UserIp", UserIP);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);

            var spName = "usp_CostCenter_DeleteCostCenter";

            dapperManager.UpdateRecord(spName, queryParameters);
        }
        #endregion

        
        #region DocumentSubType Setup
        public async Task<IEnumerable<DocumentSubType>> GetDocumentSubTypeDapper()
        {
            var queryParameters = new DynamicParameters();
            var spName = "usp_DocumentSubType_Get_DocumentSubTypeList";

            DocumentSubType model = new DocumentSubType();
            IEnumerable<DocumentSubType> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }

        public async Task<IEnumerable<DocumentSubType>> SearchDocumentSubTypeDapper(string documentsubType)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@DocumentSubName", documentsubType);

            var spName = "usp_DocumentSubType_Get_Search_DocumentSubType";

            DocumentSubType model = new DocumentSubType();
            IEnumerable<DocumentSubType> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }

        public async void CreateDocumentSubTypeDataDapper(DocumentSubType model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();

            queryParameters.Add("@DocumentSubName", model.DocumentSubName);
            queryParameters.Add("@DocumentTypeId", model.DocumentTypeId);
            queryParameters.Add("@CreatedBy", model.CreatedBy);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_DocumentSubType_CreateDocumentSubType";

            dapperManager.InsertQuery(spName, queryParameters);
        }

        public async void UpdateDocumentSubTypeDataDapper(DocumentSubType model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@DocumentSubTypeId", model.DocumentSubTypeId);
            queryParameters.Add("@DocumentTypeId", model.DocumentTypeId);
            queryParameters.Add("@DocumentSubName", model.DocumentSubName);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_DocumentSubType_UpdateDocumentSubType";

            dapperManager.UpdateRecord(spName, queryParameters);
        }

        public async void DeleteDocumentSubTypeDapper(DocumentSubType model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@DocumentSubTypeId", model.DocumentSubTypeId);
            queryParameters.Add("@UserIp", UserIP);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);

            var spName = "usp_DocumentSubType_DeleteDocumentSubType";

            dapperManager.UpdateRecord(spName, queryParameters);
        }
        #endregion

        #region Domain Setup
        public async Task<IEnumerable<Domain>> GetDomainDapper()
        {
            var queryParameters = new DynamicParameters();
            var spName = "usp_Domain_Get_DomainList";

            Domain model = new Domain();
            IEnumerable<Domain> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }

        public async Task<IEnumerable<Domain>> SearchDomainDapper(string searchKeyword)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@DomainName", searchKeyword);

            var spName = "usp_Domain_Get_Search_Domain";

            Domain model = new Domain();
            IEnumerable<Domain> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }

        public async void CreateDomainDataDapper(Domain model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();

            queryParameters.Add("@DomainName", model.DomainName);
            queryParameters.Add("@CompanyId", model.CompanyId);
            queryParameters.Add("@CreatedBy", model.CreatedBy);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_Domain_CreateDomain";

            dapperManager.InsertQuery(spName, queryParameters);
        }

        public async void UpdateDomainDataDapper(Domain model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@DomainId", model.DomainId);
            queryParameters.Add("@CompanyId", model.CompanyId);
            queryParameters.Add("@DomainName", model.DomainName);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_Domain_UpdateDomain";

            dapperManager.UpdateRecord(spName, queryParameters);
        }

        public async void DeleteDomainDapper(Domain model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@DomainId", model.DomainId);
            queryParameters.Add("@UserIp", UserIP);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);

            var spName = "usp_Domain_DeleteDomain";

            dapperManager.UpdateRecord(spName, queryParameters);
        }
        #endregion

        #region Designation Setup
        public async Task<IEnumerable<Designation>> GetDesignationDapper()
        {
            var queryParameters = new DynamicParameters();
            var spName = "usp_Designation_Get_DesignationList";

            Designation model = new Designation();
            IEnumerable<Designation> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }

        public async Task<IEnumerable<Designation>> SearchDesignationDapper(string searchKeyword)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@DesignationName", searchKeyword);

            var spName = "usp_Designation_Get_Search_Designation";

            Designation model = new Designation();
            IEnumerable<Designation> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }

        public async void CreateDesignationDataDapper(Designation model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();

            queryParameters.Add("@DesignationName", model.DesignationName);
            queryParameters.Add("@CategoryId", model.CategoryId);
            queryParameters.Add("@CreatedBy", model.CreatedBy);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_Designation_CreateDesignation";

            dapperManager.InsertQuery(spName, queryParameters);
        }

        public async void UpdateDesignationDataDapper(Designation model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@DesignationId", model.DesignationId);
            queryParameters.Add("@JobCategoryId", model.CategoryId);
            queryParameters.Add("@DesignationName", model.DesignationName);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_Designation_UpdateDesignation";

            dapperManager.UpdateRecord(spName, queryParameters);
        }

        public async void DeleteDesignationDapper(Designation model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@DesignationId", model.DesignationId);
            queryParameters.Add("@UserIp", UserIP);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);

            var spName = "usp_Designation_DeleteDesignation";

            dapperManager.UpdateRecord(spName, queryParameters);
        }
        #endregion

        #region EmployeeType
        public async Task<IEnumerable<EmployeeType>> GetEmployeeTypeDapper()
        {
            var queryParameters = new DynamicParameters();
            var spName = "usp_EmployeeType_Get_EmployeeTypeList";

            EmployeeType model = new EmployeeType();
            IEnumerable<EmployeeType> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }
        public async Task<IEnumerable<EmployeeType>> SearchEmployeeTypeDapper(string searchKeyword)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@EmployeeTypeName", searchKeyword);

            var spName = "usp_EmployeeType_Get_Search_EmployeeType";

            EmployeeType model = new EmployeeType();
            IEnumerable<EmployeeType> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }

        public async void CreateEmployeeTypeDataDapper(EmployeeType model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();

            queryParameters.Add("@CompanyId", model.CompanyId);
            queryParameters.Add("@EmployeeTypeName", model.EmployeeTypeName);
            queryParameters.Add("@CreatedBy", model.CreatedBy);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_EmployeeType_CreateEmployeeType";

            dapperManager.InsertQuery(spName, queryParameters);
        }

        public async void UpdateEmployeeTypeDataDapper(EmployeeType model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@EmployeeTypeId", model.EmployeeTypeId);
            queryParameters.Add("@EmployeeTypeName", model.EmployeeTypeName);
            queryParameters.Add("@CompanyId", model.CompanyId);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_EmployeeType_UpdateEmployeeType";

            dapperManager.UpdateRecord(spName, queryParameters);
        }

        public async void DeleteEmployeeTypeDapper(EmployeeType model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@EmployeeTypeId", model.EmployeeTypeId);
            queryParameters.Add("@UserIp", UserIP);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);

            var spName = "usp_EmployeeType_DeleteEmployeeType";

            dapperManager.UpdateRecord(spName, queryParameters);
        }
        #endregion

        #region Education Score , Education Status, Company,Location,Designation
        public async Task<IEnumerable<SetupMasterDetail>> GetEducationScoreDapper()
        {
            var queryParameters = new DynamicParameters();

            var spName = "usp_SetupMasterDetail_Get_EducationScore";

            SetupMasterDetail model = new SetupMasterDetail();
            IEnumerable<SetupMasterDetail> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }
        public async Task<IEnumerable<SetupMasterDetail>> GetGenderDapper()
        {
            var queryParameters = new DynamicParameters();

            var spName = "usp_SetupMasterDetail_Get_Gender";

            SetupMasterDetail model = new SetupMasterDetail();
            IEnumerable<SetupMasterDetail> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }
        public async Task<IEnumerable<SetupMasterDetail>> GetQualificationDapper()
        {
            var queryParameters = new DynamicParameters();

            var spName = "usp_SetupMasterDetail_Get_Qualification";

            SetupMasterDetail model = new SetupMasterDetail();
            IEnumerable<SetupMasterDetail> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }
        public async Task<IEnumerable<SetupMasterDetail>> GetNationalityDapper()
        {
            var queryParameters = new DynamicParameters();

            var spName = "usp_SetupMasterDetail_Get_Nationality";

            SetupMasterDetail model = new SetupMasterDetail();
            IEnumerable<SetupMasterDetail> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }
        public async Task<IEnumerable<SetupMasterDetail>> GetReligionDapper()
        {
            var queryParameters = new DynamicParameters();

            var spName = "usp_SetupMasterDetail_Get_Religion";

            SetupMasterDetail model = new SetupMasterDetail();
            IEnumerable<SetupMasterDetail> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }
        public async Task<IEnumerable<SetupMasterDetail>> GetMaritalStatusDapper()
        {
            var queryParameters = new DynamicParameters();

            var spName = "usp_SetupMasterDetail_Get_MaritalStatus";

            SetupMasterDetail model = new SetupMasterDetail();
            IEnumerable<SetupMasterDetail> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }
        public async Task<IEnumerable<SetupMasterDetail>> GetEducationStatusDapper()
        {
            var queryParameters = new DynamicParameters();

            var spName = "usp_SetupMasterDetail_Get_EducationStatus";

            SetupMasterDetail model = new SetupMasterDetail();
            IEnumerable<SetupMasterDetail> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }
        public async Task<IEnumerable<SetupMasterDetail>> GetEducationTypeDapper()
        {
            var queryParameters = new DynamicParameters();

            var spName = "usp_SetupMasterDetail_Get_EducationType";

            SetupMasterDetail model = new SetupMasterDetail();
            IEnumerable<SetupMasterDetail> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }
        public async Task<IEnumerable<SetupMasterDetail>> GetCompanyDapper()
        {
            var queryParameters = new DynamicParameters();

            var spName = "usp_SetupMasterDetail_Get_Company";

            SetupMasterDetail model = new SetupMasterDetail();
            IEnumerable<SetupMasterDetail> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }
        public async Task<IEnumerable<SetupMasterDetail>> GetLocationDapper()
        {
            var queryParameters = new DynamicParameters();

            var spName = "usp_SetupMasterDetail_Get_Location";

            SetupMasterDetail model = new SetupMasterDetail();
            IEnumerable<SetupMasterDetail> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }
        public async Task<IEnumerable<SetupMasterDetail>> GetBuildingDapper()
        {
            var queryParameters = new DynamicParameters();

            var spName = "usp_SetupMasterDetail_Get_Building";

            SetupMasterDetail model = new SetupMasterDetail();
            IEnumerable<SetupMasterDetail> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }
        public async Task<IEnumerable<SetupMasterDetail>> GetFloorDapper()
        {
            var queryParameters = new DynamicParameters();

            var spName = "usp_SetupMasterDetail_Get_Floor";

            SetupMasterDetail model = new SetupMasterDetail();
            IEnumerable<SetupMasterDetail> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }
        public async Task<IEnumerable<SetupMasterDetail>> GetAreaDapper()
        {
            var queryParameters = new DynamicParameters();

            var spName = "usp_SetupMasterDetail_Get_Area";

            SetupMasterDetail model = new SetupMasterDetail();
            IEnumerable<SetupMasterDetail> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }
        public async Task<IEnumerable<SetupMasterDetail>> GetTMSShiftDapper(int companyId)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@CompanyId", companyId);

            var spName = "usp_Employee_Get_ShiftByCompanyId";

            SetupMasterDetail model = new SetupMasterDetail();
            IEnumerable<SetupMasterDetail> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }
        public async Task<IEnumerable<EmployeePersonal>> GetHODNameDapper(int? designationId = null)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@DesignationId", designationId);

            var spName = "usp_SetupMasterDetail_Get_HODName";

            EmployeePersonal model = new EmployeePersonal();
            IEnumerable<EmployeePersonal> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }
        public async Task<IEnumerable<EmployeePersonal>> GetManagerNameDapper(int? designationId = null)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@DesignationId", designationId);

            var spName = "usp_SetupMasterDetail_Get_ManagerName";

            EmployeePersonal model = new EmployeePersonal();
            IEnumerable<EmployeePersonal> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }
        public async Task<IEnumerable<EmployeePersonal>> GetInchargeNameDapper(int? designationId = null)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@DesignationId", designationId);

            var spName = "usp_SetupMasterDetail_Get_InChargeName";

            EmployeePersonal model = new EmployeePersonal();
            IEnumerable<EmployeePersonal> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }
        
        public async Task<IEnumerable<SetupMasterDetail>> GetJobCategoryDapper()
        {
            var queryParameters = new DynamicParameters();

            var spName = "usp_SetupMasterDetail_Get_Jobcategory";

            SetupMasterDetail model = new SetupMasterDetail();
            IEnumerable<SetupMasterDetail> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }
        public async Task<IEnumerable<SetupMasterDetail>> GetCountryDapper()
        {
            var queryParameters = new DynamicParameters();

            var spName = "usp_SetupMasterDetail_Get_Country";

            SetupMasterDetail model = new SetupMasterDetail();
            IEnumerable<SetupMasterDetail> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }

        public async Task<IEnumerable<SetupMasterDetail>> GetDocumentTypeDapper()
        {
            var queryParameters = new DynamicParameters();

            var spName = "usp_SetupMasterDetail_Get_DocumentType";

            SetupMasterDetail model = new SetupMasterDetail();
            IEnumerable<SetupMasterDetail> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }

        public async Task<IEnumerable<SetupMasterDetail>> GetRelationShipDapper()
        {
            var queryParameters = new DynamicParameters();

            var spName = "usp_SetupMasterDetail_Get_Relationship";

            SetupMasterDetail model = new SetupMasterDetail();
            IEnumerable<SetupMasterDetail> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }
        #endregion

        #region MenuItemFeatureMapping
        public async Task<IEnumerable<MenuFeatureMapping>> GetMenuItemFeatureMappingDapper(int menuId)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@MenuId", menuId);

            var spName = "usp_Feature_Get_FeatureByMenuId";

            MenuFeatureMapping model = new MenuFeatureMapping();
            IEnumerable<MenuFeatureMapping> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }
        public async void CreateMenuFeatureMappingDataDapper(MenuFeatureMapping model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();

            queryParameters.Add("@MenuItemId", model.MenuItemId);
            queryParameters.Add("@FeatureId", model.FeatureId);

            queryParameters.Add("@CreatedBy", model.CreatedBy);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_MenuItemFeatureMapping_CreateMenuItemFeatureMapping";

            dapperManager.InsertQuery(spName, queryParameters);
        }

        public async Task<Boolean> GetMenuItemFeatureMappingAlreadyExistDapper(int menuItemId,int featureId)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@MenuId", menuItemId);
            queryParameters.Add("@FeatureId", featureId);

            var spName = "usp_Feature_IsAlreadyExist_FeatureByMenuId";

            MenuFeatureMapping model = new MenuFeatureMapping();
            MenuFeatureMapping results = await dapperManager.QueryFirstOrDefault(model, spName, queryParameters);
            if(results == null)
            {
                return true;
            }
            else
            {
                return false;
            }
          

        }

        #endregion

        #region UserLocationMapping
        public async void CreateUserLocationMappingDataDapper(UserLocationMapping model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();

            queryParameters.Add("@UserId", model.UserId);
            queryParameters.Add("@LocationId", model.LocationId);

            queryParameters.Add("@CreatedBy", model.CreatedBy);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_UserLocationMapping_CreateMapping";

            dapperManager.InsertQuery(spName, queryParameters);
        }

        public async Task<IEnumerable<UserLocationMapping>> GetUserRoleDetailDapper()
        {
            var queryParameters = new DynamicParameters();

            var spName = "usp_UserLocationMapping_Get_MappingList";

            UserLocationMapping model = new UserLocationMapping();
            IEnumerable<UserLocationMapping> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }

        public async void DeleteUserLocationDataDapper(UserLocationMapping model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@UserLocationMappingId", model.UserLocationMappingId);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_UserLocationMapping_DeleteRecord";

            dapperManager.UpdateRecord(spName, queryParameters);
        }
        #endregion

        #region UserBusinessUnitMapping
        public async void CreateUserBusinessUnitMappingDataDapper(UserBusinessUnitMapping model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();

            queryParameters.Add("@UserId", model.UserId);
            queryParameters.Add("@BusinessUnitId", model.BusinessUnitId);

            queryParameters.Add("@CreatedBy", model.CreatedBy);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_UserBusinessUnitMapping_CreateMapping";

            dapperManager.InsertQuery(spName, queryParameters);
        }

        public async Task<IEnumerable<UserBusinessUnitMapping>> GetUserBusinessUnitDetailDapper()
        {
            var queryParameters = new DynamicParameters();

            var spName = "usp_UserBusinessUNITMapping_Get_MappingList";

            UserBusinessUnitMapping model = new UserBusinessUnitMapping();
            IEnumerable<UserBusinessUnitMapping> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }

        public async void DeleteUserBusinessUnitDataDapper(UserBusinessUnitMapping model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@UserBusinessUnitMappingId", model.UserBusinessUnitMappingId);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_UserBusinessUnitMapping_DeleteRecord";

            dapperManager.UpdateRecord(spName, queryParameters);
        }
        #endregion

        #region Setup Master
        public async Task<IEnumerable<SetupMaster>> GetSetUpMasterDapper()
        {
            var queryParameters = new DynamicParameters();
            var spName = "usp_SetupMaster_Get_SetupMasterList";

            SetupMaster model = new SetupMaster();
            IEnumerable<SetupMaster> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }
        public async Task<IEnumerable<SetupMasterDetail>> GetSetupDetailDapper(int masterId)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@SetupMasterId", masterId);

            var spName = "usp_MasterDetail_Get_MasterDetail";

            SetupMasterDetail model = new SetupMasterDetail();
            IEnumerable<SetupMasterDetail> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }
        public async void DeleteSetupDetailDapper(SetupMasterDetail model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@SetupDetailId", model.SetupDetailId);
            queryParameters.Add("@UserIp", UserIP);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);

            var spName = "usp_MasterDetail_DeleteMasterDetail";

            dapperManager.UpdateRecord(spName, queryParameters);

        }

        public async void CreateSetupDetailDataDapper(SetupMasterDetail model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();

            queryParameters.Add("@SetupMasterId", model.SetupMasterId);
            queryParameters.Add("@SetupDetailName", model.SetupDetailName);

            queryParameters.Add("@CreatedBy", model.CreatedBy);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_MasterDetail_CreateMasterDetail";

            dapperManager.InsertQuery(spName, queryParameters);
        }

        public async void UpdateSetupDetailDataDapper(SetupMasterDetail model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@SetupDetailId", model.SetupDetailId);
            queryParameters.Add("@SetupDetailName", model.SetupDetailName);

            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_MasterDetail_UpdateMasterDetail";

            dapperManager.UpdateRecord(spName, queryParameters);
        }
        #endregion

      
    }
}

