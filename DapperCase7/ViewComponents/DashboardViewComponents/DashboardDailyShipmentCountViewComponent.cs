using DapperCase7.Services.DashboardServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperCase7.ViewComponents.DashboardViewComponents
{
    public class DashboardDailyShipmentCountViewComponent : ViewComponent
    {
        private readonly IDashboardService _dashboardService;

        public DashboardDailyShipmentCountViewComponent(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _dashboardService.GetDailyShipmentCountAsync();
            return View(values);
        }
    }
}