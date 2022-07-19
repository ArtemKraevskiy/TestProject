using System.Collections.Generic;

namespace TestProject.Models
{
    public class Course
    {
        public int Id { set; get; }
        public int Number { set; get; }
        public List<Group> Groups { set; get; }
    }
}
