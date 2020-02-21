using DemoRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoRepository.Repositories.Interfaces
{
	public interface IOrderRepository
	{
		Task<int> AddOrder(Order order);
		Task<int> EditOrder(int id, Order order);
		Task<int> DeleteOrder(int? id);
		Task<Order> GetOrder(int? id);
		Task<List<Order>> ListOrder();
	}
}
