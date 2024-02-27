using Cgs.Leilao.API.Contracts;
using Cgs.Leilao.API.Entities;

namespace Cgs.Leilao.API.Repositories.DataAccess
{
    public class UserRepository: IUserRepository
    {
        private readonly CgsLeilaoDbContext _dbcontext;
        public UserRepository(CgsLeilaoDbContext dbContext) => _dbcontext = dbContext;

        public bool ExistsUserEmail(string email)
        {
            return _dbcontext.Users.Any(user => user.Email.Equals(email));
        }

        public User GetUserByEmail(string email) => _dbcontext.Users.First(user => user.Email.Equals(email));
    }
}
