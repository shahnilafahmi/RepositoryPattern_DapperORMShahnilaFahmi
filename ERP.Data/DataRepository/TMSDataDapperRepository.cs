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
using System.Globalization;
using System.ComponentModel;
//using ERP.Data.BaseRepository;


namespace ERP.Data.DataRepository.SecurityDataDapperRepositor
{
    public interface ITMSDataDapperRepositor
    {
        #region Apply Leave
        Task<IEnumerable<LeaveType>> GetLeaveTypeList();
        Task<string> CreateApplyLeaveDataDapper(Leave model);
        Task<IEnumerable<LeaveBalance>> BalanceLeaveDataDapper(int employeeId);
        #endregion

        #region Leave History
        Task<IEnumerable<LeaveHistory>> LeaveHistoryDataDapper(
            int employeeId);

        Task<LeaveHistory> LeaveHistoryDetailDataDapper(
            int leaveAppliedId);
        #endregion

        Task<IEnumerable<Employee>> GetEmployeeDetailDapper(
            int companyId);

        #region View Calendar
        Task<IEnumerable<Employee>> GetEmployeeByDepartmentDetailDapper(
            int departmentId);
        Task<IEnumerable<string>> GetMonthsDetailDapper();
        Task<IEnumerable<ViewCalendar>> GetViewCalendarDetailDapper(
            int employeeId, 
            int month, 
            int year);

        Task<IEnumerable<ViewCalendar>> GetShiftByEmployeeDetailDapper(
            int employeeId);


        #endregion

        #region InOut Time 

        Task<IEnumerable<InOutTimming>> GetInOutTimmingDetailDapper(
          int employeeId,
          Boolean IsMonthwise,
          int month,
          int year);
        Task<TMS_TimeAdjustmentRequest> GetTimeAdjustmentDetailDapper(
            int? timeAdjustmentId = null);
        Task<TMS_DailyActivity> GetEmptyTimeAdjustmentDetailDapper(
            int? dailyActivityId = null);
        Task<IEnumerable<TMS_AdjustmentReason>> GetAdjustmentReasonDetailDapper();

        Task<string> CreateTimeAdjustmentDetailDapper(
            TMS_TimeAdjustmentRequest input, int IsInRequest);

        Task<ActivityDetail> GetActivityDetailDapper(
            int dailyActivityId);

        Task<int> GetPendingLeaveDataDapper(
            int employeeId,
            int leaveTypeId,
            int noOfDays);
        #endregion

        #region TMS Setup
        Task<string> CreateEmployeeLeaveDataDapper(
           TMS_EmployeeLeave mainModel);
        Task<TMS_EmployeeLeave> GetEmployeeLeaveByIdDetailDapper(
            int employeeId);
        Task<IEnumerable<TMS_DailyActivity>> GetDailyActivityByIdDetailDapper(
            TMS_DailyActivity model);
        Task<string> CreateEmployeeDailyActivityDataDapper(
            TMS_DailyActivity mainModel);
        Task<string> UpdateEmployeeDailyActivityDataDapper(
            TMS_DailyActivity mainModel);

        Task<IEnumerable<ShiftSearch>> GetShiftDetailDapper(
           int? companyId = null,
           int? departmentId = null,
           string searchKeyWords = null);

        void CreateShiftSetupDataDapper(
            TMS_Setup_Shift mainModel
           );
        void CreateDepartmentShiftDataDapper(
            int[] arrDepartment, int userId);
        #endregion
    }

    public class TMSDataDapperRepository : ITMSDataDapperRepositor

    {
        private string connectionString = "";
      
        private readonly DapperManager dapperManager;


        public TMSDataDapperRepository()
        {

            connectionString = GenericConstants.ConnectionStringHRMS;
            dapperManager = new DapperManager(connectionString);
        }

        public IDbConnection _Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

      

        #region TMS - Apply Leave
        public async Task<IEnumerable<LeaveType>> GetLeaveTypeList()
        {
            var queryParameters = new DynamicParameters();
            var spName = "usp_LeaveType_GetLeaveType";

            LeaveType model = new LeaveType();
            IEnumerable<LeaveType> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;
        }
        public async Task<IEnumerable<LeaveBalance>> BalanceLeaveDataDapper(int employeeId)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@EmployeeID", employeeId);

            var spName = "TMS_Employee_LeaveBalance";

            LeaveBalance model = new LeaveBalance();
            IEnumerable<LeaveBalance> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }
        public async Task<string> CreateApplyLeaveDataDapper(Leave model)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            string message = string.Empty;
            //Check Some Criteria to Apply Leave
            
            DateTime fromDate = model.FromDate;
            DateTime toDate = model.ToDate;
          
            if (fromDate.Year >= DateTime.Now.Year && toDate.Year >= DateTime.Now.Year)
            {
                message = "You can apply Leave for Current Year Only!";
                return message;
            }


            var queryParamMonthEnd = new DynamicParameters();
            queryParamMonthEnd.Add("@CompanyId", model.CompanyId);

            var spMonthEnd = "usp_MonthEnd_GetMonthEndParameter";

            TMS_MonthEndParameter modelmonthEnd = new TMS_MonthEndParameter();
            TMS_MonthEndParameter monthEndParameter = await dapperManager.QueryFirstOrDefault(modelmonthEnd, spMonthEnd, queryParamMonthEnd);
            if(monthEndParameter != null)
            {
                DateTime runDate = new DateTime();
                runDate = model.FromDate.Date;
                DateTime Allowdays = new DateTime(monthEndParameter.CurrentYear, monthEndParameter.CurrentMonth, monthEndParameter.MonthEnd_StartDate);
                int result = DateTime.Compare(runDate, Allowdays.Date.AddMonths(-1));
                if (result < 0)
                {
                    message = "You Can't apply Leave after the Month End. kindly Co-Ordinate with your Supervisor.";
                    return message;
                }
            }
            var fromDateValue = model.FromDate.Date.ToString("yyyy-MM-dd");
            var toDateValue = model.ToDate.Date.ToString("yyyy-MM-dd");

            var queryParamTimeAdj = new DynamicParameters();
            queryParamTimeAdj.Add("@ToDate", fromDateValue);
            queryParamTimeAdj.Add("@FromDate", toDateValue);
            queryParamTimeAdj.Add("@EmpID", model.EmployeeId);
            queryParamTimeAdj.Add("@multiple", false);

            var spTimeAdj = "TMS_usp_TimeAdjustmentList";

            TMS_TimeAdjustmentRequest modelTimeAdj = new TMS_TimeAdjustmentRequest();
            IEnumerable<TMS_TimeAdjustmentRequest> timeAdjustment = await dapperManager.QueryList(modelTimeAdj, spTimeAdj, queryParamTimeAdj);
            timeAdjustment = timeAdjustment.Where(x => x.StartTime != null).ToList();
            if (timeAdjustment.Any())
            {
                message = "You cannot apply Leave because your Activity exist on this Day.";
                return message;
            }
            if (!CanUpdateLeave(toDate, model.EmployeeId))
            {
                message = "Cannot Apply For Leave After Hours.";
                return message;
               
            }

