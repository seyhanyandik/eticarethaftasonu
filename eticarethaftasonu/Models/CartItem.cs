﻿namespace eticarethaftasonu.Models
{
    public class CartItem
    {
        public long ProductId { get; set; } 
        public string ProductName { get; set; }
        public int Quantity { get; set; }   
        public decimal Price { get; set; }  
        public string Image { get; set; }
        public decimal Total
        {
            get { return Quantity * Price; }
        }
        public CartItem() { }
        public CartItem(Products product)
        {
            ProductId = product.ProductId;
            ProductName = product.ProductName;
            Quantity = 1;
            Price = product.ProductPrice;
            Image = product.ProuctPicture;

        }
    }
}
