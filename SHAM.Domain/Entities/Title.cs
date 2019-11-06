using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SHAM.Domain.Entities
{
    [Table("TITLE")]
    public class Title
    {
        public Title()
        {
            EMPLOYEES = new HashSet<Employee>();
        }

        [Key,Required]
        public int ID { get; set; } //PK

        [Required,StringLength(30)]
        public string TITLE_NAME { get; set; }

        public virtual ICollection<Employee> EMPLOYEES { get; set; }
    }
}
