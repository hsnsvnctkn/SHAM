using SHAM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SHAM.Repository.Dto
{
    public class AvtivityDto
    {
        public int ID { get; set; }//PK

        public int PROJECT_NUMBER { get; set; }//FK --

        public string ACTIVITY_DETAIL { get; set; }

        public int ACTIVITY_CREATOR { get; set; }//FK--

        public DateTime ESTIMATE_START_DATE { get; set; }

        public DateTime ESTIMATE_END_DATE { get; set; }

        public DateTime START_DATE { get; set; }

        public DateTime? END_DATE { get; set; }

        public bool ACTIVITY_STATUS { get; set; }

        public int ACTIVITY_PRIORITY { get; set; }//FK--

        public DateTime CREATED_DATE { get; set; } = DateTime.Now;

        public TimeSpan CREATED_TIME { get; set; } = DateTime.Now.TimeOfDay;

        public bool INVOICE { get; set; }


        public virtual Project PROJECT { get; set; }

        public virtual ICollection<ActivityEmployee> EMPLOYEES { get; set; } //????

        public virtual Employee CREATED_EMPLOYEE { get; set; }

        public virtual Priority PRIORITY { get; set; }
    }
}
