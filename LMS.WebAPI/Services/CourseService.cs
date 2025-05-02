using LMS.WebAPI.Entities;
using LMS.WebAPI.Repositories;

namespace LMS.WebAPI.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return _courseRepository.GetAll();
        }

        public Course GetCourseById(int id)
        {
            return _courseRepository.GetById(id);
        }

        public void AddCourse(Course course)
        {
            _courseRepository.Add(course);
        }

        public void UpdateCourse(Course course)
        {
            _courseRepository.Update(course);
        }

        public void DeleteCourse(int id)
        {
            _courseRepository.Delete(id);
        }
    }
}