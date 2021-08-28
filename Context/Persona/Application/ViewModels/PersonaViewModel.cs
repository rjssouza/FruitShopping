using System.Collections.Generic;

namespace Persona.Application.ViewModels
{
    public class PersonaViewModel
    {
        public string Name { get; set; }
        public List<PhotoViewModel> Photo { get; set; }
    }
}