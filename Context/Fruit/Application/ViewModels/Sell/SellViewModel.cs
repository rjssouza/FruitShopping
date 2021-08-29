using System;
using System.Collections.Generic;

namespace Fruit.Application.ViewModels.Sell
{
    public class SellViewModel
    {
        public Guid FruitId { get; set; }
        public int Quantity { get; set; }
        public Guid SellId { get; set; }
        public List<SellItemViewModel> SellItems { get; set; }
    }
}