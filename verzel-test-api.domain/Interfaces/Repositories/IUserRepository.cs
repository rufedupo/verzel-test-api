using verzel_test_api.domain.Models;

namespace verzel_test_api.domain.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<User> 
    {
        Task<User> GetByEmail(string email);

        Task<User> GetByEmailAndPassword(string email, string password);
    }
}
