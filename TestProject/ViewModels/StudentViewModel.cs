namespace TestProject.ViewModels
{
    public class StudentViewModel
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public int PhoneNumber { set; get; }
        public string Photo { set; get; }
        public int GroupID { set; get; }
        public virtual GroupViewModel Group { set; get; }
    }
}
