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
        void Delete(int id);
        void Update(EmployeeDto employee);
    }
}
