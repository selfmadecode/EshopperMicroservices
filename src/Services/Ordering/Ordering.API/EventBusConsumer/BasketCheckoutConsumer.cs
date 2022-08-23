using EventBus.Message.Events;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.API.EventBusConsumer
{
    // The IConsumer class is need to make basketcheckoutConsumer the subscriber of BasketCheckoutEvent
    public class BasketCheckoutConsumer : IConsumer<BasketCheckoutEvent>
    {
    }
}
