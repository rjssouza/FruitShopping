using System;
using System.Collections.Generic;

namespace Fruit.Application.ViewModels.Cart
{
    public class CartViewModel
    {
        public string UserId { get; set; }
        public Guid Id { get; set; }
        public List<CartItemViewModel> Items { get; set; }
    }
}