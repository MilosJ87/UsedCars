using UsedCars.Entities;

namespace UsedCars.Services
{
    public interface IMakeRepo
    {
        bool CreateMake(Make make);
        bool DeleteMake(Make make);
        void Dispose();
        Make GetMake(Guid id);
        ICollection<Make> GetMakes();
        bool MakeExists(Guid id);
        bool Save();
        void UpdateMake(Make make);
    }
}