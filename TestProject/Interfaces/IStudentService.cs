using System.Collections.Generic;
using TestProject.Models;
using TestProject.ViewModels;

namespace TestProject.Interfaces
{
    public interface IStudentService
    {
        IEnumerable<Student> GetAllByGroupId(int groupID);
        bool ExistStudentsInGroup(int groupID);
        Student GetByld(int id);
        void DeletePhotoFile(Student student);
        void AddPhoto(StudentViewModel studentModel);
        StudentViewModel ChangePhoto(Student student, StudentViewModel studentModel);
        void Add(Student student);
        void Delete(Student student);
        void Update(Student student);
    }
}
