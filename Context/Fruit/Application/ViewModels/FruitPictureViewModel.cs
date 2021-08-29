using System;

namespace Fruit.Application.ViewModels
{
    public class FruitPictureViewModel
    {
        public byte[] Content { get; set; }
        public Guid FruitId { get; set; }
        public string Name { get; set; }
    }
}