using SHAM.Domain.Entities;
using System;

namespace SHAM.Repository.Dto
{
    public class EmployeeDto
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public string SURNAME { get; set; }
        public string PHONE_NO { get; set; }
        public string ADRESS { get; set; }
        public string MAIL { get; set; }
        public bool STATUS { get; set; }
        public int TITLE_ID { get; set; }
        public int CREATOR_ID { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public TimeSpan CREATED_TIME { get; set; }

        virtual public Title TITLE { get; set; }
    }
}
