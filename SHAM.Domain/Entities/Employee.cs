using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SHAM.Domain.Entities
{
    [Table("EMPLOYEES")]
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }//PK

        [Required]
        public string EMPLOYEE_NAME { get; set; }

        [Required]
        public string EMPLOYEE_SURNAME { get; set; }

        [Required]
        public string EMPLOYEE_PHONE_NO { get; set; }
        
        [Required]
        public string EMPLOYEE_ADRESS { get; set; }
        
        [Required]
        public string EMPLOYEE_MAIL { get; set; }

        [Required]
        public bool EMPLOYEE_STATUS { get; set; }

        [Required]
        public int EMPLOYEE_TITLE { get; set; }//FK ---

        [Required]
        public int EMPLOYEE_CREATOR { get; set; }//FK ---

        [Required]
        public DateTime CREATED_DATE { get; set; }

        [Required]
        public TimeSpan CREATED_TIME { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual Title Title { get; set; }
        public virtual Employee EmployeeID { get; set; }
    }
}
