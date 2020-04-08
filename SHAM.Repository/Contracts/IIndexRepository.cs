using SHAM.Repository.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SHAM.Repository.Contracts
{
    public interface IIndexRepository : IGenericRepository<IndexDto>
    {
        IndexDto GetAdminIndex(int id, bool isAdmin);
        List<ProjectDto> GetUserProject(int id);
        List<ActivityDto> GetMyActivity(int id);
        List<double> GetSumActivityWhour(List<ActivityDto> activities);
        List<double> GetSumProjectWhour(List<ProjectDto> projects);
    }
}
