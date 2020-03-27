using SHAM.Domain.Entities;
using SHAM.Repository.Dto;
using System.Collections.Generic;

namespace SHAM.Repository.Contracts
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        EmpConsDto GetList();
        void Create(EmployeeDto employee);
        EmployeeDto Get(int id);
        UserDto Get(string email);
        void Delete(int id);
        void Update(EmployeeDto employee);
        void UpdateMyInfo(UserDto user);
        void UpdateMyPass(int id, string pass);
        bool IsAnyEmployee(string mail);
        List<EmployeeDto> EntryDailyActivity();
    }
}
