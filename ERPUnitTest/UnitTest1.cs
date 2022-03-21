using NUnit.Framework;
using System.Threading.Tasks;
using System.Collections.Generic;
using Erp.Core.Model;
using ERP.Application.DataRepository.HomeDataDapperRepository;


namespace ERPUnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1()
        {
            var employeeId = 1;
            //HomeDapperRepository obj = new HomeDapperRepository(DataRepository);
            //HomeDataDapperRepository obj = new HomeDataDapperRepository();

            //List<HomeDto>
            //List<HomeDto> output = await obj.HomeDataTest(employeeId);

        }
        [Test]
        public void EmployeeAddTest()
        {
            HomeDataDapperRepository obj = new HomeDataDapperRepository();

            HomeDto model = new HomeDto();
            model.EmployeeName = "Saqia";
            model.Designation = "Retailer";
            model.EmployeeNo = 24234;

            //List<HomeDto>
         obj.AddProduct(model);

        }
    }
}