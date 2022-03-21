using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Application.Repositories.HomeService;
using ERP.Core.Model;
using ERP.Data.DataRepository.HomeDataDapperRepository;
using System.Net.NetworkInformation;
using ERP.API.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ERP.API.Controllers
{
    [Obsolete]
    //[ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
       // private readonly HomeService homeService;
       
        private readonly IHomeService _homeService;
        

        public HomeController(IHomeService homeService)
        {
         
            _homeService = homeService;
        }




        //[HttpGet]
        [HttpGet("GetAllEmployee")]
        public async Task<IEnumerable<HomeDto>> GetAllEmployee()
        {
            return await _homeService.GetAllHomeTest();
        }

        // GET api/<HomeController>/5
        [HttpGet("{id}")]
        public async Task<HomeDto> GetEmployeeById(int id)
        {
            return await _homeService.HomeTest(id);
        }


        // POST api/<HomeController>

        [HttpPost("CreateEmployee")]
        public async void CreateEmployee(HomeDto input)
        {
            _homeService.AddEmployee(input);

        }

        // PUT api/<HomeController>/5
        //[HttpPut("{id}")]
        [HttpPut("UpdateEmployee")]
        public async void UpdateEmployee(HomeDto input)
        {

            _homeService.UpdateHomeTest(input);

        }

      
        //[HttpDelete("DeleteEmployee/{id}")]
        [HttpDelete("DeleteEmployee")]
        public async void DeleteEmployee(int employeeId)
        {
            _homeService.DeleteEmployee(employeeId);
        }
    }
}
