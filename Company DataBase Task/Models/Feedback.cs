using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company_DataBase_Task.Models
{
    public class Feedback:MainEntity
    {
        [Required]
        public string SenderEmail { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Message { get; set; }
        [NotMapped]
        public DateTime ReceivedDate { get; set; }
    }
}
