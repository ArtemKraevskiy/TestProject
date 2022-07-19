using System.Collections.Generic;

namespace TestProject.Models
{
    public class Group
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public int Year { set; get; }
        public string Specialty { set; get; }
        public int TeacherID { set; get; }
        public virtual Teacher Teacher { set; get; }
        public int CourseID { set; get; }
        public virtual Course Course { set; get; }
        public List<Student> Students { set; get; }
    }
}
