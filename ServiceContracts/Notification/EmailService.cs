using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.Notification
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmail(string to,string toName,string body,string subject)
        {
            var apiKey = _configuration.GetSection("SendGrid").GetSection("ApiKey").Value;
            var from = _configuration.GetSection("SendGrid").GetSection("From").Value;
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress(from),
                Subject = "Sending with Twilio SendGrid is Fun",
                PlainTextContent = body
            };
            msg.AddTo(new EmailAddress("ungureanualexbogdan@gmail.com", toName));
            var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
        }
    }
}
