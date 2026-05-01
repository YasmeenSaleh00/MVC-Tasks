namespace Company_DataBase_Task.Models
{
    public class Assignment:MainEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public string ImportanceLevel { get; set; }
        public List<AssignmentEmployees> AssignmentEmployees { get; set; }

    }
}
