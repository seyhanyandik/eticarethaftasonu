using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace eticaretapi.Models
{
	public class Category
	{
		[Key]
		public int CategoryId { get; set; }
		[Required(ErrorMessage = "Boş Bırakmazsınız")]
		[DisplayName("Kategori Adı")]
		public string CategoryName { get; set; }
		virtual public List<Products> Products { get; set; }
	}
}
