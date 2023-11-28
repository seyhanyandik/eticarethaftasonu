using eticarethaftasonu.Models;

namespace eticarethaftasonu.Dto
{
    public class CartViewModel
    {
        public List<CartItem>CartItems { get; set; }
        public decimal GrandTotal { get; set; } 
    }
}
