using Core.Domain.Interfaces.Repositories;
using System.Collections.Generic;

namespace Core.Domain.Validations
{
    public abstract class UnitValidation : Validation
    {
        protected IUnitOfWork _unitOfWork;

        public UnitValidation(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this.Errors = new List<string>();
        }
    }
}