using AutoMapper;
using TestProject.ViewModels;

namespace TestProject.Models
{
    public class AppMappingProfile : Profile
	{
		public AppMappingProfile()
		{
			CreateMap<Group, GroupViewModel>();
			CreateMap<Teacher, TeacherViewModel>();
			CreateMap<Course, CourseViewModel>();
			CreateMap<Teacher, CreateGroupViewModel>();
			CreateMap<GroupViewModel, Group>();
			CreateMap<CourseViewModel, Course>();
			CreateMap<TeacherViewModel, Teacher>();
			CreateMap<Student, StudentViewModel>();
			CreateMap<StudentViewModel, Student>();
			CreateMap<Group, ChangeGroupViewModel>();
			CreateMap<Student, ChangeStudentViewModel>();
		}
	}
}
