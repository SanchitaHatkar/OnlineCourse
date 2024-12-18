namespace OnlineCourseRegistration.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public DateTime DOB { get; set; }
        public string ?Gender { get; set; }
        public string ?Address { get; set; }
        public string ?City { get; set; }
        public string ?Country { get; set; }
        public string ?Email { get; set; }
        public int ?Contactno { get; set; }
        public int CourseID { get; set; }
        public Course Course   { get; set; }
    } 
}
