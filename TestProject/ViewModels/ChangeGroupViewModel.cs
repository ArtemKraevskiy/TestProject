using System.Collections.Generic;

namespace TestProject.ViewModels
{
    public class ChangeGroupViewModel
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public int Year { set; get; }
        public string Specialty { set; get; }
        public int TeacherID { set; get; }
        public string TeacherName { set; get; }
        public List<TeacherViewModel> ListOfTeachers { set; get; }
        public int CourseID { set; get; }
        public int CourseNumber { set; get; }
        public List<CourseViewModel> ListOfCourses { set; get; }
    }
}
