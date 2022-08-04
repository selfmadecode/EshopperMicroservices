using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly IOrderRepository _repo;
        private readonly ILogger<DeleteOrderCommandHandler> _logger;

        public DeleteOrderCommandHandler(IOrderRepository repo, ILogger<DeleteOrderCommandHandler> logger)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var orderToDelete = await _repo.GetByIdAsync(request.Id);

            if(orderToDelete == null)
            {
                _logger.LogInformation($"Order with Id {request.Id} not found");
                // throw exception
            }

            await _repo.DeleteAsync(orderToDelete);
            _logger.LogInformation($"Order with id {request.Id} deleted successfully");

            return Unit.Value;
        }
    }
}
