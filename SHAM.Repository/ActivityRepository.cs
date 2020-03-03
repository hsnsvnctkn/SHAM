using SHAM.Domain.Entities;
using SHAM.Repository.Contracts;
using SHAM.Repository.Dto;
using System;
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
                ACTIVITY_DATE = activity.ACTIVITY_DATE,
                START_TIME = activity.START_TIME,
                END_TIME = activity.END_TIME,
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
                ACTIVITY_DATE = a.ACTIVITY_DATE,
                START_TIME = a.START_TIME,
                END_TIME = a.END_TIME,
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

            var employee = _context.Employees.Select(e => new EmployeeDto { ID = e.ID, NAME = e.EMPLOYEE_NAME, SURNAME = e.EMPLOYEE_SURNAME, PROJECTS = e.PROJECTS }).ToList();

            var priority = _context.Priorities.Select(p => new PriorityDto { ID = p.ID, NAME = p.PRIORITY_NAME }).ToList();

            return new ActivityAllDto { ActivityDto = activity, ProjectDto = project, EmployeeDto = employee, PriorityDto = priority };
        }

        public ActivityAllDto GetMyActivity(int id)
        {
            DateTime dt = DateTime.Now;

            var activity = _context.Activities.OrderByDescending(a => a.ACTIVITY_DATE).Where(a => a.ACTIVITY_EMPLOYEE == id && a.ACTIVITY_DATE.Month == dt.Month).Select(a => new ActivityDto
            {
                ID = a.ID,
                PROJECT_NUMBER = a.PROJECT_NUMBER,
                ACTIVITY_DETAIL = a.ACTIVITY_DETAIL,
                CREATOR = a.ACTIVITY_CREATOR,
                ACTIVITY_EMPLOYEE = a.ACTIVITY_EMPLOYEE,
                ACTIVITY_DATE = a.ACTIVITY_DATE,
                START_TIME = a.START_TIME,
                END_TIME = a.END_TIME,
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
            var projectID = _context.ProjectEmployees.Where(e => e.EmployeeID == id).Select(p => p.ProjectID);

            var project = _context.Projects.Where(p => projectID.Contains(p.ID)).Select(p => new ProjectDto { ID = p.ID, NAME = p.PROJECT_NAME }).ToList();

            var employee = _context.Employees.Select(e => new EmployeeDto { ID = e.ID, NAME = e.EMPLOYEE_NAME, SURNAME = e.EMPLOYEE_SURNAME }).ToList();

            var priority = _context.Priorities.Select(p => new PriorityDto { ID = p.ID, NAME = p.PRIORITY_NAME }).ToList();

            return new ActivityAllDto { ActivityDto = activity, ProjectDto = project, EmployeeDto = employee, PriorityDto = priority };
        }
        public ActivityAllDto GetMyAllActivity(int id)
        {
            DateTime dt = DateTime.Now;

            var activity = _context.Activities.OrderByDescending(a => a.ACTIVITY_DATE).Where(a => a.ACTIVITY_EMPLOYEE == id).Select(a => new ActivityDto
            {
                ID = a.ID,
                PROJECT_NUMBER = a.PROJECT_NUMBER,
                ACTIVITY_DETAIL = a.ACTIVITY_DETAIL,
                CREATOR = a.ACTIVITY_CREATOR,
                ACTIVITY_EMPLOYEE = a.ACTIVITY_EMPLOYEE,
                ACTIVITY_DATE = a.ACTIVITY_DATE,
                START_TIME = a.START_TIME,
                END_TIME = a.END_TIME,
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
            var projectID = _context.ProjectEmployees.Where(e => e.EmployeeID == id).Select(p => p.ProjectID);

            var project = _context.Projects.Where(p => projectID.Contains(p.ID)).Select(p => new ProjectDto { ID = p.ID, NAME = p.PROJECT_NAME }).ToList();

            var employee = _context.Employees.Select(e => new EmployeeDto { ID = e.ID, NAME = e.EMPLOYEE_NAME, SURNAME = e.EMPLOYEE_SURNAME }).ToList();

            var priority = _context.Priorities.Select(p => new PriorityDto { ID = p.ID, NAME = p.PRIORITY_NAME }).ToList();

            return new ActivityAllDto { ActivityDto = activity, ProjectDto = project, EmployeeDto = employee, PriorityDto = priority };
        }

        public void Update(ActivityDto activity)
        {
            var thisActivity = _context.Activities.FirstOrDefault(a => a.ID == activity.ID);

            thisActivity.PROJECT_NUMBER = activity.PROJECT_NUMBER;
            thisActivity.ACTIVITY_DETAIL = activity.ACTIVITY_DETAIL;
            thisActivity.ACTIVITY_DATE = activity.ACTIVITY_DATE;
            thisActivity.START_TIME = activity.START_TIME;
            thisActivity.END_TIME = activity.END_TIME;
            thisActivity.ACTIVITY_STATUS = activity.STATUS;
            thisActivity.ACTIVITY_PRIORITY = activity.ACTIVITY_PRIORITY;
            thisActivity.INVOICE = activity.INVOICE;


            _context.Activities.Update(thisActivity);
            _context.SaveChanges();
        }
    }
}
