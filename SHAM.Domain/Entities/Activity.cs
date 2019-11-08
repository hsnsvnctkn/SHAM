using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SHAM.Domain.Entities
{
    [Table("ACTIVITIES")]
    public class Activity
    {
        //public Activity()
        //{
        //    EMPLOYEES = new HashSet<Employee>();
        //}
        [Key]
        public int ID { get; set; }//PK
        
        [Required]
        public int PROJECT_NUMBER { get; set; }//FK --

        [Required,StringLength(100)]
        public string ACTIVITY_DETAIL { get; set; }
        
        [Required]
        public int EMPLOYEE_NUMBER { get; set; }//FK --

        [Required]
        public int ACTIVITY_CREATOR { get; set; }//FK--

        [Required]
        public DateTime ESTIMATE_START_DATE { get; set; }

        [Required]
        public DateTime ESTIMATE_END_DATE { get; set; }

        [Required]
        public DateTime START_DATE { get; set; }

        public DateTime? END_DATE { get; set; }

        [Required]
        public bool ACTIVITY_STATUS { get; set; }

        [Required]
        public int ACTIVITY_PRIORITY { get; set; }//FK--

        [Required]
        public DateTime CREATED_DATE { get; set; } = DateTime.Now;

        [Required]
        public TimeSpan CREATED_TIME { get; set; } = DateTime.Now.TimeOfDay;

        [Required]
        public bool INVOICE { get; set; }


        public virtual Project PROJECT { get; set; }

        public virtual ICollection<ActivityEmployee> EMPLOYEES { get; set; } //????

        public virtual Employee CREATED_EMPLOYEE { get; set; }

        public virtual Priority PRIORITY { get; set; }
    }
}
