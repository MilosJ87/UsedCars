using Microsoft.EntityFrameworkCore.Diagnostics;
using UsedCars.DbContexts;
using UsedCars.Entities;

namespace UsedCars.Services
{
    public class MakeRepo : IMakeRepo, IDisposable
    {
        private readonly UsedCarsContext _usedCarsContext;
        public MakeRepo(UsedCarsContext usedCarsContext)
        {
            _usedCarsContext = usedCarsContext ?? throw new ArgumentNullException(nameof(usedCarsContext));
        }
        public bool MakeExists(Guid id)
        {
            return _usedCarsContext.Makes.Any(c => c.Id == id);
        }
        public ICollection<Make> GetMakes()
        {
            return _usedCarsContext.Makes.ToList();
        }
        public Make GetMake(Guid id)
        {
            return _usedCarsContext.Makes.Where(e => e.Id == id).FirstOrDefault();
        }
        public bool CreateMake(Make make)
        {
            _usedCarsContext.Add(make);
            return Save();
        }
        public void UpdateMake(Make make)
        {

        }
        public bool DeleteMake(Make make)
        {
            _usedCarsContext.Remove(make);
            return Save();
        }
        public bool Save()
        {
            var saved = _usedCarsContext.SaveChanges();
            return saved > 0 ? true : false;
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
