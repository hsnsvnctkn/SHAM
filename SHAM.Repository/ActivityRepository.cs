using SHAM.Domain.Entities;
using SHAM.Repository.Contracts;
using SHAM.Repository.Dto;
using System.Collections.Generic;
using System.Linq;

namespace SHAM.Repository
{
    public class ActivityRepository : GenericRepository<Activity>, IActivityRepository
    {
        public ActivityRepository(IUnitOfWork uow)
            : base(uow)
        {

        }

        public void Create(ActivityDto activity)
        {
            _context.Activities.Add(new Activity
            {
                ID = activity.ID,
                PROJECT_NUMBER = activity.PROJECT_NUMBER,
                ACTIVITY_DETAIL = activity.ACTIVITY_DETAIL,
                ACTIVITY_CREATOR = activity.CREATOR,
                ACTIVITY_EMPLOYEE = activity.ACTIVITY_EMPLOYEE,
                ESTIMATE_START_DATE = activity.EST_START_DATE,
                ESTIMATE_END_DATE = activity.EST_END_DATE,
                END_DATE = activity.END_DATE,
                START_DATE = activity.START_DATE,
                ACTIVITY_STATUS = activity.STATUS,
                ACTIVITY_PRIORITY = activity.ACTIVITY_PRIORITY,
                INVOICE = activity.INVOICE,
            });
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var activity = _context.Activities.FirstOrDefault(p => p.ID == id);

            _context.Activities.Remove(activity);
            _context.SaveChanges();
        }

        public ActivityAllDto GetList()
        {
            var activity = _context.Activities.Select(a => new ActivityDto
            {
                ID = a.ID,
                PROJECT_NUMBER = a.PROJECT_NUMBER,
                ACTIVITY_DETAIL = a.ACTIVITY_DETAIL,
                CREATOR = a.ACTIVITY_CREATOR,
                ACTIVITY_EMPLOYEE = a.ACTIVITY_EMPLOYEE,
                EST_START_DATE = a.ESTIMATE_START_DATE,
                EST_END_DATE = a.ESTIMATE_END_DATE,
                START_DATE = a.START_DATE,
                END_DATE = a.END_DATE,
                STATUS = a.ACTIVITY_STATUS,
                ACTIVITY_PRIORITY = a.ACTIVITY_PRIORITY,
                INVOICE = a.INVOICE,
                CREATED_DATE = a.CREATED_DATE,
                CREATED_TIME = a.CREATED_TIME,
                PROJECT = a.PROJECT,
                CREATED_EMPLOYEE = a.CREATED_EMPLOYEE,
                PRIORITY = a.PRIORITY,
                EMPLOYEE = a.EMPLOYEE
            }).ToList();

            var project = _context.Projects.Select(p => new ProjectDto { ID = p.ID, NAME = p.PROJECT_NAME }).ToList();

            var employee = _context.Employees.Select(e => new EmployeeDto { ID = e.ID, NAME = e.EMPLOYEE_NAME, SURNAME = e.EMPLOYEE_SURNAME }).ToList();

            var priority = _context.Priorities.Select(p => new PriorityDto { ID = p.ID, NAME = p.PRIORITY_NAME }).ToList();

            return new ActivityAllDto { ActivityDto = activity, ProjectDto = project, EmployeeDto = employee, PriorityDto = priority };
        }

        public ActivityAllDto GetMyActivity(int id)
        {

            var activity = _context.Activities.Where(a => a.ACTIVITY_EMPLOYEE == id).Select(a => new ActivityDto
            {
                ID = a.ID,
                PROJECT_NUMBER = a.PROJECT_NUMBER,
                ACTIVITY_DETAIL = a.ACTIVITY_DETAIL,
                CREATOR = a.ACTIVITY_CREATOR,
                ACTIVITY_EMPLOYEE = a.ACTIVITY_EMPLOYEE,
                EST_START_DATE = a.ESTIMATE_START_DATE,
                EST_END_DATE = a.ESTIMATE_END_DATE,
                START_DATE = a.START_DATE,
                END_DATE = a.END_DATE,
                STATUS = a.ACTIVITY_STATUS,
                ACTIVITY_PRIORITY = a.ACTIVITY_PRIORITY,
                INVOICE = a.INVOICE,
                CREATED_DATE = a.CREATED_DATE,
                CREATED_TIME = a.CREATED_TIME,
                EMPLOYEE = a.EMPLOYEE,
                PROJECT = a.PROJECT,
                CREATED_EMPLOYEE = a.CREATED_EMPLOYEE,
                PRIORITY = a.PRIORITY
            }).ToList();

            var project = _context.Projects.Select(p => new ProjectDto { ID = p.ID, NAME = p.PROJECT_NAME }).ToList();

            var employee = _context.Employees.Select(e => new EmployeeDto { ID = e.ID, NAME = e.EMPLOYEE_NAME, SURNAME = e.EMPLOYEE_SURNAME }).ToList();

            var priority = _context.Priorities.Select(p => new PriorityDto { ID = p.ID, NAME = p.PRIORITY_NAME }).ToList();

            return new ActivityAllDto { ActivityDto = activity, ProjectDto = project, EmployeeDto = employee, PriorityDto = priority };
        }

        public void Update(ActivityDto activity)
        {
            _context.Activities.Update(new Activity
            {
                ID = activity.ID,
                PROJECT_NUMBER = activity.PROJECT_NUMBER,
                ACTIVITY_DETAIL = activity.ACTIVITY_DETAIL,
                ACTIVITY_EMPLOYEE = activity.ACTIVITY_EMPLOYEE,
                ACTIVITY_CREATOR = activity.CREATOR,
                ESTIMATE_START_DATE = activity.EST_START_DATE,
                ESTIMATE_END_DATE = activity.EST_END_DATE,
                END_DATE = activity.END_DATE,
                START_DATE = activity.START_DATE,
                ACTIVITY_STATUS = activity.STATUS,
                ACTIVITY_PRIORITY = activity.ACTIVITY_PRIORITY,
                INVOICE = activity.INVOICE,
            });
            _context.SaveChanges();
        }
    }
}
