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
    public interface ISecurityDataDapperRepositor
    {
        Task<UserLogin> GetUserByLoginId(string loginId, string password);

        Task<IEnumerable<Role>> GetRolesDapper();

        Task CreateDataLoginHistory(UserLoginHistory model);

        void UpdateDataUserLogin(UserLogin prod);

        Task ResetPasswordDataUserLogin(string loginId);

        void DeleteRoleDapper(Role model);

        void UpdateRoleDataDapper(Role model);

        void CreateRoleDataDapper(Role model);

        void CreateRoleMenuItemDataDapper(List<RoleMenuItemFeatureMapping> model);

        void DeleteRoleMenuItemDataDapper(int roleId, int menuItemFeatureId);

        Task<IEnumerable<MenuFeatureMapping>> GetMenuItemByRoleIdDataDapper(int roleId);

        Task<IEnumerable<Role>> SearchRolesDapper(string roleName);

        Task<IEnumerable<CompanyApplication>> GetModuleAccessByCompnay(int companyId);
        Task<IEnumerable<AccessFeatureRolewise>> GetAccessFeatureRolewise(
            int roleId, 
            int menuItemId);

        Task<IEnumerable<MenuFeatureMapping>> GetHomeMenuItemByRoleIdDataDapper(int roleId);
        void DeleteMenuItemByMenuIdDataDapper(int roleId, int MenuItemId);
        Task<IEnumerable<Company>> GetCompanyOfCorrespondentAdminDapper();

        Task<IEnumerable<UserRoleApplicationMapping>> GetEmployeeListByCompanyIdDapper(int companyId);
        Task<IEnumerable<Applications>> GetApplicationByCompanyIdDapper(int companyId);

        void CreateUserRoleApplicationMappingDataDapper(List<UserRoleApplicationMapping> model);

    }

    public class SecurityDataDapperRepositor : ISecurityDataDapperRepositor

    {
        private string connectionString = "";
        private Random _random = new Random();

        private readonly DapperManager dapperManager;


        public SecurityDataDapperRepositor()
        {

            connectionString = GenericConstants.ConnectionStringDB1;
            dapperManager = new DapperManager(connectionString);
        }

        public IDbConnection _Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

        #region UserLogin
        public async Task<UserLogin> GetUserByLoginId(string loginId, string password)

        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@LoginId", loginId);
            queryParameters.Add("@Password", password);

            var spName = "usp_UserLogin_Get_UserByLoginId";

            UserLogin userLogin = new UserLogin();
            UserLogin results = await dapperManager.QueryFirstOrDefault(userLogin, spName, queryParameters);
            return results;

        }

        public async Task ResetPasswordDataUserLogin(string loginId)
        {
            Random rnd = new Random();
            int generatedPassword = rnd.Next(10000000, 99999999);

            var queryParams = new DynamicParameters();
            queryParams.Add("@LoginId", loginId);
            var spName = "usp_Employee_GetEmployeeInfoByLoginId";

            UserLogin _userLogin = new UserLogin();
            UserLogin model = await dapperManager.QueryFirstOrDefault(_userLogin, spName, queryParams);
            //Send Reset Email

            string senderName = model.Name;
            string CC = "";
            string subject = $"Reset Password Email for {senderName}";

            string message = EmailTemplateSecuritySetUp.ResetPasswordTemplate(senderName, generatedPassword);

            EmailSecuritySetUp.SendMail(loginId, subject, message, CC, "", "");


            var queryParameters = new DynamicParameters();
            queryParameters.Add("@LoginId", loginId);
            queryParameters.Add("@password", generatedPassword);

            var spNameReset = "usp_Reset_UserLogin_Password";
            dapperManager.UpdateRecord(spNameReset, queryParameters);
        }


        public async Task CreateDataLoginHistory(UserLoginHistory model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@UserId", model.UserId);
            queryParameters.Add("@IsSuccess", model.IsSuccess);
            queryParameters.Add("@UserIp", UserIP);

            var spName = "usp_UserLoginHistory_Insert";
            dapperManager.InsertQuery(spName, queryParameters);

        }

        public async void UpdateDataUserLogin(UserLogin model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@UserId", model.UserId);
            queryParameters.Add("@OldPassword", model.OldPassword);
            queryParameters.Add("@NewPassword", model.NewPassword);
            queryParameters.Add("@UserIp", UserIP);

            var spName = "usp_UserLogin_UpdatePassword";
            // db.Open();
            dapperManager.UpdateRecord(spName, queryParameters);
        }
        #endregion

        #region Role
        public async Task<IEnumerable<Role>> GetRolesDapper()
        {
            var queryParameters = new DynamicParameters();
            var spName = "usp_Role_Get_RoleList";

            Role role = new Role();
            IEnumerable<Role> results = await dapperManager.QueryList(role, spName, queryParameters);
            return results;

        }
        public async Task<IEnumerable<Role>> SearchRolesDapper(string roleName)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@RoleName", roleName);

            var spName = "usp_Role_Get_SearchRole";

            Role role = new Role();
            IEnumerable<Role> results = await dapperManager.QueryList(role, spName, queryParameters);
            return results;

        }

        public async void CreateRoleDataDapper(Role model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();

            queryParameters.Add("@RoleName", model.RoleName);
            queryParameters.Add("@ApplicationId", model.ApplicationId);
            queryParameters.Add("@CreatedBy", model.CreatedBy);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_Role_CreateRole";

            dapperManager.InsertQuery(spName, queryParameters);
        }

        public async void UpdateRoleDataDapper(Role model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@RoleId", model.RoleId);
            queryParameters.Add("@RoleName", model.RoleName);
            queryParameters.Add("@ApplicationId", model.ApplicationId);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_Role_UpdateRole";

            dapperManager.UpdateRecord(spName, queryParameters);
        }

        public async void DeleteRoleDapper(Role model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@RoleId", model.RoleId);
            queryParameters.Add("@UserIp", UserIP);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@ModifiedDate", model.ModifiedDate);

            var spName = "usp_Role_DeleteRole";

            dapperManager.UpdateRecord(spName, queryParameters);
        }
        #endregion

        #region UserRoleApplicationMapping
        public async Task<IEnumerable<Company>> GetCompanyOfCorrespondentAdminDapper()
        {
            var queryParameters = new DynamicParameters();
            var spName = "usp_Company_GetCompanyOfCorrespondentAdmin";

            Company model = new Company();
            IEnumerable<Company> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }
        public async Task<IEnumerable<UserRoleApplicationMapping>> GetEmployeeListByCompanyIdDapper(int companyId)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@CompanyId", companyId);

            var spName = "usp_Employee_GetEmployeeByCompanyId";

            UserRoleApplicationMapping model = new UserRoleApplicationMapping();
            IEnumerable<UserRoleApplicationMapping> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }
        public async Task<IEnumerable<Applications>> GetApplicationByCompanyIdDapper(int companyId)
        {
            List<Applications> nodes = new List<Applications>();

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@CompanyId", companyId);

            var spName = "usp_Application_GetApplicationNameByCompanyId";

            Applications model = new Applications();
            IEnumerable<Applications> results = await dapperManager.QueryList(model, spName, queryParameters);
            foreach (Applications appNode in results)
            {
                model = new Applications() { ApplicationName  = appNode.ApplicationName,  ApplicationId = appNode.ApplicationId };
               
                //Get Role List Correspondent to ApplicationId
                string tableName = "Role";
                string qry = $"ApplicationId = @ApplicationId";
                object parameters = new { ApplicationId = appNode.ApplicationId };
                IEnumerable<Role> roleList = dapperManager.FindByID<Role>(qry, parameters, tableName).ToList();
                foreach (Role appSubNode in roleList)
                {
                    model.roleDropDownList.Add(new Applications() { RoleId = appSubNode.RoleId, RoleName = appSubNode.RoleName});
                
                }
                nodes.Add(model);
               
            }

            return nodes; 

        }
       
        public async void CreateUserRoleApplicationMappingDataDapper(List<UserRoleApplicationMapping> model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();

            foreach (var item in model) // Loop through List with foreach
            {
                queryParameters.Add("@RoleId", item.RoleId);
                queryParameters.Add("@UserId", item.UserId);

                queryParameters.Add("@CreatedBy", item.CreatedBy);
                queryParameters.Add("@ModifiedBy", item.ModifiedBy);
                queryParameters.Add("@UserIP", UserIP);

                var spName = "usp_UserRoleApplicationMapping_CreateUserRoleApplicationMapping";

                dapperManager.InsertQuery(spName, queryParameters);
            }
              
        }
        #endregion 

        #region Menu Access
        public async void CreateRoleMenuItemDataDapper(List<RoleMenuItemFeatureMapping> model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();

            foreach (var item in model) // Loop through List with foreach
            {
                if (item.Checked)
                {
                   

                    if(item.MenuItemFeatureId == 0)
                    {
                        queryParameters.Add("@RoleId", item.RoleId);
                        queryParameters.Add("@MenuItemId", item.MenuItemId);
                        queryParameters.Add("@CreatedBy", item.CreatedBy);
                        queryParameters.Add("@ModifiedBy", item.ModifiedBy);
                        queryParameters.Add("@UserIP", UserIP);
                        var spName = "usp_MenuItem_CreateMenuAccessParent";

                        dapperManager.InsertQuery(spName, queryParameters);
                    }
                    else
                    {
                        queryParameters.Add("@RoleId", item.RoleId);
                        queryParameters.Add("@MenuItemFeatureId", item.MenuItemFeatureId);
                        queryParameters.Add("@CreatedBy", item.CreatedBy);
                        queryParameters.Add("@ModifiedBy", item.ModifiedBy);
                        queryParameters.Add("@UserIP", UserIP);
                        var spName = "usp_MenuItem_CreateMenuAccess";

                        dapperManager.InsertQuery(spName, queryParameters);
                    }
                }

            }



        }

        public async void DeleteRoleMenuItemDataDapper(int roleId, int menuItemFeatureId)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@RoleId", roleId);
            queryParameters.Add("@MenuItemFeatureId", menuItemFeatureId);
           

            var spName = "usp_MenuItem_DeleteMenuAccessByMenuItemId";

            dapperManager.InsertQuery(spName, queryParameters);
        }

        public async void DeleteMenuItemByMenuIdDataDapper(int roleId, int MenuItemId)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@RoleId", roleId);
            queryParameters.Add("@MenuItemId", MenuItemId);
          
            var spName = "usp_MenuItem_DeleteMenuItemByMenuItemId";

            dapperManager.InsertQuery(spName, queryParameters);
        }

        public async Task<IEnumerable<MenuFeatureMapping>> GetMenuItemByRoleIdDataDapper(int roleId)
        {
            List<MenuFeatureMapping> nodes = new List<MenuFeatureMapping>();
            MenuFeatureMapping parent = new MenuFeatureMapping();


            RoleMenuItemFeatureMapping roleMenuItemFeatureMapping = new RoleMenuItemFeatureMapping();

            MenuItemFeature menuItemFeature = new MenuItemFeature();

            var queryParametersParent = new DynamicParameters();
            queryParametersParent.Add("@RoleId", roleId);

            var spNameParentNode = "usp_MenuItem_Get_RoleMenuItemParent ";
            IEnumerable<RoleMenuItemFeatureMapping> modelParent = await dapperManager.QueryList(roleMenuItemFeatureMapping, spNameParentNode, queryParametersParent);

            foreach (RoleMenuItemFeatureMapping type in modelParent)
            {
                //Get Checked menu Item (Parent Node)


                if (type.SubNode == "#")
                {
                    //Get Parent Name from Below Line and Check and UnCheck Node behalf on this
                    var queryParamParent = new DynamicParameters();
                    queryParamParent.Add("@RoleId", roleId);
                    queryParamParent.Add("@MenuItemId", type.MenuId);

                    var spNameParent = "usp_MenuItem_GetRoleMenuItemFeatureMappingExist";
                    RoleMenuItemFeatureMapping ParentNode = new RoleMenuItemFeatureMapping();
                    IEnumerable<RoleMenuItemFeatureMapping> modelParentChecked = await dapperManager.QueryList(ParentNode, spNameParent, queryParamParent);
                    if(modelParentChecked.Any())
                    {
                        parent = new MenuFeatureMapping() { MenuItemId = type.MenuId, Value = type.MenuId.ToString(), ApplicationId = type.ApplicationId, parent = "#", Label = type.MenuName, Checked = true };
                    }
                    else
                    {
                        parent = new MenuFeatureMapping() { MenuItemId = type.MenuId, Value = type.MenuId.ToString(), ApplicationId = type.ApplicationId, parent = "#", Label = type.MenuName, Checked = false };
                    }
                    
                    //Get Child Node Name from Below Line
                    var queryParametersSubModule = new DynamicParameters();
                    queryParametersSubModule.Add("@ParentId", type.MenuId);

                    var spNameSubChildModule = "usp_MenuItem_Get_RoleMenuItemChildModule ";

                    IEnumerable<MenuFeatureMapping> modelSubModule = await dapperManager.QueryList(parent, spNameSubChildModule, queryParametersSubModule);
                    var i = 0;
                    foreach (MenuFeatureMapping SubModule in modelSubModule)
                    {
                        if (SubModule.MenuId == 4)
                        {

                        }
                        string randomSubModule = GenerateRandomNo();
                      
                        var queryParameters = new DynamicParameters();
                        queryParameters.Add("@RoleId", roleId);
                        queryParameters.Add("@MenuItemId", SubModule.MenuId);

                        var spName = "usp_MenuItem_GetRoleMenuItemFeatureMappingExist";
                        RoleMenuItemFeatureMapping role = new RoleMenuItemFeatureMapping();
                        IEnumerable<RoleMenuItemFeatureMapping> modelSubModuleChecked = await dapperManager.QueryList(role, spName, queryParameters);
                        if (modelSubModuleChecked.Any())
                        {
                            parent.children.Add(new MenuFeatureMapping() { MenuItemId = SubModule.MenuId, Value = SubModule.MenuId + randomSubModule, ParentId = type.ParentId, Label = SubModule.MenuName, Checked = true });

                            //Get Grand Child Node Name from Below Line
                            var queryParametersSubChild = new DynamicParameters();
                            queryParametersSubChild.Add("@MenuItemId", SubModule.MenuId);

                            var spNameSubChildNode = "usp_MenuItem_Get_RoleMenuItemSubChild ";
                            IEnumerable<MenuFeatureMapping> modelFeature = await dapperManager.QueryList(parent, spNameSubChildNode, queryParametersSubChild);
                            foreach (MenuFeatureMapping SubModulefeature in modelFeature)
                            {
                                //Query if Record Exist in RoleMenuItemFeatureMapping Table then Mark Checked Else Checked = false
                                string tableNameFeature = "RoleMenuItemFeatureMapping";
                                string qryFeature = $"RoleId = @RoleId  AND  MenuItemFeatureId = @MenuItemFeatureId";
                                object paramFeature = new { RoleId = roleId, MenuItemId = SubModule.MenuId, MenuItemFeatureId = SubModulefeature.MenuItemFeatureId };
                                //object paramSubModule = new { RoleId = roleId, MenuItemId = type.MenuId };
                                RoleMenuItemFeatureMapping modelFeatureChecked = dapperManager.FindByID<RoleMenuItemFeatureMapping>(qryFeature, paramFeature, tableNameFeature).FirstOrDefault();
                                if (modelFeatureChecked != null)
                                {
                                    parent.children[i].children.Add(new MenuFeatureMapping() { FeatureId = SubModulefeature.MenuItemFeatureId, MenuItemId = SubModule.MenuId, Value = randomSubModule + 1, Label = SubModulefeature.Feature,MenuItemFeatureId = SubModulefeature.MenuItemFeatureId, Checked = true });
                                }
                                else
                                {
                                    parent.children[i].children.Add(new MenuFeatureMapping() { FeatureId = SubModulefeature.MenuItemFeatureId, MenuItemId = SubModule.MenuId, Value = randomSubModule + 1, Label = SubModulefeature.Feature, MenuItemFeatureId = SubModulefeature.MenuItemFeatureId, Checked = false });
                                }

                            }
                             nodes.Add(parent);

                        }
                        else
                        {
                            parent.children.Add(new MenuFeatureMapping() { MenuItemId = SubModule.MenuId, ParentId = type.ParentId, Value = SubModule.MenuId + randomSubModule, Label = SubModule.MenuName, Checked = false });

                            //Get Grand Child Node Name from Below Line
                            var queryParametersSubChild = new DynamicParameters();
                            queryParametersSubChild.Add("@MenuItemId", SubModule.MenuId);

                            var spNameSubChildNode = "usp_MenuItem_Get_RoleMenuItemSubChild ";
                            IEnumerable<MenuFeatureMapping> modelFeature = await dapperManager.QueryList(parent, spNameSubChildNode, queryParametersSubChild);
                            foreach (MenuFeatureMapping SubModulefeature in modelFeature)
                            {
                                parent.children[i].children.Add(new MenuFeatureMapping() { FeatureId = SubModulefeature.MenuItemFeatureId, MenuItemId = SubModule.MenuId, Value = randomSubModule + 1, Label = SubModulefeature.Feature, MenuItemFeatureId = SubModulefeature.MenuItemFeatureId, Checked = false });
                                // parent.children[i].children.Add(new MenuFeatureMapping() { FeatureId = SubModulefeature.FeatureId, MenuItemId = type.MenuId, Value = randomSubModule + 1, Label = SubModulefeature.Feature, Checked = true });
                            }

                            nodes.Add(parent);
                        }
                        i++;
                    }

                }
                else
                {
                    if (type.SubNode != "###" && type.SubNode != "#")
                    {
                        if (type.MenuId == 2 )
                        {

                        }
                        var queryParameters = new DynamicParameters();
                        queryParameters.Add("@RoleId", roleId);
                        queryParameters.Add("@MenuItemId", type.MenuId);

                        var spName = "usp_MenuItem_GetRoleMenuItemFeatureMappingExist";
                        RoleMenuItemFeatureMapping role = new RoleMenuItemFeatureMapping();
                        IEnumerable<RoleMenuItemFeatureMapping> modelParentNodeChecked = await dapperManager.QueryList(role, spName, queryParameters);
                        if(modelParentNodeChecked.Any())
                        {
                            parent = new MenuFeatureMapping() { MenuItemId = type.MenuId, ApplicationId = type.ApplicationId, Value = type.MenuId.ToString(), parent = "#", Label = type.MenuName, Checked = true };
                            nodes.Add(parent);
                        }
                        else
                        {
                            parent = new MenuFeatureMapping() { MenuItemId = type.MenuId, ApplicationId = type.ApplicationId, Value = type.MenuId.ToString(), parent = "#", Label = type.MenuName, Checked = false };
                            nodes.Add(parent);

                        }

                       
                    }

                }
                // }
                if (type.SubNode != "#" && type.SubNode != "###")

                {
                    //Get Child Node Feature Mapping
                    var queryParametersSubChild = new DynamicParameters();
                    queryParametersSubChild.Add("@MenuItemId", type.MenuId);

                    var spNameSubChildNode = "usp_MenuItem_Get_RoleMenuItemSubChild ";
                    IEnumerable<MenuFeatureMapping> modelSubChild = await dapperManager.QueryList(parent, spNameSubChildNode, queryParametersSubChild);
                    string randomChild = GenerateRandomNo();
                    foreach (MenuFeatureMapping Subfeature in modelSubChild)
                    {
                        string tableNameFeature = "RoleMenuItemFeatureMapping";
                        string qryFeature = $"RoleId = @RoleId  AND MenuItemFeatureId = @MenuItemFeatureId ";
                        object paramFeature = new { RoleId = roleId, MenuItemId = type.MenuId, MenuItemFeatureId = Subfeature.MenuItemFeatureId };
                        RoleMenuItemFeatureMapping modelFeature = dapperManager.FindByID<RoleMenuItemFeatureMapping>(qryFeature, paramFeature, tableNameFeature).FirstOrDefault();

                        if (modelFeature != null)
                        {
                            parent.children.Add(new MenuFeatureMapping() { FeatureId = Subfeature.MenuItemFeatureId, MenuItemId = type.MenuId, Value = Subfeature.FeatureId + randomChild, Label = Subfeature.Feature, MenuItemFeatureId = Subfeature.MenuItemFeatureId, Checked = true });
                        }
                        else
                        {
                            parent.children.Add(new MenuFeatureMapping() { FeatureId = Subfeature.MenuItemFeatureId, MenuItemId = type.MenuId, Value = Subfeature.FeatureId + randomChild, Label = Subfeature.Feature, MenuItemFeatureId = Subfeature.MenuItemFeatureId, Checked = false });
                        }

                    }
                }
            }
            return nodes.Distinct().ToList();

        }

        //public async Task<IEnumerable<MenuFeatureMapping>> GetMenuItemByRoleIdDataDapper(int roleId)
        //{
        //    List<MenuFeatureMapping> nodes = new List<MenuFeatureMapping>();
        //    MenuFeatureMapping parent = new MenuFeatureMapping();


        //    RoleMenuItemFeatureMapping roleMenuItemFeatureMapping = new RoleMenuItemFeatureMapping();

        //    MenuItemFeature menuItemFeature = new MenuItemFeature();

        //    var queryParametersParent = new DynamicParameters();
        //    queryParametersParent.Add("@RoleId", roleId);

        //    var spNameParentNode = "usp_MenuItem_Get_RoleMenuItemParent ";
        //    IEnumerable<RoleMenuItemFeatureMapping> modelParent = await dapperManager.QueryList(roleMenuItemFeatureMapping, spNameParentNode, queryParametersParent);

        //    foreach (RoleMenuItemFeatureMapping type in modelParent)
        //    {
        //        //Get Checked menu Item (Parent Node)


        //        if (type.SubNode == "#")
        //        {
        //            //Get Parent Name from Below Line
        //            parent = new MenuFeatureMapping() { MenuItemId = type.MenuId, Value = type.MenuId.ToString(), ApplicationId = type.ApplicationId, parent = "#", Label = type.MenuName, Checked = true };
        //            //Get Child Node Name from Below Line
        //            var queryParametersSubModule = new DynamicParameters();
        //            queryParametersSubModule.Add("@ParentId", type.MenuId);

        //            var spNameSubChildModule = "usp_MenuItem_Get_RoleMenuItemChildModule ";

        //            IEnumerable<MenuFeatureMapping> modelSubModule = await dapperManager.QueryList(parent, spNameSubChildModule, queryParametersSubModule);
        //            var i = 0;
        //            foreach (MenuFeatureMapping SubModule in modelSubModule)
        //            {
        //                if(SubModule.MenuId == 26)
        //                {

        //                }
        //                string randomSubModule = GenerateRandomNo();
        //                string tableNameSubModule = "RoleMenuItemFeatureMapping";
        //                string qrySubModule = $"RoleId = @RoleId AND  MenuItemId = @MenuItemId";
        //                object paramSubModule = new { RoleId = roleId, MenuItemId = SubModule.MenuId };
        //                //object paramSubModule = new { RoleId = roleId, MenuItemId = type.MenuId };
        //                RoleMenuItemFeatureMapping modelSubModuleChecked = dapperManager.FindByID<RoleMenuItemFeatureMapping>(qrySubModule, paramSubModule, tableNameSubModule).FirstOrDefault();
        //                if (modelSubModuleChecked != null)
        //                {
        //                    parent.children.Add(new MenuFeatureMapping() { MenuItemId = SubModule.MenuId, Value = SubModule.MenuId + randomSubModule, ParentId = type.ParentId, Label = SubModule.MenuName, Checked = true });

        //                    //Get Grand Child Node Name from Below Line
        //                    var queryParametersSubChild = new DynamicParameters();
        //                    queryParametersSubChild.Add("@MenuItemId", SubModule.MenuId);

        //                    var spNameSubChildNode = "usp_MenuItem_Get_RoleMenuItemSubChild ";
        //                    IEnumerable<MenuFeatureMapping> modelFeature = await dapperManager.QueryList(parent, spNameSubChildNode, queryParametersSubChild);
        //                    foreach (MenuFeatureMapping SubModulefeature in modelFeature)
        //                    {
        //                        //Query if Record Exist in RoleMenuItemFeatureMapping Table then Mark Checked Else Checked = false
        //                        string tableNameFeature = "RoleMenuItemFeatureMapping";
        //                        string qryFeature = $"RoleId = @RoleId AND  MenuItemId = @MenuItemId AND  MenuItemFeatureId = @MenuItemFeatureId";
        //                        object paramFeature = new { RoleId = roleId, MenuItemId = SubModule.MenuId , MenuItemFeatureId = SubModulefeature.MenuItemFeatureId };
        //                        //object paramSubModule = new { RoleId = roleId, MenuItemId = type.MenuId };
        //                        RoleMenuItemFeatureMapping modelFeatureChecked = dapperManager.FindByID<RoleMenuItemFeatureMapping>(qryFeature, paramFeature, tableNameFeature).FirstOrDefault();
        //                        if(modelFeatureChecked != null)
        //                        {
        //                            parent.children[i].children.Add(new MenuFeatureMapping() { FeatureId = SubModulefeature.MenuItemFeatureId, MenuItemId = SubModule.MenuId, Value = randomSubModule + 1, Label = SubModulefeature.Feature, Checked = true });
        //                        }
        //                        else
        //                        {
        //                            parent.children[i].children.Add(new MenuFeatureMapping() { FeatureId = SubModulefeature.MenuItemFeatureId, MenuItemId = SubModule.MenuId, Value = randomSubModule + 1, Label = SubModulefeature.Feature, Checked = false });
        //                        }

        //                    }


        //                    nodes.Add(parent);

        //                }
        //                else
        //                {
        //                    parent.children.Add(new MenuFeatureMapping() { MenuItemId = SubModule.MenuId, ParentId = type.ParentId, Value = SubModule.MenuId + randomSubModule, Label = SubModule.MenuName, Checked = false });

        //                    //Get Grand Child Node Name from Below Line
        //                    var queryParametersSubChild = new DynamicParameters();
        //                    queryParametersSubChild.Add("@MenuItemId", SubModule.MenuId);

        //                    var spNameSubChildNode = "usp_MenuItem_Get_RoleMenuItemSubChild ";
        //                    IEnumerable<MenuFeatureMapping> modelFeature = await dapperManager.QueryList(parent, spNameSubChildNode, queryParametersSubChild);
        //                    foreach (MenuFeatureMapping SubModulefeature in modelFeature)
        //                    {
        //                        parent.children[i].children.Add(new MenuFeatureMapping() { FeatureId = SubModulefeature.MenuItemFeatureId, MenuItemId = SubModule.MenuId, Value = randomSubModule + 1, Label = SubModulefeature.Feature, Checked = false });
        //                        // parent.children[i].children.Add(new MenuFeatureMapping() { FeatureId = SubModulefeature.FeatureId, MenuItemId = type.MenuId, Value = randomSubModule + 1, Label = SubModulefeature.Feature, Checked = true });
        //                    }

        //                    nodes.Add(parent);
        //                }
        //                i++;
        //            }

        //        }
        //        else
        //        {
        //            if (type.SubNode != "###" && type.SubNode != "#")
        //            {
        //                parent = new MenuFeatureMapping() { MenuItemId = type.MenuId, ApplicationId = type.ApplicationId, Value = type.MenuId.ToString(), parent = "#", Label = type.MenuName, Checked = true };
        //                nodes.Add(parent);
        //            }

        //        }
        //        // }
        //        if (type.SubNode != "#" && type.SubNode != "###")

        //        {
        //            //Get Child Node Feature Mapping
        //            var queryParametersSubChild = new DynamicParameters();
        //            queryParametersSubChild.Add("@MenuItemId", type.MenuId);

        //            var spNameSubChildNode = "usp_MenuItem_Get_RoleMenuItemSubChild ";
        //            IEnumerable<MenuFeatureMapping> modelSubChild = await dapperManager.QueryList(parent, spNameSubChildNode, queryParametersSubChild);
        //            string randomChild = GenerateRandomNo();
        //            foreach (MenuFeatureMapping Subfeature in modelSubChild)
        //            {
        //                string tableNameFeature = "RoleMenuItemFeatureMapping";
        //                string qryFeature = $"RoleId = @RoleId AND  MenuItemId = @MenuItemId AND MenuItemFeatureId = @MenuItemFeatureId ";
        //                object paramFeature = new { RoleId = roleId, MenuItemId = type.MenuId, MenuItemFeatureId = Subfeature.MenuItemFeatureId };
        //                RoleMenuItemFeatureMapping modelFeature = dapperManager.FindByID<RoleMenuItemFeatureMapping>(qryFeature, paramFeature, tableNameFeature).FirstOrDefault();

        //                if (modelFeature != null)
        //                {
        //                    parent.children.Add(new MenuFeatureMapping() { FeatureId = Subfeature.MenuItemFeatureId, MenuItemId = type.MenuId, Value = Subfeature.FeatureId + randomChild, Label = Subfeature.Feature, Checked = true });
        //                }
        //                else
        //                {
        //                    parent.children.Add(new MenuFeatureMapping() { FeatureId = Subfeature.MenuItemFeatureId, MenuItemId = type.MenuId, Value = Subfeature.FeatureId + randomChild, Label = Subfeature.Feature, Checked = false });
        //                }

        //            }
        //        }
        //    }
        //    return nodes.Distinct().ToList();

        //}

        public async Task<IEnumerable<MenuFeatureMapping>> GetHomeMenuItemByRoleIdDataDapper(int roleId)
        {
            List<MenuFeatureMapping> nodes = new List<MenuFeatureMapping>();
            MenuFeatureMapping parent = new MenuFeatureMapping();


            RoleMenuItemFeatureMapping roleMenuItemFeatureMapping = new RoleMenuItemFeatureMapping();

            MenuItemFeature menuItemFeature = new MenuItemFeature();

            var queryParametersParent = new DynamicParameters();
            queryParametersParent.Add("@RoleId", roleId);

            var spNameParentNode = "usp_MenuItem_Get_RoleMenuItemHome ";
            IEnumerable<RoleMenuItemFeatureMapping> modelParent = await dapperManager.QueryList(roleMenuItemFeatureMapping, spNameParentNode, queryParametersParent);

            foreach (RoleMenuItemFeatureMapping type in modelParent)
            {
              
                if (type.SubNode == "#")
                {
                    //Get Parent Name from Below Line
                    parent = new MenuFeatureMapping() { MenuItemId = type.MenuId, ApplicationId = type.ApplicationId, parent = "#", Label = type.MenuName, Checked = true };
                    //Get Child Node Name from Below Line
                    var queryParametersSubModule = new DynamicParameters();
                    queryParametersSubModule.Add("@ParentId", type.MenuId);

                    var spNameSubChildModule = "usp_MenuItem_Get_RoleMenuItemChildModule ";

                    IEnumerable<MenuFeatureMapping> modelSubModule = await dapperManager.QueryList(parent, spNameSubChildModule, queryParametersSubModule);
                    // var i = 0;
                    foreach (MenuFeatureMapping SubModule in modelSubModule)
                    {

                        var queryParamParent = new DynamicParameters();
                        queryParamParent.Add("@RoleId", roleId);
                        queryParamParent.Add("@MenuItemId", SubModule.MenuId);

                        var spNameParent = "usp_MenuItem_GetRoleMenuItemFeatureMappingExist";
                        RoleMenuItemFeatureMapping ParentNode = new RoleMenuItemFeatureMapping();
                        IEnumerable<RoleMenuItemFeatureMapping> modelSubModuleShow = await dapperManager.QueryList(ParentNode, spNameParent, queryParamParent);
                        if (modelSubModuleShow.Any())
                        {
                            parent.children.Add(new MenuFeatureMapping() { MenuItemId = SubModule.MenuId, MenuURL = SubModule.MenuURL, ApplicationId = type.ApplicationId, ParentId = type.ParentId, Label = SubModule.MenuName, Checked = true });
                            nodes.Add(parent);
                        }

                    }

                }
                else
                {
                    if (type.SubNode != "###" && type.SubNode != "#")
                    {
                        parent = new MenuFeatureMapping() { MenuItemId = type.MenuId, ApplicationId = type.ApplicationId, MenuURL = type.menuUrl, parent = "#", Label = type.MenuName, Checked = true };
                        nodes.Add(parent);
                    }

                }

            }
            return nodes.Distinct().ToList();

        }
        public async Task<IEnumerable<CompanyApplication>> GetModuleAccessByCompnay(int companyId)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@CompanyId", companyId);

            var spName = "usp_Company_Get_ApplicationAccess";

            CompanyApplication role = new CompanyApplication();
            IEnumerable<CompanyApplication> results = await dapperManager.QueryList(role, spName, queryParameters);
            return results;

        }
        public async Task<IEnumerable<AccessFeatureRolewise>> GetAccessFeatureRolewise(int roleId,int menuItemId)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@RoleId", roleId);
            queryParameters.Add("@MenuItemId", menuItemId);

            var spName = "usp_RoleFeature_AccessFeatureRolewise";

            AccessFeatureRolewise role = new AccessFeatureRolewise();
            IEnumerable<AccessFeatureRolewise> results = await dapperManager.QueryList(role, spName, queryParameters);
            return results;

        }

        #endregion

        public string GenerateRandomNo()
        {
            return _random.Next(0, 9999).ToString("D4");
        }
    }
}

