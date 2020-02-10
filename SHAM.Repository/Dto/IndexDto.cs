using System;
using System.Collections.Generic;
using System.Text;

namespace SHAM.Repository.Dto
{
    public class IndexDto
    {
        public int projectCount { get; set; }
        public int employeeCount { get; set; }
        public int customerCount { get; set; }
        public int activityCount { get; set; }
        public int levelCount { get; set; }
        public List<ProjectDto> Project { get; set; }
        public List<ActivityDto> Activity { get; set; }


        public int myProjectCount { get; set; }
        public int myActivityCount { get; set; }
        public List<ProjectDto> MyProject { get; set; }
        public List<ActivityDto> MyActivity { get; set; }
    }
}
