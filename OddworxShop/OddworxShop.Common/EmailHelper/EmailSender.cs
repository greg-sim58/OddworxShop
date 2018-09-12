using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;

/*
<add key = "EmailWebService.RestServiceURI" value=" " />
    <add key = "EmailWebService.ApplicationName" value=" " />
    <add key = "EmailWebService.ApplicationLicenseKey" value=" " />
    <add key = "SmtpHost" value="mail.capetown.gov.za" />
    <add key = "FromAddress" value="no-reply@capetown.gov.za" />
    */

namespace OddworxShop.Common.EmailHelper
{
    public class EmailSender
    {
        public static void SendMail(List<string> toAddresses, List<string> carbonCopies, string subject, string body)
        {
            

            using (SmtpClient smtp = new SmtpClient())
            {
                string smtpHost = ConfigurationManager.AppSettings["SmtpHost"];
                string fromAddress = ConfigurationManager.AppSettings["FromAddress"];

                smtp.Host = smtpHost;

                using (MailMessage mail = new MailMessage())
                {
                    mail.Subject = subject;
                    mail.From = new MailAddress(fromAddress);

                    foreach (string to in toAddresses)
                    {
                        mail.To.Add(to);
                    }

                    if (carbonCopies != null)
                    {
                        foreach (string cc in carbonCopies)
                        {
                            mail.CC.Add(cc);
                        }
                    }

                    mail.IsBodyHtml = true;
                    mail.Body = "<span style=\"font-family:'Century Gothic'\" >" + body + "</span><br/><br/><br/>";

                    smtp.Send(mail);
                }
            }
        }
        public static void SendMail(List<string> toAddresses, List<string> carbonCopies, string subject, string body, List<string> attachmentFilename)
        {
            using (SmtpClient smtp = new SmtpClient())
            {
                string smtpHost = ConfigurationManager.AppSettings["SmtpHost"];
                string fromAddress = ConfigurationManager.AppSettings["FromAddress"];

                smtp.Host = smtpHost;

                using (MailMessage mail = new MailMessage())
                {
                    mail.Subject = subject;
                    mail.From = new MailAddress(fromAddress);

                    foreach (string to in toAddresses)
                    {
                        mail.To.Add(to);
                    }

                    if (carbonCopies != null)
                    {
                        foreach (string cc in carbonCopies)
                        {
                            mail.CC.Add(cc);
                        }
                    }

                    foreach (var file in attachmentFilename)
                        mail.Attachments.Add(new Attachment(file));

                    mail.IsBodyHtml = true;
                    mail.Body = "<span style=\"font-family:'Century Gothic'\" >" + body + "</span><br/><br/><br/>";

                    smtp.Send(mail);
                }
            }
        }
    }
}