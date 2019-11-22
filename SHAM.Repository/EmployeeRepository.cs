using SHAM.Domain.Entities;
using SHAM.Repository.Contracts;
using SHAM.Repository.Dto;
using System.Collections.Generic;
using System.Linq;

namespace SHAM.Repository
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IUnitOfWork uow)
            : base(uow)
        {

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
                CREATOR_ID = e.EMPLOYEE_CREATOR,
                CREATED_DATE = e.CREATED_DATE,
                CREATED_TIME = e.CREATED_TIME,
            }).ToList();
            
            var title = _context.Titles.Select(t => new TitleDto { ID = t.ID, NAME = t.TITLE_NAME }).ToList();

            return new EmpConsDto { TitleDto = title, EmployeeDto = emp };

        }

        //public List<DropDownListDto> dropDownListDtos()
        //{
        //    var level = _context.Levels.Select(l => new Level { ID = l.ID, LEVEL_NAME = l.LEVEL_NAME });
        //    var title = _context.Titles.Select(t => new Title { ID = t.ID, TITLE_NAME = t.TITLE_NAME });
        //    var priority = _context.Priorities.Select(p => new Priority { ID = p.ID, PRIORITY_NAME = p.PRIORITY_NAME });
        //    var project_type = _context.Project_Types.Select(pt => new Project_Type { ID = pt.ID, TYPE_NAME = pt.TYPE_NAME });

        //    return 0;
        //}
    }
}
