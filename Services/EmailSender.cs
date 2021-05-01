using BlazorJob.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BlazorJob.Services
{

    public class SmtpSettings
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public string FromAddress { get; set; }
        public string Password { get; set; }

    }

    public class EmailSender : IEmailSender
    {

        private SmtpSettings _smtpSettings;

        //public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        public EmailSender(IOptions<SmtpSettings> optionsAccessor)
        {
            //Options = optionsAccessor.Value;
            _smtpSettings = optionsAccessor.Value;
        }

        public AuthMessageSenderOptions Options { get; } //set only via Secret Manager

        public Task SendEmailAsync(string email, string subject, string message)
        {
            //return Execute(Options.SendGridKey, subject, message, email);
            return SendEmailWithSmtpClientAsync(email, subject, message);
        }

#if SENDGRID_FORM_LESSONS
        public Task Execute(string apiKey, string subject, string message, string email)
        {

            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("Joe@contoso.com", Options.SendGridUser),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email)); 

            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("Joe@contoso.com", Options.SendGridUser),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);

            return client.SendEmailAsync(msg);
        }
#endif

        async public Task SendEmailWithSmtpClientAsync(string email, string subject, string message)
        {
            string from = _smtpSettings.FromAddress;
            string host = _smtpSettings.Server;
            int port = _smtpSettings.Port;

            //other logic
            using (var client = new SmtpClient(host, port))
            {
                {
                    //await client.SendMailAsync(_smtpSettings.Server, _smtpSettings.Port, true);
                    try
                    {
                        await client.SendMailAsync(from, email, subject, message);
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }
            }

            //return Task.CompletedTask;
        }


    }
}
