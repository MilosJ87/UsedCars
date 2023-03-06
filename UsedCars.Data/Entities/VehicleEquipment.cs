namespace UsedCars.Entities
{
    public class VehicleEquipment
    {
        public Guid? VehicleId { get; set; }
        public Guid? AdditionalEquipmentId { get; set; }

        public Vehicle? Vehicle { get; set; }

        public AdditionalEquipment? AdditionalEquipment { get; set; }
    }
}
