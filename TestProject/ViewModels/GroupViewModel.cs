namespace TestProject.ViewModels
{
    public class GroupViewModel
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public int Year { set; get; }
        public string Specialty { set; get; }
        public int TeacherID { set; get; }
        public virtual TeacherViewModel Teacher { set; get; }
        public int CourseID { set; get; }
        public virtual CourseViewModel Course { set; get; }
    }
}
