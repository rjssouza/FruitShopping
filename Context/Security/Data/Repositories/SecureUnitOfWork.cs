using Core.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Security.Data.Context;
using Security.Domain.Interfaces.Repositories;
using System;

namespace Security.Data.Repositories
{
    internal class SecureUnitOfWork : ISecureUnitOfWork, IUnitOfWorkTransaction
    {
        private readonly DbContext _context;
        private readonly IServiceProvider _serviceProvider;
        private bool disposedValue;

        public SecureUnitOfWork(SecureDbContext context, IServiceProvider serviceProvider)
        {
            this._context = context;
            this._serviceProvider = serviceProvider;
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public TRepository GetRepository<TRepository>()
        {
            var repository = this._serviceProvider.GetService(typeof(TRepository));

            return (TRepository)repository;
        }

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this._context.Dispose();
                }

                disposedValue = true;
            }
        }
    }
}