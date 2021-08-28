using Core.Domain.Interfaces.Repositories;
using System;

namespace Core.Domain.Services
{
    public abstract class UnitService<TUnitOfWork> : Service
        where TUnitOfWork : IUnitOfWork
    {
        protected TUnitOfWork _unitOfWork;

        public UnitService(TUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}