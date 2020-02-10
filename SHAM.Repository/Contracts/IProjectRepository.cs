using SHAM.Domain.Entities;
using SHAM.Repository.Contracts;
using SHAM.Repository.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SHAM.Repository.Contracts
{
    public interface IProjectRepository : IGenericRepository<Project>
    {
        ProjectAllDto GetList();
        void Create(ProjectDto project);
        void Delete(int id);
        void Update(ProjectDto project);
        ProjectAllDto GetMyProject(int id);
    }
}
