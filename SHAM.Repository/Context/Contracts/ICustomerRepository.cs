using SHAM.Domain.Entities;
using SHAM.Repository.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SHAM.Repository.Contracts
{
    public interface ICustomerRepository:IGenericRepository<Customer>
    {
        CustomerEmployeeDto GetList();
        void Delete(int id);
        void Create(CustomerDto customer);
        void Update(CustomerDto customer);
    }
}
