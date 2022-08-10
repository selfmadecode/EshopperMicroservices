using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ordering.Application.Features.Orders.Commands.CheckoutOrder;
using Ordering.Application.Features.Orders.Commands.DeleteOrder;
using Ordering.Application.Features.Orders.Commands.UpdateOrder;
using Ordering.Application.Features.Orders.Queries.GetOrdersList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Ordering.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("{userName}", Name = nameof(GetOrdersByUserName))]
        [ProducesResponseType(typeof(IEnumerable<OrdersVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<OrdersVm>>> GetOrdersByUserName(string userName)
        {
            var query = new GetOrdersListQuery(userName);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // rabbitMQ
        [HttpPost(Name = nameof(Checkout))]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Guid>> Checkout([FromBody] CheckoutOrderCommand model)
        {
            var result = await _mediator.Send(model);
            return Ok(result);
        }

        [HttpPut(Name = nameof(Update))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateOrderCommand model)
        {
            await _mediator.Send(model);
            return NoContent();
        }

        [HttpDelete("{id}", Name = nameof(Delete))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteOrderCommand()
            {
                Id = id
            };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
