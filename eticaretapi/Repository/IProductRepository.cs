using eticaretapi.Models;

namespace eticaretapi.Repository
{
	public interface IProductRepository
	{
		Task<IEnumerable<Products>> GetAll();
		Task<IEnumerable<Products>> FindAll(int id);
		Task<Products> GetById(int id);
		Task<Products> AddProduct(Products product);
		Task<Products> UpdateProduct(Products product,int id);
		Task<Products> DeleteProduct(int id);
		Task<IEnumerable<Products>> Searching(string name);
	}
}
