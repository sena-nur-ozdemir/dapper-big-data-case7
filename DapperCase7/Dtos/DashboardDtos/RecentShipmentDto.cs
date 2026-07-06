namespace DapperCase7.Dtos.DashboardDtos
{
    public class RecentShipmentDto
    {
        public string TrackingNumber { get; set; } = string.Empty;
        public string SenderCity { get; set; } = string.Empty;
        public string ReceiverCity { get; set; } = string.Empty;
        public int ShipmentStatus { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
