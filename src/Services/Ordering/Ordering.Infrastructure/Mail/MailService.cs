using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
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
        public ILogger<EmailSettings> _logger { get;}

        public MailService(IOptions<EmailSettings> emailSettings, ILogger<EmailSettings> logger)
        {
            _emailSettings = emailSettings.Value ?? throw new ArgumentNullException(nameof(emailSettings));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task<bool> SendEmail(Email email)
        {
            throw new NotImplementedException();
        }
    }
}
