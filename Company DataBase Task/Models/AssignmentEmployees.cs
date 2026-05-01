namespace Company_DataBase_Task.Models
{
    public class AssignmentEmployees:MainEntity
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int AssignmentId { get; set; }
        public Assignment Assignment { get; set; }
    }
}
