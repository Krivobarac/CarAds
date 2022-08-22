using Microsoft.AspNetCore.Mvc;

namespace CarAds.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
