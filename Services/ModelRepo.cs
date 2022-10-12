using Microsoft.EntityFrameworkCore.Diagnostics;
using UsedCars.DbContexts;
using UsedCars.Entities;

namespace UsedCars.Services
{
    public class ModelRepo : IModelRepo
    {
        private readonly UsedCarsContext _usedCarsContext;

        public ModelRepo(UsedCarsContext usedCarsContext)
        {
            _usedCarsContext = usedCarsContext;
        }

        public bool ModelExists(Guid id)
        {
            return _usedCarsContext.Models.Any(x => x.Id == id);
        }

        public ICollection<Model> GetModels()
        {
            return _usedCarsContext.Models.ToList();
        }

        public Model GetModel(Guid id)
        {
            return _usedCarsContext.Models.Where(e => e.Id == id).FirstOrDefault();
        }

        public bool CreateModel(Model model)
        {
            _usedCarsContext.Add(model);
            return Save();
        }

        public void UpdateModel(Model model)
        {

        }

        public bool DeleteModel(Model model)
        {
            _usedCarsContext.Remove(model);
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
