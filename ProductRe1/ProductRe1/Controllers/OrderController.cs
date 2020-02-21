using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DemoRepository.Models;
using DemoRepository.Services.Interfaces;

namespace DemoRepository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        // GET: api/Order
        [HttpGet]
        public async Task<IActionResult> ListOrder()
        {
            var order = await _orderService.ListOrder();
            return StatusCode(200, order);
        }

        [HttpGet] //api/Order/id
        [Route("{id}")]

        public async Task<IActionResult> GetOrder(int? id)
        {
            var order = await _orderService.GetOrder(id);
            return StatusCode(200, order);
        }
        [HttpPost]
        public async Task<IActionResult> AddOrder(Order order)
        {
            await _orderService.AddOrder(order);
            return StatusCode(200, order);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> EditOrder(int id, Order order)
        {
            await _orderService.EditOrder(id, order);
            return StatusCode(200, order);
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteOrder(int? id)
        {
            var order = await _orderService.DeleteOrder(id);
            return StatusCode(200, order);
        }
    }
}