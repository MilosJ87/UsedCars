namespace UsedCars.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        void Delete(object id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetById(object id);
        void Insert(T obj);
        void Save();
        void Update(T obj);
    }
}