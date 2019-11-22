using System;
using System.Collections.Generic;
using System.Text;

namespace SHAM.Repository.Dto
{
    public class DropDownListDto
    {
        public int TYPE_ID { get; set; }
        public string TYPE_NAME { get; set; }

        public int TITLE_ID { get; set; }
        public string TITLE_NAME { get; set; }

        public int LEVEL_ID { get; set; }
        public string LEVEL_NAME { get; set; }

        public int PRIORTIY_ID { get; set; }
        public string PRIORITY_NAME { get; set; }
    }
}
