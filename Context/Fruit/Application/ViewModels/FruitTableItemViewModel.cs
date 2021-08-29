using System;

namespace Fruit.Application.ViewModels
{
    public class FruitTableItemViewModel
    {
        public string Description { get; private set; }
        public Guid InventoryId { get; set; }
        public string Name { get; private set; }
        public byte[] Picture { get; set; }
        public decimal Price { get; private set; }
    }
}