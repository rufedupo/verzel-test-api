using verzel_test_api.domain.Interfaces.Repositories;
using verzel_test_api.domain.Models;
using verzel_test_api.infra.Contexts;

namespace verzel_test_api.infra.Repositories
{
    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        private readonly DatabaseContext _context;

        public CarRepository(DatabaseContext context) : base(context) => _context = context;
    }
}
