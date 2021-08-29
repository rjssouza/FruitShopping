using AutoMapper;
using Core.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;

namespace Core.Application.AppServices
{
    public class AppServiceTransaction : AppServiceBase
    {
        protected readonly IUnitOfWorkTransaction _coreUnitOfWorkTransaction;

        public AppServiceTransaction(IUnitOfWorkTransaction coreUnitOfWorkTransaction, IMapper mapper, IHttpContextAccessor httpContextAccessor)
            : base(mapper, httpContextAccessor)
        {
            this._coreUnitOfWorkTransaction = coreUnitOfWorkTransaction;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            this._coreUnitOfWorkTransaction.Dispose();
        }

        protected void SaveChanges()
        {
            this._coreUnitOfWorkTransaction.SaveChanges();
        }
    }
}