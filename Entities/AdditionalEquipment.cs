using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsedCars.Entities
{
    public class AdditionalEquipment
    {
        public AdditionalEquipment()
        {
            this.Vehicles = new HashSet<Vehicle>();
        }
        [Key]
        public Guid Id { get; set; }
        
        public string Name { get; set; }


        
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
