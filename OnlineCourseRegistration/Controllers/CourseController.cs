using Microsoft.AspNetCore.Mvc;
using OnlineCourseRegistration.Data;
using OnlineCourseRegistration.Models;
using OnlineCourseRegistration.ViewModel;

namespace OnlineCourseRegistration.Controllers
{
    public class CourseController : Controller
    {
        private readonly ApplicationDBContext _Context;

        public CourseController(ApplicationDBContext context)
        {
            _Context = context;

        }
        public IActionResult Index()
        {
            var Course = _Context.Courses.ToList();
            List<CreateCourseViewModel> vm = new List<CreateCourseViewModel>();
            foreach(var item in Course)
            {
                vm.Add(new CreateCourseViewModel()
                {
                    ID = item.Id,
                    Name = item.Name

                });
            }
            return View(vm);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateCourseViewModel coursevm)
        {
            Course course = new Course();
            course.Id=coursevm.ID;
            course.Name=coursevm.Name;
                
            _Context.Courses.Add(course);
            _Context.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var Course = _Context.Courses.Find(Id);
            CreateCourseViewModel vm = new CreateCourseViewModel();
            vm.ID = Course.Id;
            vm.Name = Course.Name;
            return View(vm);
        }
        [HttpPost]
        public IActionResult Edit(CreateCourseViewModel coursevm)
        {
            Course course = new Course();
            course.Id = coursevm.ID;
            course.Name = coursevm.Name;
            _Context.Courses.Update(course);
            _Context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int Id)
        {
            var Course = _Context.Courses.Find(Id);
            _Context.Remove(Course);
            _Context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
