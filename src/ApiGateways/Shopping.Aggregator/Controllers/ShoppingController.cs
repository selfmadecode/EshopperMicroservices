using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopping.Aggregator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
