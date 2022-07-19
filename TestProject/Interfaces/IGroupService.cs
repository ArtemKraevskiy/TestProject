using System.Collections.Generic;
using TestProject.Models;

namespace TestProject.Interfaces
{
    public interface IGroupService
    {
        IEnumerable<Group> GetAll();
        Group GetByld(int id);
        void AddByld(Group group);
        void RemovByld(Group group);
        void ChangeByld(Group group);
    }
}
