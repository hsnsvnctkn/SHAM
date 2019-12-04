using Microsoft.EntityFrameworkCore;
using SHAM.Domain.Entities;
using SHAM.Repository.Contracts;
using SHAM.Repository.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SHAM.Repository
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(IUnitOfWork uow)
            : base(uow)
        {

        }


        public ProjectAllDto GetList()
        {

            var project = _context.Projects.Select(p => new ProjectDto
            {
                ID = p.ID,
                NAME = p.PROJECT_NAME,
                TYPE = p.PROJECT_TYPE,
                CUSTOMER_ID = p.CUSTOMER_NUMBER,
                EST_START_DATE = p.ESTIMATE_START_DATE,
                EST_END_DATE = p.ESTIMATE_END_DATE,
                STATUS = p.PROJECT_STATUS,
                LEVEL_ID = p.PROJECT_LEVEL,
                CREATOR = p.PROJECT_CREATOR,
                CREATED_DATE = p.CREATED_DATE,
                CREATED_TIME = p.CREATED_TIME,
                END_DATE = p.END_DATE,
                START_DATE = p.START_DATE,
                ACTIVITIES = p.ACTIVITIES,
                CREATED_EMPLOYEE = p.CREATED_EMPLOYEE,
                CUSTOMER = p.CUSTOMER,
                EMPLOYEES = p.EMPLOYEES,
                LEVEL = p.LEVEL,
                PROJECT_TYPE_ = p.PROJECT_TYPE_
            }).ToList();

            var type = _context.Project_Types.Select(pt => new ProjectTypeDto
            {
                ID = pt.ID,
                NAME = pt.TYPE_NAME
            }).ToList();

            var customer = _context.Customers.Select(c => new CustomerDto
            {
                ID = c.ID,
                NAME = c.CUSTOMER_NAME
            }).ToList();

            var employee = _context.Employees.Select(e => new EmployeeDto
            {
                ID = e.ID,
                NAME = e.EMPLOYEE_NAME,
                SURNAME = e.EMPLOYEE_SURNAME,
                PROJECTS = e.PROJECTS,
                ACTIVITIES = e.ACTIVITIES
            }).ToList();

            var level = _context.Levels.Select(l => new LevelDto
            {
                ID = l.ID,
                NAME = l.LEVEL_NAME
            }).ToList();

            return new ProjectAllDto { CustomerDto = customer, EmployeeDto = employee, LevelDto = level, ProjectDto = project, ProjectTypeDto = type };
        }
    }
}
