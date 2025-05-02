using LMS.WebAPI.Data;
using LMS.WebAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LMS.WebAPI.Repositories
{
    public class QuizRepository : GenericRepository<Quiz>, IQuizRepository
    {
        private readonly LMSDbContext _context;

        public QuizRepository(LMSDbContext context) : base(context)
        {
            _context = context;
        }

    }
}