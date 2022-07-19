namespace TestProject.Models
{
    public class Student
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public int PhoneNumber { set; get; }
        public string Photo { set; get; }
        public int GroupID { set; get; }
        public virtual Group Group { set; get; }
    }
}
