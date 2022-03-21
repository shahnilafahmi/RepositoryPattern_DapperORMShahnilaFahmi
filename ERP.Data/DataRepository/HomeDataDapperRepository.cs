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

namespace ERP.Data.DataRepository.HomeDataDapperRepository
{
    public interface IHomeDataDapperService
    {
        Task AddEmployee(HomeDto prod);

        Task DeleteEmployee(int? employeeId);
        Task<HomeDto> HomeDataTest(int? employeeId);

        void UpdateEmployee(HomeDto prod);

        Task<IEnumerable<HomeDto>> GetAllHomeData();

    }

    public class HomeDataDapperRepository : IHomeDataDapperService
 
    {
        private string connectionString = "";

        private readonly DapperManager dapperManager;
       

        public HomeDataDapperRepository()
        {
            // connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=EmployeeDB;Trusted_Connection=True";
             connectionString = GenericConstants.ConnectionStringDB2;
            dapperManager = new DapperManager(connectionString);
        }

        public IDbConnection _Connection
        {
            get {
                return new SqlConnection(connectionString);

             
            }
        }

        public async Task AddEmployee(HomeDto prod)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();


            var queryParameters = new DynamicParameters();
            queryParameters.Add("@EmployeeName", prod.EmployeeName);
            queryParameters.Add("@Designation", prod.Designation);
            queryParameters.Add("@EmployeeNo", prod.EmployeeNo);

            var spName = "InsertEmployeeInfo";
            dapperManager.InsertQuery(spName, queryParameters);

        }

        public async Task DeleteEmployee(int? employeeId)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@EmployeeId", employeeId);

            var spName = "DeleteEmployeeById";
            dapperManager.DeleteRecord(spName, queryParameters);


        }
        public async Task DeleteEmployeeByQuery(int? employeeId)
        {
            //var queryParameters = new DynamicParameters();
            //queryParameters.Add("@EmployeeId", employeeId);

            //var spName = "DeleteEmployeeById";
            //db.Open();
            //dapperManager.DeleteRecord(spName, queryParameters);

            //use below line of code if Delete from one Table

            string tableName = "Employee";
            string deleteId = "EmployeeId";
           dapperManager.DeleteRecordByQuery(tableName, deleteId, employeeId.Value);
        }

        public async void UpdateEmployee(HomeDto prod)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@EmployeeName", prod.EmployeeName);
            queryParameters.Add("@Designation", prod.Designation);
            queryParameters.Add("@EmployeeNo", prod.EmployeeNo);
            queryParameters.Add("@EmployeeId", prod.EmployeeId);

            var spName = "UpdateEmployeeInfo";
          
            dapperManager.UpdateRecord(spName, queryParameters);
        }

        public async  Task<HomeDto> HomeDataTest(int? employeeId)
        {
             var queryParameters = new DynamicParameters();
             queryParameters.Add("@EmployeeId", employeeId);
             var spName = "GetEmployeeInfoByEmployeeId ";

            HomeDto _homeModel = new HomeDto();
            HomeDto model = await dapperManager.QueryFirstOrDefault(_homeModel, spName, queryParameters);
            return model;
           
         }

        public async Task<IEnumerable<HomeDto>> GetAllHomeData()

        {

            //string to = "shahnila.fahmi@sybrid.com";

            //string CC = "shahnila.fahmi@sybrid.com";
            //string subject = "Test Email By Shahnila";
            //string senderName = "Shahnila Fahmi";
            //string Template = "Dear shahnila fahmi, </br> we are testing with emails............";
            //try
            //{
            //    EmailSecuritySetUp.SendMail(to, subject, Template, CC, "", "");
            //}
            //catch (Exception ex)
            //{

            //}


            var queryParameters = new DynamicParameters();
            var spName = "GetAllEmployeeInfo ";
            HomeDto _homeDto = new HomeDto();
            IEnumerable<HomeDto>  result = await dapperManager.QueryList(_homeDto, spName, queryParameters);
            return result;

        }
        public async Task<IEnumerable<HomeDto>> GetAllHomeDataByQuery()
        {
            string tableName = "Employee";
            IEnumerable<HomeDto> lstEmployee = dapperManager.FindAll_SQL<HomeDto>(tableName);
            return lstEmployee;
        }

        public async Task<IEnumerable<HomeDto>> FindDataById(int? employeeId)

        {
            //Get List of Data from Single tABLE
            string tableName = "Employee";
            string qry = $"Employeeid = @Employeeid";
            object parameters = new { Employeeid = 1 };
            IEnumerable<HomeDto> model = dapperManager.FindByID<HomeDto>(qry, parameters, tableName).ToList();
            return model;

            //Below Line will Get single row  of Data from Single tABLE

            //string tableName = "Employee";
            //string primaryKey = "Employeeid";
            //HomeDto model =  dapperManager.FindByID<HomeDto>(primaryKey, employeeId.Value, tableName);
            //return model;

        }


    }
}

