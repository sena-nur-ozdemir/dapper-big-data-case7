namespace DapperCase7.Dtos.DashboardDtos
{
    public class TopRouteDto
    {
        public string SenderCity { get; set; } = string.Empty;
        public string ReceiverCity { get; set; } = string.Empty;
        public int ShipmentCount { get; set; }
        public decimal TotalRevenue { get; set; }
    }
}
