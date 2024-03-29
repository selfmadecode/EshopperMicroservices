﻿using AutoMapper;
using EventBus.Message.Events;
using Ordering.Application.Features.Orders.Commands.CheckoutOrder;

namespace Ordering.API.Mapper
{
    public class OrderingProfile : Profile
    {
        public OrderingProfile()
        {
            CreateMap<BasketCheckoutEvent, CheckoutOrderCommand>().ReverseMap();
        }
    }
}
