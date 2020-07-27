using SHAM.Domain.Entities;
using SHAM.Repository.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SHAM.Repository.Contracts
{
    public interface IPublicHolidays : IGenericRepository<PublicHoliday>
    {
        string IsPublicHoliday(DateTime date);
        void loadPublicHolidays();
        List<string> GetMonthHolidays(int month, int year);
    }
}
