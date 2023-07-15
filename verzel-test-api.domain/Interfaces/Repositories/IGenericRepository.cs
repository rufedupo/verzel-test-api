namespace verzel_test_api.domain.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetById(Guid id);

        Task<T> Insert(T obj);

        Task<T> Update(T obj);

        Task Delete(Guid id);
    }
}
