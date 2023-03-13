using Microsoft.EntityFrameworkCore;
using UsedCars.DbContexts;

namespace UsedCars.GenericRepository
{

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private protected UsedCarsContext _context = null;
        private readonly DbSet<T> _entities = null;
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
            return  _entities.Find(id);
        }
        public void Insert(T obj)
        {
            _entities.Add(obj);
        }
        public virtual async Task<T> InsertAsync(T TEntity)
        {
            _context.Set<T>().Add(TEntity);
            await _context.SaveChangesAsync();
            return TEntity;

        }

        public void Update(T obj)
        {
            _entities.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public virtual async Task UpdateAsync(T obj)
        {
            _entities.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }


        public async Task<int> Delete(object id)
        {
            T existing = _entities.Find(id);
            _entities.Remove(existing);
            return await _context.SaveChangesAsync();
        }

        public void Save() => _context.SaveChanges();

        public virtual async Task<int> SaveAsync() => await _context.SaveChangesAsync();

        public bool Exsits(object id)
        {
            T entity = _entities.Find(id);

            return entity != null;


        }
    }
}


