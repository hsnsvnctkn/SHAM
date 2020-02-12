using SHAM.Domain.Entities;
using SHAM.Repository.Contracts;
using SHAM.Repository.Dto;
using System;
using System.Linq;

namespace SHAM.Repository
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IUnitOfWork uow)
            : base(uow)
        {

        }
        public void Update(EmployeeDto employee)
        {
            _context.Employees.Update(new Employee
            {
                ID = employee.ID,
                EMPLOYEE_NAME = employee.NAME,
                EMPLOYEE_SURNAME = employee.SURNAME,
                EMPLOYEE_PHONE_NO = employee.PHONE_NO,
                EMPLOYEE_ADRESS = employee.ADRESS,
                EMPLOYEE_MAIL = employee.MAIL,
                EMPLOYEE_STATUS = employee.STATUS,
                EMPLOYEE_TITLE = employee.TITLE_ID,
                EMPLOYEE_CREATOR = employee.CREATOR_ID
            });
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
            _context.Employees.Add(new Employee
            {
                ID = employee.ID,
                EMPLOYEE_NAME = employee.NAME,
                EMPLOYEE_SURNAME = employee.SURNAME,
                EMPLOYEE_PHONE_NO = employee.PHONE_NO,
                EMPLOYEE_ADRESS = employee.ADRESS,
                EMPLOYEE_MAIL = employee.MAIL,
                EMPLOYEE_STATUS = employee.STATUS,
                EMPLOYEE_TITLE = employee.TITLE_ID,
                EMPLOYEE_CREATOR = employee.CREATOR_ID
            });
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
                PROJECTS = e.PROJECTS,
                TITLE = e.TITLE
            }).ToList();


            return new EmpConsDto { TitleDto = title, EmployeeDto = emp };

        }

        public void UpdateMyPass(int id, string pass)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.ID == id);

            employee.PASSWORD = pass;

            _context.Employees.Update(employee);

            _context.SaveChanges();
        }
    }
}
