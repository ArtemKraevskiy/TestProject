using System.Collections.Generic;
using TestProject.Models;

namespace TestProject.Interfaces
{
    public interface IGroupService
    {
        IEnumerable<Group> GetAll();
        Group GetByld(int id);
        void Add(Group group);
        void Delete(Group group);
        void Update(Group group);
    }
}
