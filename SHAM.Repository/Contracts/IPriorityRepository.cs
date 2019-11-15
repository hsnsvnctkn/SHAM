using SHAM.Domain.Entities;
using SHAM.Repository.Dto;
using System.Collections.Generic;

namespace SHAM.Repository.Contracts
{
    public interface IPriorityRepository : IGenericRepository<Priority>
    {
        List<ConstantDto> GetList();
        ConstantDto Get(int id);
        void DeletePriority(int id);
        void Create(ConstantDto priority);
        void Update(ConstantDto priority);
    }

}
