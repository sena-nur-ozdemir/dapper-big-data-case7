using Microsoft.AspNetCore.Mvc;

namespace DapperCase7.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
