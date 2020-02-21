using DemoRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoRepository.Repositories.Interfaces
{
	public interface IProductRepository
	{
		Task<int> AddProduct(Product product);
		Task<int> EditProduct(int id, Product product);
		Task<int> DeleteProduct(int? id);
		Task<Product> GetProduct(int? id);
		Task<List<Product>> ListProduct();
		//Task<List<Product>> ListProductPaging(int pageSize, int pageIndex);

	}
}