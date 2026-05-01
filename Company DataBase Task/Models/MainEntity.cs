namespace Company_DataBase_Task.Models
{
    public class MainEntity
    {
        public int Id { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
