using SHAM.Domain.Entities;
using SHAM.Repository.Dto;
using System.Collections.Generic;

namespace SHAM.Repository.Contracts
{
    public interface IProjectTypeRepository : IGenericRepository<Project_Type>
    {
        List<ConstantDto> GetList();
        ConstantDto Get(int id);
        void DeleteProjectType(int id);
        void Create(ConstantDto projectType);
        void Update(ConstantDto projectType);
    }
}
