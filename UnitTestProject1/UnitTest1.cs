using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ERP.Data.DataRepository.HomeDataDapperRepository;

using System.Threading.Tasks;
using System.Collections.Generic;

using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Http;
using System.Net;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddEmployeeTest()
        {
            Random rnd = new Random();
            int myRandomNo = rnd.Next(10000000, 99999999);

            //HomeService obj = new HomeService();

            //HomeDto model = new HomeDto();
            //model.EmployeeName = "Sidra";
            //model.EmployeeNo = 98786;
            //model.Designation = "Manager";

            //obj.AddEmployee(model);
        }

        [TestMethod]
        public void GetEmployeeTest()
        {
            // HomeDataDapperRepository obj = new HomeDataDapperRepository();
            //HomeService obj = new HomeService();

            
            //Task<HomeDto> output = await obj.HomeDataTest(employeeId);
           // obj.HomeTest(1);
        }
        [TestMethod]
        public void GetAllEmployeeTest()
        {
            //HomeService obj = new HomeService();
            //obj.GetAllHomeTest();
        }

        [TestMethod]
        public void UpdateEmployeeTest()
        {
            //HomeService obj = new HomeService();

            //HomeDto model = new HomeDto();
            //model.EmployeeName = "Shahnila*****";
            //model.EmployeeNo = 98786;
            //model.Designation = "Accountant****";
            //model.EmployeeId = 1;

            //obj.UpdateHomeTest(model);
        }

        [TestMethod]
        public void DeleteEmployeeTest()
        {
            //HomeService obj = new HomeService();
            //var employeeId = 7;
            //obj.DeleteEmployee(employeeId);
            string tableName = "Employee";
            string deleteId = "EmployeeId";
            string deleteQuery = "DELETE FROM " + tableName + " WHERE " + deleteId +  " = @ID";

            //string deleteQuery =    "DELETE FROM " + tableName + " WHERE " + deleteId + = @ID ", new { ID = entity }
        }
        [TestMethod]
        public void EmailSendTest()
        {
           
        

        }
    }
}
