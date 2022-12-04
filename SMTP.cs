using Core.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class SMTP
    {
        public bool SendEMail(SendEmailRequest sendEmailRequest)
        {
            StringBuilder sbLogger = new StringBuilder();
            sbLogger.Append(Environment.NewLine + "--------------------------------------------" + Environment.NewLine + "Log Start :" + DateTime.Now.ToLongTimeString() + " " + DateTime.Now.ToLongDateString() + Environment.NewLine + "--------------------------------------------" + Environment.NewLine);
            sbLogger.Append(Newtonsoft.Json.JsonConvert.SerializeObject(sendEmailRequest));
            bool response = false;
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");//("secure.emailsrvr.com");
                mail.From = new MailAddress(sendEmailRequest.FromEmail);
                mail.To.Add(sendEmailRequest.ToEmail);
                if (!string.IsNullOrEmpty(sendEmailRequest.CcEmail))
                    mail.CC.Add(sendEmailRequest.CcEmail.ToLower());
                if (!string.IsNullOrEmpty(sendEmailRequest.BccEmail))
                    mail.Bcc.Add(sendEmailRequest.BccEmail.ToLower());

                mail.Subject = sendEmailRequest.MailSubject;
                mail.IsBodyHtml = true;
                mail.Body = sendEmailRequest.MailBody;
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(sendEmailRequest.FromEmail, System.Configuration.ConfigurationManager.AppSettings["SendEmailPwd"]);
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                response = true;
                sbLogger.Append(Environment.NewLine + "--------------------------------------------" + Environment.NewLine + "Log Entry :" + DateTime.Now.ToLongTimeString() + " " + DateTime.Now.ToLongDateString() + Environment.NewLine + "--------------------------------------------" + Environment.NewLine);
                sbLogger.Append("SendMail:-" + response.ToString());
                sbLogger.Append(Environment.NewLine + "--------------------------------------------" + Environment.NewLine + "Log End :" + DateTime.Now.ToLongTimeString() + " " + DateTime.Now.ToLongDateString() + Environment.NewLine + "--------------------------------------------" + Environment.NewLine);
                new LogWriter(sbLogger.ToString(), "Email-" + DateTime.Today.ToString("ddMMyyyy"));
            }
            catch (Exception ex)
            {
                sbLogger.Append(Environment.NewLine + "--------------------------------------------" + Environment.NewLine + "Log Entry :" + DateTime.Now.ToLongTimeString() + " " + DateTime.Now.ToLongDateString() + Environment.NewLine + "--------------------------------------------" + Environment.NewLine);
                sbLogger.Append("SendMail:-" + response.ToString());
                sbLogger.Append(Environment.NewLine + "--------------------------------------------" + Environment.NewLine + "Log Entry :" + DateTime.Now.ToLongTimeString() + " " + DateTime.Now.ToLongDateString() + Environment.NewLine + "--------------------------------------------" + Environment.NewLine);
                sbLogger.Append(ex.ToString());
                sbLogger.Append(Environment.NewLine + "--------------------------------------------" + Environment.NewLine + "Log End :" + DateTime.Now.ToLongTimeString() + " " + DateTime.Now.ToLongDateString() + Environment.NewLine + "--------------------------------------------" + Environment.NewLine);
                new LogWriter(sbLogger.ToString(), "EmailExeption-" + DateTime.Today.ToString("ddMMyyyy"));
            }
            return response;
        }

        public bool SendEMail_Zoho(SendEmailRequest sendEmailRequest)
        {
            StringBuilder sbLogger = new StringBuilder();
            sbLogger.Append(Environment.NewLine + "--------------------------------------------" + Environment.NewLine + "Log Start :" + DateTime.Now.ToLongTimeString() + " " + DateTime.Now.ToLongDateString() + Environment.NewLine + "--------------------------------------------" + Environment.NewLine);
            sbLogger.Append(Newtonsoft.Json.JsonConvert.SerializeObject(sendEmailRequest));
            bool response = false;
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtppro.zoho.eu");//("secure.emailsrvr.com");
                mail.From = new MailAddress("reservations@flightforall.com");
                mail.To.Add("shailendra.flightapi@gmail.com");
                //if (!string.IsNullOrEmpty(sendEmailRequest.CcEmail))
                //    mail.CC.Add(sendEmailRequest.CcEmail.ToLower());
                //if (!string.IsNullOrEmpty(sendEmailRequest.BccEmail))
                //    mail.Bcc.Add(sendEmailRequest.BccEmail.ToLower());

                mail.Subject = sendEmailRequest.MailSubject;
                mail.IsBodyHtml = true;
                mail.Body = sendEmailRequest.MailBody;
                SmtpServer.Port = 465;
                SmtpServer.Credentials = new System.Net.NetworkCredential("reservations@flightforall.com", "Flights@123");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                response = true;
                sbLogger.Append(Environment.NewLine + "--------------------------------------------" + Environment.NewLine + "Log Entry :" + DateTime.Now.ToLongTimeString() + " " + DateTime.Now.ToLongDateString() + Environment.NewLine + "--------------------------------------------" + Environment.NewLine);
                sbLogger.Append("SendMail:-" + response.ToString());
                sbLogger.Append(Environment.NewLine + "--------------------------------------------" + Environment.NewLine + "Log End :" + DateTime.Now.ToLongTimeString() + " " + DateTime.Now.ToLongDateString() + Environment.NewLine + "--------------------------------------------" + Environment.NewLine);
                //new LogWriter(sbLogger.ToString(), "Email-" + DateTime.Today.ToString("ddMMyyyy"));
            }
            catch (Exception ex)
            {
                sbLogger.Append(Environment.NewLine + "--------------------------------------------" + Environment.NewLine + "Log Entry :" + DateTime.Now.ToLongTimeString() + " " + DateTime.Now.ToLongDateString() + Environment.NewLine + "--------------------------------------------" + Environment.NewLine);
                sbLogger.Append("SendMail:-" + response.ToString());
                sbLogger.Append(Environment.NewLine + "--------------------------------------------" + Environment.NewLine + "Log Entry :" + DateTime.Now.ToLongTimeString() + " " + DateTime.Now.ToLongDateString() + Environment.NewLine + "--------------------------------------------" + Environment.NewLine);
                sbLogger.Append(ex.ToString());
                sbLogger.Append(Environment.NewLine + "--------------------------------------------" + Environment.NewLine + "Log End :" + DateTime.Now.ToLongTimeString() + " " + DateTime.Now.ToLongDateString() + Environment.NewLine + "--------------------------------------------" + Environment.NewLine);
                new LogWriter(sbLogger.ToString(), "EmailExeption-" + DateTime.Today.ToString("ddMMyyyy"));
            }
            return response;
        }
        private string getPassword(string FromEmail)
        {
            string Pwd = string.Empty;
            switch (FromEmail.ToLower())
            {
                case "Truairfare@flightbookingsupport.com": Pwd = "Axptra@0909"; break;

                default: break;
            }
            return Pwd;
        }
    }
}
