using Newtonsoft.Json;
using System;

namespace Persona.Application.ViewModels
{
    public class PhotoViewModel
    {
        public byte[] Content { get; set; }

        [JsonIgnore]
        public int Identifier { get; set; }

        [JsonIgnore]
        public string Name { get; set; }

        [JsonIgnore]
        public Guid PersonaId { get; set; }

        public string PicureUrl { get; set; }
    }
}