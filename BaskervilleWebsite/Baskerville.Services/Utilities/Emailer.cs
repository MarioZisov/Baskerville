﻿namespace Baskerville.Services.Utilities
{
    using Constants;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Net;
    using System.Net.Configuration;
    using System.Net.Mail;

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
            try
            {
                foreach (var receiver in receivers)
                {
                    MailMessage message = new MailMessage();
                    message.From = new MailAddress(this.section.From, "Club Baskerville");
                    message.Subject = subject;
                    message.Body = body;
                    message.IsBodyHtml = isHtml;
                    message.To.Add(new MailAddress(receiver));

                    this.client.Send(message);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}