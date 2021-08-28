using System;

namespace Core.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        TRepository GetRepository<TRepository>();
    }
}