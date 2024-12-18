using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineCourseRegistration.Data;
using OnlineCourseRegistration.Models;
using OnlineCourseRegistration.ViewModel;

namespace OnlineCourseRegistration.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDBContext _Context;

        public StudentController(ApplicationDBContext context)
        {
            _Context = context;

        }
        public IActionResult Index()
        {
            var students = _Context.Students.Include(x=>x.Course).ToList(); 
            List<ListOfStudentViewModel> vm = new List<ListOfStudentViewModel>();
            foreach (var student in students)
            {
                vm.Add(new ListOfStudentViewModel()
                {
                    Id = student.Id,
                    StudentName = student.StudentName,
                    Address = student.Address,
                    DOB = student.DOB,
                    Gender = student.Gender,
                    Contactno = student.Contactno,
                    Email = student.Email,
                    Country = student.Country,
                    City = student.City,
                    CourseName = student.Course.Name 

                });
            }
            return View(vm);
        }
        [HttpGet]
        public IActionResult Register()
        {
            var vm = new CreateStudentViewModel();
            vm.Courses = _Context.Courses.ToList(); 
            return View(vm);
        }
        [HttpPost]
        public IActionResult Register(CreateStudentViewModel student)
        {
            Student stud = new Student();
            stud.StudentName = student.FName + " " + student.MName + " " + student.LName;
            stud.Address = student.Address;
            stud.DOB = student.DOB;
            stud.Gender = student.Gender;
            stud.Contactno = student.Contactno;
            stud.Email = student.Email;
            stud.Country = student.Country;
            stud.City = student.City;
            stud.CourseID = student.SelectedCourseID;
            _Context.Students.Add(stud);
            _Context.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var student = _Context.Students.Find(Id);
            CreateStudentViewModel vm = new CreateStudentViewModel();
            vm.Id = student.Id;
            vm.Address = student.Address;
            vm.StudentName = student.StudentName;
            vm.SelectedCourseID = student.CourseID;
            vm.Gender = student.Gender;
            vm.City = student.City;
            vm.Contactno = student.Contactno;
            vm.Country = student.Country;
            vm.DOB = student.DOB;
            vm.Email = student.Email;
            vm.Courses= _Context.Courses.ToList();
            return View(vm);
        }
        [HttpPost]
        public IActionResult Edit(CreateStudentViewModel student)
        { 
            Student stud = new Student();
            stud.Id = student.Id;
            stud.StudentName = student.StudentName;
            stud.Address = student.Address;
            stud.DOB = student.DOB;
            stud.Gender = student.Gender;
            stud.Contactno = student.Contactno;
            stud.Email = student.Email;
            stud.Country = student.Country;
            stud.City = student.City;
            stud.CourseID = student.SelectedCourseID;
            _Context.Students.Update(stud);
            _Context.SaveChanges();

            return RedirectToAction("Index"); 
        }
        public IActionResult Delete(int Id)
        {
            var student = _Context.Students.Find(Id);
            _Context.Remove(student);
            _Context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
