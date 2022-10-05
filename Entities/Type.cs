
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsedCars.Entities

{
    public class Type
    {
        [Key]
        public Guid Id { get; set; }

     
        public string Name { get; set; }


        [ForeignKey("VehicleId")]
        public Vehicle Vehicle { get; set; }

        public Guid VehicleId { get; set; }

    }
}
