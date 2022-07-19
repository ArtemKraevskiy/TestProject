using Microsoft.EntityFrameworkCore;
using TestProject.Models;

namespace TestProject.Data
{
    public class TestProjectContext : DbContext
    {
        public TestProjectContext(DbContextOptions<TestProjectContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Number = 1 },
                new Course { Id = 2, Number = 2 },
                new Course { Id = 3, Number = 3 },
                new Course { Id = 4, Number = 4 },
                new Course { Id = 5, Number = 5 }
                );
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher { Id = 1, Name = "Имя1 Фамилия1"},
                new Teacher { Id = 2, Name = "Имя2 Фамилия2" },
                new Teacher { Id = 3, Name = "Имя3 Фамилия3" },
                new Teacher { Id = 4, Name = "Имя4 Фамилия4" },
                new Teacher { Id = 5, Name = "Имя5 Фамилия5" }
                );
            modelBuilder.Entity<Group>().HasData(
                new Group { Id = 1, Name = "Название Группы1", Year=2020, Specialty= "Специальность1", TeacherID = 1, CourseID = 2 },
                new Group { Id = 2, Name = "Название Группы2", Year = 2018, Specialty = "Специальность2", TeacherID = 3, CourseID = 4 }
                );
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, Name = "Студент1", PhoneNumber = 77836940 ,Photo = "/img/Студент1.jpg", GroupID = 1 },
                new Student { Id = 2, Name = "Студент2", PhoneNumber = 77840182, Photo = "/img/Студент2.jpg", GroupID = 1 },
                new Student { Id = 3, Name = "Студент3", PhoneNumber = 68593027, Photo = "/img/Студент3.jpg", GroupID = 2 },
                new Student { Id = 4, Name = "Студент4", PhoneNumber = 77869104, Photo = "/img/Студент4.jpg", GroupID = 2 }
                );
        }

    }
}
