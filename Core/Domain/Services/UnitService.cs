using Core.Domain.Interfaces.Repositories;
using System;

namespace Core.Domain.Services
{
    public abstract class UnitService : Service
    {
        protected IUnitOfWork _unitOfWork;

        public UnitService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}