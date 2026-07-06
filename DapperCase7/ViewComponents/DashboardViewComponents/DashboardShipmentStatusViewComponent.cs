using DapperCase7.Services.DashboardServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperCase7.ViewComponents.DashboardViewComponents
{
    public class DashboardShipmentStatusViewComponent : ViewComponent
    {
        private readonly IDashboardService _dashboardService;

        public DashboardShipmentStatusViewComponent(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _dashboardService.GetShipmentStatusAsync();
            return View(values);
        }
    }
}