﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHAM.Domain.Entities
{
    [Table("PRIORITY")]
    public class Priority
    {
        [Key]
        public int ID { get; set; }

        [Required, StringLength(20)]
        public string PRIORITY_NAME { get; set; }


        public virtual ICollection<Activity> ACTIVITIES { get; set; }
    }
}
