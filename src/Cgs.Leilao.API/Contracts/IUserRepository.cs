using Cgs.Leilao.API.Entities;

namespace Cgs.Leilao.API.Contracts
{
    public interface IUserRepository
    {
        public bool ExistsUserEmail(string email);

        public User GetUserByEmail(string email);
    }
}
