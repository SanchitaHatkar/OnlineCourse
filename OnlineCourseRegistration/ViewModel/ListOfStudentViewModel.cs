using OnlineCourseRegistration.Models;

namespace OnlineCourseRegistration.ViewModel
{
    public class ListOfStudentViewModel
    {
        public int Id { get; set; }
        public string StudentName { get; set; } 
        public DateTime DOB { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Email { get; set; }
        public int? Contactno { get; set; }
        public string CourseName{ get; set; }
    }
}
