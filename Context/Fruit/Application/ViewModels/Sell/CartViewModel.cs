using System;
using System.Collections.Generic;

namespace Fruit.Application.ViewModels.Sell
{
    public class CartViewModel
    {
        public Guid FruitId { get; set; }
        public int Quantity { get; set; }
        public Guid Id { get; set; }
        public List<CartItemViewModel> Items { get; set; }
    }
}