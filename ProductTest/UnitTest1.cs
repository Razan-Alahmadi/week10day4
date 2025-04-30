using ProductApi.Models;
using ProductApi.Services;
using ProductApi.Data;
using Xunit;
using System.Linq;
using System.Collections.Generic;

namespace ProductTest
{
    public class UnitTest1
    {
        private ProductService _service;

        public UnitTest1()
        {
            // Reset the static ProductData for isolated tests (optional)
            ProductData.Products.Clear();
            ProductData.Products.AddRange(new List<Product>
            {
                new Product { Id = 1, Name = "Laptop", Price = 1500 },
                new Product { Id = 2, Name = "Smartphone", Price = 800 }
            });

            _service = new ProductService();
        }

        [Fact]
        public void GetAll_ReturnsAllProducts()
        {
            var result = _service.GetAll();
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void GetById_ExistingId_ReturnsCorrectProduct()
        {
            var result = _service.GetById(1);
            Assert.NotNull(result);
            Assert.Equal("Laptop", result.Name);
        }

        [Fact]
        public void GetById_NonExistingId_ReturnsNull()
        {
            var result = _service.GetById(999);
            Assert.Null(result);
        }

        [Fact]
        public void Add_NewProduct_IncreasesCountAndAssignsId()
        {
            var newProduct = new Product { Name = "Tablet", Price = 600 };

            _service.Add(newProduct);

            var allProducts = _service.GetAll();
            Assert.Equal(3, allProducts.Count);
            Assert.Contains(allProducts, p => p.Name == "Tablet" && p.Id == 3);
        }
    }
}
