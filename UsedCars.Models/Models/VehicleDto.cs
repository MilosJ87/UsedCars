namespace UsedCars.Models
{
    public class VehicleDto
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public Guid CategoryId { get; set; }

        public Guid ModelId { get; set; }

        public Guid MakeId { get; set; }

       public virtual List<AdditionalEquipmentDto>? AdditionalEquipmentDtoList { get; set; }
     }

 }


