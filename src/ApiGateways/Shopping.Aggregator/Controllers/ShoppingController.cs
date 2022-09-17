using Microsoft.AspNetCore.Mvc;
using Shopping.Aggregator.Models;
using Shopping.Aggregator.Services;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Shopping.Aggregator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingController : ControllerBase
    {
        private readonly IBasketService _basket;
        private readonly IOrderService _order;
        private readonly ICatalogService _catalog;

        public ShoppingController(IBasketService basket, IOrderService order, ICatalogService catalog)
        {
            _basket = basket ?? throw new ArgumentNullException(nameof(basket));
            _order = order ?? throw new ArgumentNullException(nameof(order));
            _catalog = catalog ?? throw new ArgumentNullException(nameof(catalog));
        }

        [HttpGet("{userName}", Name = "GetShopping")]
        [ProducesResponseType(typeof(ShoppingModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingModel>> GetShopping(string userName)
        {
            // get basket with username
            // iterate basket items and consume products with basket item productId member
            // map product related members into basketitem dto with extended columns
            // consume ordering microservices in order to retrieve order list
            // return root ShoppngModel dto class which including all responses

            var basket = await _basket.GetBasket(userName);

            foreach (var item in basket.Items)
            {
                var product = await _catalog.GetCatalog(item.ProductId);

                // set additional product fields onto basket item
                item.ProductName = product.Name;
                item.Category = product.Category;
                item.Summary = product.Summary;
                item.Description = product.Description;
                item.ImageFile = product.ImageFile;
            }

            var orders = await _order.GetOrdersByUserName(userName);

            var shoppingModel = new ShoppingModel
            {
                UserName = userName,
                BasketWithProducts = basket,
                Orders = orders
            };

            return Ok(shoppingModel);
        }
    }
}
