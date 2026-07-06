namespace DapperCase7.Dtos.ShipmentDtos
{
    public class UpdateShipmentDto
    {
        public int Id { get; set; }
        public string TrackingNumber { get; set; } = string.Empty;
        public string SenderCity { get; set; } = string.Empty;
        public string ReceiverCity { get; set; } = string.Empty;
        public int ShipmentStatus { get; set; }
        public decimal Price { get; set; }
    }
}
