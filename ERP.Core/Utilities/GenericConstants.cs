using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace ERP.Core.Utilities
{
    public struct GenericConstants
    {
        public const string ConnectionStringKey = "ConnectionString";
        public static int Sql_CommandTimeout = 36000;
        public const string DefaultDateFormat = "MMM dd,yyyy";
        public const string DateFormat1 = "dd-MMM-yyyy ddd";
        public const string DateFormat2 = "MM/dd/yyyy";
        public const string DefaultDateFormatWithTime = "MMM dd,yyyy HH:mm:ss";
        public const string DateFormatDDMMYYYY = "dd-MM-yyyy";
        public const string TimeFormatLong = "HH:mm:ss";
        public const string TimeFormatAMPM = "hh:mm:ss tt";
        public const string ErrorLog = "Logs/ExceptionsLogs";
        public const string GetDefaultPage = "/Default.aspx";
        public const string EmailLog = "Logs/EmailLog";
        //public const string ApplicationPath = "http://localhost:3000/";
        public const string ApplicationPath = "http://192.12.123.25:999/";

        #region DB_NAMES

        public const string DB_Setup = "SW_Setup";
        public const string DB_HRMS = "SW_HRMS";
        public const string DB_TMS = "SW_TMS";

        #endregion

        #region Connection String
        public const string ConnectionStringDB1 = @"Data Source = 192.168.132.54\MSSQLSERVER2017;Initial Catalog = DB1;User ID=sa;pwd=ABC123;";
        public const string ConnectionStringDB2 = @"Data Source = 192.168.132.54\MSSQLSERVER2017;Initial Catalog = DB2; User ID=sa;pwd=ABC123;";
        #endregion
    }
    public struct UserRole
    {
        public const int SuperAdmin = 1;
        public const int Admin = 2;
        public const int Incharge = 3;
        public const int Employee = 4;
    }
    public struct Setup_Master
    {
    }
    public struct Setup_MasterDetail
    {

    }
    public struct Feature
    {
        public const int Add = 1;
        public const int Edit = 2;
        public const int Delete = 3;
        public const int View = 4;
    }

    public class Constant
    {
        public enum TMSDayTypes
        {

            Working = 1,
            Alternate = 2,
            Holiday = 3,
            Leave = 4,
            Off = 5,
            NotApplicable = 10
        }
        public enum DayOfWeek
        {
            Sunday = 0,
            Monday = 1,
            Tuesday = 2,
            Wednesday = 3,
            Thursday = 4,
            Friday = 5,
            Saturday = 6
        }
        public enum TMSLeaveTypes
        {
            Sick = 1,
            Annual = 2,
            Casual = 3,
            Maternity = 4,
            Default = 5,
            WithoutPay = 6,
            Official = 7
        }
        public enum LeaveChangesCode
        {
            YE = 1,
            CR = 2,
            MC = 3
        }


    }
    


}
