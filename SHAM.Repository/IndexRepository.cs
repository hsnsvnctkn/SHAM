using SHAM.Repository.Contracts;
using SHAM.Repository.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SHAM.Repository
{
    public class IndexRepository : GenericRepository<IndexDto>, IIndexRepository
    {
        public IndexRepository(IUnitOfWork uow)
            : base(uow)
        {

        }

        public IndexDto GetAdminIndex(int id, bool isAdmin)
        {

            var projectID = _context.ProjectEmployees.Where(pe => pe.EmployeeID == id).Select(p => p.ProjectID).ToList();

            var getIndex = new IndexDto
            {
                levelCount = _context.Levels.Count(),

                MyProject = _context.Projects.Where(p => projectID.Contains(p.ID)).Select(p => new ProjectDto
                {
                    NAME = p.PROJECT_NAME,
                    STATUS = p.PROJECT_STATUS,
                    LEVEL = p.LEVEL
                }).ToList(),

                MyActivity = _context.Activities.Where(a => a.ACTIVITY_EMPLOYEE == id).Select(a => new ActivityDto
                {
                    ACTIVITY_DETAIL = a.ACTIVITY_DETAIL,
                    STATUS = a.ACTIVITY_STATUS,
                    PROJECT = a.PROJECT,
                    PRIORITY = a.PRIORITY
                }).ToList(),
            };
            if (getIndex.MyActivity != null)
                getIndex.myActivityCount = getIndex.MyActivity.Count();
            if (getIndex.MyProject != null)
                getIndex.myProjectCount = getIndex.MyProject.Count();


            if (isAdmin == true)
            {
                getIndex.projectCount = _context.Projects.Count();
                getIndex.employeeCount = _context.Employees.Count();
                getIndex.activityCount = _context.Activities.Count();
                getIndex.customerCount = _context.Customers.Count();

                getIndex.Project = _context.Projects.Select(p => new ProjectDto
                {
                    NAME = p.PROJECT_NAME,
                    STATUS = p.PROJECT_STATUS,
                    LEVEL = p.LEVEL
                }).ToList();

                getIndex.Activity = _context.Activities.Select(a => new ActivityDto
                {
                    PROJECT = a.PROJECT,
                    PRIORITY = a.PRIORITY,
                    STATUS = a.ACTIVITY_STATUS,
                    ACTIVITY_DETAIL = a.ACTIVITY_DETAIL

                }).ToList();
            }

            return getIndex;
        }
    }
}
