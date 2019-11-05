using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SHAM.Domain.Entities
{
    [Table("CUSTOMERS")]
    public class Customer
    {
        public Customer()
        {
            
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }//PK
        
        [Required]
        public string CUSTOMER_TYPE { get; set; }

        [Required]
        public string CUSTOMER_NAME { get; set; }

        [Required]
        public string CUSTOMER_PHONE_NO { get; set; }

        [Required]

        public string CUSTOMER_ADRESS { get; set; }
        [Required]
        public string CUSTOMER_MAIL { get; set; }

        [Required]
        public bool CUSTOMER_STATUS { get; set; }

        [Required]
        public int CUSTOMER_CREATOR { get; set; } //FK ---

        [Required]
        public DateTime CREATED_DATE { get; set; }

        [Required]
        public TimeSpan CREATED_TIME { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
