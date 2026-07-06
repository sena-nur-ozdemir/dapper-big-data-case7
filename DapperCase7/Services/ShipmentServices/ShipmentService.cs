using Dapper;
using DapperCase7.Context;
using DapperCase7.Dtos.ShipmentDtos;

namespace DapperCase7.Services.ShipmentServices
{
    public class ShipmentService : IShipmentService
    {
        private readonly DapperContext _context;

        public ShipmentService(DapperContext context)
        {
            _context = context;
        }
        public async Task CreateShipmentAsync(CreateShipmentDto createShipmentDto)
        {
            // Havalı ve gerçekçi bir takip numarası üretiyoruz (Örn: LF-8452194)
            string trackingNumber = "LF-" + new Random().Next(1000000, 9999999).ToString();

            string query = @"INSERT INTO Shipments (TrackingNumber, SenderCity, ReceiverCity, ShipmentStatus, Price, CreatedAt) 
                             VALUES (@TrackingNumber, @SenderCity, @ReceiverCity, 1, @Price, GETDATE())";

            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, new
            {
                TrackingNumber = trackingNumber,
                SenderCity = createShipmentDto.SenderCity,
                ReceiverCity = createShipmentDto.ReceiverCity,
                Price = createShipmentDto.Price
            });
        }

        public async Task<(List<ShipmentListDto> Shipments, int TotalCount)> GetShipmentsWithPagingAsync(int pageNumber, int pageSize, string searchTrackNo = "")
        {
            int offset = (pageNumber - 1) * pageSize;

            // Arama kelimesi varsa WHERE şartını ekle, yoksa boş bırak
            string whereClause = string.IsNullOrEmpty(searchTrackNo) ? "" : "WHERE TrackingNumber LIKE '%' + @Search + '%'";

            string dataQuery = $@"
        SELECT Id, TrackingNumber, SenderCity, ReceiverCity, ShipmentStatus, Price, CreatedAt 
        FROM Shipments 
        {whereClause}
        ORDER BY Id DESC 
        OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

            string countQuery = $"SELECT COUNT(*) FROM Shipments {whereClause}";

            using var connection = _context.CreateConnection();

            var shipments = await connection.QueryAsync<ShipmentListDto>(dataQuery, new { Offset = offset, PageSize = pageSize, Search = searchTrackNo });
            var totalCount = await connection.ExecuteScalarAsync<int>(countQuery, new { Search = searchTrackNo });

            return (shipments.ToList(), totalCount);
        }
        public async Task DeleteShipmentAsync(int id)
        {
            string query = "DELETE FROM Shipments WHERE Id = @Id";
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, new { Id = id });
        }

        public async Task<UpdateShipmentDto> GetShipmentByIdAsync(int id)
        {
            string query = "SELECT Id, TrackingNumber, SenderCity, ReceiverCity, ShipmentStatus, Price FROM Shipments WHERE Id = @Id";
            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<UpdateShipmentDto>(query, new { Id = id });
        }

        public async Task UpdateShipmentAsync(UpdateShipmentDto updateShipmentDto)
        {
            // Takip numarasını değiştirmiyoruz, sadece diğer detayları güncelliyoruz
            string query = @"UPDATE Shipments 
                             SET SenderCity = @SenderCity, 
                                 ReceiverCity = @ReceiverCity, 
                                 ShipmentStatus = @ShipmentStatus, 
                                 Price = @Price 
                             WHERE Id = @Id";
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, updateShipmentDto);
        }
    }
}