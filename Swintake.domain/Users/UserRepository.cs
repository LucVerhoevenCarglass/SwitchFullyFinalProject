using Swintake.domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Swintake.domain.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly SwintakeContext _dbContext;

        public UserRepository(SwintakeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User FindByEmail(string email)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Email == email);
        }
    }
}
