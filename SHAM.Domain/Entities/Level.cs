using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SHAM.Domain.Entities
{
    [Table("LEVELS")]
    public class Level
    {
        [Required]
        public int LEVEL_NUMBER { get; set; }//PK

        [Required]
        public string LEVEL_NAME { get; set; }


        public virtual ICollection<Project> Project { get; set; }
    }
}
