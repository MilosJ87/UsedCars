using UsedCars.Entities;

namespace UsedCars.Services
{
    public interface IModelRepo
    {
        bool CreateModel(Model model);
        bool DeleteModel(Model model);
        void Dispose();
        Model GetModel(Guid id);
        ICollection<Model> GetModels();
        bool ModelExists(Guid id);
        bool Save();
        void UpdateModel(Model model);
    }
}