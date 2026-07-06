using DapperCase7.Dtos.DashboardDtos;

namespace DapperCase7.Services.DashboardServices
{
    public interface IDashboardService
    {
        Task<KpiCardDto> GetDashboardKpiCardsAsync();
        Task<List<ShipmentMapDto>> GetShipmentMapAsync();
        Task<List<ShipmentStatusDto>> GetShipmentStatusAsync();
        Task<List<DailyShipmentCountDto>> GetDailyShipmentCountAsync();
        Task<List<RecentShipmentDto>> GetRecentShipmentsAsync();
        Task<List<TopRouteDto>> GetTopRoutesAsync();
        Task<List<BusiestCityDto>> GetBusiestSenderCitiesAsync();
        Task<List<ReturnAnalyticsDto>> GetReturnedShipmentsAnalyticsAsync();
    }
}