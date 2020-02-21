using DemoRepository.Models;
using DemoRepository.Repositories.Interfaces;
using DemoRepository.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoRepository.Services
{
	public class ProductService : IProductService
	{
		private readonly IProductRepository _productRepository;
		public ProductService(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}
		public Task<int> AddProduct(Product product)
		{
			return _productRepository.AddProduct(product);
		}

		public Task<int> DeleteProduct(int? id)
		{
			return _productRepository.DeleteProduct(id);
		}

		public Task<int> EditProduct(int id,Product product)
		{
			return _productRepository.EditProduct(id, product);
		}

		public Task<Product> GetProduct(int? id)
		{
			return _productRepository.GetProduct(id);
		}

		public async Task<List<Product>> ListProduct()
		{
			return await _productRepository.ListProduct();
		}

		//public Task<List<Product>> ListProductPaging(int pageSize, int page)
		//{
		//	return _productRepository.ListProductPaging(pageSize, page);
		//}
	}
}
