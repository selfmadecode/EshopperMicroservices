using AutoMapper;
using Basket.API.Entities;
using Basket.API.GrpcServices;
using Basket.API.Repositories;
using EventBus.Message.Events;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Basket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        // Creates a cart for a user
        // Calls Discount GRPC service to get discount of items before calculating the total price and store
        // Uses a RedisDb for Caching
        // Raise BasketCheckoutEvent using RabbitMq and MassTransit
        // Ordering.API will consume the event raise

        private readonly IBasketRepository _repository;
        private readonly DiscountGrpcService _discountGrpcService;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _massTransitPublishEndpoint;

        public BasketController(IBasketRepository repository, DiscountGrpcService discountGrpcService,
            IMapper mapper, IPublishEndpoint massTransitPublishEndpoint)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _discountGrpcService = discountGrpcService ?? throw new ArgumentNullException(nameof(discountGrpcService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _massTransitPublishEndpoint = massTransitPublishEndpoint ?? throw new ArgumentNullException(nameof(massTransitPublishEndpoint));
        }

        [HttpGet("{userName}", Name = nameof(GetBasket))]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> GetBasket(string userName)
        {
            var basket = await _repository.GetBasket(userName);

            return Ok(basket ?? new ShoppingCart(userName));
        }

        // CREATE A BASKET OR UPDATE A BASKET FOR A USER
        // ADD ITEMS INTO THE USER'S BASKET
        // BEFORE SAVING, WE CONSUME DISCOUNT GRPC SERVICES TO GET DISCOUNT INFO FOR THE ITEM(s)
        // MINUS DISCOUNT PRICES FOR SELECTED ITEMS
        [HttpPost]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> UpdateBasket([FromBody] ShoppingCart basket)
        {
            // TODO : Communicate with Discount.Grpc
            // To setup the connection, basket controller has to have the contract/proto file
            // right click project, click add connected services,
            // service reference(grpc..)
            // add service reference
            // select grpc, locate the discount proto file
            // type-> Client (Discount is the Server, Basket is the Client

            // and Calculate latest prices of product into shopping cart
            // consume Discount Grpc
            foreach (var item in basket.Items)
            {
                var coupon = await _discountGrpcService.GetDiscount(item.ProductName);
                item.Price -= coupon.Amount;
            }

            return Ok(await _repository.UpdateBasket(basket));
        }

        [HttpDelete("{userName}", Name = nameof(DeleteBasket))]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBasket(string userName)
        {
            await _repository.DeleteBasket(userName);

            return Ok();
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Checkout([FromBody] BasketCheckout basketCheckout)
        {
            // Get existing basket using username
            // create BasketCheckoutEvent - set total price on basketCheckout eventMessage
            // send checkout event to rabbitMq
            // remove/delete the basket

            var basket = await _repository.GetBasket(basketCheckout.UserName);

            if(basket == null)
            {
                return BadRequest();
            }

            var eventMessage = _mapper.Map<BasketCheckoutEvent>(basketCheckout);
            eventMessage.TotalPrice = basket.TotalPrice;

            await _massTransitPublishEndpoint.Publish(eventMessage);

            await _repository.DeleteBasket(basketCheckout.UserName);

            return Accepted();
        }
    }
}
