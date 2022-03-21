using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Core.Model;
using ERP.Data.DataRepository.HomeDataDapperRepository;
using ERP.Data.DataRepository.SecurityDataDapperRepositor;


namespace ERP.Application.Repositories.SecuritySetupService
{
    public interface ITMSSetupService
    {

        #region Apply leave
        Task<IEnumerable<LeaveType>> GetLeaveTypeListService();
        Task<string> CreateApplyLeaveService(Leave model);
        Task<IEnumerable<LeaveBalance>> GetLeaveBalanceService(
            int employeeId);

        #endregion

        #region Leave History
        Task<IEnumerable<LeaveHistory>> LeaveHistoryService(
            int employeeId);

        Task<LeaveHistory> LeaveHistoryDetailService(
            int leaveAppliedId);

        #endregion

        Task<IEnumerable<Employee>> GetEmployeeService(int companyId);

        #region View Calendar
        Task<IEnumerable<Employee>> GetEmployeeByDepartmentService(
            int departmentId);

        Task<IEnumerable<string>> GetMonthsService();
        Task<IEnumerable<ViewCalendar>> GetViewCalendarService(int employeeId, 
            int month, 
            int year);
        Task<IEnumerable<ViewCalendar>> GetShiftByEmployeeService(
            int employeeId);

        #endregion

        #region In Out Timming
        Task<IEnumerable<InOutTimming>> GetInOutTimmingService(
        int employeeId,
         Boolean IsMonthwise,
         int month,
         int year);

        Task<TMS_TimeAdjustmentRequest> GetTimeAdjustmentDetailService(
            int? timeAdjustmentId = null);

        Task<TMS_DailyActivity> GetEmptyTimeAdjustmentDetailService(
            int? dailyActivityId = null);
        Task<IEnumerable<TMS_AdjustmentReason>> GetAdjustmentReasonService();
        Task<string> CreateTimeAdjustmentService(
           TMS_TimeAdjustmentRequest input, int IsInRequest);

        Task<ActivityDetail> GetActivityService(
            int dailyActivityId);

        Task<int> GetPendingLeaveService(
            int employeeId, 
            int leaveTypeId, 
            int noOfDays);
        #endregion

        #region TMS SETUP
        Task<string> CreateEmployeeLeaveService(
            TMS_EmployeeLeave mainModel);
        Task<TMS_EmployeeLeave> GetEmployeeLeaveByIdService(
            int employeeId);
        Task<IEnumerable<TMS_DailyActivity>> GetDailyActivityByIdService(
            TMS_DailyActivity model);
        Task<string> CreateEmployeeDailyActivityService(
            TMS_DailyActivity model);
        Task<string> UpdateEmployeeDailyActivityService(
            TMS_DailyActivity model);
        Task<IEnumerable<ShiftSearch>> GetShiftService(
            int? companyId = null,
           int? departmentId = null,
           string searchKeyWords = null);
        void CreateShiftService(
            TMS_Setup_Shift model);

        void CreateDepartmentShiftService(
            int[] arrDepartment, int userId);
        #endregion

    }
    public class TMSSetupService : ITMSSetupService
    {
        private readonly ITMSDataDapperRepositor _tmsDataDapperRepositor;

        public TMSSetupService(
          ITMSDataDapperRepositor tmsDataDapperRepositor)

        {
            _tmsDataDapperRepositor = tmsDataDapperRepositor;
        }

        #region Apply Leave
        public async Task<IEnumerable<LeaveType>> GetLeaveTypeListService()
        {
            return await _tmsDataDapperRepositor.GetLeaveTypeList();
        }
        public async Task<IEnumerable<LeaveBalance>> GetLeaveBalanceService(int employeeId)
        {
            return await _tmsDataDapperRepositor.BalanceLeaveDataDapper(employeeId);
        }

        public async Task<string> CreateApplyLeaveService(Leave model)
        {
           return  await _tmsDataDapperRepositor.CreateApplyLeaveDataDapper(model);
        }
        public async Task<int> GetPendingLeaveService(int employeeId, int leaveTypeId, int noOfDays)
        {
            return await _tmsDataDapperRepositor.GetPendingLeaveDataDapper(employeeId,
               leaveTypeId,
               noOfDays);
        }
        #endregion

        #region Leave History
        public async Task<IEnumerable<LeaveHistory>> LeaveHistoryService(int employeeId)
        {
            return await _tmsDataDapperRepositor.LeaveHistoryDataDapper(employeeId);
        }

