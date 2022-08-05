using MediatR;
using System;

namespace Ordering.Application.Features.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
