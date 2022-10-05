using System.ComponentModel.DataAnnotations;

namespace UsedCars.Entities
{
    public class Vehicle
    {
        public Vehicle()
        {
            this.AdditionalEquipment = new HashSet<AdditionalEquipment>();
        }

        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

       
        public Type Type { get; set; }
      
        public Model Model { get; set; }
               
        public Brand Brand { get; set; }

              
        public virtual ICollection<AdditionalEquipment> AdditionalEquipment { get; set; }
    }
}
