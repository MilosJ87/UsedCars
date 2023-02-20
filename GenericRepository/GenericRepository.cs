using Microsoft.EntityFrameworkCore;
using UsedCars.DbContexts;

namespace UsedCars.GenericRepository
{

    public class GenericRepository<T> :  IGenericRepository<T> where T : class
    {
        private UsedCarsContext _context = null;
        private DbSet<T> _entities = null;
        public GenericRepository(UsedCarsContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
            _entities = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }
        public async Task<T> GetById(object id)
        {
            return _entities.Find(id);
        }
        public void Insert(T obj)
        {
            _entities.Add(obj);
        }
        public void Update(T obj)
        {
            _entities.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object id)
        {
            T existing = _entities.Find(id);
            _entities.Remove(existing);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}


