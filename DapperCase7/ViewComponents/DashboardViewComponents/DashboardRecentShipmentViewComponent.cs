using DapperCase7.Services.DashboardServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperCase7.ViewComponents.DashboardViewComponents
{
    public class DashboardRecentShipmentsViewComponent : ViewComponent
    {
        private readonly IDashboardService _dashboardService;

        public DashboardRecentShipmentsViewComponent(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _dashboardService.GetRecentShipmentsAsync();
            return View(values);
        }
    }
}