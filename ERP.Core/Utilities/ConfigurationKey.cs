using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Utilities
{
    public  struct ConfigurationKey
    {
        public const string SenderEmailAddress = "sdg.app@sybrid.com";
        public const string SenderEmailPassword = "Sybrid@098";
        public const string SenderSMTPServer = "smtp.gmail.com";
        public const string Port = "587";
        public const string clientEnableSsl = "true";
        public const string Displayname = "Sybrid";
        public const string BCC = "";
        //public const string ReplyTo = ConfigurationManager.AppSettings["ReplyTo"];
    }
}
