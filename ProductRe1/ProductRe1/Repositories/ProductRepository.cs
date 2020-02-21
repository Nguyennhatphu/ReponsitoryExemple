using Microsoft.EntityFrameworkCore;
using DemoRepository.Models;
using DemoRepository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoRepository.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private readonly AppDbContext _context;
		public ProductRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task<int> AddProduct(Product product)
		{
			int result = 0;
			if (_context != null)
			{
				product.CreatedDate = DateTime.Now;
				await _context.Product.AddAsync(product);

				await _context.SaveChangesAsync();
				result = product.Id;
			}
			return result;
		}

		public async Task<int> DeleteProduct(int? id)
		{
			int result = 0;
			if (_context != null)
			{
				var product = await _context.Product.FirstOrDefaultAsync(x => x.Id == id);
				if (product != null)
				{
					product.IsDeleted = true;
					result = await _context.SaveChangesAsync();
				}
			}
			return result;
		}

		public async Task<int> EditProduct(int id, Product product)
		{
			product.Id = id;
			int result = 0;
			if (_context != null)
			{
				//Edit Product
				_context.Product.Update(product);

				//Commit
				result = await _context.SaveChangesAsync();
			}
			return result;
		}

		public async Task<Product> GetProduct(int? id)
		{
			if (_context != null)
			{
				return await (from p in _context.Product
							  where p.Id == id
							  select new Product
							  {
								  Id = p.Id,
								  Name = p.Name,
								  Detail = p.Detail,
								  Price = p.Price,
								  Unit = p.Unit,
								  Quantity = p.Quantity,
								  CreatedDate = p.CreatedDate,
								  ModifiedDate = p.ModifiedDate,
								  IsDeleted = p.IsDeleted
							  }).FirstOrDefaultAsync();
			}
			return null;
		}


		public async Task<List<Product>> ListProduct()
		{
			if (_context != null)
			{
				return await(from p in _context.Product
							 where p.IsDeleted == false
							 orderby p.Id
							 select new Product
							 {
								 Id = p.Id,
								 Name = p.Name,
								 Detail = p.Detail,
								 Price = p.Price,
								 Unit = p.Unit,
								 Quantity = p.Quantity,
								 CreatedDate = p.CreatedDate,
								 ModifiedDate = p.ModifiedDate,
								 IsDeleted = p.IsDeleted
							 }).ToListAsync();
			}
			return null;
		}

		//public Task<List<Product>> ListProductPaging(int pageSize, int pageIndex)
		//{
		//	throw new NotImplementedException();
		//}
	}
}
