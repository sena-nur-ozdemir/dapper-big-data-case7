using DapperCase7.Services.DashboardServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperCase7.ViewComponents.DashboardViewComponents
{
    public class DashboardShipmentMapViewComponent : ViewComponent
    {
        private readonly IDashboardService _dashboardService;

        public DashboardShipmentMapViewComponent(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _dashboardService.GetTopRoutesAsync();
            return View(values);
        }
    }
}