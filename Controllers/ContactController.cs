using Microsoft.AspNetCore.Mvc;

namespace CarAds.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
