using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsedCars.Entities
{
    public class AdditionalEquipment
    {
       
        [Key]
        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public  ICollection<Vehicle> Vehicles = new List<Vehicle>();        
       
    }
}
