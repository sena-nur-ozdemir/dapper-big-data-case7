using DapperCase7.Services.DashboardServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperCase7.ViewComponents.DashboardViewComponents
{
    public class DashboardBusiestCitiesViewComponent : ViewComponent
    {
        private readonly IDashboardService _dashboardService;

        public DashboardBusiestCitiesViewComponent(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _dashboardService.GetBusiestSenderCitiesAsync();
            return View(values);
        }
    }
}