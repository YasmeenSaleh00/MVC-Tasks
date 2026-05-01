namespace Company_DataBase_Task.Models
{
    public class Employee:MainEntity
    {
        public string FullName { get; set; }
        public DateOnly BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string NationalId { get; set; }
        public string Nationality { get; set; }
        public string MaritalStatus { get; set; }
        public string PersonalPhotoPath { get; set; }
        public string Password { get; set; }
        public int? ManagerId { get; set; }
        public  Employee Manager { get; set; }
        public  List<Employee> Team { get; set; }
        public List<AssignmentEmployees> AssignmentEmployees { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
