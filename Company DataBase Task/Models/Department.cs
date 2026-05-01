using System.ComponentModel.DataAnnotations;

namespace Company_DataBase_Task.Models
{
    public class Department:MainEntity
    {
        [Required(ErrorMessage = "The Name Of Department Required")]
        [MaxLength(100)]
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
