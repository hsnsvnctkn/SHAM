using System;
using System.Collections.Generic;
using System.Text;

namespace SHAM.Repository.Dto
{
    public class EmployeeReportsDto
    {
        public List<ProjectDto> Projects { get; set; }
        public List<double> Whours { get; set; }
        public List<double> ProjectWhours { get; set; }
        public List<EmployeeDto> Employees { get; set; }
        public EmployeeDto SelectedEmployee { get; set; }
    }
}
