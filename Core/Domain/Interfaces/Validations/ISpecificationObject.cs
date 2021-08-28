using System.Collections.Generic;

namespace Core.Domain.Interfaces.Validations
{
    public interface ISpecificationObject
    {
        List<string> Errors { get; }

        bool IsValid();
    }
}