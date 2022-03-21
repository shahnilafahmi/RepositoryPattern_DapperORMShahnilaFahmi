using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Utilities
{
    public class EmailTemplateSecuritySetUp
    {
        public static string ResetPasswordTemplate(string senderName, int generatedPassword)
        {
            string applicationPath = GenericConstants.ApplicationPath;
            //string emailTemplate = $"Dear {senderName}, <br> <br> we have received request to reset the Password associated with your account.<br>You can signIn with Temporary Passord that is generated for you. Password:  {generatedPassword}. <br> <br> Thanks, <br> Sybrid Team";
            string emailTemplate = $"Dear {senderName}, <br> <br> we have received request to reset the Password associated with your account.<br>You can signIn with Temporary Passord that is generated for you. Click this link to change password <a href='{applicationPath}changepassword'> Change Password </a> <br> <br> Thanks, <br> Sybrid Team";
            return emailTemplate;
        }
        public static string EmailSendToHRForApplyLeave(string senderName,string applicantName,string leaveType)
        {
            string applicationPath = GenericConstants.ApplicationPath;
            //string emailTemplate = $"Dear {senderName}, <br> <br> we have received request to reset the Password associated with your account.<br>You can signIn with Temporary Passord that is generated for you. Password:  {generatedPassword}. <br> <br> Thanks, <br> Sybrid Team";
            string emailTemplate = $"Dear {senderName}, <br> <br> {applicantName} has applied for {leaveType} Leave .  <br> <br> Thanks, <br> Sybrid Team";
            return emailTemplate;
        }
    }
}
