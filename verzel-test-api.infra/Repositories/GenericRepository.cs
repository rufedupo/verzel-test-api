using Microsoft.EntityFrameworkCore;
using verzel_test_api.domain.Interfaces.Repositories;
using verzel_test_api.infra.Contexts;

namespace verzel_test_api.infra.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DatabaseContext _context;

        public GenericRepository(DatabaseContext context) => _context = context;

        public async Task<IEnumerable<T>> GetAll() => await _context.Set<T>().AsNoTracking().ToListAsync();

        public async Task<T> GetById(Guid id) => await _context.Set<T>().FindAsync(id);

        public async Task<T> Insert(T obj)
        {
            try
            {
                await _context.Set<T>().AddAsync(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public async Task<T> Update(T obj)
        {
            _context.Set<T>().Update(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task Delete(Guid id)
        {
            var entity = await GetById(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
