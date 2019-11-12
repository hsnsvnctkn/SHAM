namespace SHAM.Domain.Entities
{
    public class ActivityEmployee
    {
        public int ActivityID { get; set; }
        public int EmployeeID { get; set; }


        public virtual Activity ACTIVITY { get; set; }
        public virtual Employee EMPLOYEE { get; set; }
    }
}
