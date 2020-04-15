using System;
using System.Collections.Generic;
using System.Text;

namespace SHAM.Repository.Dto
{
    public class SendEmailDto
    {
        public List<EmployeeDto> Employees { get; set; }
        public List<ProjectDto> Projects { get; set; }
        public List<CustomerDto> Customers { get; set; }
    }
}
