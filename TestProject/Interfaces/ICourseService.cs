using System.Collections.Generic;
using TestProject.Models;

namespace TestProject.Interfaces
{
    public interface ICourseService
    {
        IEnumerable<Course> GetAll();
        Course GetByld(int id);
    }
}
