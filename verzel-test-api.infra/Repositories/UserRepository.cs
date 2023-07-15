using Microsoft.EntityFrameworkCore;
using verzel_test_api.domain.Interfaces.Repositories;
using verzel_test_api.domain.Models;
using verzel_test_api.infra.Contexts;

namespace verzel_test_api.infra.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly DatabaseContext _context;

        public UserRepository(DatabaseContext context) : base(context) => _context = context;

        public async Task<User> GetByEmail(string email)
        {
            return await _context
                            .Set<User>()
                                .Where(u => u.Email == email)
                                    .FirstOrDefaultAsync();
        }

        public async Task<User> GetByEmailAndPassword(string email, string password)
        {
            return await _context
                            .Set<User>()
                                .Where(u => u.Email == email && u.Password == password)
                                    .FirstOrDefaultAsync();
        }
    }
}
