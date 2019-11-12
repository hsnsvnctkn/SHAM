using SHAM.Domain.Entities;
using System.Collections.Generic;

namespace SHAM.Repository.Contracts
{
    public interface ITitleRepository : IGenericRepository<Title>
    {
        List<Title> GetList();
    }
}
