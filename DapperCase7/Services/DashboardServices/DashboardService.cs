using Dapper;
using DapperCase7.Context;
using DapperCase7.Dtos.DashboardDtos;

namespace DapperCase7.Services.DashboardServices
{
    public class DashboardService : IDashboardService
    {
        private readonly DapperContext _context;

        public DashboardService(DapperContext context)
        {
            _context = context;
        }

        // 1. KPI Kartları: 1 milyon satır içerisinden toplam kargo sayısını, ciroyu ve durumları tek sorguda hesaplar.
        public async Task<KpiCardDto> GetDashboardKpiCardsAsync()
        {
            string query = @"SELECT 
                                COUNT(*) AS TotalShipments,
                                ISNULL(SUM(Price), 0) AS TotalRevenue,
                                SUM(CASE WHEN ShipmentStatus = 4 THEN 1 ELSE 0 END) AS DeliveredCount,
                                SUM(CASE WHEN ShipmentStatus = 2 THEN 1 ELSE 0 END) AS InTransitCount
                             FROM Shipments";

            using var connection = _context.CreateConnection();
            var values = await connection.QueryFirstAsync<KpiCardDto>(query, commandTimeout: 120);
            return values;
        }

        // 2. Harita Verisi: Türkiye haritası üzerinde en çok kargo inen ilk 15 şehri ve koordinatlarını getirir.
        public async Task<List<ShipmentMapDto>> GetShipmentMapAsync()
        {
            string query = @"SELECT TOP 15 
                                ReceiverCity, 
                                AVG(ReceiverLat) AS ReceiverLat, 
                                AVG(ReceiverLng) AS ReceiverLng, 
                                COUNT(*) AS ShipmentCount 
                             FROM Shipments 
                             GROUP BY ReceiverCity 
                             ORDER BY ShipmentCount DESC";

            using var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ShipmentMapDto>(query);
            return values.ToList();
        }

        // 3. Pasta Grafiği: Kargo durumlarına göre (Hazırlanıyor, Yolda, Teslim Edildi vb.) adet dağılımını çeker.
        public async Task<List<ShipmentStatusDto>> GetShipmentStatusAsync()
        {
            string query = @"SELECT ShipmentStatus, COUNT(*) AS Count 
                             FROM Shipments 
                             GROUP BY ShipmentStatus 
                             ORDER BY ShipmentStatus";

            using var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ShipmentStatusDto>(query);
            return values.ToList();
        }

        // 4. Çizgi Grafiği: Operasyonun son 7 günlük kargo hacmini gün gün gruplayarak getirir.
        public async Task<List<DailyShipmentCountDto>> GetDailyShipmentCountAsync()
        {
            // FORMAT yerine doğrudan DATE dönüşümü yapıyoruz, SQL motoru katbekat hızlı grupluyor
            string query = @"SELECT TOP 7 
                                FORMAT(CAST(CreatedAt AS DATE), 'dd MMM') AS Date, 
                                COUNT(*) AS Count 
                             FROM Shipments 
                             GROUP BY CAST(CreatedAt AS DATE)
                             ORDER BY CAST(CreatedAt AS DATE)";

            using var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<DailyShipmentCountDto>(query, commandTimeout: 120);
            return values.ToList();
        }

        // 5. Son İşlemler Özet Tablosu: Sisteme en son eklenen 5 kargonun bilgilerini çeker.
        public async Task<List<RecentShipmentDto>> GetRecentShipmentsAsync()
        {
            string query = @"SELECT TOP 5 
                                TrackingNumber, SenderCity, ReceiverCity, ShipmentStatus, Price, CreatedAt 
                             FROM Shipments 
                             ORDER BY Id DESC";

            using var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<RecentShipmentDto>(query);
            return values.ToList();
        }
        // 6. En Yoğun Rotalar: Çıkış ve varış illerini gruplayarak en çok ciro getiren hatları bulur.
        public async Task<List<TopRouteDto>> GetTopRoutesAsync()
        {
            string query = @"SELECT TOP 5 
                                SenderCity, ReceiverCity, 
                                COUNT(*) AS ShipmentCount, 
                                SUM(Price) AS TotalRevenue 
                             FROM Shipments 
                             GROUP BY SenderCity, ReceiverCity 
                             ORDER BY ShipmentCount DESC";

            using var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<TopRouteDto>(query);
            return values.ToList();
        }

        // 7. En Yoğun Çıkış Şehirleri: Kargo çıkış hacmi en yüksek 5 ili getirir.
        public async Task<List<BusiestCityDto>> GetBusiestSenderCitiesAsync()
        {
            string query = @"SELECT TOP 5 
                                SenderCity AS CityName, 
                                COUNT(*) AS ShipmentCount 
                             FROM Shipments 
                             GROUP BY SenderCity 
                             ORDER BY ShipmentCount DESC";

            using var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<BusiestCityDto>(query, commandTimeout: 120);
            return values.ToList();
        }

        // 8. İade Analizi: Operasyonel olarak en çok iade (Status=5) alan şehirleri listeler.
        public async Task<List<ReturnAnalyticsDto>> GetReturnedShipmentsAnalyticsAsync()
        {
            string query = @"SELECT TOP 5 
                                ReceiverCity AS CityName, 
                                COUNT(*) AS ReturnedCount 
                             FROM Shipments 
                             WHERE ShipmentStatus = 5 
                             GROUP BY ReceiverCity 
                             ORDER BY ReturnedCount DESC";

            using var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ReturnAnalyticsDto>(query, commandTimeout: 120);
            return values.ToList();
        }
    }
}