using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspnetRunBasics.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspnetRunBasics
{
    public class OrderModel : PageModel
    {
        private readonly IOrderService _orderService;

        public OrderModel(IOrderService orderService)
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        }

        public IEnumerable<Entities.Order> Orders { get; set; } = new List<Entities.Order>();

        public async Task<IActionResult> OnGetAsync()
        {
            Orders = await _orderRepository.GetOrdersByUserName("test");

            return Page();
        }       
    }
}