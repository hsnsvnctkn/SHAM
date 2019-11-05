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
        [Required]
        public int TITLE_NUMBER { get; set; }//PK

        [Required]
        public string TITLE_NAME { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
