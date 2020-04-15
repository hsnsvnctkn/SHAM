using SHAM.Domain.Entities;
using SHAM.Repository.Contracts;
using SHAM.Repository.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SHAM.Repository
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly IIndexRepository _indexRepository;
        private readonly ISendEmail _sendEmail;
        public EmployeeRepository(IUnitOfWork uow, IIndexRepository indexRepository, ISendEmail sendEmail)
            : base(uow)
        {
            _indexRepository = indexRepository;
            _sendEmail = sendEmail;
        }
        public void Update(EmployeeDto employee)
        {
            var newEmployee = _context.Employees.FirstOrDefault(e => e.ID == employee.ID);

            newEmployee.EMPLOYEE_NAME = employee.NAME;
            newEmployee.EMPLOYEE_SURNAME = employee.SURNAME;
            newEmployee.EMPLOYEE_PHONE_NO = employee.PHONE_NO;
            newEmployee.EMPLOYEE_ADRESS = employee.ADRESS;
            newEmployee.EMPLOYEE_MAIL = employee.MAIL;
            newEmployee.EMPLOYEE_STATUS = employee.STATUS;
            newEmployee.EMPLOYEE_TITLE = employee.TITLE_ID;
            newEmployee.ROLE = employee.ROLE;

            _context.Employees.Update(newEmployee);

            _context.SaveChanges();
        }

        public void UpdateMyInfo(UserDto user)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.ID == Convert.ToInt16(user.ID));

            employee.EMPLOYEE_NAME = user.NAME;
            employee.EMPLOYEE_SURNAME = user.SURNAME;
            employee.EMPLOYEE_MAIL = user.EMAIL;
            employee.EMPLOYEE_ADRESS = user.ADRESS;
            employee.EMPLOYEE_PHONE_NO = user.PHONE_NO;

            _context.Employees.Update(employee);

            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var emp = _context.Employees.FirstOrDefault(e => e.ID == id);
            _context.Employees.Remove(emp);
            _context.SaveChanges();
        }
        public EmployeeDto Get(int id)
        {
            var emp = _context.Employees.Select(e => new EmployeeDto
            {
                ID = e.ID,
                NAME = e.EMPLOYEE_NAME,
                SURNAME = e.EMPLOYEE_SURNAME,
                PHONE_NO = e.EMPLOYEE_PHONE_NO,
                ADRESS = e.EMPLOYEE_ADRESS,
                MAIL = e.EMPLOYEE_MAIL,
                STATUS = e.EMPLOYEE_STATUS,
                TITLE = e.TITLE,
                ROLE = e.ROLE
            }).Where(e => e.ID == id).FirstOrDefault();

            return emp;
        }
        public UserDto Get(string email)
        {
            var emp = _context.Employees.Select(e => new UserDto
            {
                NAME = e.EMPLOYEE_NAME,
                SURNAME = e.EMPLOYEE_SURNAME,
                PHONE_NO = e.EMPLOYEE_PHONE_NO,
                ADRESS = e.EMPLOYEE_ADRESS,
                EMAIL = e.EMPLOYEE_MAIL,
            }).Where(e => e.EMAIL == email).FirstOrDefault();

            return emp;
        }

        public void Create(EmployeeDto employee)
        {
            var newEmployee = new Employee
            {
                ID = employee.ID,
                EMPLOYEE_NAME = employee.NAME,
                EMPLOYEE_SURNAME = employee.SURNAME,
                EMPLOYEE_PHONE_NO = employee.PHONE_NO,
                EMPLOYEE_ADRESS = employee.ADRESS,
                EMPLOYEE_MAIL = employee.MAIL,
                EMPLOYEE_STATUS = employee.STATUS,
                EMPLOYEE_TITLE = employee.TITLE_ID,
                EMPLOYEE_CREATOR = employee.CREATOR_ID,
                ROLE = employee.ROLE,
                PASSWORD = employee.PASSWORD
            };
            _context.Employees.Add(newEmployee);

            _context.SaveChanges();
        }

        public EmpConsDto GetList()
        {
            var title = _context.Titles.Select(t => new TitleDto { ID = t.ID, NAME = t.TITLE_NAME }).ToList();

            var emp = _context.Employees.Select(e => new EmployeeDto
            {
                ID = e.ID,
                NAME = e.EMPLOYEE_NAME,
                SURNAME = e.EMPLOYEE_SURNAME,
                PHONE_NO = e.EMPLOYEE_PHONE_NO,
                ADRESS = e.EMPLOYEE_ADRESS,
                MAIL = e.EMPLOYEE_MAIL,
                STATUS = e.EMPLOYEE_STATUS,
                TITLE_ID = e.EMPLOYEE_TITLE,
                CREATOR_ID = e.EMPLOYEE_CREATOR,
                CREATED_DATE = e.CREATED_DATE,
                CREATED_TIME = e.CREATED_TIME,
                ACTIVITIES = e.ACTIVITIES,
                CREATED_EMPLOYEE = e.CREATED_EMPLOYEE,
                PROJECTS = e.PROJECTEMPLOYEE,
                TITLE = e.TITLE,
                ROLE = e.ROLE
            }).ToList();

            List<string> roles = new List<string>();

            var propList = typeof(Roles).GetFields();
            foreach (var item in propList)
            {
                roles.Add(item.GetValue(null).ToString());
            }
            return new EmpConsDto { TitleDto = title, EmployeeDto = emp, RoleDto = roles };

        }

        public void UpdateMyPass(int id, string pass)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.ID == id);

            employee.PASSWORD = pass;

            _context.Employees.Update(employee);

            _context.SaveChanges();
        }

        public bool IsAnyEmployee(string mail)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.EMPLOYEE_MAIL == mail);

            if (employee != null)
                return true;
            else
                return false;
        }
        public List<EmployeeDto> EntryDailyActivity()
        {
            var activity = _context.Activities.Where(a => a.ACTIVITY_DATE.Date == DateTime.Now.Date).Select(a => a.ACTIVITY_EMPLOYEE);

            var emp = _context.Employees.Where(e => !activity.Contains(e.ID)).Select(e => new EmployeeDto
            {
                NAME = e.EMPLOYEE_NAME,
                SURNAME = e.EMPLOYEE_SURNAME,
                MAIL = e.EMPLOYEE_MAIL,
            }).ToList();

            return emp;
        }
        public List<EmployeeDto> GetAllEmployeeNewMember()
        {
            return _context.Employees.Select(e => new EmployeeDto
            {
                ID = e.ID,
                ROLE = e.ROLE,
                MAIL = e.EMPLOYEE_MAIL
            }).ToList();
        }
        public EmployeeReportsDto GetEmployeesId()
        {
            var employeesId = _context.Employees.Select(e => new EmployeeDto
            {
                ID = e.ID,
                NAME = e.EMPLOYEE_NAME,
                SURNAME = e.EMPLOYEE_SURNAME
            }).ToList();
            return new EmployeeReportsDto { Employees = employeesId };
        }
        public EmployeeReportsDto GetReports(int id)
        {
            var employeesId = _context.Employees.Select(e => new EmployeeDto
            {
                ID = e.ID,
                NAME = e.EMPLOYEE_NAME,
                SURNAME = e.EMPLOYEE_SURNAME
            }).ToList();

            var projects = _indexRepository.GetUserProject(id);

            var activities = _indexRepository.GetMyActivity(id);

            var whour = _indexRepository.GetSumActivityWhour(activities);

            var projectWhour = _indexRepository.GetSumProjectWhour(projects);

            var selectedEmp = _context.Employees.Where(e => e.ID == id).Select(e => new EmployeeDto { ID = e.ID, NAME = e.EMPLOYEE_NAME, SURNAME = e.EMPLOYEE_SURNAME }).FirstOrDefault();

            return new EmployeeReportsDto { Projects = projects, ProjectWhours = projectWhour, Whours = whour, Employees = employeesId, SelectedEmployee = selectedEmp };
        }
        public void SendMailAllEmployees(List<int> employeesId, string subject, bool isInput)
        {
            var employees = new List<EmployeeDto>();
            if (isInput == true)
                employees = _context.Employees.Where(e => employeesId.Contains(e.ID)).Select(e => new EmployeeDto
                {
                    ID = e.ID,
                    NAME = e.EMPLOYEE_NAME,
                    SURNAME = e.EMPLOYEE_SURNAME,
                    MAIL = e.EMPLOYEE_MAIL
                }).ToList();
            else
            {
                employees = EntryDailyActivity();
            }
            foreach (var item in employees)
            {
                string msg;
                if (isInput == true)
                    msg = EmailContents.ReminderActivity(item.NAME, item.SURNAME);
                else
                    msg = EmailContents.ReminderDailyActivity(item.NAME, item.SURNAME);

                _sendEmail.Send(subject, item.MAIL, msg);
            }
        }

        public SendEmailDto GetSendEmailDto()
        {
            var projects = _context.Projects.Select(p => new ProjectDto
            {
                ID = p.ID,
                NAME = p.PROJECT_NAME,
                EMPLOYEES = p.PROJECTEMPLOYEE,
                CUSTOMER_ID = p.CUSTOMER_NUMBER
            }).ToList();
            var employees = _context.Employees.Select(e => new EmployeeDto
            {
                ID = e.ID,
                NAME = e.EMPLOYEE_NAME,
                SURNAME = e.EMPLOYEE_SURNAME,
                ROLE = e.ROLE
            }).ToList();
            var customers = _context.Customers.Select(c => new CustomerDto
            {
                ID = c.ID,
                NAME = c.CUSTOMER_NAME,

            }).ToList();
            return new SendEmailDto { Customers = customers, Employees = employees, Projects = projects };
        }
        public void SendSpecialMailEmployee(List<int> id, string subject, string header, string content)
        {
            var employees = _context.Employees.Where(e => id.Contains(e.ID)).Select(e => new { e.EMPLOYEE_NAME, e.EMPLOYEE_SURNAME, e.EMPLOYEE_MAIL }).ToList();

            foreach (var item in employees)
            {
                var mailStr = EmailContents.EditableContent(item.EMPLOYEE_NAME, item.EMPLOYEE_SURNAME, content, header);
                _sendEmail.Send(subject, item.EMPLOYEE_MAIL, mailStr);
            }
        }
        public void SendMailProjectEmployee(int projectId, string subject, string header, string content)
        {
            var employees = _context.ProjectEmployees.Where(pe => pe.ProjectID == projectId).Select(pe => pe.EmployeeID).ToList();
            SendSpecialMailEmployee(employees, subject, header, content);
        }
        public void SendMailCustomer(List<int> customerId, string subject, string header, string content)
        {
            var customers = _context.Customers.Where(c => customerId.Contains(c.ID)).Select(c => new { c.CUSTOMER_MAIL, c.CUSTOMER_NAME });

            foreach (var item in customers)
            {
                var mailStr = EmailContents.EditableContent(item.CUSTOMER_NAME, " ", content, header);
                _sendEmail.Send(subject, item.CUSTOMER_MAIL, mailStr);
            }
        }
    }
}
