using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsedCars.Entities
{
    public class Vehicle
    {


        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        [ForeignKey("TypeId")]
        public Guid TypeId { get; set; }
        public Type Type { get; set; }

        [ForeignKey("ModelId")]
        public Guid ModelId { get; set; }
        public Model Model { get; set; }

        [ForeignKey("MarkeId")]
        public Guid MarkeId { get; set; }
        public Marke Marke { get; set; }

        public ICollection<AdditionalEquipment> AdditionalEquipments { get; set; } = new List<AdditionalEquipment>();
    }
}
