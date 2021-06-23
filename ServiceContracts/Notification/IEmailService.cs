using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.Notification
{
    public interface IEmailService
    {
        Task SendEmail(string to, string toName, string body, string subject);
    }
}
