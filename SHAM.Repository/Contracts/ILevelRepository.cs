using SHAM.Domain.Entities;
using SHAM.Repository.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SHAM.Repository.Contracts
{
    public interface ILevelRepository : IGenericRepository<Level>
    {
        List<ConstantDto> GetList();
        ConstantDto Get(int id);
        void DeleteLevel(int id);
        void Create(ConstantDto level);
        void Update(ConstantDto level);
    }
}
