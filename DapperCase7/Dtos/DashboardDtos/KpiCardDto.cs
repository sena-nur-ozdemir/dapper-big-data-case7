namespace DapperCase7.Dtos.DashboardDtos
{
    public class KpiCardDto
    {
        public int TotalShipments { get; set; }
        public decimal TotalRevenue { get; set; }
        public int DeliveredCount { get; set; }
        public int InTransitCount { get; set; }
    }
}
