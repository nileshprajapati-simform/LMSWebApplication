using LMS.WebAPI.Entities;
using LMS.WebAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LMS.WebAPI.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly LMSDbContext _context;

        public UserRepository(LMSDbContext context) : base(context)
        {
            _context = context;
        }

    }
}