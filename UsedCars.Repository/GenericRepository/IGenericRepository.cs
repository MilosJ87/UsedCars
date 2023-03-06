namespace UsedCars.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<int> Delete(object id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetById(object id);
        Task<T> InsertAsync(T TEntity);
        Task<int> SaveAsync();
        Task UpdateAsync(T obj);
    }
}