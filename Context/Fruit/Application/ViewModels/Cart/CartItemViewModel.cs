using System;

namespace Fruit.Application.ViewModels.Cart
{
    public class CartItemViewModel
    {
        public Guid CartId { get; set; }
        public Guid FruitId { get; set; }
        public string FruitName { get; set; }
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}