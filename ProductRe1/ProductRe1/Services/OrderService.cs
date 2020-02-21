using DemoRepository.Models;
using DemoRepository.Repositories.Interfaces;
using DemoRepository.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoRepository.Services
{
	public class OrderService : IOrderService
	{
		private readonly IOrderRepository _orderRepository;
		public OrderService(IOrderRepository orderRepository)
		{
			_orderRepository = orderRepository;
		}
		public Task<int> AddOrder(Order order)
		{
			return _orderRepository.AddOrder(order);
		}

		public Task<int> DeleteOrder(int? id)
		{
			return _orderRepository.DeleteOrder(id);
		}

		public Task<int> EditOrder(int id, Order order)
		{
			return _orderRepository.EditOrder(id, order);
		}

		public Task<Order> GetOrder(int? id)
		{
			return _orderRepository.GetOrder(id);
		}

		public async Task<List<Order>> ListOrder()
		{
			return await _orderRepository.ListOrder();
		}
	}
}
