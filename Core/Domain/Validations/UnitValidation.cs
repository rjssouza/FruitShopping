using Core.Domain.Interfaces.Repositories;
using System.Collections.Generic;

namespace Core.Domain.Validations
{
    public abstract class UnitValidation<TUnitOfWork> : Validation
        where TUnitOfWork : IUnitOfWork
    {
        protected TUnitOfWork _unitOfWork;

        public UnitValidation(TUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this.Errors = new List<string>();
        }
    }
}