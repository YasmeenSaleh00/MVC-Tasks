using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public DateTime? CreationDate { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? UpdatedAte  { get; set; }

        [NotMapped]
        public string ? FullName { get; set; }
    }
}
