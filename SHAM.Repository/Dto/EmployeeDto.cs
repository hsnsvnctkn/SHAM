using SHAM.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SHAM.Repository.Dto
{
    public class EmployeeDto
    {
        public EmployeeDto()
        {
            ACTIVITIES = new HashSet<ActivityEmployee>();
        }
        public int ID { get; set; }
        public string NAME { get; set; }
        public string SURNAME { get; set; }
        public string PHONE_NO { get; set; }
        public string ADRESS { get; set; }
        public string MAIL { get; set; }
        public bool STATUS { get; set; }
        public int TITLE_ID { get; set; }
        public int CREATOR_ID { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public TimeSpan CREATED_TIME { get; set; }


        virtual public TitleDto TITLE { get; set; }

        public virtual ICollection<Employee> CREATED_EMPLOYEES { get; set; }
        public virtual Employee CREATED_EMPLOYEE { get; set; }

        public virtual ICollection<ActivityEmployee> ACTIVITIES { get; set; } //????

        public virtual ICollection<Activity> CREATED_ACTIVITY { get; set; }

        public virtual ICollection<Customer> CUSTOMERS { get; set; }

        public virtual ICollection<ProjectEmployee> PROJECTS { get; set; }

        public virtual ICollection<Project> CREATED_PROJECTS { get; set; }

    }
}
