using eticaretapi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eticaretapi.Models;
namespace eticaretapi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IProductRepository _productRepository;

		public ProductsController(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		[HttpGet]
		public async Task<IActionResult> GetProductAll()
		{
			try
			{
				return Ok(await _productRepository.GetAll());
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Hata Oluştu veri gelmiyor");
			}
		}
		[HttpGet("{id:int}")]
		//public async Task<IActionResult<Products>> GetAll(int id)
		//{
		//	try
		//	{
		//		var result = await _productRepository.FindAll(id);
		//		if (result == null)
		//		{
		//			return NotFound();
		//		}
		//		return result;
		//	}
		//	catch (Exception ex)
		//	{

		//		return StatusCode(StatusCodes.Status500InternalServerError, "Hata Oluştu veri gelmiyor");
		//	}
		//}
		[HttpPost]
		public async Task<IActionResult> CreateProduct(Products product)
		{
			try
			{
				if (product == null)
				{
					return BadRequest();

				}
				else
				{
					var CreateProduct = await _productRepository.AddProduct(product);
					return Ok(CreateProduct);
				}
			}
			catch (Exception ex)
			{


				return StatusCode(StatusCodes.Status500InternalServerError, "Hata Oluştu veri gelmiyor");
			}
		}
		[HttpPut("{id:int}")]
		public async Task<IActionResult>UpdateProduct(Products product,int id)
		{
			try
			{
				var productfind = await _productRepository.GetById(id);
				if (productfind == null)
				{
					return NotFound($"Ürün Bulunamadı Id{id} bulunamadı");
				}
				else
				{
					var result = await _productRepository.UpdateProduct(product, id);
					return Ok(result);
				}

			}
			catch (Exception ex)
			{

				return StatusCode(StatusCodes.Status500InternalServerError, "Hata Oluştu veri gelmiyor");
			}
		}






		[HttpDelete("{id:int}")]
		public async Task<IActionResult> DeleteProduct(int id)
		{
			try
			{
				var productfind = await _productRepository.GetById(id);
				if(productfind == null)
				{
					return NotFound($"Ürün Bulunamadı Id{id} bulunamadı");
				}
				else
				{
					var result = await _productRepository.DeleteProduct(id);
					return Ok(result);
				}
			}
			catch (Exception ex)
			{

				return StatusCode(StatusCodes.Status500InternalServerError, "Hata Oluştu veri gelmiyor");
			}
		}
	}
}
