using SHAM.Repository.Context;
using System;
using System.Threading.Tasks;

namespace SHAM.Repository.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        SHAMDbContext DbContext { get; }

        void SaveChanges();

        Task<int> SaveChangesAsync();
    }
}
