using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Data;
using TestProject.Interfaces;
using TestProject.Models;
using TestProject.Services;
using TestProject.ViewModels;

namespace TestProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly ILogger<GroupController> _logger;
        private TestProjectContext _context;
        private readonly IMapper _mapper;
        private IGroupService _groupService;
        private IStudentService _studentService;
        private ITeacherService _teacherService;
        private ICourseService _courseService;

        public GroupController(ILogger<GroupController> logger, TestProjectContext context, IMapper mapper, IGroupService groupService, IStudentService studentService, ICourseService courseService, ITeacherService teacherService)
        {
            _mapper = mapper;
            _context = context;
            _logger = logger;
            _groupService = groupService;
            _studentService = studentService;
            _courseService = courseService;
            _teacherService = teacherService;
        }

        [HttpGet("ListGroups")]
        public IEnumerable<GroupViewModel> ListGroups()
        {
            try
            {
                return _mapper.Map<List<GroupViewModel>>(_groupService.GetAll());
            }
            catch
            {
                return null;
            }
        }

        [HttpGet("CreateGroup")]
        public CreateGroupViewModel CreateGroup()
        {
            var createGroupViewModel = new CreateGroupViewModel
            {
                ListOfTeachers = _mapper.Map<List<TeacherViewModel>>(_teacherService.GetAll()),
                ListOfCourses = _mapper.Map<List<CourseViewModel>>(_courseService.GetAll())
            };
            return createGroupViewModel;
        }

        [HttpPost("CreateGroup")]
        public bool CreateGroup(GroupViewModel model)
        {
            try
            {
                _groupService.AddByld(_mapper.Map<Group>(model));
                return true;
            }
            catch
            {
                return false;
            }
        }

        [HttpDelete("{id}")]
        public bool DeleteGroup(int id)
        {
            try
            {
                if (!_studentService.ExistStudentsInGroup(id))
                {
                    _groupService.RemovByld(_groupService.GetByld(id));
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return true;
            }
        }

        [HttpGet("ChangeGroup/{groupID}")]
        public ChangeGroupViewModel ChangeGroup(int groupID)
        {
            var group = _groupService.GetByld(groupID);
            var changeGroupViewModel = _mapper.Map<ChangeGroupViewModel>(group);
            changeGroupViewModel.TeacherName = _teacherService.GetByld(group.TeacherID).Name;
            changeGroupViewModel.ListOfTeachers = _mapper.Map<List<TeacherViewModel>>(_teacherService.GetAll());
            changeGroupViewModel.CourseNumber = _courseService.GetByld(group.CourseID).Number;
            changeGroupViewModel.ListOfCourses = _mapper.Map<List<CourseViewModel>>(_courseService.GetAll());

            return changeGroupViewModel;
        }
        [HttpPut("ChangeGroup")]
        public bool ChangeGroup(GroupViewModel model)
        {
            try {
                _groupService.ChangeByld(_mapper.Map<Group>(model));
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
