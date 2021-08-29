using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;

namespace Core.Application.AppServices
{
    public abstract class AppServiceBase : IDisposable
    {
        protected readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private bool disposedValue;

        public AppServiceBase(IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this._mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        protected string CurrentUserId => _httpContextAccessor.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier).Value;

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