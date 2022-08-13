using Ordering.Application.Contracts.Infrastructure;
using Ordering.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Mail
{
    public class MailService : IEmailService
    {
        public EmailSettings _emailSettings { get; }
        public Task<bool> SendEmail(Email email)
        {
            throw new NotImplementedException();
        }
    }
}
