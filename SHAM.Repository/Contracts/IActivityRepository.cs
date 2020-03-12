using SHAM.Domain.Entities;
using SHAM.Repository.Contracts;
using SHAM.Repository.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SHAM.Repository.Contracts
{
    public interface IActivityRepository : IGenericRepository<Activity>
    {
        ActivityAllDto GetList();
        ActivityAllDto GetMonthList();
        void Create(ActivityDto activity);
        void Update(ActivityDto activity);
        void Delete(int id);
        ActivityAllDto GetMyActivity(int id);
        ActivityAllDto GetMyAllActivity(int id);
    }
}
