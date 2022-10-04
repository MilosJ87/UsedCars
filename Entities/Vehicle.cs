using System.ComponentModel.DataAnnotations;

namespace UsedCars.Entities
{
    public class Vehicle
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
