using System.Collections.Generic;
using System.Linq;
using TestProject.Data;
using TestProject.Interfaces;
using TestProject.Models;

namespace TestProject.Services
{
    public class CourseService : ICourseService
    {
        private readonly TestProjectContext _context;
        public CourseService(TestProjectContext context)
        {
            _context = context;
        }
        public IEnumerable<Course> GetAll() => _context.Courses;
        public Course GetByld(int id) => _context.Courses.FirstOrDefault(t => t.Id == id);

    }
}
