using AutoMapper;
using WaterLoggic.Core.Dto;
using WaterLoggic.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WaterLoggic.Core;

namespace WaterLoggic.Controllers
{
    public class MOrderController : Controller
    {

        private readonly IMShoppingCartService _shoppingCartService;
        private readonly IMapper _mapper;
        private readonly IMOrderRepository _orderRepository;

        public MOrderController(
            IMShoppingCartService shoppingCartService,
            IMapper mapper,
            IMOrderRepository orderRepository)
        {
            _shoppingCartService = shoppingCartService;
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<IActionResult> Checkout()
        {
            var cartItems = await _shoppingCartService.GetShoppingCartItemsAsync();
            if (cartItems?.Count() <= 0)
            {
                return Redirect("/shoppingcart");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Checkout([FromForm]MOrderDto orderDto)
        {
            if (!ModelState.IsValid)
            {
                return View(orderDto);
            }

            var cartItems = await _shoppingCartService.GetShoppingCartItemsAsync();

            if (cartItems?.Count() <= 0)
            {
                ModelState.AddModelError("", "Your Cart is empty. Please add some cakes before checkout");
                return View(orderDto);
            }

            var order = _mapper.Map<MOrderDto, MOrder>(orderDto);
            order.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _orderRepository.CreateOrderAsync(order);

            await _shoppingCartService.ClearCartAsync();


            return View("CheckoutComplete");
        }


        public async Task<IActionResult> MyOrder()
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var orders = await _orderRepository.GetAllOrdersAsync(userId);
            return View(orders);
        }
    }
}
