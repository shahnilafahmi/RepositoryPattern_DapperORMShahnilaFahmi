using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net.Mail;
using ERP.Utilities.Email;

namespace ERP.Utilities.Email.EmailSecuritySetUp
{
    public class EmailSecuritySetUp
    {
        public static string SenderEmailAddress = ConfigurationKey.SenderEmailAddress;
        public static string SenderEmailPassword = ConfigurationKey.SenderEmailPassword;
        public static string SenderSMTPServer = ConfigurationKey.SenderSMTPServer ;
        public static string Port = ConfigurationKey.Port;
        public static string clientEnableSsl = ConfigurationKey.clientEnableSsl;
        public static string Displayname = ConfigurationKey.Displayname;
       // public static string ReplyTo = CConfigurationKey.re;

        public static void SendMail(string to, string subject, string msg, string cc, string Attachment, string var)
        {
            //to = "faizan.farooq@sybrid.com";
            to = "shahnila.fahmi@sybrid.com";

            cc = "";
            if (string.IsNullOrEmpty(to) == false)
            {
                if (SenderSMTPServer != "" && SenderEmailAddress != "" && Port != "")
                {
                    string BCC = System.Configuration.ConfigurationManager.AppSettings["BCC"];
                    string LogMessage = subject + " : " + to + (cc != "" ? (";" + cc + "") : "") + (BCC != "" ? (";" + BCC + "") : "");
                    try
                    {
                        MailMessage message = new MailMessage();
                        string[] addresses = to.Split(';');
                        foreach (string address in addresses)
                        {
                            if (address != "")
                            {
                                message.To.Add(new MailAddress(address));
                            }
                        }
                        if (cc != "")
                        {
                            string[] cc_address = cc.Split(';');
                            foreach (string address in cc_address)
                            {
                                if (address != "")
                                {
                                    message.CC.Add(new MailAddress(address));
                                }
                            }
                        }
                        if (BCC != "")
                        {
                            string[] BCC_address = BCC.Split(';');
                            foreach (string address in BCC_address)
                            {
                                if (address != "")
                                {
                                    message.Bcc.Add(new MailAddress(address));
                                }
                            }
                        }


                        if (Attachment != string.Empty)
                        {
                            string[] Attachment_ = Attachment.Split(';');
                            foreach (string file in Attachment_)
                            {
                                if (file != "")
                                {
                                    System.Net.Mail.Attachment attach = new System.Net.Mail.Attachment(file);
                                    message.Attachments.Add(attach);
                                }
                            }
                        }

                        message.From = new MailAddress(SenderEmailAddress, Displayname);
                        message.Subject = subject;
                        message.Body = msg;
                        message.IsBodyHtml = true;
                        SmtpClient client = new SmtpClient();
                        client.Port = Convert.ToInt32(Port);
                        client.Host = SenderSMTPServer;
                        System.Net.NetworkCredential objNetworkCredential = new System.Net.NetworkCredential(SenderEmailAddress, SenderEmailPassword);
                        client.EnableSsl = Convert.ToBoolean(clientEnableSsl);
                        client.UseDefaultCredentials = false;
                        client.Credentials = objNetworkCredential;
                        client.Send(message);
                        //Logger.WriteEmailLog("Success - ", "", LogMessage);
                    }
                    catch (Exception ex)
                    {
                       // Logger.WriteEmailLog("Error - ", ex.Message, LogMessage);
                    }
                }
            }
        }
    }
}
