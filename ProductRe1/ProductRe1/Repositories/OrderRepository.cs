using Microsoft.EntityFrameworkCore;
using DemoRepository.Models;
using DemoRepository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoRepository.Repositories
{
	public class OrderRepository : IOrderRepository
	{
		private readonly AppDbContext _context;

		public OrderRepository(AppDbContext context)
		{
			_context = context;
		}
		public async Task<int> AddOrder(Order order)
		{
			int result = 0;
			if (_context != null)
			{
				//Tạo datetime theo thời gian thực
				order.CreatedDate = DateTime.Now;
				await _context.Order.AddAsync(order);

				await _context.SaveChangesAsync();
				result = order.Id;
			}
			return result;
		}

		public async Task<int> DeleteOrder(int? id)
		{
			int result = 0;
			if (_context != null)
			{
				var order = await _context.Order.FirstOrDefaultAsync(x => x.Id == id);
				if (order != null)
				{
					//đưa trạng thái của IsDeleted thành trạng thái true
					order.IsDeleted = true;
					result = await _context.SaveChangesAsync();
				}
			}
			return result;
		}

		public async Task<int> EditOrder(int id, Order order)
		{
			order.Id = id;
			int result = 0;
			if (_context != null)
			{
				//Edit Product
				_context.Order.Update(order);

				//Commit
				result = await _context.SaveChangesAsync();
			}
			return result;
		}

		public async Task<Order> GetOrder(int? id)
		{
			if (_context != null)
			{
				return await(from o in _context.Order
							 where o.Id == id
							 select new Order
							 {
								 Id = o.Id,
								 ProductId = o.ProductId,
								 Quantity = o.Quantity,
								 CreatedDate = o.CreatedDate,
								 IsDeleted = o.IsDeleted
							 }).FirstOrDefaultAsync();
			}
			return null;
		}

		public async Task<List<Order>>ListOrder()
		{
			if (_context != null)
			{
				return await(from o in _context.Order
							 where o.IsDeleted == false
							 orderby o.Id descending
							 select new Order
							 {
								 Id = o.Id,
								 ProductId = o.ProductId,
								 Quantity = o.Quantity,
								 CreatedDate = o.CreatedDate,
								 IsDeleted = o.IsDeleted
							 }).ToListAsync();
			}
			return null;
		}
	}
}
