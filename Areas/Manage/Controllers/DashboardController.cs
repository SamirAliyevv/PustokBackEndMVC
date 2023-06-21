using Microsoft.AspNetCore.Mvc;

namespace Pustok.Areas.Manage.Controllers
{
    public class DashboardController : Controller
    {

        [Area("manage")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
