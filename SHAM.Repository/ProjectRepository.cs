using SHAM.Domain.Entities;
using SHAM.Repository.Contracts;
using SHAM.Repository.Dto;
using System.Collections.Generic;
using System.Linq;

namespace SHAM.Repository
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(IUnitOfWork uow)
            : base(uow)
        {

        }

        public void Create(ProjectDto project)
        {
            var emp = new List<ProjectEmployee>();

            foreach (var item in project.NEWPROJECTEMPLOYEE)
            {
                emp.Add(new ProjectEmployee { EmployeeID = item });
            }

            _context.Projects.Add(new Project
            {
                ID = project.ID,
                PROJECT_NAME = project.NAME,
                PROJECT_TYPE = project.TYPE,
                CUSTOMER_NUMBER = project.CUSTOMER_ID,
                ESTIMATE_START_DATE = project.EST_START_DATE,
                ESTIMATE_END_DATE = project.EST_END_DATE,
                PROJECT_STATUS = project.STATUS,
                PROJECT_LEVEL = project.LEVEL_ID,
                PROJECT_CREATOR = project.CREATOR,
                END_DATE = project.END_DATE,
                START_DATE = project.START_DATE,
                EMPLOYEES = emp
            });
            _context.SaveChanges();

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
                SURNAME = e.EMPLOYEE_SURNAME
            }).ToList();

            var level = _context.Levels.Select(l => new LevelDto
            {
                ID = l.ID,
                NAME = l.LEVEL_NAME
            }).ToList();

            return new ProjectAllDto { CustomerDto = customer, EmployeeDto = employee, LevelDto = level, ProjectDto = project, ProjectTypeDto = type };
        }

        public void Delete(int id)
        {
            var project = _context.Projects.FirstOrDefault(p => p.ID == id);
            var projectEmployee = _context.ProjectEmployees.Where(pe => pe.ProjectID == id);

            foreach (var item in projectEmployee)
            {
                _context.ProjectEmployees.Remove(item);
            }
            _context.Projects.Remove(project);
            _context.SaveChanges();
        }

        public void Update(ProjectDto project)
        {
            foreach (var item in project.NEWPROJECTEMPLOYEE)
            {
                var pe = _context.ProjectEmployees.Where(pe => pe.ProjectID == project.ID && pe.EmployeeID == item).ToList();
                if (pe.Count == 0)
                {
                    _context.ProjectEmployees.Add(new ProjectEmployee
                    {
                        ProjectID = project.ID,
                        EmployeeID = item
                    });
                    _context.SaveChanges();
                }

            }
            var pe2 = _context.ProjectEmployees.Where(pe => pe.ProjectID == project.ID);

            foreach (var item in pe2)
            {
                if (!project.NEWPROJECTEMPLOYEE.Contains(item.EmployeeID))
                {
                    _context.ProjectEmployees.Remove(item);
                }

            }
            _context.SaveChanges();

            _context.Projects.Update(new Project
            {
                ID = project.ID,
                PROJECT_NAME = project.NAME,
                PROJECT_TYPE = project.TYPE,
                CUSTOMER_NUMBER = project.CUSTOMER_ID,
                ESTIMATE_START_DATE = project.EST_START_DATE,
                ESTIMATE_END_DATE = project.EST_END_DATE,
                PROJECT_STATUS = project.STATUS,
                PROJECT_LEVEL = project.LEVEL_ID,
                PROJECT_CREATOR = project.CREATOR,
                END_DATE = project.END_DATE,
                START_DATE = project.START_DATE,
            });
            _context.SaveChanges();
        }
    }
}
