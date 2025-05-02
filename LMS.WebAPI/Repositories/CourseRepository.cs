using LMS.WebAPI.Data;
using LMS.WebAPI.Entities;

namespace LMS.WebAPI.Repositories
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(LMSDbContext context) : base(context)
        {
        }
    }
}