using DapperCase7.Services.DashboardServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperCase7.ViewComponents.DashboardViewComponents
{
    public class DashboardKpiCardsViewComponent : ViewComponent
    {
        private readonly IDashboardService _dashboardService;

        public DashboardKpiCardsViewComponent(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _dashboardService.GetDashboardKpiCardsAsync();
            return View(values);
        }
    }
}