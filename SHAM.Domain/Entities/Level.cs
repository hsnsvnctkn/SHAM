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
        public int ID { get; set; }

        [Required,StringLength(15)]
        public string LEVEL_NAME { get; set; }
    }
}
