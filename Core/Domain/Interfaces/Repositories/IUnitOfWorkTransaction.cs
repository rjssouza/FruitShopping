using System;

namespace Core.Domain.Interfaces.Repositories
{
    public interface IUnitOfWorkTransaction : IDisposable
    {
        void SaveChanges();
    }
}