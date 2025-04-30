using ProductApi.Models;
using ProductApi.Data;
using System.Collections.Generic;
using System.Linq;

namespace ProductApi.Services
{
	public class ProductService : IProductService
	{
		public List<Product> GetAll()
		{
			return ProductData.Products;
		}

		public Product GetById(int id)
		{
			return ProductData.Products.FirstOrDefault(p => p.Id == id);
		}

		public void Add(Product product)
		{
			product.Id = ProductData.Products.Max(p => p.Id) + 1;
			ProductData.Products.Add(product);
		}
	}
}
