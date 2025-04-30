using ProductApi.Models;
using System.Collections.Generic;

namespace ProductApi.Services
{
	public interface IProductService
	{
		public List<Product> GetAll();
		public Product GetById(int id);
		public void Add(Product product);
	}
}
