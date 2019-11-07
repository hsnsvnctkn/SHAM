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
        public int ID { get; set; }

        [Required,StringLength(20)]
        public string PRIORITY_NAME { get; set; }
    }
}
