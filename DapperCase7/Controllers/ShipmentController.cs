using DapperCase7.Services.ShipmentServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperCase7.Controllers
{
    public class ShipmentController : Controller
    {
        private readonly IShipmentService _shipmentService;

        public ShipmentController(IShipmentService shipmentService)
        {
            _shipmentService = shipmentService;
        }

        // Sayfa numarası gelmezse varsayılan olarak 1. sayfayı açar
        public async Task<IActionResult> Index(int page = 1, string searchTrackNo = "")
        {
            int pageSize = 15;
            var (shipments, totalCount) = await _shipmentService.GetShipmentsWithPagingAsync(page, pageSize, searchTrackNo);

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            ViewBag.TotalCount = totalCount;
            ViewBag.SearchTrackNo = searchTrackNo; // Kutunun içinde aranan kelime silinmesin diye tutuyoruz

            return View(shipments);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _shipmentService.DeleteShipmentAsync(id);
            TempData["Success"] = "Kargo kaydı başarıyla silindi!"; 
            return RedirectToAction("Index"); // Sildikten sonra listeye geri dön
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var values = await _shipmentService.GetShipmentByIdAsync(id);
            return View(values); // Güncelleme formunu aç
        }

        [HttpPost]
        public async Task<IActionResult> Update(DapperCase7.Dtos.ShipmentDtos.UpdateShipmentDto updateShipmentDto)
        {
            await _shipmentService.UpdateShipmentAsync(updateShipmentDto);
            TempData["Success"] = "Kargo durumu başarıyla güncellendi!";
            return RedirectToAction("Index"); // Kaydettikten sonra listeye geri dön
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(); // Sadece boş formu ekrana basar
        }

        [HttpPost]
        public async Task<IActionResult> Create(DapperCase7.Dtos.ShipmentDtos.CreateShipmentDto createShipmentDto)
        {
            await _shipmentService.CreateShipmentAsync(createShipmentDto);
            TempData["Success"] = "Yeni kargo sisteme eklendi!";
            return RedirectToAction("Index"); // Kayıt başarıyla eklenince listeye geri atar
        }
    }
}