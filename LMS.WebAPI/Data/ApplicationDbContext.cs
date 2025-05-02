using LMS.WebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace LMS.WebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
    }
}