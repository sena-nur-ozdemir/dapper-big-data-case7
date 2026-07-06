using DapperCase7.Services.DashboardServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperCase7.Controllers
{
    public class AnalysisController : Controller
    {
        private readonly IDashboardService _dashboardService;

        public AnalysisController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        // 1. Transfer Merkezleri (En Yoğun Rotalar) Sayfası
        public async Task<IActionResult> TransferCenters()
        {
            var values = await _dashboardService.GetTopRoutesAsync();
            return View(values);
        }

        // 2. İade ve Risk Analizi Sayfası
        public async Task<IActionResult> ReturnAnalytics()
        {
            var values = await _dashboardService.GetReturnedShipmentsAnalyticsAsync();
            return View(values);
        }

        // 3. Şehir Analizi Sayfası
        public async Task<IActionResult> CityAnalysis()
        {
            var values = await _dashboardService.GetBusiestSenderCitiesAsync();
            return View(values);
        }
    }
}