            var queryParamLeaveapp = new DynamicParameters();
            queryParamLeaveapp.Add("@fromDate", model.FromDate);
            queryParamLeaveapp.Add("@toDate", model.ToDate);
            queryParamLeaveapp.Add("@EmployeeId", model.EmployeeId);
            var spLeaveApplied = "usp_LeaveApplied_GetLeaveApplied";

            TMS_LeaveApplied modelLeaveApp = new TMS_LeaveApplied();
            TMS_LeaveApplied leaveCheck = await dapperManager.QueryFirstOrDefault(modelLeaveApp, spLeaveApplied, queryParamLeaveapp);
            if (leaveCheck != null)
            {
                message = "You have already applied Leave on this date range";
                return message;
            }
            if (model.LeaveTypeId == (int)Constant.TMSLeaveTypes.Casual)
            {
                if (model.NoOfDays > 0 && model.NoOfDays > 3)
                {
                    message = "You can apply maximum 3 days of Casual Leaves";
                    return message;
                }
            }

          

            #region Send Email to HR
            //Send HR Email
            UserLogin modelUser = new UserLogin();
            var queryParam = new DynamicParameters();
            queryParam.Add("@EmployeeID", modelUser.EmployeeId);
            var spNameUserLogin = "usp_UserLogin_Get_UserLoginInfo";

            IEnumerable<UserLogin> resultUser = await dapperManager.QueryList(modelUser, spNameUserLogin, queryParam);

            if (resultUser.Any())
            {
                foreach (var item in resultUser)
                {
                    string HRName = item.EmployeeName;
                    string TO = item.LoginId;
                    //string TO = "shahnila.fahmi@sybrid.com";
                    string CC = "";
                    string applicantName = item.ApplicantName;
                    string subject = $"Apply Leave for {item.LeaveType}";

                    string emailMessage = EmailTemplateSecuritySetUp.EmailSendToHRForApplyLeave(HRName, applicantName, item.LeaveType);

                    EmailSecuritySetUp.SendMail(TO, subject, emailMessage, CC, "", "");
                }
            }

            #endregion

            var queryParameters = new DynamicParameters();

            queryParameters.Add("@EmployeeId", model.EmployeeId);
            queryParameters.Add("@EmployeeReason", model.EmployeeReason);
            queryParameters.Add("@LeaveTypeId", model.LeaveTypeId);
            queryParameters.Add("@FromDate", model.FromDate);
            queryParameters.Add("@ToDate", model.ToDate);
            queryParameters.Add("@NoOfDays", model.NoOfDays);


            queryParameters.Add("@CreatedBy", model.CreatedBy);
            queryParameters.Add("@ModifiedBy", model.ModifiedBy);
            queryParameters.Add("@UserIP", UserIP);

            var spName = "usp_Leave_CreateLeave";

            dapperManager.InsertQuery(spName, queryParameters);

            if (string.IsNullOrEmpty(message))
                message = "Record Inserted Successfully";

