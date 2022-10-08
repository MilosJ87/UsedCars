using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsedCars.Entities
{
    public class Vehicle
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }


        public Guid CategoryId { get; set; }
        public Category Category { get; set; }



        public Guid ModelId { get; set; }
        public Model Model { get; set; }


        public Guid MakeId { get; set; }
        public Make Make { get; set; }
             

        public ICollection<AdditionalEquipment> AdditionalEquipments { get; set; } = new List<AdditionalEquipment>();
    }
}
