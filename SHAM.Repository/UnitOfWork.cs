using SHAM.Repository.Context;
using SHAM.Repository.Contracts;
using System.Threading.Tasks;

namespace SHAM.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly SHAMDbContext _dbContext;

        public SHAMDbContext DbContext => _dbContext;

        public UnitOfWork(SHAMDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {

        }
    }
}
