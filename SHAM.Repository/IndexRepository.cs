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
            var notifi = _context.Notifications.Where(n => (n.END_TIME >= DateTime.Now || n.END_TIME == null) && n.START_TIME <= DateTime.Now).Select(n => new NotificationDto { TEXT_INFO = n.TEXT_INFO }).ToList();

            var myActivity = GetMyActivity(id);

            var myProject = GetUserProject(id);

            var getIndex = new IndexDto { myProjectCount = myProject.Count(), MyProject = myProject };

            getIndex.myActivityCount = myActivity.Count();

            getIndex.Notification = notifi;

            if (isAdmin == true)
            {
                getIndex.projectCount = _context.Projects.Count();
                getIndex.employeeCount = _context.Employees.Count();
                getIndex.activityCount = _context.Activities.Count();
                getIndex.customerCount = _context.Customers.Count();
            }

            getIndex.wHours = GetSumActivityWhour(myActivity);
            getIndex.projectWhour = GetSumProjectWhour(myProject);

            return getIndex;
        }

        public List<double> GetSumProjectWhour(List<ProjectDto> projects)
        {
            List<double> projectWhour = new List<double>();

            foreach (var item in projects)
            {
                var sumProjectWhour = item.ACTIVITIES.Where(a => a.ACTIVITY_DATE.Month == DateTime.Now.Month).Select(a => a.WHOUR).Sum();

                projectWhour.Add(sumProjectWhour);
            }
            return projectWhour;
        }

        public List<ProjectDto> GetUserProject(int id)
        {
            var projectID = GetUserProjectID(id);

            return _context.Projects.Where(p => projectID.Contains(p.ID)).Select(p => new ProjectDto
            {
                NAME = p.PROJECT_NAME,
                STATUS = p.PROJECT_STATUS,
                LEVEL = p.LEVEL,
                ACTIVITIES = p.ACTIVITIES.Where(a => a.ACTIVITY_DATE.Month == DateTime.Now.Month && a.ACTIVITY_EMPLOYEE == id).ToList(),
                CUSTOMER = p.CUSTOMER
            }).ToList();
        }

        private List<int> GetUserProjectID(int id)
        {
            return _context.ProjectEmployees.Where(pe => pe.EmployeeID == id).Select(p => p.ProjectID).ToList();
        }

        public List<ActivityDto> GetMyActivity(int id)
        {
            return _context.Activities.Where(a => a.ACTIVITY_EMPLOYEE == id && a.ACTIVITY_DATE.Month == DateTime.Now.Month).Select(a => new ActivityDto
            {
                ACTIVITY_DATE = a.ACTIVITY_DATE,
                ID = a.ID,
                WHOUR = a.WHOUR
            }).ToList();
        }

        public List<double> GetSumActivityWhour(List<ActivityDto> activities)
        {
            List<double> dailyWHour = new List<double>();

            for (int i = 1; i <= DateTime.Now.Day; i++)
            {
                var sumWHour = activities.Where(a => a.ACTIVITY_DATE.Month == DateTime.Now.Month && a.ACTIVITY_DATE.Day == i).Select(a => a.WHOUR).Sum();

                dailyWHour.Add(sumWHour);
            }
            return dailyWHour;
        }
    }
}
