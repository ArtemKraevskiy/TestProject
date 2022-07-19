using System.Collections.Generic;

namespace TestProject.ViewModels
{
    public class ChangeStudentViewModel
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public int PhoneNumber { set; get; }
        public string Photo { set; get; }
        public int GroupID { set; get; }
        public List<GroupViewModel> ListOfGroups { set; get; }
    }
}
