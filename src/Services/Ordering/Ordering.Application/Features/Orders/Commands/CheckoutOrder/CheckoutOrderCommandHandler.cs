using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Contracts.Infrastructure;
using Ordering.Application.Contracts.Persistence;
using Ordering.Application.Models;
using Ordering.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Commands.CheckoutOrder
{
    public class CheckoutOrderCommandHandler : IRequestHandler<CheckoutOrderCommand, Guid>
    {
        private readonly IOrderRepository _repo;
        private readonly IMapper _mapper;
        private readonly ILogger<CheckoutOrderCommandHandler> _logger;
        private readonly IEmailService _emailService;

        public CheckoutOrderCommandHandler(IOrderRepository repo, IMapper mapper,
            ILogger<CheckoutOrderCommandHandler> logger, IEmailService emailService)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
        }

        public async Task<Guid> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<Order>(request);
            var newOrder = await _repo.AddAsync(order);

            _logger.LogInformation($"Order with id {newOrder.Id} created successfully");

            await SendMail(newOrder);
            return newOrder.Id;
        }

        private async Task SendMail(Order order)
        {
            var email = new Email()
            {
                Body = "New Order Created.",
                Subject = "New Order",
                To = "kentekz61@gmail.com"
            };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {

                _logger.LogError($"Order with id {order.Id} failed to send: {ex.Message}");
            }
        }
    }
}
