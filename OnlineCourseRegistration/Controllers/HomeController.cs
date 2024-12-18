using System.Diagnostics;
using System.Diagnostics.Metrics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineCourseRegistration.Data;
using OnlineCourseRegistration.Models;
using OnlineCourseRegistration.ViewModel;

namespace OnlineCourseRegistration.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDBContext _Context;

        public HomeController(ApplicationDBContext context)
        {
            _Context = context; 
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
