using LMS.WebAPI.Entities;

namespace LMS.WebAPI.Services
{
    public interface IQuizService
    {
        IEnumerable<Quiz> GetAllQuizzes();
        Quiz GetQuizById(int id);
        void AddQuiz(Quiz quiz);
        void UpdateQuiz(Quiz quiz);
        void DeleteQuiz(int id);
    }
}