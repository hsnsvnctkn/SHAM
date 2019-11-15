using SHAM.Domain.Entities;
using SHAM.Repository.Dto;
using System.Collections.Generic;

namespace SHAM.Repository.Contracts
{
    public interface ITitleRepository : IGenericRepository<Title>
    {
        ConstantDto Get(int id);

        List<ConstantDto> GetList();

        void DeleteTitle(int id);
        void Create(ConstantDto title);
        void Update(ConstantDto title);
    }
}
