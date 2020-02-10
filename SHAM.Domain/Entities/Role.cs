using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SHAM.Domain.Entities
{
    [Table("ROLE")]
    public class Role
    {
        public int ID { get; set; }
        public string ROLE_NAME { get; set; }

    }
}
