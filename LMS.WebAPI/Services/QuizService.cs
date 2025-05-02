using LMS.WebAPI.Entities;
using LMS.WebAPI.Repositories;

namespace LMS.WebAPI.Services
{
    public class QuizService : IQuizService
    {
        private readonly IQuizRepository _quizRepository;

        public QuizService(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        public IEnumerable<Quiz> GetAllQuizzes()
        {
            return _quizRepository.GetAll();
        }

        public Quiz GetQuizById(int id)
        {
            return _quizRepository.GetById(id);
        }

        public void AddQuiz(Quiz quiz)
        {
            _quizRepository.Add(quiz);
        }

        public void UpdateQuiz(Quiz quiz)
        {
            _quizRepository.Update(quiz);
        }

        public void DeleteQuiz(int id)
        {
            _quizRepository.Delete(id);
        }
    }
}