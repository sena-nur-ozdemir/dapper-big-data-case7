namespace DapperCase7.Dtos.DashboardDtos
{
    public class ShipmentMapDto
    {
        public string ReceiverCity { get; set; } = string.Empty;
        public decimal ReceiverLat { get; set; }
        public decimal ReceiverLng { get; set; }
        public int ShipmentCount { get; set; }
    }
}
