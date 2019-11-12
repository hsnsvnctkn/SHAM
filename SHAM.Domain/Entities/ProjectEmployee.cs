namespace SHAM.Domain.Entities
{
    public class ProjectEmployee
    {
        public int ProjectID { get; set; }
        public int EmployeeID { get; set; }


        public virtual Project PROJECT { get; set; }
        public virtual Employee EMPLOYEE { get; set; }
    }
}
