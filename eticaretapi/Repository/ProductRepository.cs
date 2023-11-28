using eticaretapi.Data;
using eticaretapi.Models;
using Microsoft.EntityFrameworkCore;

namespace eticaretapi.Repository
{
	public class ProductRepository : IProductRepository
	{
		private readonly ApplicationDbContext _context;

		public ProductRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<Products> AddProduct(Products product)
		{
			var result = await _context.Products.AddAsync(product);
			await _context.SaveChangesAsync();
			return result.Entity;
		}

		public async Task<Products> DeleteProduct(int id)
		{
			var result = await _context.Products.Where(x => x.ProductId == id).FirstOrDefaultAsync();
			if(result !=null)
			{
				_context.Products.Remove(result);
				await _context.SaveChangesAsync();

			}
			return result;
		}

		public async Task<IEnumerable<Products>> FindAll(int id)
		{
			return await _context.Products.Where(x => x.ProductId == id).ToListAsync();
		}

		public async Task<IEnumerable<Products>> GetAll()
		{
			return await _context.Products.ToListAsync();
		}

		public async Task<Products> GetById(int id)
		{
			return await _context.Products.FindAsync(id);
		}

		public async Task<IEnumerable<Products>> Searching(string name)
		{
			IQueryable<Products> sorgu = _context.Products;
			if(string.IsNullOrEmpty(name))
			{
				sorgu=sorgu.Where(a=>a.ProductName.Contains(name));
			}
			return await sorgu.ToListAsync();
		}

		public async Task<Products> UpdateProduct(Products product,int id)
		{
			var result = await _context.Products.Where(x=>x.ProductId== id).FirstOrDefaultAsync();	
			if(result != null)
			{
				_context.Products.Update(product);
				await _context.SaveChangesAsync();
			}
			return result;
		}
	}
}
