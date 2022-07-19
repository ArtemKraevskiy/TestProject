using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using TestProject.Data;
using TestProject.Interfaces;
using TestProject.Models;
using TestProject.ViewModels;

namespace TestProject.Services
{
    public class StudentService : IStudentService
    {
        private readonly TestProjectContext _context;
        private IWebHostEnvironment _appEnvironment;
        public StudentService(TestProjectContext context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        public IEnumerable<Student> GetAllByGroupId(int groupID) => _context.Students.Where(t => t.GroupID == groupID).Include(t => t.Group);

        public bool ExistStudentsInGroup(int groupID)
        {
            return _context.Students.Any(t => t.GroupID == groupID);
        }
        public Student GetByld(int id) => _context.Students.FirstOrDefault(t => t.Id == id);

        public void DeletePhotoFile(Student student)
        {
            FileInfo fileInf = new FileInfo(_appEnvironment.WebRootPath + student.Photo);
            fileInf.Delete();
        }
        public void AddPhoto(StudentViewModel studentModel)
        {
            studentModel.Photo = studentModel.Photo.Replace("data:image/png;base64,", String.Empty);
            studentModel.Photo = studentModel.Photo.Replace("data:image/jpeg;base64,", String.Empty);
            Bitmap bitmap = new Bitmap(new MemoryStream(Convert.FromBase64String(studentModel.Photo)));
            bitmap.Save(_appEnvironment.WebRootPath + "/img/" + studentModel.Name + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            studentModel.Photo = "/img/" + studentModel.Name + ".jpg";
        }

        public StudentViewModel ChangePhotoFile(Student student, StudentViewModel studentModel)
        {
            string oldPhotoFileName = _appEnvironment.WebRootPath + student.Photo;
            studentModel.Photo = "/img/" + studentModel.Name + ".jpg";
            FileInfo fileInf = new FileInfo(oldPhotoFileName);
            fileInf.MoveTo(_appEnvironment.WebRootPath + studentModel.Photo);
            return studentModel;
        }
        public void AddByld(Student student)
        {
            _context.Add(student);
            _context.SaveChanges();
        }
        public void RemovByld(Student student)
        {
            _context.Students.Remove(student);
            _context.SaveChangesAsync();
        }
        public void ChangeByld(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
        }
    }
}
