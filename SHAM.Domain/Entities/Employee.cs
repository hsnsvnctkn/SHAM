using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHAM.Domain.Entities
{
    [Table("EMPLOYEES")]
    public class Employee
    {
        public Employee()
        {
            CREATED_ACTIVITY = new HashSet<Activity>();
            ACTIVITIES = new HashSet<ActivityEmployee>();
            PROJECTS = new HashSet<ProjectEmployee>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; } //PK

        [Required, StringLength(50)]
        public string EMPLOYEE_NAME { get; set; }

        [Required, StringLength(50)]
        public string EMPLOYEE_SURNAME { get; set; }

        [Required, StringLength(13)]
        public string EMPLOYEE_PHONE_NO { get; set; }

        [Required, StringLength(100)]
        public string EMPLOYEE_ADRESS { get; set; }

        [Required, StringLength(50)]
        public string EMPLOYEE_MAIL { get; set; }

        [Required]
        public bool EMPLOYEE_STATUS { get; set; }

        [Required]
        public int EMPLOYEE_TITLE { get; set; } //FK --

        [Required]
        public int EMPLOYEE_CREATOR { get; set; } //FK ~~~~~~

        [Required]
        public DateTime CREATED_DATE { get; set; } = DateTime.Now;

        [Required]
        public TimeSpan CREATED_TIME { get; set; } = DateTime.Now.TimeOfDay;


        public virtual Title TITLE { get; set; }

        public virtual ICollection<Employee> CREATED_EMPLOYEES { get; set; }
        public virtual Employee CREATED_EMPLOYEE { get; set; }

        public virtual ICollection<ActivityEmployee> ACTIVITIES { get; set; } //????

        public virtual ICollection<Activity> CREATED_ACTIVITY { get; set; }

        public virtual ICollection<Customer> CUSTOMERS { get; set; }

        [ForeignKey("ProjectID")]
        public virtual ICollection<ProjectEmployee> PROJECTS { get; set; }

        public virtual ICollection<Project> CREATED_PROJECTS { get; set; }


    }
}
