using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Data;
using TestProject.Models;
using TestProject.ViewModels;
using Microsoft.AspNetCore.Hosting;
using TestProject.Interfaces;
using System.IO;

namespace TestProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        private TestProjectContext _context;
        private readonly IMapper _mapper;
        private IStudentService _studentService;
        private IGroupService _groupService;

        public StudentController(ILogger<StudentController> logger, TestProjectContext context, IMapper mapper, IStudentService studentService, IGroupService groupService)
        {
            _mapper = mapper;
            _context = context;
            _logger = logger;
            _studentService = studentService;
            _groupService = groupService;
        }

        [HttpGet("ListStudents/{groupID}")]
        public IEnumerable<StudentViewModel> GetListStudents(int groupID)
        {
            try
            {
                return _mapper.Map<List<StudentViewModel>>(_studentService.GetAllByGroupId(groupID));
            }
            catch
            {
                return null;
            }
        }

        [HttpPost("CreateStudent")]
        public bool CreateStudent(StudentViewModel model)
        {
            try
            {
                _studentService.AddPhoto(model);
                _studentService.Add(_mapper.Map<Student>(model));
                return true;
            }
            catch
            {
                return false;
            }
        }

        [HttpDelete("{id}")]
        public void DeleteStudent(int id)
        {
            if (_studentService.GetByld(id) != null)
            {
                _studentService.DeletePhotoFile(_studentService.GetByld(id));
                _studentService.Delete(_studentService.GetByld(id));
            }
        }

        [HttpGet("ChangeStudent/{studentID}")]
        public  ChangeStudentViewModel ChangeStudent(int studentID)
        {
            var changeStudentViewModel = _mapper.Map<ChangeStudentViewModel>(_studentService.GetByld(studentID));
            changeStudentViewModel.ListOfGroups = _mapper.Map<List<GroupViewModel>>(_groupService.GetAll());
            return changeStudentViewModel;
        }

        [HttpPut("ChangeStudent")]
        public bool ChangeStudent(StudentViewModel model)
        {
            try
            {
                if (!model.Photo.StartsWith("data:image/"))
                {
                    var student = _studentService.GetByld(model.Id);
                    model = _studentService.ChangePhoto(student, model);
                    _mapper.Map(model, student);
                    _studentService.Update(student);
                }
                else
                {
                    var student = _studentService.GetByld(model.Id);
                    _studentService.DeletePhotoFile(student);
                    _studentService.AddPhoto(model);                   
                    _mapper.Map(model, student);
                    _studentService.Update(student);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
