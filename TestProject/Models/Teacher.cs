using System.Collections.Generic;

namespace TestProject.Models
{
    public class Teacher
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public List<Group> Groups { set; get; }
    }
}