        public async Task<LeaveHistory> LeaveHistoryDetailService(int leaveAppliedId)
        {
            return await _tmsDataDapperRepositor.LeaveHistoryDetailDataDapper(leaveAppliedId);
        }
        #endregion

        #region View Calendar
        public async Task<IEnumerable<Employee>> GetEmployeeByDepartmentService(int departmentId)
        {
            return await _tmsDataDapperRepositor.GetEmployeeByDepartmentDetailDapper(departmentId);
        }
        public async Task<IEnumerable<string>> GetMonthsService()
        {
            return await _tmsDataDapperRepositor.GetMonthsDetailDapper();
        }
        public async Task<IEnumerable<ViewCalendar>> GetViewCalendarService(int employeeId, int month, int year)
        {
            return await _tmsDataDapperRepositor.GetViewCalendarDetailDapper(employeeId, month, year);
        }
        public async Task<IEnumerable<ViewCalendar>> GetShiftByEmployeeService(int employeeId)
        {
            return await _tmsDataDapperRepositor.GetShiftByEmployeeDetailDapper(employeeId);
        }

        #endregion

        #region In Out Timming
        public async Task<IEnumerable<InOutTimming>> GetInOutTimmingService(int employeeId,
          Boolean IsMonthwise,
          int month,
          int year)
        {
            return await _tmsDataDapperRepositor.GetInOutTimmingDetailDapper(employeeId, IsMonthwise, month, year);
        }
        public async Task<TMS_TimeAdjustmentRequest> GetTimeAdjustmentDetailService(int? timeAdjustmentId = null)
        {
            return await _tmsDataDapperRepositor.GetTimeAdjustmentDetailDapper(timeAdjustmentId);
        }
        public async Task<TMS_DailyActivity> GetEmptyTimeAdjustmentDetailService(int? dailyActivityId = null)
        {
            return await _tmsDataDapperRepositor.GetEmptyTimeAdjustmentDetailDapper(dailyActivityId);
        }
        public async Task<IEnumerable<TMS_AdjustmentReason>> GetAdjustmentReasonService()
        {
            return await _tmsDataDapperRepositor.GetAdjustmentReasonDetailDapper();
        }
        public async Task<string> CreateTimeAdjustmentService(TMS_TimeAdjustmentRequest input, int IsInRequest)
        {
            return await _tmsDataDapperRepositor.CreateTimeAdjustmentDetailDapper(input,IsInRequest);
        }
        public async Task<ActivityDetail> GetActivityService(int dailyActivityId)
        {
            return await _tmsDataDapperRepositor.GetActivityDetailDapper(dailyActivityId);
        }
        #endregion

        #region TMS SETUP
        public async Task<string> CreateEmployeeLeaveService( TMS_EmployeeLeave mainModel)
        {
            return await _tmsDataDapperRepositor.CreateEmployeeLeaveDataDapper(mainModel);
        }
        public async Task<TMS_EmployeeLeave> GetEmployeeLeaveByIdService(int employeeId)
        {
            return await _tmsDataDapperRepositor.GetEmployeeLeaveByIdDetailDapper(employeeId);
        }
        public async Task<IEnumerable<TMS_DailyActivity>> GetDailyActivityByIdService(TMS_DailyActivity model)
        {
            return await _tmsDataDapperRepositor.GetDailyActivityByIdDetailDapper(model);
        }
        public async Task<string> CreateEmployeeDailyActivityService(TMS_DailyActivity model)
        {
            return await _tmsDataDapperRepositor.CreateEmployeeDailyActivityDataDapper(model);
        }
        public async Task<string> UpdateEmployeeDailyActivityService(TMS_DailyActivity model)
        {
            return await _tmsDataDapperRepositor.UpdateEmployeeDailyActivityDataDapper(model);
        }
        public async Task<IEnumerable<ShiftSearch>> GetShiftService(int? companyId = null,
           int? departmentId = null,
           string searchKeyWords = null)
        {
            return await _tmsDataDapperRepositor.GetShiftDetailDapper(companyId, departmentId, searchKeyWords);
        }
        public async void CreateShiftService(TMS_Setup_Shift model)
        {
              _tmsDataDapperRepositor.CreateShiftSetupDataDapper(model);
        }
        public async void CreateDepartmentShiftService(int[] arrDepartment, int userId)
        {
            _tmsDataDapperRepositor.CreateDepartmentShiftDataDapper(arrDepartment, userId);
        }
        #endregion

        #region Employee List By Company
        public async Task<IEnumerable<Employee>> GetEmployeeService(int companyId)
        {
            return await _tmsDataDapperRepositor.GetEmployeeDetailDapper(companyId);
        }

        #endregion

    }
}
