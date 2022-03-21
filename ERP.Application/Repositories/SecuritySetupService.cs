using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Core.Model;
using ERP.Data.DataRepository.HomeDataDapperRepository;
using ERP.Data.DataRepository.SecurityDataDapperRepositor;

//namespace ERP.Application.Repositories.SecuritySetupService
namespace ERP.Application.Repositories.SecuritySetupService
{
    public interface ISecuritySetupService
    {
        Task<UserLogin> GetUserByLoginId(string loginId,string password);

        Task<IEnumerable<Role>> GetRolesService();

        void CreateLoginHistory(UserLoginHistory model);

        void UpdateUserLogin(UserLogin model);

        void ResetPasswordService(string loginId);

        void DeleteRoleService(Role model);

        void UpdateRoleService(Role model);

        void CreateRoleService(Role model);

        void CreateRoleMenuItemService(List<RoleMenuItemFeatureMapping> model);

        void DeleteRoleMenuItemService(int roleId, int menuItemFeatureId);

    

        Task<IEnumerable<MenuFeatureMapping>> GetMenuItemByRoleIdService(int roleId);

        Task<IEnumerable<Role>> SearchRolesService(string roleName);

        Task<IEnumerable<CompanyApplication>> GetModuleAccessByCompnayService(int companyId);
        Task<IEnumerable<AccessFeatureRolewise>> GetAccessFeatureRolewiseService(int roleId,
            int menuItemId);

        Task<IEnumerable<MenuFeatureMapping>> GetHomeMenuItemByRoleIdService(int roleId);

        void DeleteMenuItemByItemIdService(int roleId, int MenuItemId);
        Task<IEnumerable<Company>> GetCompanyOfCorrespondentAdminService();

        Task<IEnumerable<UserRoleApplicationMapping>> GetEmployeeListByCompanyIdService(int companyId);

        Task<IEnumerable<Applications>> GetApplicationByCompanyIdService(int companyId);
       
        void CreateUserRoleApplicationMappingService(List<UserRoleApplicationMapping> model);
    }
    public class SecuritySetupService : ISecuritySetupService
    {
        private readonly ISecurityDataDapperRepositor _securityDataDapperRepositor;

        public SecuritySetupService(
          ISecurityDataDapperRepositor securityDataDapperRepositor)

        {
            _securityDataDapperRepositor = securityDataDapperRepositor;
        }

        #region UserLogin Service
        public async Task<UserLogin> GetUserByLoginId(string loginId, string password)
        {
            return await _securityDataDapperRepositor.GetUserByLoginId(loginId, password);
        }

        public async void CreateLoginHistory(UserLoginHistory model)
        {
            _securityDataDapperRepositor.CreateDataLoginHistory(model);

        }
        public async void UpdateUserLogin(UserLogin model)
        {
            _securityDataDapperRepositor.UpdateDataUserLogin(model);

        }
        public async void ResetPasswordService(string loginId)
        {
            _securityDataDapperRepositor.ResetPasswordDataUserLogin(loginId);

        }
       
        #endregion

        #region Role Service
        public async Task<IEnumerable<Role>> GetRolesService()
        {
            return await _securityDataDapperRepositor.GetRolesDapper();
        }

        public async Task<IEnumerable<Role>> SearchRolesService(string roleName)
        {
            return await _securityDataDapperRepositor.SearchRolesDapper(roleName);
        }

        public async void UpdateRoleService(Role model)
        {
            _securityDataDapperRepositor.UpdateRoleDataDapper(model);

        }

        public async void CreateRoleService(Role model)
        {
            _securityDataDapperRepositor.CreateRoleDataDapper(model);

        }
        public async void DeleteRoleService(Role model)
        {
            _securityDataDapperRepositor.DeleteRoleDapper(model);

        }
        #endregion

        #region UserRoleApplicationMapping
        public async Task<IEnumerable<Company>> GetCompanyOfCorrespondentAdminService()
        {
            return await _securityDataDapperRepositor.GetCompanyOfCorrespondentAdminDapper();
        }
        public async Task<IEnumerable<UserRoleApplicationMapping>> GetEmployeeListByCompanyIdService(int companyId)
        {
            return await _securityDataDapperRepositor.GetEmployeeListByCompanyIdDapper(companyId);
        }
        public async Task<IEnumerable<Applications>> GetApplicationByCompanyIdService(int companyId)
        {
            return await _securityDataDapperRepositor.GetApplicationByCompanyIdDapper(companyId);
        }
       
        public async void CreateUserRoleApplicationMappingService(List<UserRoleApplicationMapping> model)
        {
             _securityDataDapperRepositor.CreateUserRoleApplicationMappingDataDapper(model);
        }
        #endregion

        #region Access Menu By Role
        public async void CreateRoleMenuItemService(List<RoleMenuItemFeatureMapping> model)
        {
            _securityDataDapperRepositor.CreateRoleMenuItemDataDapper(model);
        }

        public async void DeleteRoleMenuItemService(int roleId, int menuItemFeatureId)
        {
            _securityDataDapperRepositor.DeleteRoleMenuItemDataDapper(roleId, menuItemFeatureId);

        }

        public async void DeleteMenuItemByItemIdService(int roleId, int MenuItemId)
        {
            _securityDataDapperRepositor.DeleteMenuItemByMenuIdDataDapper(roleId, MenuItemId);

        }

        public async Task<IEnumerable<MenuFeatureMapping>> GetMenuItemByRoleIdService(int roleId)
        {
            return await _securityDataDapperRepositor.GetMenuItemByRoleIdDataDapper(roleId);
        }

        public async Task<IEnumerable<MenuFeatureMapping>> GetHomeMenuItemByRoleIdService(int roleId)
        {
            return await _securityDataDapperRepositor.GetHomeMenuItemByRoleIdDataDapper(roleId);
        }

        public async Task<IEnumerable<CompanyApplication>> GetModuleAccessByCompnayService(int companyId)
        {
            return await _securityDataDapperRepositor.GetModuleAccessByCompnay(companyId);
        }

        public async Task<IEnumerable<AccessFeatureRolewise>> GetAccessFeatureRolewiseService(int roleId, int menuItemId)
        {
            return await _securityDataDapperRepositor.GetAccessFeatureRolewise(roleId, menuItemId);
        }

        #endregion


    }
}
