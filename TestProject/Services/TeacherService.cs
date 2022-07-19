using System.Collections.Generic;
using System.Linq;
using TestProject.Data;
using TestProject.Interfaces;
using TestProject.Models;

namespace TestProject.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly TestProjectContext _context;
        public TeacherService(TestProjectContext context)
        {
            _context = context;
        }
        public IEnumerable<Teacher> GetAll() => _context.Teachers;
        public Teacher GetByld(int id) => _context.Teachers.FirstOrDefault(t => t.Id == id);
    }
}
