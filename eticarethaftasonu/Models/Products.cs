using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eticarethaftasonu.Models
{
	public class Products
	{
		[Key]
		public int ProductId { get; set; }
		[DisplayName("Ürün Adı")]
		[Required(ErrorMessage ="Boş Bırakmazsınız")]
		

		public string? ProductName { get; set; }
		[DisplayName("Ürün Kodu")]
		[Required(ErrorMessage = "Boş Bırakmazsınız")]
		public string? ProductCode { get; set; }
		[DisplayName("Ürün Açıklaması")]
		[Required(ErrorMessage = "Boş Bırakmazsınız")]
		public string? ProductDescription { get; set; }
		
		public string? ProuctPicture { get; set; }
		
        [DisplayName("Ürün Fiyatı")]
        public int ProductPrice { get; set; }
        [DisplayName("Ürün Kategorisi")]
        public int? CategoryId { get; set; }
		virtual public Category? Category { get; set; }
		[NotMapped]
		public IFormFile? ResimYukle { get; set; }
	}
}
