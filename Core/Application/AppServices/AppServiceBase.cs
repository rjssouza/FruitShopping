using AutoMapper;
using System;

namespace Core.Application.AppServices
{
    public abstract class AppServiceBase : IDisposable
    {
        protected readonly IMapper _mapper;
        private bool disposedValue;

        public AppServiceBase(IMapper mapper)
        {
            this._mapper = mapper;
        }

        public void Dispose()
        {
            Dispose(disposing: true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                disposedValue = true;
            }
        }
    }
}