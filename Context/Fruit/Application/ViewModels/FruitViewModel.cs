using Fruit.Application.ViewModels.Cart;
using System;
using System.Collections.Generic;

namespace Fruit.Application.ViewModels
{
    public class FruitViewModel
    {
        public string Description { get; private set; }
        public virtual FruitInventoryViewModel Inventory { get; private set; }
        public Guid InventoryId { get; set; }
        public string Name { get; private set; }
        public virtual List<FruitPictureViewModel> Pictures { get; private set; }
        public decimal Price { get; private set; }
        public virtual List<CartItemViewModel> SellItems { get; private set; }
    }
}