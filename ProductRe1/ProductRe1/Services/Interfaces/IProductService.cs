using DemoRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoRepository.Services.Interfaces
{
	public interface IProductService
	{
		Task<int> AddProduct(Product product);
		Task<int> EditProduct(int id,Product product);
		Task<int> DeleteProduct(int? id);
		Task<Product> GetProduct(int? id);
		Task<List<Product>> ListProduct();
		//Task<List<Product>> ListProductPaging(int pageSize, int page);

	}
}
