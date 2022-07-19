using System.Collections.Generic;
using TestProject.Models;

namespace TestProject.Interfaces
{
    public interface ITeacherService
    {
        IEnumerable<Teacher> GetAll();
        Teacher GetByld(int id);
    }
}
