using System;

namespace Fruit.Application.ViewModels
{
    public class FruitTableItemViewModel
    {
        public Guid Id { get; set; }
        public string Description { get; private set; }
        public int Quantity { get; set; }
        public string Name { get; private set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; private set; }
    }
}