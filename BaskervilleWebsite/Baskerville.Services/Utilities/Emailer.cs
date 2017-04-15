using Baskerville.Services.Constants;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Baskerville.Services.Utilities
{
    public class Emailer
    {
        private SmtpSection section;
        private SmtpClient client;

        public Emailer(string smtpName)
        {
            this.ConfigureClient(smtpName);
        }

        private void ConfigureClient(string smtpName)
        {
            this.section = (SmtpSection)ConfigurationManager.GetSection(MailSettings.SmtpSettings + smtpName);

            this.client = new SmtpClient();
            this.client.Port = section.Network.Port;
            this.client.Host = section.Network.Host;
            this.client.Credentials = new NetworkCredential(section.Network.UserName, section.Network.Password);
            this.client.EnableSsl = section.Network.EnableSsl;
        }

        public bool SendEmail(string body, string subject, bool isHtml, string receiver)
        {
            string[] receivers = new string[] { receiver };

            return this.SendEmail(body, subject, isHtml, receivers);
        }

        public bool SendEmail(string body, string subject, bool isHtml, IEnumerable<string> receivers)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(this.section.From);
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = isHtml;

            foreach (var receiver in receivers)
                message.To.Add(new MailAddress(receiver));
            
            try
            {
                this.client.Send(message);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
