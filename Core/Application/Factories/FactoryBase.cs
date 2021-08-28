using Core.Domain.Interfaces.Repositories;
using System;

namespace Core.Application.Interfaces.Factories
{
    public abstract class FactoryBase : IDisposable
    {
        public IUnitOfWork _CoreUnitOfWork;
        private bool disposedValue;

        public FactoryBase(IUnitOfWork CoreUnitOfWork)
        {
            this._CoreUnitOfWork = CoreUnitOfWork;
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }
                disposedValue = true;
            }
        }
    }
}