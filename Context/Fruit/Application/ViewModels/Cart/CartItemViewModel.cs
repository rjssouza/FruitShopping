using System;

namespace Fruit.Application.ViewModels.Cart
{
    public class CartItemViewModel
    {
        public Guid Id { get; set; }
        public Guid FruitId { get; set; }
        public int Quantity { get; set; }
        public Guid CartId { get; set; }
    }
}