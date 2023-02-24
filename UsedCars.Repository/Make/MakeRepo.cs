using Microsoft.EntityFrameworkCore.Diagnostics;
using UsedCars.DbContexts;
using UsedCars.Entities;
using UsedCars.GenericRepository;

namespace UsedCars.Services
{
    public class MakeRepo : GenericRepository<Entities.Make>, IDisposable, IMakeRepo
    {
        public MakeRepo(UsedCarsContext context) : base(context)
        {
        }
        public bool MakeExists(Guid id)
        {
            return _context.Makes.Any(c => c.Id == id);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
        }
    }
}
