using System.Diagnostics.Metrics;
using Microsoft.EntityFrameworkCore;
using OnlineCourseRegistration.Models;

namespace OnlineCourseRegistration.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        { 
        
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
