using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SHAM.Domain.Entities
{
    [Table("PRIORITY")]
    public class Priority
    {
        [Required]
        public int PRIORIT_NUMBER { get; set; }//PK

        [Required]
        public string PRIORITY_NAME { get; set; }

        public virtual ICollection<Activity> Activitys { get; set; }
    }
}
