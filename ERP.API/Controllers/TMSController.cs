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
using System.IO;
using Microsoft.AspNetCore.Hosting;



namespace ERP.API.Controllers
{
   
    [EnableCors("Security")]
    [Route("api/[controller]")]
    [ApiController]
    public class TMSController : ControllerBase
    {
        private readonly ITMSSetupService _tmsService;
        private readonly byte[] fileBytes;
        public IHostingEnvironment hostingEnvironment;

        public TMSController(ITMSSetupService tmsService)
        {

            _tmsService = tmsService;
           

        }
        #region Apply Leave
        [HttpGet("LeavesType")]
        public async Task<IEnumerable<LeaveType>> LeavesType()
        {
            return await _tmsService.GetLeaveTypeListService();
        }
        [HttpGet("LeaveBalance")]
        public async Task<IEnumerable<LeaveBalance>> LeaveBalance(int employeeId)
        {
            return await _tmsService.GetLeaveBalanceService(employeeId);
        }
        [HttpPost("ApplyLeaves")]
        public async Task<string> ApplyLeaves(Leave input)
        {
            return await _tmsService.CreateApplyLeaveService(input);
        }
        [HttpGet("PendingLeaves")]
        public async Task<int> PendingLeaves(int employeeId,
            int leaveTypeId,
            int noOfDays)
        {
            return await _tmsService.GetPendingLeaveService(employeeId, leaveTypeId, noOfDays);
        }
        #endregion

        #region Leave History
        [HttpGet("LeaveHistory")]
        public async Task<IEnumerable<LeaveHistory>> LeaveHistory(int employeeId)
        {
            return await _tmsService.LeaveHistoryService(employeeId);
        }
        [HttpGet("LeaveHistoryDetail")]
        public async Task<LeaveHistory> LeaveHistoryDetail(int leaveAppliedId)
        {
            return await _tmsService.LeaveHistoryDetailService(leaveAppliedId);
        }
        #endregion

        #region View Calendar
        [HttpGet("EmployeeByDepartment")]
        public async Task<IEnumerable<Employee>> EmployeeByDepartment(int departmentId)
        {
            return await _tmsService.GetEmployeeByDepartmentService(departmentId);
        }

        [HttpGet("ListOfMonths")]
        public async Task<IEnumerable<string>> ListOfMonths()
        {
            return await _tmsService.GetMonthsService();
        }
        [HttpGet("ViewCalendarMonth")]
        public async Task<IEnumerable<ViewCalendar>> ViewCalendarMonth(int employeeId,
            int month,
            int year)
        {
            return await _tmsService.GetViewCalendarService(employeeId, month, year);
        }
        [HttpGet("ShiftByEmployee")]
        public async Task<IEnumerable<ViewCalendar>> ShiftByEmployee(int employeeId)
        {
            return await _tmsService.GetShiftByEmployeeService(employeeId);
        }


        #endregion

        #region In out Timming
        [HttpGet("InOutTimming")]
        public async Task<IEnumerable<InOutTimming>> InOutTimming(int employeeId,
        Boolean IsMonthwise,
        int month,
        int year)
        {
            return await _tmsService.GetInOutTimmingService(employeeId, IsMonthwise, month, year);
        }
        [HttpGet("TimeAdjustmentById")]
        public async Task<TMS_TimeAdjustmentRequest> TimeAdjustmentById(int? timeAdjustmentId = null)
        {
            return await _tmsService.GetTimeAdjustmentDetailService(timeAdjustmentId);
        }
        [HttpGet("TimeAdjustmentByDailyActivity")]
        public async Task<TMS_DailyActivity> TimeAdjustmentByDailyActivity(int? dailyActivityId = null)
        {
            return await _tmsService.GetEmptyTimeAdjustmentDetailService(dailyActivityId);
        }

        [HttpGet("AdjustmentReasonList")]
        public async Task<IEnumerable<TMS_AdjustmentReason>> AdjustmentReasonList()
        {
            return await _tmsService.GetAdjustmentReasonService();
        }
        [HttpPost("CreatetimeAdjustment")]
        public async Task<string> CreatetimeAdjustment(TMS_TimeAdjustmentRequest input, int IsInRequest)
        {
           return await _tmsService.CreateTimeAdjustmentService(input, IsInRequest);
        }
        [HttpGet("ViewActivityDetail")]
        public async Task<ActivityDetail> ViewActivityDetail(int dailyActivityId)
        {
            return await _tmsService.GetActivityService(dailyActivityId);
        }
        #endregion

        #region Bing Employee By Company Id
        [HttpGet("EmployeeByCompanyList")]
        public async Task<IEnumerable<Employee>> EmployeeList(int companyId)
        {
            return await _tmsService.GetEmployeeService(companyId);
        }
        #endregion

        #region TMS SETUP
        [HttpPost("LeaveAdjustment")]
        public async Task<string> LeaveAdjustment(TMS_EmployeeLeave mainModel)
        {
            return await _tmsService.CreateEmployeeLeaveService(mainModel);
        }
        [HttpGet("SearchEmployeeLeaveById")]
        public async Task<TMS_EmployeeLeave> SearchEmployeeLeaveById(int employeeId)
        {
            return await _tmsService.GetEmployeeLeaveByIdService(employeeId);
        }
        [HttpPost("SearchDailyActivity")]
        public async Task<IEnumerable<TMS_DailyActivity>> SearchDailyActivity(TMS_DailyActivity model)
        {
            return await _tmsService.GetDailyActivityByIdService(model);
        }
        [HttpPost("CreateDailyActivity")]
        public async Task<string> CreateDailyActivity(TMS_DailyActivity model)
        {
            return await _tmsService.CreateEmployeeDailyActivityService(model);
        }
        [HttpPost("UpdateDailyActivity")]
        public async Task<string> UpdateDailyActivity(TMS_DailyActivity model)
        {
            return await _tmsService.UpdateEmployeeDailyActivityService(model);
        }

        [HttpGet("SearchShift")]
        public async Task<IEnumerable<ShiftSearch>> SearchShift(int? companyId = null,
           int? departmentId = null,
           string searchKeyWords = null)
        {
            return await _tmsService.GetShiftService(companyId, departmentId, searchKeyWords);
        }
        [HttpPost("CreateShift")]
        public async void CreateShift(TMS_Setup_Shift model)
        {
             _tmsService.CreateShiftService(model);
        }
        [HttpPost("CreateDepartmentShift")]
        public async void CreateDepartmentShift(int[] arrDepartment, int userId)
        {
            _tmsService.CreateDepartmentShiftService(arrDepartment, userId);
        }
        #endregion

    }
}
