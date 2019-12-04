using SHAM.Domain.Entities;
using SHAM.Repository.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SHAM.Repository.Contracts
{
    public interface IProjectRepository : IGenericRepository<Project>
    {
        ProjectAllDto GetList();
    }
}
