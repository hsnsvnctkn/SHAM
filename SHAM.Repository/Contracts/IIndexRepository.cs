using SHAM.Repository.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SHAM.Repository.Contracts
{
    public interface IIndexRepository : IGenericRepository<IndexDto>
    {
        IndexDto GetAdminIndex(int id, bool isAdmin);

    }
}
