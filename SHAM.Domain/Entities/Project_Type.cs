using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SHAM.Domain.Entities
{
    [Table("PROJECT_TYPE")]
    public class Project_Type
    {
        public int ID { get; set; }
        
        [Required,StringLength(50)]
        public string TYPE_NAME { get; set; }
    }
}
