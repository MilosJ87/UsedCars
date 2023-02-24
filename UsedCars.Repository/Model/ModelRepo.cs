using Microsoft.EntityFrameworkCore.Diagnostics;
using UsedCars.DbContexts;
using UsedCars.Entities;
using UsedCars.GenericRepository;

namespace UsedCars.Repository
{
    public class ModelRepo : GenericRepository<Entities.Model>, IModelRepo
    {
        public ModelRepo(UsedCarsContext context) : base(context)
        {
        }

        public bool ModelExists(Guid id)
        {
            return _context.Models.Any(x => x.Id == id);
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
