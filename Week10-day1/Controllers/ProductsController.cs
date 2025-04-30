using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;
using ProductApi.Services;

namespace ProductApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IProductService _productService;
		private readonly IConfiguration _configuration;

		public ProductsController(IProductService productService, IConfiguration configuration)
		{
			_productService = productService;
			_configuration = configuration;
		}

		// GET /api/products
		[HttpGet]
		public ActionResult<List<Product>> GetAll()
		{
			return Ok(_productService.GetAll());
		}

		// GET /api/products/{id}
		[HttpGet("{id}")]
		public ActionResult<Product> GetById(int id)
		{
			var product = _productService.GetById(id);
			if (product == null)
				return NotFound();
			return Ok(product);
		}

		// POST /api/products
		[HttpPost]
		public ActionResult Add(Product product)
		{
			_productService.Add(product);
			return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
		}

		// GET /api/products/config
		[HttpGet("config")]
		public ActionResult GetConfig()
		{
			var appName = _configuration["AppName"];
			var defaultCurrency = _configuration["DefaultCurrency"];
			return Ok(new { AppName = appName, DefaultCurrency = defaultCurrency });
		}
	}
}