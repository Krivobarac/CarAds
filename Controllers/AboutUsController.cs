using Microsoft.AspNetCore.Mvc;

namespace CarAds.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
