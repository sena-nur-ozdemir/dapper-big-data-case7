namespace DapperCase7.Dtos.ShipmentDtos
{
    public class CreateShipmentDto
    {
        public string SenderCity { get; set; } = string.Empty;
        public string ReceiverCity { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
