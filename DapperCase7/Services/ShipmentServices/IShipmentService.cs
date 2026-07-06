using DapperCase7.Dtos.ShipmentDtos;

namespace DapperCase7.Services.ShipmentServices
{
    public interface IShipmentService
    {
        Task<(List<ShipmentListDto> Shipments, int TotalCount)> GetShipmentsWithPagingAsync(int pageNumber, int pageSize, string searchTrackNo = "");
        Task DeleteShipmentAsync(int id);
        Task<UpdateShipmentDto> GetShipmentByIdAsync(int id);
        Task UpdateShipmentAsync(UpdateShipmentDto updateShipmentDto);
        Task CreateShipmentAsync(CreateShipmentDto createShipmentDto);
    }
}