            return message;
        }

        public async Task<int> GetPendingLeaveDataDapper(int employeeId,int leaveTypeId,int noOfDays)
        {
            //Get Pending Leaves
            var queryParamPendingLeave = new DynamicParameters();
          
            queryParamPendingLeave.Add("@LeaveTypeId", leaveTypeId);
            queryParamPendingLeave.Add("@EmployeeId", employeeId);
            var spPendingLeave = "usp_LeaveApplied_GetPendingLeave";

            TMS_LeaveApplied modelPendingLeaves = new TMS_LeaveApplied();
            IEnumerable<TMS_LeaveApplied> pendingLeaves = await dapperManager.QueryList(modelPendingLeaves, spPendingLeave, queryParamPendingLeave);
            if (pendingLeaves != null)
            {
                int pendingLeave = pendingLeaves.Sum(x => x.NoOfDays);
                noOfDays = noOfDays + pendingLeave;
            }
            return noOfDays;

        }
        #endregion

        #region TMS - Leave History
        public async Task<IEnumerable<LeaveHistory>> LeaveHistoryDataDapper(int employeeId)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@EmployeeID", employeeId);

            var spName = "usp_EmployeeLeaveHistory";

            LeaveHistory model = new LeaveHistory();
            IEnumerable<LeaveHistory> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }
        public async Task<LeaveHistory> LeaveHistoryDetailDataDapper(int leaveAppliedId)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@LeaveAppliedId", leaveAppliedId);

            var spName = "usp_EmployeeLeaveHistory_Detail";

            LeaveHistory model = new LeaveHistory();
            LeaveHistory result = await dapperManager.QueryFirstOrDefault(model, spName, queryParameters);
            return result;

        }
        #endregion

        #region View Calendar
        public async Task<IEnumerable<Employee>> GetEmployeeByDepartmentDetailDapper(int departmentId)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@DepartmentId", departmentId);

            var spName = "usp_Employee_Get_EmployeeListByDepartmentId";

            Employee model = new Employee();
            IEnumerable<Employee> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }
        public async Task<IEnumerable<ViewCalendar>> GetShiftByEmployeeDetailDapper(int employeeId)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@EmployeeId", employeeId);

            var spName = "usp_Employee_Get_ShiftByEmployeeId";

            ViewCalendar model = new ViewCalendar();
            IEnumerable<ViewCalendar> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }
        public async Task<IEnumerable<ViewCalendar>> GetViewCalendarDetailDapper(int employeeId,int month,int year)
        {
            
            string calendarToSee = month + "/01/" + year;
            DateTime dtCalendar = Convert.ToDateTime(calendarToSee);
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@EmployeeId", employeeId);
            queryParameters.Add("@Date", dtCalendar);
          

            var spName = "usp_Calendar_Get_Employee_Calendar";

            ViewCalendar model = new ViewCalendar();
            IEnumerable<ViewCalendar> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }
        public async Task<IEnumerable<string>> GetMonthsDetailDapper()
        {
            var queryParameters = new DynamicParameters();

            IdAndNameDTO model = new IdAndNameDTO();
            string[] MonthNames = DateTimeFormatInfo.CurrentInfo.MonthNames;
            List<string> results = new List<string>();
            foreach (var a in MonthNames)
            {
                if(a != "")
                {
                    results.Add(a);
                }
               
            }

            return results;

        }
        #endregion

        #region InOut Timming
       public async Task<IEnumerable<InOutTimming>> GetInOutTimmingDetailDapper(int employeeId, Boolean IsMonthwise, int month, int year)
        {
            DateTime DateFrom, DateTo;
            if (IsMonthwise)
            {
                DateFrom = DateTime.ParseExact(month + "/1/" + year, "M/d/yyyy", CultureInfo.InvariantCulture);

                DateTo = Convert.ToDateTime(month + "/" + DateTime.DaysInMonth(DateFrom.Year, DateFrom.Month) + "/" + year + " 23:59:59");
            }
            else
            {
                string tableName = "TMS_MonthEndParameter";
                TMS_MonthEndParameter parameter = dapperManager.FindAll_SQL<TMS_MonthEndParameter>(tableName).FirstOrDefault();
                //int monthpayrol = month == 1 ? 13 : month;
                int monthpayrol = month == 1 ? 2 : month;
                int yearpayrol = month == 1 ? (year - 1) : year;

                DateFrom = Convert.ToDateTime(month - 1 + "/" + parameter.MonthEnd_StartDate.ToString() + "/" + yearpayrol.ToString());
                DateTo = Convert.ToDateTime(monthpayrol + "/" + parameter.MonthEnd_EndDate.ToString() + "/" + yearpayrol);

            }
            var fromDate = DateFrom.ToString("yyyy-MM-dd");
            var toDate = DateTo.ToString("yyyy-MM-dd");

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@FromDate", toDate);
            queryParameters.Add("@ToDate", fromDate);
            queryParameters.Add("@EmpID", employeeId);
            queryParameters.Add("@multiple", true);

            var spName = "TMS_usp_TimeAdjustmentList";

            InOutTimming model = new InOutTimming();
            IEnumerable<InOutTimming> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }

        public async Task<TMS_TimeAdjustmentRequest> GetTimeAdjustmentDetailDapper(int? timeAdjustmentId = null)
        {
            TMS_TimeAdjustmentRequest result = new TMS_TimeAdjustmentRequest();
            if (timeAdjustmentId != null)
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@TimeAdjustmentRequestId", timeAdjustmentId);
                var spName = "usp_TimeAdjustment_GetTimeAdjustmentRequest";

                TMS_TimeAdjustmentRequest model = new TMS_TimeAdjustmentRequest();
                result = await dapperManager.QueryFirstOrDefault(model, spName, queryParameters);
            }
            return result;
        }
        public async Task<TMS_DailyActivity> GetEmptyTimeAdjustmentDetailDapper(int? dailyActivityId = null)
        {
                TMS_DailyActivity result = new TMS_DailyActivity();
            
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@DailyActivityId", dailyActivityId);
                var spName = "usp_DailyActivity_GetDailyActivity";

                TMS_DailyActivity model = new TMS_DailyActivity();
                result = await dapperManager.QueryFirstOrDefault(model, spName, queryParameters);
           
            return result;
        }
        public async Task<IEnumerable<TMS_AdjustmentReason>> GetAdjustmentReasonDetailDapper()
        {
            var queryParameters = new DynamicParameters();
            var spName = "usp_AdjustmentReason_GetAdjustmentReason";

            TMS_AdjustmentReason model = new TMS_AdjustmentReason();
            IEnumerable<TMS_AdjustmentReason> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }
        public async Task<string> CreateTimeAdjustmentDetailDapper(TMS_TimeAdjustmentRequest input, int IsInRequest)
        {
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            string message = "";
            string requestedDateTime = "";
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@DailyActivityId", input.DailyActivityId);
            
            var spName = "usp_DailyActivity_GetDailyActivity";

            TMS_DailyActivity model = new TMS_DailyActivity();
            TMS_DailyActivity da = await dapperManager.QueryFirstOrDefault(model, spName, queryParameters);

            requestedDateTime = input.RequestedDateTime.ToString().Split()[0];
            DateTime dtRequestedDateTime = Convert.ToDateTime(requestedDateTime + " " + input.RequestedTimeHour + ":" + input.RequestedTimeMinute);
           if (da != null)
            {
                if (da.Processed)
                {
                    message = "Cannot apply adjustment because the current month payroll process has been completed.";
                    return message;
                }

            }
            if (IsInRequest == 0)
            {
                DateTime dtShiftStart = new DateTime(da.CreatedDate.Year, da.CreatedDate.Month, da.CreatedDate.Day
                    , da.ShiftStartTime.Hours, da.ShiftStartTime.Minutes, da.ShiftStartTime.Seconds);
                if (dtRequestedDateTime <= dtShiftStart)
                {
                    message = "Requested DateTime must be greater than Shift Start Time.";
                    return message;

                }
            }
            if (!CanUpdate(da, IsInRequest, input.EmployeeId))
            //if (!CanUpdate(da))
            {
                message = "Cannot Apply For Time Adjustment After 1 working Days.";
                return message;
            }

            //Save Record in TMS_TimeAdjustmentRequest Table
            var queryParam = new DynamicParameters();

            queryParam.Add("@DailyActivityId", input.DailyActivityId);
            queryParam.Add("@AdjustmentReasonId", input.AdjustmentReasonId);
            queryParam.Add("@EmployeeComment", input.EmployeeComment);
            queryParam.Add("@EmployeeId", input.EmployeeId);
            queryParam.Add("@IsTimeOutRequest", input.IsTimeOutRequest);
            queryParam.Add("@OriginalDateTime", input.OriginalDateTime);
            queryParam.Add("@RequestedDateTime", input.RequestedDateTime);
            queryParam.Add("@SiteId", input.SiteId);
            queryParam.Add("@CompanyId", input.CompanyId);
            queryParam.Add("@ApproverId", input.ApproverId);
            

            queryParam.Add("@CreatedBy", input.CreatedBy);
            queryParam.Add("@ModifiedBy", input.ModifiedBy);
            queryParam.Add("@UserIP", UserIP);

            var spInsertName = "usp_TimeAdjustment_CreateTimeAdjustmentRequest";

            dapperManager.InsertQuery(spInsertName, queryParam);
            if (string.IsNullOrEmpty(message))
                message = "Record Inserted Successfully";
           // input.Message
            return message;

        }

        public async Task<ActivityDetail> GetActivityDetailDapper(int dailyActivityId)
        {
            ActivityDetail mainmodel = new ActivityDetail();
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@DailyActivityId", dailyActivityId);

            var spName = "usp_DailyActivity_GetDailyActivity";

            TMS_DailyActivity model = new TMS_DailyActivity();
            TMS_DailyActivity da = await dapperManager.QueryFirstOrDefault(model, spName, queryParameters);
            if (da != null)
            {
                mainmodel.DailyActivityId = da.DailyActivityId;
                mainmodel.EmployeeId = da.EmployeeId;
                mainmodel.DailyActivityCreatedDate = da.CreatedDate.ToString(GenericConstants.DateFormat1) + " " + da.StartTime.ToString();

                var queryParam = new DynamicParameters();
                queryParam.Add("@EmployeeId", mainmodel.EmployeeId);

                var spEmployee = "usp_Employee_GetEmployeeByEmpId";
                Employee modelEmployee = new Employee();
                Employee resultEmployee = await dapperManager.QueryFirstOrDefault(modelEmployee, spEmployee, queryParam);
                if(resultEmployee != null)
                {
                    mainmodel.EmployeeCode = resultEmployee.EmployeeCode;
                    mainmodel.CardNumber = resultEmployee.CardNumber;
                    mainmodel.EmployeeName = resultEmployee.EmployeeName;
                    mainmodel.Designation = resultEmployee.DesignationName;
                    mainmodel.Department = resultEmployee.DepartmentName;
                    mainmodel.InchargeName = resultEmployee.InChargeName;
                    mainmodel.InTime = mainmodel.DailyActivityCreatedDate;
                }
                mainmodel.ReaderIn = da.ReaderIn;
                mainmodel.OutTime = (da.ModifiedDate != null && da.EndTime != null)
                                        ? (da.ModifiedDate.ToString(GenericConstants.DateFormat1) + " " + da.EndTime.ToString())
                                        : "";
                mainmodel.ReaderOut = da.ReaderOut;
                mainmodel.MonthEndProcessed = da.Processed == true ? "Yes" : "No";

                int day = (int)da.CreatedDate.DayOfWeek;
                var queryParamShift = new DynamicParameters();
                queryParamShift.Add("@ShiftId", da.ShiftID);
                queryParamShift.Add("@DayInt", day);

                var spShiftDetail = "usp_ShiftDetail_GetShiftDetail";
                TMS_Setup_ShiftDetail modelShift = new TMS_Setup_ShiftDetail();
                TMS_Setup_ShiftDetail shiftDetail = await dapperManager.QueryFirstOrDefault(modelShift, spShiftDetail, queryParamShift);
                if(shiftDetail != null)
                {
                    mainmodel.ShiftName = shiftDetail.ShiftName;
                    mainmodel.ShiftDescription = shiftDetail.ShiftDescription;
                    mainmodel.StartTimeSt = shiftDetail.StartTimeSt;
                    mainmodel.EndTimeSt = shiftDetail.EndTimeSt;
                    mainmodel.FlixeInSt = shiftDetail.FlixeInSt;
                    mainmodel.FlixeOutSt = shiftDetail.FlixeOutSt;
                    mainmodel.NatureOfDay = shiftDetail.ShiftDayTypeName;
                    mainmodel.Day = Convert.ToString((DayOfWeek)shiftDetail.DayInt); 
                }
                mainmodel.ShiftStartTime = da.ShiftStartTime.Hours.ToString("D2") + ":" + da.ShiftStartTime.Minutes.ToString("D2");
                mainmodel.ShiftEndTime = da.ShiftEndTime.Hours.ToString("D2") + ":" + da.ShiftEndTime.Minutes.ToString("D2"); 
                mainmodel.FlexiIn = da.FlexiIn.Hours.ToString("D2") + ":" + da.FlexiIn.Minutes.ToString("D2"); 
                mainmodel.FlexiOut = da.FlexiOut.Hours.ToString("D2") + ":" + da.FlexiOut.Minutes.ToString("D2");

                double reqHours = Convert.ToDouble(da.ShiftReqHours);
                int totalHours = Convert.ToInt16(TimeSpan.FromSeconds(reqHours).TotalHours);
                int minutes = TimeSpan.FromSeconds(reqHours).Minutes;
                mainmodel.WorkHours = totalHours.ToString("D2") + ":" + minutes.ToString("D2");

            }
              return mainmodel;

        }
        #endregion

        #region EmployeeByCompnay
        public async Task<IEnumerable<Employee>> GetEmployeeDetailDapper(int companyId)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@CompanyId", companyId);

            var spName = "usp_Employee_Get_EmployeeListByCompanyId";

            Employee model = new Employee();
            IEnumerable<Employee> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }
        public async Task<TMS_EmployeeLeave> GetEmployeeLeaveByIdDetailDapper(int employeeId)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@EmployeeId", employeeId);
            queryParameters.Add("@Code_ID", (int)Constant.LeaveChangesCode.CR);

            var spName = "usp_EmployeeLeave_GetEmployeeLeave";

            TMS_EmployeeLeave model = new TMS_EmployeeLeave();
            TMS_EmployeeLeave result = await dapperManager.QueryFirstOrDefault(model, spName, queryParameters);
            return result;

        }
        
        #endregion

        #region TMS SETUP
        public async Task<string> CreateEmployeeLeaveDataDapper(TMS_EmployeeLeave mainModel)
        {
            string message = string.Empty;
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;


            string tableEmployee = "Employee";
            string qry = $"EmployeeId = @EmployeeId";
            object parameters = new { Employeeid = mainModel.EmployeeId };
            Employee modelEmployee = dapperManager.FindByID<Employee>(qry, parameters, tableEmployee).FirstOrDefault();
            if (modelEmployee != null)
            {
                //Get Leave Defination of Employee bt TMSLeaveId
                string tableLeaveDefination = "TMS_Setup_LeaveDefinition";
                string qryLeaveDef = $"LeaveDefId = @LeaveDefId";
                object paramLeaveDef = new { LeaveDefId = modelEmployee.TMSLeaveId };
                TMS_Setup_LeaveDefinition leave = dapperManager.FindByID<TMS_Setup_LeaveDefinition>(qryLeaveDef, paramLeaveDef, tableLeaveDefination).FirstOrDefault();
                if(leave != null)
                {
                    int maxAnnualLeave = leave.AnualLeavesForward == true ? (Convert.ToInt16(leave.AnualLeaves) * 2) : Convert.ToInt16(leave.AnualLeaves);
                    int maxSickLeave = leave.SickLeavesForward == true ? (Convert.ToInt16(leave.SickLeaves) * 2) : Convert.ToInt16(leave.SickLeaves);
                    int maxCasualLeave = leave.CasualLeavesFarward == true ? (Convert.ToInt16(leave.CasualLeaves) * 2) : Convert.ToInt16(leave.CasualLeaves);
                    int maxMaternityLeave = leave.MaternityLeavesForward == true ? (Convert.ToInt16(leave.MaternityLeaves) * 2) : Convert.ToInt16(leave.MaternityLeaves);
                    int maxDefaultLeave = leave.DefaultLeavesForward == true ? (Convert.ToInt16(leave.DefaultLeaves) * 2) : Convert.ToInt16(leave.DefaultLeaves);

                    int annaulLeave = mainModel.AnualLeaves;
                    int sickLeave = mainModel.SickLeaves;
                    int casualLeave = mainModel.CasualLeaves;
                    int maternityLeave = mainModel.MaternityLeaves;
                    int defaultLeave = mainModel.DefaultLeaves;
                    if (annaulLeave > maxAnnualLeave)
                    {
                        message = "Maximum Number Of Annual Leaves are " + maxAnnualLeave.ToString();
                        return message;
                    }
                    if (sickLeave > maxSickLeave)
                    {
                        message = "Maximum number of Sick leaves are " + maxSickLeave.ToString();
                        return message;
                    }
                    if (casualLeave > maxCasualLeave)
                    {
                        message = "Maximum number of Casual Leaves are " + maxCasualLeave.ToString();
                        return message;

                    }
                    if (maternityLeave > maxMaternityLeave)
                    {
                        message = "Maximum number of Maternity Leaves are " + maxMaternityLeave.ToString();
                        return message;

                    }
                    if (defaultLeave > maxDefaultLeave)
                    {
                        message = "Maximum number of Default Leaves are " + maxDefaultLeave.ToString();
                        return message;
                    }
                    // Mark Inactive to Current Record
                    var queryParam = new DynamicParameters();
                    queryParam.Add("@EmployeeId", mainModel.EmployeeId);
                    queryParam.Add("@Code_ID", (int)Constant.LeaveChangesCode.CR);
                   

                    var spName = "usp_EmployeeLeave_GetEmployeeLeave";

                    TMS_EmployeeLeave model = new TMS_EmployeeLeave();
                    TMS_EmployeeLeave empLeave = await dapperManager.QueryFirstOrDefault(model, spName, queryParam);
                    if(empLeave != null)
                    {
                        //Inactive Record 
                        var queryParameters = new DynamicParameters();
                        queryParameters.Add("@EmployeeId", modelEmployee.EmployeeId);
                        queryParameters.Add("@ModifiedBy", mainModel.ModifiedBy);

                        var spUpdate = "usp_Inactive_UpdateEmployeeLeave";
                        dapperManager.UpdateRecord(spUpdate, queryParameters);
                    }
                    //else
                    //{
                    //    message = "This Employee don't have the Leave Record";
                    //    return message;
                    //}

                    //Insert New Record in EmployeeLeave Table
                    var queryParamInsert = new DynamicParameters();

                    queryParamInsert.Add("@AnualLeaves", annaulLeave);
                    queryParamInsert.Add("@AnualLeavesRemain", annaulLeave);
                    queryParamInsert.Add("@SickLeaves", sickLeave);
                    queryParamInsert.Add("@SickLeavesRemin", sickLeave);
                    queryParamInsert.Add("@CasualLeaves", casualLeave);
                    queryParamInsert.Add("@CasualLeavesRemain", casualLeave);
                    queryParamInsert.Add("@MaternityLeaves", maternityLeave);
                    queryParamInsert.Add("@MaternityLeavesRemain", maternityLeave);
                    queryParamInsert.Add("@DefaultLeaves", defaultLeave);
                    queryParamInsert.Add("@DefaultLeavesRemain", defaultLeave);
                    queryParamInsert.Add("@EmployeeID", mainModel.EmployeeId);
                    queryParamInsert.Add("@Remarks", mainModel.Remarks);
                    queryParamInsert.Add("@UserIP", UserIP);


                    queryParamInsert.Add("@CreatedBy", mainModel.CreatedBy);
                    queryParamInsert.Add("@ModifiedBy", mainModel.ModifiedBy);

                    var spInsertName = "usp_TMSEmployeeLeave_CreateEmployeeLeave";
                    dapperManager.InsertQuery(spInsertName, queryParamInsert);

                    if (string.IsNullOrEmpty(message))
                        message = "Record Inserted Successfully";
                }

            }
            return message;

        }
        public async Task<IEnumerable<TMS_DailyActivity>> GetDailyActivityByIdDetailDapper(TMS_DailyActivity model)
        {
            int companyId = 0;
            DateTime DateFrom = DateTime.Now;
            DateTime DateTo = DateTime.Now;

            string tableEmployee = "Employee";
            string qry = $"EmployeeId = @EmployeeId";
            object parameters = new { Employeeid = model.EmployeeId };
            Employee modelEmployee = dapperManager.FindByID<Employee>(qry, parameters, tableEmployee).FirstOrDefault();
            
            if (modelEmployee != null)
            {
                companyId = modelEmployee.CompanyId;
               
                if (model.IsMonthWise)
                {
                    DateFrom = DateTime.ParseExact(model.Month + "/1/" + model.Year, "M/d/yyyy", CultureInfo.InvariantCulture);
                    DateTo = Convert.ToDateTime(model.Month + "/" + DateTime.DaysInMonth(DateFrom.Year, DateFrom.Month) + "/" + model.Year + " 23:59:59");
                }
                else
                {
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("@CompanyId", companyId);
                    var spName = "usp_MonthEnd_GetMonthEndParameter";

                    TMS_MonthEndParameter modelMonthEnd = new TMS_MonthEndParameter();
                    TMS_MonthEndParameter result = await dapperManager.QueryFirstOrDefault(modelMonthEnd, spName, queryParameters);
                    if(result != null)
                    {
                        int month = model.Month == 1 ? 13 : model.Month;
                        int year = model.Month == 1 ? (model.Year - 1) : model.Year;
                        DateFrom = Convert.ToDateTime(Convert.ToString((month - 1)) + "/" + result.MonthEnd_StartDate.ToString() + "/" + year.ToString());
                        DateTo = Convert.ToDateTime(model.Month + "/" + result.MonthEnd_EndDate.ToString() + "/" + model.Year + " 23:59:59");
                    }
                   
                }

               
            }
            var queryParamDailyAct = new DynamicParameters();
            queryParamDailyAct.Add("@EmployeeId", model.EmployeeId);
            queryParamDailyAct.Add("@DateFrom", DateFrom);
            queryParamDailyAct.Add("@DateTo", DateTo);
            var spDailyAct = "usp_DailyActivity_GetDailyActivityByEmployee";

            TMS_DailyActivity modelDailyActivity = new TMS_DailyActivity();
            IEnumerable<TMS_DailyActivity> resultMonthEnd = await dapperManager.QueryList(modelDailyActivity, spDailyAct, queryParamDailyAct);
            return resultMonthEnd;
        }
        public async Task<string> CreateEmployeeDailyActivityDataDapper(TMS_DailyActivity mainModel)
        {
            string message = string.Empty;
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            DateTime Allowdays = DateTime.Now;
            DateTime StartDate = Convert.ToDateTime(mainModel.OrignalCreatedDate).Date;
            string StartTime_ = mainModel.StartTimeHour  + ":" + mainModel.StartTimeMinute + ":00";
            DateTime EndDate = Convert.ToDateTime(mainModel.OrignalModifiedDate).Date;
            string EndTime_ = mainModel.EndTimeHour + ":" + mainModel.EndTimeMinute + ":00";
            TimeSpan StartTime = Convert.ToDateTime(StartTime_).TimeOfDay;
            TimeSpan EndTime = Convert.ToDateTime(EndTime_).TimeOfDay;


            if ((StartDate <= DateTime.Now.Date && EndDate <= DateTime.Now.Date) &&
                EndDate >= StartDate)
            {
                DateTime dt = DateTime.Now;

                string tableEmployee = "Employee";
                string qry = $"EmployeeId = @EmployeeId";
                object parameters = new { Employeeid = mainModel.EmployeeId };
                Employee modelEmployee = dapperManager.FindByID<Employee>(qry, parameters, tableEmployee).FirstOrDefault();
                if (modelEmployee != null)
                {
                    DateTime DateOfJoining = modelEmployee.JoiningDate.Date;
                    if (StartDate >= DateOfJoining)
                    {
                        //Daily Activity Check

                        string tableDailyActivity = "Employee";
                        string qryDailyActivity = $"EmployeeId = @EmployeeId";
                        object paramDailyActivity = new { Employeeid = mainModel.EmployeeId };
                        TMS_DailyActivity modelDailyActivity = dapperManager.FindByID<TMS_DailyActivity>(qryDailyActivity, paramDailyActivity, tableDailyActivity).FirstOrDefault();
                        if(modelDailyActivity == null)
                        {
                            bool Processed = false;
                            var queryParameters = new DynamicParameters();
                            queryParameters.Add("@CompanyId", modelEmployee.CompanyId);
                            var spName = "usp_MonthEnd_GetMonthEndParameter";

                            TMS_MonthEndParameter modelMonthEnd = new TMS_MonthEndParameter();
                            TMS_MonthEndParameter monthEndParameter = await dapperManager.QueryFirstOrDefault(modelMonthEnd, spName, queryParameters);
                            if (monthEndParameter != null)
                            {
                                Allowdays = new DateTime(monthEndParameter.CurrentYear, monthEndParameter.CurrentMonth, monthEndParameter.MonthEnd_StartDate);
                                int result = DateTime.Compare(StartDate, Allowdays.Date.AddMonths(-1));
                                if (result < 0)
                                {
                                    Processed = true;
                                }
                            }
                            if (Processed == false)
                            {
                                int? ShiftId = null;
                                TimeSpan? ShiftStartTime = null;
                                TimeSpan? ShiftEndTime = null;
                                TimeSpan? FlexiIn = null;
                                TimeSpan? FlexiOut = null;
                                int ShiftReqHours = 0;
                                int DayInt = (int)StartDate.DayOfWeek;
                                var queryParamHalfDay = new DynamicParameters();
                                queryParamHalfDay.Add("@Date", StartDate);
                                queryParamHalfDay.Add("@EmployeeId", mainModel.EmployeeId);

                                var spHalfDay = "Get_CalculateHalfDay";

                                HalfDays modelHalfDays = new HalfDays();
                                HalfDays modelShiftData = await dapperManager.QueryFirstOrDefault(modelHalfDays, spHalfDay, queryParamHalfDay);
                                if (modelShiftData != null)
                                {
                                    ShiftStartTime = Convert.ToDateTime(modelShiftData.StartTimeSt).TimeOfDay; 
                                    ShiftEndTime = Convert.ToDateTime(modelShiftData.EndTimeSt).TimeOfDay;
                                    ShiftId = modelShiftData.ShiftId;
                                    ShiftReqHours = modelShiftData.ShiftReqHours;
                                    FlexiIn = Convert.ToDateTime(modelShiftData.FlixeInSt).TimeOfDay; 
                                    FlexiOut = Convert.ToDateTime(modelShiftData.FlixeOutSt).TimeOfDay;  
                                }
                               
                                var queryParamInsert = new DynamicParameters();

                                queryParamInsert.Add("@StartTime", StartTime);
                                queryParamInsert.Add("@EndTime", EndTime);
                                queryParamInsert.Add("@EmployeeId", modelEmployee.EmployeeId);
                                queryParamInsert.Add("@Processed", Processed);
                                queryParamInsert.Add("@ReaderIn", UserIP);
                                queryParamInsert.Add("@ReaderOut", UserIP);
                                queryParamInsert.Add("@CreatedDate", StartDate);
                                queryParamInsert.Add("@OrignalCreatedDate", StartDate);
                                queryParamInsert.Add("@CreatedBy", modelEmployee.EmployeeId);
                                queryParamInsert.Add("@ModifiedDate", EndDate);
                                queryParamInsert.Add("@OrignalModifiedDate", EndDate);
                                queryParamInsert.Add("@ModifiedBy", modelEmployee.EmployeeId);
                                queryParamInsert.Add("@FlexiIn", FlexiIn);
                                queryParamInsert.Add("@FlexiOut", FlexiOut);
                                queryParamInsert.Add("@ShiftID", ShiftId.Value);
                                queryParamInsert.Add("@ShiftReqHours", ShiftReqHours);
                                queryParamInsert.Add("@DepartmentID", modelEmployee.DepartmentId);
                                queryParamInsert.Add("@CostCenterID", modelEmployee.CostCenterId);
                                queryParamInsert.Add("@DesignationID", modelEmployee.DesignationId);
                                queryParamInsert.Add("@CategoryID", modelEmployee.JobCategoryId);
                                queryParamInsert.Add("@IsNewTMS", true);
                                queryParamInsert.Add("@UserIp", UserIP);
                                queryParamInsert.Add("@ManualEntryBy", mainModel.ManualEntryBy);
                                queryParamInsert.Add("@ManualEntryDateime", DateTime.Now);
                                queryParamInsert.Add("@IsLateIn", ShiftReqHours == 0 ? false : (StartTime > (ShiftStartTime + FlexiIn) ? true : false));
                                queryParamInsert.Add("@IsLateOut", ShiftReqHours == 0 ? false : (EndTime < (ShiftEndTime - FlexiOut) ? true : false));

                                queryParamInsert.Add("@CreatedBy", mainModel.CreatedBy);
                                queryParamInsert.Add("@ModifiedBy", mainModel.ModifiedBy);

                                //Insert
                                var spInsertName = "usp_TMS_DailyActivity_CreateDailyActivity";
                                dapperManager.InsertQuery(spInsertName, queryParamInsert);


                                if (string.IsNullOrEmpty(message))
                                    message = "Record Inserted Successfully";
                               
                            }
                            else
                            {
                                message = "Month End has been Executed already!";
                                return message;
                               
                            }
                        }
                        else
                        {
                            message = "Daily Activity Found on Date " + Convert.ToDateTime(StartDate).ToString(GenericConstants.DateFormat2) + "";
                            return message;
                        }
                        message = "Start Date Should be Greater or Equal to the Date Of Joining";
                        return message;
                    }

                }
              

            }



           
            return message;

        }

        public async Task<string> UpdateEmployeeDailyActivityDataDapper(TMS_DailyActivity mainModel)
        {
            string message = string.Empty;
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            DateTime Allowdays = DateTime.Now;

            var queryParam = new DynamicParameters();
            queryParam.Add("@DailyActivityId", mainModel.DailyActivityId);
          

            var spName = "usp_DailyActivity_GetDailyActivity";

            TMS_DailyActivity model = new TMS_DailyActivity();
            TMS_DailyActivity resultDailyActivity = await dapperManager.QueryFirstOrDefault(model, spName, queryParam);
            if(resultDailyActivity != null)
            {
                DateTime StartDate = mainModel.OrignalCreatedDate.Date;
                string StartTime_ = mainModel.StartTimeHour + ":" + mainModel.StartTimeMinute + ":00";
                DateTime EndDate = Convert.ToDateTime(mainModel.OrignalModifiedDate).Date;
                string EndTime_ = mainModel.EndTimeHour + ":" + mainModel.EndTimeMinute + ":00";
                TimeSpan StartTime = Convert.ToDateTime(StartTime_).TimeOfDay;
                TimeSpan EndTime = Convert.ToDateTime(EndTime_).TimeOfDay;
                if ((StartDate <= DateTime.Now.Date && EndDate <= DateTime.Now.Date) &&
                EndDate >= StartDate)
                {
                    DateTime dt = DateTime.Now;

                    string tableEmployee = "Employee";
                    string qry = $"EmployeeId = @EmployeeId";
                    object parameters = new { Employeeid = mainModel.EmployeeId };
                    Employee modelEmployee = dapperManager.FindByID<Employee>(qry, parameters, tableEmployee).FirstOrDefault();
                    if (modelEmployee != null)
                    {
                        DateTime DateOfJoining = modelEmployee.JoiningDate.Date;
                        if (StartDate >= DateOfJoining)
                        {
                            int _CompanyId = modelEmployee.CompanyId;
                            bool Processed = false;

                            var queryParamMonthEnd = new DynamicParameters();
                            queryParamMonthEnd.Add("@CompanyId", _CompanyId);
                            var spMonthEnd = "usp_MonthEnd_GetMonthEndParameter";

                            TMS_MonthEndParameter modelMonthEnd = new TMS_MonthEndParameter();
                            TMS_MonthEndParameter monthEndParameter = await dapperManager.QueryFirstOrDefault(modelMonthEnd, spMonthEnd, queryParamMonthEnd);

                            if (monthEndParameter != null)
                            {
                                Allowdays = new DateTime(monthEndParameter.CurrentYear, monthEndParameter.CurrentMonth, monthEndParameter.MonthEnd_StartDate);
                                int result = DateTime.Compare(StartDate, Allowdays.Date.AddMonths(-1));
                                if (result < 0)
                                {
                                    Processed = true;
                                }
                            }
                            if (Processed == false)
                            {
                                int? ShiftId = null;
                                TimeSpan? ShiftStartTime = null;
                                TimeSpan? ShiftEndTime = null;
                                TimeSpan? FlexiIn = null;
                                TimeSpan? FlexiOut = null;
                                int ShiftReqHours = 0;
                                int DayInt = (int)StartDate.DayOfWeek;
                                var queryParamHalfDay = new DynamicParameters();
                                queryParamHalfDay.Add("@Date", StartDate);
                                queryParamHalfDay.Add("@EmployeeId", mainModel.EmployeeId);

                                var spHalfDay = "Get_CalculateHalfDay";

                                HalfDays modelHalfDays = new HalfDays();
                                HalfDays modelShiftData = await dapperManager.QueryFirstOrDefault(modelHalfDays, spHalfDay, queryParamHalfDay);
                                if (modelShiftData != null)
                                {
                                    ShiftStartTime = Convert.ToDateTime(modelShiftData.StartTimeSt).TimeOfDay;
                                    ShiftEndTime = Convert.ToDateTime(modelShiftData.EndTimeSt).TimeOfDay;
                                    ShiftId = modelShiftData.ShiftId;
                                    ShiftReqHours = modelShiftData.ShiftReqHours;
                                    FlexiIn = Convert.ToDateTime(modelShiftData.FlixeInSt).TimeOfDay;
                                    FlexiOut = Convert.ToDateTime(modelShiftData.FlixeOutSt).TimeOfDay;
                                }

                                var queryParamInsert = new DynamicParameters();

                                queryParamInsert.Add("@DailyActivityId", mainModel.DailyActivityId);
                                queryParamInsert.Add("@StartTime", StartTime);
                                queryParamInsert.Add("@EndTime", EndTime);
                                queryParamInsert.Add("@EmployeeId", modelEmployee.EmployeeId);
                                queryParamInsert.Add("@Processed", Processed);
                                queryParamInsert.Add("@ReaderIn", UserIP);
                                queryParamInsert.Add("@ReaderOut", UserIP);
                                queryParamInsert.Add("@CreatedDate", StartDate);
                                queryParamInsert.Add("@OrignalCreatedDate", StartDate);
                                queryParamInsert.Add("@CreatedBy", modelEmployee.EmployeeId);
                                queryParamInsert.Add("@ModifiedDate", EndDate);
                                queryParamInsert.Add("@OrignalModifiedDate", EndDate);
                                queryParamInsert.Add("@ModifiedBy", modelEmployee.EmployeeId);
                                queryParamInsert.Add("@FlexiIn", FlexiIn);
                                queryParamInsert.Add("@FlexiOut", FlexiOut);
                                queryParamInsert.Add("@ShiftID", ShiftId.Value);
                                queryParamInsert.Add("@ShiftReqHours", ShiftReqHours);
                                queryParamInsert.Add("@DepartmentID", modelEmployee.DepartmentId);
                                queryParamInsert.Add("@CostCenterID", modelEmployee.CostCenterId);
                                queryParamInsert.Add("@DesignationID", modelEmployee.DesignationId);
                                queryParamInsert.Add("@CategoryID", modelEmployee.JobCategoryId);
                                queryParamInsert.Add("@IsNewTMS", true);
                                queryParamInsert.Add("@UserIp", UserIP);
                                queryParamInsert.Add("@ManualEntryBy", mainModel.ManualEntryBy);
                                queryParamInsert.Add("@ManualEntryDateime", DateTime.Now);
                                queryParamInsert.Add("@IsLateIn", ShiftReqHours == 0 ? false : (StartTime > (ShiftStartTime + FlexiIn) ? true : false));
                                queryParamInsert.Add("@IsLateOut", ShiftReqHours == 0 ? false : (EndTime < (ShiftEndTime - FlexiOut) ? true : false));

                                queryParamInsert.Add("@CreatedBy", mainModel.CreatedBy);
                                queryParamInsert.Add("@ModifiedBy", mainModel.ModifiedBy);
                                //Update Record
                                var spUpdateName = "usp_TMS_DailyActivity_UpdateDailyActivity";
                                dapperManager.UpdateRecord(spUpdateName, queryParamInsert);
                                
                                if (string.IsNullOrEmpty(message))
                                    message = "Record Updated Successfully";

                            }
                            else
                            {
                                message = "Month End has been Executed already!";
                                return message;

                            }
                        }
                    }
                }
            }
            else
            {
                message = "Could not add Manual Attendance of Future Dates";
            }
            return message;

        }

        public async Task<IEnumerable<ShiftSearch>> GetShiftDetailDapper(int? companyId = null, int? departmentId = null,string searchKeyWords = null)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@CompanyId", companyId);
            queryParameters.Add("@DepartmentId", departmentId);
            queryParameters.Add("@ShiftName", searchKeyWords);

            var spName = "usp_Shift_GetShiftBySearch";

            ShiftSearch model = new ShiftSearch();
            IEnumerable<ShiftSearch> results = await dapperManager.QueryList(model, spName, queryParameters);
            return results;

        }

        public async void CreateShiftSetupDataDapper(TMS_Setup_Shift mainModel)
        {
            string message = string.Empty;
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            //Insert Shift SetUp
            var queryParamInsert = new DynamicParameters();
            queryParamInsert.Add("@ShiftId",  dbType: DbType.Int32, direction: ParameterDirection.InputOutput);
            queryParamInsert.Add("@ShiftName", mainModel.ShiftName);
            queryParamInsert.Add("@CompanyId", mainModel.CompanyId);
            queryParamInsert.Add("@Description", mainModel.Description);
            queryParamInsert.Add("@UserIP", UserIP);

            queryParamInsert.Add("@CreatedBy", mainModel.CreatedBy);
            queryParamInsert.Add("@ModifiedBy", mainModel.ModifiedBy);

            var spInsertName = "usp_TMSShift_CreateShift";
            int shiftId = dapperManager.InsertQueryAndGetId(spInsertName, queryParamInsert);

        }

        public async void CreateDepartmentShiftDataDapper(int[] arrDepartment,int userId)
        {
            string message = string.Empty;
            string IPAddress = Network.GetIPAddress();
            string MACAddress = Network.GetMACAddress();
            string UserIP = IPAddress + " - " + MACAddress;

            var queryParameters = new DynamicParameters();
            
            var spName = "usp_Shift_GetMaxShift";

            TMS_DepartmentShift model = new TMS_DepartmentShift();
            TMS_DepartmentShift result = await dapperManager.QueryFirstOrDefault(model, spName, queryParameters);
            int shiftId = result.ShiftId;

            foreach (var departmentId in arrDepartment)
            {
                var queryParamInsert = new DynamicParameters();
                queryParamInsert.Add("@DepartmentId", departmentId);
                queryParamInsert.Add("@ShiftId", shiftId);
                queryParamInsert.Add("@CreatedBy", userId);
                queryParamInsert.Add("@ModifiedBy", userId);

                queryParamInsert.Add("@UserIP", UserIP);

                var spInsertName = "usp_TMSShift_CreateDepartmentShift";
                dapperManager.InsertQuery(spInsertName, queryParamInsert);
            }

        }
       #endregion

            private bool CanUpdate(TMS_DailyActivity da, int IsInRequest, int employeeId)
        {
            if (da != null)
            {
                TimeSpan ts = new TimeSpan();
                DateTime dt = new DateTime();
                if (IsInRequest == 1)
                {
                    dt = Convert.ToDateTime(Convert.ToDateTime(da.CreatedDate).ToString("MM/dd/yyyy") + " " + da.StartTime);
                }
                else
                {
                    dt = da.ModifiedDate != null
                        ? Convert.ToDateTime(Convert.ToDateTime(da.ModifiedDate).ToString("MM/dd/yyyy") + " " + da.EndTime)
                        : Convert.ToDateTime(Convert.ToDateTime(da.CreatedDate).ToString("MM/dd/yyyy") + " " + da.StartTime);
                }

                int offHours = GetTotalOffHours(dt, DateTime.Now, employeeId);

                ts = (TimeSpan)(DateTime.Now - dt);

                //if (ts.TotalHours < (Convert.ToInt16(b.RoleTats) + offHours))
                if (ts.TotalHours < offHours)
                {
                    return true;
                }
            }
            return false;
        }

        private bool CanUpdateLeave(DateTime PeriodTo,int employeeId)
        {
          
            int offHours = GetTotalOffHours(PeriodTo, DateTime.Now, employeeId);
            TimeSpan ts = new TimeSpan();

            ts = (TimeSpan)(DateTime.Now - PeriodTo);

            //if (ts.TotalHours < (Convert.ToInt16(baseClass.RoleTats) + offHours + 24))
            if (ts.TotalHours <  offHours + 24)
            {
                return true;
            }
            return false;
        }

        public int GetTotalOffHours(DateTime dtFrom, DateTime dtTo, int EmployeeId)
        {

            int hours = 0;
            //if (dtFrom.Month == dtTo.Month)
            {
                int monthCal = dtFrom.Month != 0 ? dtFrom.Month : dtTo.Month;
                int yearCal = dtFrom.Year != 0 ? dtFrom.Year : dtTo.Year;
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Month", monthCal);
                queryParameters.Add("@Year", yearCal);
                queryParameters.Add("@EmployeeId", EmployeeId);


                var spName = "GetTMS_Calendar";

                TMS_TM_Employee_Calendar model = new TMS_TM_Employee_Calendar();
                 IEnumerable<TMS_TM_Employee_Calendar> empCals = dapperManager.QueryListWithoutTask(model, spName, queryParameters);
                //IEnumerable<TMS_TM_Employee_Calendar> empCals = null;

                var dt = HelperClass.ToDataTable<TMS_TM_Employee_Calendar>(empCals.ToList());
                int offDayCount = 0;
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int month = Convert.ToInt16(dt.Rows[i]["Month"]);
                        int year = Convert.ToInt16(dt.Rows[i]["Year"]);

                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            if (dt.Columns[j].ColumnName.ToUpper().Contains("DAY"))
                            {
                                int ColumnDay = Convert.ToInt16(dt.Columns[j].ColumnName.Remove(0, 3));
                                DateTime dtCalculated;
                                bool isValidDate = DateTime.TryParse((month + "/" + ColumnDay + "/" + year), out dtCalculated);
                                if (isValidDate && dtCalculated >= dtFrom && dtCalculated <= dtTo)
                                {
                                    if (Convert.ToInt16(dt.Rows[i][j]) == (int)Constant.TMSDayTypes.Holiday || Convert.ToInt16(dt.Rows[i][j]) == (int)Constant.TMSDayTypes.Off)
                                    {
                                        offDayCount++;
                                    }
                                }
                            }
                        }
                    }
                }
                hours = offDayCount * 24;
            }
            return hours;
        }



    }

   
}

