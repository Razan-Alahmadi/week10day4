using ProductApi.Models;

namespace ProductApi.Data
{
	public static class ProductData
	{
		public static List<Product> Products { get; } = new List<Product>
		{
			new Product { Id = 1, Name = "Laptop", Price = 1500 },
			new Product { Id = 2, Name = "Smartphone", Price = 800 },
			new Product { Id = 3, Name = "Headphones", Price = 200 },
			new Product { Id = 4, Name = "Monitor", Price = 300 },
			new Product { Id = 5, Name = "Keyboard", Price = 100 }
		};
	}
}
