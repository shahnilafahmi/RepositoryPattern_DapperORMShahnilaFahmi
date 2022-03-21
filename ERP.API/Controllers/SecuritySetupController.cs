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
using ERP.Application.Repositories.SecuritySetupService;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System.Net.Http;
using Microsoft.AspNetCore.Cors;

namespace ERP.API.Controllers
{
   
    [EnableCors("Security")]
    [Route("api/[controller]")]
    [ApiController]
    public class SecuritySetupController : ControllerBase
    {
        private readonly ISecuritySetupService _securitySetupService;

        public SecuritySetupController(ISecuritySetupService securitySetupService)
        {

            _securitySetupService = securitySetupService;
        
        }

        #region Role API
        [HttpGet("Roles")]
        public async Task<IEnumerable<Role>> Roles()
        {
            return await _securitySetupService.GetRolesService();
        }

        [HttpGet("SearchRoles/{roleName}")]
        public async Task<IEnumerable<Role>> SearchRoles(string roleName)
        {
            return await _securitySetupService.SearchRolesService(roleName);
        }


        [HttpPut("DeleteRole")]
        public async void DeleteRole(Role input)
        {
            _securitySetupService.DeleteRoleService(input);
        }


        [HttpPut("UpdateRole")]
        public async void UpdateRole(Role input)
        {
            _securitySetupService.UpdateRoleService(input);
        }

        [HttpPost("CreateRole")]
        public async void CreateRole(Role input)
        {
            _securitySetupService.CreateRoleService(input);
        }
        #endregion

        #region UserRoleApplicationMapping
        [HttpGet("CompanyofCorrespondentAdmin")]
        public async Task<IEnumerable<Company>> CompanyofCorrespondentAdmin()
        {
            return await _securitySetupService.GetCompanyOfCorrespondentAdminService();
        }
        [HttpGet("EmployeeByCompany")]
        public async Task<IEnumerable<UserRoleApplicationMapping>> EmployeeByCompany(int companyId)
        {
            return await _securitySetupService.GetEmployeeListByCompanyIdService(companyId);
        }

        [HttpGet("ApplicationByCompany")]
        public async Task<IEnumerable<Applications>> ApplicationByCompany(int companyId)
        {
            return await _securitySetupService.GetApplicationByCompanyIdService(companyId);
        }

        [HttpPost("CreateUserRoleApplicationMapping")]
        public async void CreateUserRoleApplicationMapping(List<UserRoleApplicationMapping> input)
        {
            _securitySetupService.CreateUserRoleApplicationMappingService(input);
        }
        #endregion

        #region User Login

        // GET api/<SecuritySetupController>/5

        [HttpGet("Authenticate/{id}/{password}")]
        public async Task<UserLogin> Authenticate(string id, string password)
        {
            return await _securitySetupService.GetUserByLoginId(id, password);
        }

        [HttpPost("CreateLoginHistory")]
        public async void CreateLoginHistory(UserLoginHistory input)
        {
            _securitySetupService.CreateLoginHistory(input);
        }

        [HttpPut("UpdateUserLoginPassword")]
        public async void UpdateUserLoginPassword(UserLogin input)
        {
            _securitySetupService.UpdateUserLogin(input);
        }

        [HttpPost("ResetPassword")]
        public async void ResetPassword(string loginId)
        {
            _securitySetupService.ResetPasswordService(loginId);
        }

        #endregion

        #region Assign Menu to Role

        [HttpPost("CreateMenuAccess")]
        public async void CreateMenuAccess(List<RoleMenuItemFeatureMapping> input)
        {
            _securitySetupService.CreateRoleMenuItemService(input);
        }

        [HttpPut("DeleteMenuAccess/{roleId}/{MenuItemFeatureId}")]
        public async void DeleteMenuAccess(int roleId, int MenuItemFeatureId)
        {
            _securitySetupService.DeleteRoleMenuItemService(roleId, MenuItemFeatureId);
        }

        [HttpPut("DeleteMenuByMenuId/{roleId}/{MenuItemId}")]
        public async void DeleteMenuByMenuId(int roleId, int MenuItemId)
        {
            _securitySetupService.DeleteMenuItemByItemIdService(roleId, MenuItemId);
        }


        [HttpGet("GetMenuItemByRoleId/{roleId}")]
        public async Task<IEnumerable<MenuFeatureMapping>> GetMenuItemByRoleId(int roleId)
        {
            return await _securitySetupService.GetMenuItemByRoleIdService(roleId);
        }

        [HttpGet("GetHomeMenuItemByRoleId/{roleId}")]
        public async Task<IEnumerable<MenuFeatureMapping>> GetHomeMenuItemByRoleId(int roleId)
        {
            return await _securitySetupService.GetHomeMenuItemByRoleIdService(roleId);
        }

        [HttpGet("GetModuleAccessByCompnay/{companyId}")]
        public async Task<IEnumerable<CompanyApplication>> GetModuleAccessByCompnay(int companyId)
        {
            return await _securitySetupService.GetModuleAccessByCompnayService(companyId);
        }

        [HttpGet("GetAccessFeatureRolewise")]
        public async Task<IEnumerable<AccessFeatureRolewise>> GetAccessFeatureRolewise(int roleId, int menuItemId)
        {
            return await _securitySetupService.GetAccessFeatureRolewiseService(roleId, menuItemId);
        }
        #endregion 
    }
}
