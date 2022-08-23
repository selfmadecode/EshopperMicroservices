using AutoMapper;
using EventBus.Message.Events;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace Ordering.API.EventBusConsumer
{
    // The IConsumer class is need to make basketcheckoutConsumer the subscriber of BasketCheckoutEvent
    public class BasketCheckoutConsumer : IConsumer<BasketCheckoutEvent>
    {
        private readonly IMapper _mapper;
        public Task Consume(ConsumeContext<BasketCheckoutEvent> context)
        {
            throw new NotImplementedException();
        }
    }
}
