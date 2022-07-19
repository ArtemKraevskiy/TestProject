using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TestProject.Data;
using TestProject.Interfaces;
using TestProject.Models;

namespace TestProject.Services
{
    public class GroupService : IGroupService
    {
        private readonly TestProjectContext _context;
        public GroupService(TestProjectContext context)
        {
            _context = context;
        }

        public IEnumerable<Group> GetAll() => _context.Groups.Include(t => t.Course).Include(t => t.Teacher);

        public Group GetByld(int id) => _context.Groups.FirstOrDefault(t => t.Id == id);

        public void AddByld(Group group)
        {
            _context.Add(group);
            _context.SaveChanges();
        }
        public void RemovByld(Group group)
        {
            _context.Groups.Remove(group);
            _context.SaveChangesAsync();
        }
        public void ChangeByld(Group group)
        {
            _context.Groups.Update(group);
            _context.SaveChanges();
        }

    }
}
