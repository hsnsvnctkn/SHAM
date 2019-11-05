using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SHAM.Domain.Entities
{
    [Table("PROJECT_TYPE")]
    public class ProjectType
    {
        [Required]
        public int TYPE_NUMBER { get; set; }//PK

        [Required]
        public string TYPE_NAME { get; set; }

        public virtual Project Project { get; set; }
    }
}
