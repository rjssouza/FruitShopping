using System;

namespace Fruit.Application.ViewModels.Sell
{
    public class SellItemViewModel
    {
        public Guid FruitId { get; set; }
        public int Quantity { get; set; }
        public Guid SellId { get; set; }
    }
}