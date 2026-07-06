using DapperCase7.Services.DashboardServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperCase7.ViewComponents.DashboardViewComponents
{
    public class DashboardReturnAnalyticsViewComponent : ViewComponent
    {
        private readonly IDashboardService _dashboardService;

        public DashboardReturnAnalyticsViewComponent(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _dashboardService.GetReturnedShipmentsAnalyticsAsync();
            return View(values);
        }
    }
}