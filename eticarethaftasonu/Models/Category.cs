using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace eticarethaftasonu.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
		[Required(ErrorMessage = "Boş Bırakmazsınız")]
		[DisplayName("Kategori Adı")]
		public string CategoryName { get; set; }
        virtual public List<Products> Products { get; set; }
        //kateogir birden fazla ürün bilgiisi taşınambilir
        //
    }
}
