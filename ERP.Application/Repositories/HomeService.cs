using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Core.Model;
using ERP.Data.DataRepository.HomeDataDapperRepository;



namespace ERP.Application.Repositories.HomeService
{
    public interface IHomeService
    {
        Task<HomeDto> HomeTest(int? employeeId);

        Task<IEnumerable<HomeDto>> GetAllHomeTest();

        void UpdateHomeTest(HomeDto model);
        void AddEmployee(HomeDto model);

        void DeleteEmployee(int? employeeId);


    }


    public class HomeService : IHomeService
    {
        private readonly IHomeDataDapperService _homeDataAppService;

        public HomeService(
          IHomeDataDapperService homeDataDapperService)

        {
            _homeDataAppService = homeDataDapperService;
        }

        public async Task<IEnumerable<HomeDto>>  GetAllHomeTest()
        {
            return await _homeDataAppService.GetAllHomeData();

        }
        public async Task<HomeDto> HomeTest(int? employeeId)
        {
           
            return await _homeDataAppService.HomeDataTest(employeeId);


        }

        public async void UpdateHomeTest(HomeDto model)
        {
          _homeDataAppService.UpdateEmployee(model);

        }
        public async void AddEmployee(HomeDto model)
        {
            _homeDataAppService.AddEmployee(model);

        }

        public async void DeleteEmployee(int? employeeId)
        {
           _homeDataAppService.DeleteEmployee(employeeId.Value);

        }
    }
 }
